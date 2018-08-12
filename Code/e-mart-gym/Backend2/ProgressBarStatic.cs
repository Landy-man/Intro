/*
 * Author: Robert Fred Meyer
 * Site: rmpse.com
 * Copyright: 2014
 * Liability: None, you use at your own risk and assume all liabitlies for any and all injuries, damages, etc., cause by your use of this software.
 * License: This software is free for your use and any manner you wish.  If you make changes, you must remove all indications of my authorship.
 * 
 * All my software will use the base name space of "RFM".
 * 
 * There are three ways to have the progress bar updated:
 *      1) Every time the current value is change.
 *      2) When the Update demand is made.
 *      3) On a timer event.
 * 
 * To use this class, it is best that you use a using statement like:
 *      using pbu = RFM.RFM_WPFProgressBarUpdate;
 * This allows you to use "pbu" to refernece the class rather than "RFM.RFM_WPFProgressBarUpdate".
 * "pbu" will be used in this documentation to represent the "RFM.RFM_WPFProgressBarUpdate" class.
 * The "pbu" class is a static class and is therefore automatically instantiated.
 * 
 * To add a progress bar that needs to be updated, use the New method:
 *      int New(ProgressBar pb, double min, double max, double value, int timerTicks = 0)
 *      
 * Ues it like so:
 *      var handle = pbu.New(ProgressBar, min, max, value);  OR
 *      var handle = pbu.New(ProgressBar, min, max, value, 0);
 *      This causes the progress bar to be updated every time the value is changed.
 *      
 *      var handle = pbu.New(ProgressBar, min, max, value, 30);
 *      This causes the progress bar to be updated every three seconds (30 tenths of a second) regardless of value changes.
 *      When add a progress bar that will use the timer, the progress bar's timer is set to pause.  It will not update
 *      until you have reset the timer like so:
 *          pbu.TimerReset(handle);
 *          This ensures that your progress bar is not being updated until you are ready.
 * 
 *      var handle = pbu.New(ProgressBar, min, max, value, -1);
 *      The progress bar is only updated when the update method is called:
 *          pbu.Update(handle);
 *       
 * To update the progess bar's value use the following method:
 *      pbu.CurValue[handle] = value;
 *      
 * To get the value of the progress bar use the following method:
 *      double value = pbu.CurValue[handle];
 * 
 * When you have finished using this class for your progess bar, make sure you remove it using the method:
 *      pbu.Remove(handle);
 * 
 * If you wish to pause the timer for a progress bar, use the following method:
 *      pbu.TimerPause(handle);
 * 
 * If you wish to change the timer ticks value of a timer, use the following method:
 *      pbu.TimerTicks(handle, value);  The value must be greater than zero.
 *      
 * If you wish to reset the current value to the value it was initially assigned, use the follwing method:
 *      pbu.ResetValue(handle);
 *      
 * If you want to find out if a progress bar is complete, meaning current value is equal to or greater than the maximum value, then use this method:
 *      if (pbu.Complete(handle)) {}
 * 
 * Many of the methods can work with more than one progress bar at a time.  Those methods are:
 *      pbu.Complete(handle1, handle2, ...);  Only returns true if all are complete.
 *      pbu.CurValue[handle1, handle2, ...] = value;  This assigns the same value to all listed progress bars.
 *      value = pbu.CurValue[handle1, handle2, ...];  Only the value of the first progress bar listed will be returned.
 *      pbu.ResetValue(handle1, handle2, ...);  Resets the values of all listed progress bars.
 *      pbu.TimerPause(handle1, handle2, ...);  Pauses all timers of listed progress bars.
 *      pbu.TimerReset(handle1, handle2, ...);  Resets, or unpauses, all timers of listed progress bars.
 *      pbu.Remove(handle1, handle2, ...);  Removes all listed progress bars from the dictionary and timer list.
 * 
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Timers;

namespace Backend2
{
    public static class ProgressBarStatic
    {
        public const int InvalidHandle = -1;

        private delegate void UpdateProgressBarDelegate(System.Windows.DependencyProperty dp, Object value);

        private class ProgressBarData
        {
            public ProgressBar ProgressBar;                     // A reference to the progress bar to be updated.
            public UpdateProgressBarDelegate UpdateProgressBar; // Delegate this progress bar is updated by.
            public double MinValue;                             // Minimum value for the progress bar.
            public double MaxValue;                             // Maximum value for the progress bar.
            public double CurValue;                             // Current value for the progress bar.
            public double InitialValue;                         // Initial value used for the current value.
            public int TimerTicks;                              // >0: Number of tenths of a second per update, 0: Updates on CurValue change, <0: Update on demand.
            public int TimerTick = 0;                           // Number of ticks elapsed for this progress bar.
            public bool TimerPause = false;                     // True: Timer is paused for this progress bar, False: Timer runs as normal.
            public DateTime LastUpdate;                         // DateTime of last progress bar update.
        }

        private static Dictionary<int, ProgressBarData> progressBars = new Dictionary<int, ProgressBarData>(); // Progress bar data <handle, data>.

        private static List<int> timerList = new List<int>(); // A list of progress bar handles where the TimerTicks is greater than zero.

        private static Timer timer = new Timer(); // The timer.

        // Create and add a new progress bar data element to the progressbars dictionary, and to timerList if TimerTicks is > 0.
        public static int New(ProgressBar pb, double min, double max, double value, int timerTicks = 0)
        {// Adds a new progress bar to be updated:
            var handle = newHandle();  // Get a new handle.
            if (handle != InvalidHandle)
            {// Handle is valid, create a new data element:
                try
                {
                    var pbd = new ProgressBarData() { ProgressBar = pb }; // New progress bar data element.
                    pbd.MinValue = min;
                    pbd.ProgressBar.Minimum = min;
                    pbd.MaxValue = max;
                    pbd.ProgressBar.Maximum = max;
                    pbd.CurValue = value;
                    pbd.InitialValue = value;
                    pbd.TimerTicks = timerTicks;
                    pbd.LastUpdate = DateTime.Now;
                    pbd.UpdateProgressBar = new UpdateProgressBarDelegate(pbd.ProgressBar.SetValue);
                    progressBars.Add(handle, pbd);
                    if (pbd.TimerTicks > 0)
                    {// Updates are based on the timer.
                        pbd.TimerPause = true; // Updating does not automatically start, you must call TimerReset();
                        timerList.Add(handle);
                    }
                    timerSet(); // Make sure timer is started if there are any items in the timerList and if not, stop the timer.
                }
                catch (Exception ex)
                {// Some unforeseen error has occurred:
                    if (progressBars.ContainsKey(handle)) progressBars.Remove(handle);  // Reverse all that
                    if (timerList.Contains(handle)) timerList.Remove(handle);           // may have been done.
                    handle = InvalidHandle;                                             // Return invalid handle.
                    MessageBox.Show("New: " + ex.Message);
                }
            }
            return handle;
        }

        private static void timerSet()
        {// Any time a new progress bar data element is added or the timerTicks value is changed, this mothed should be called:
            bool timerSetup = false;    // Initially flag timer as not having 
            bool timerRunning = false;  // been set up and not running.
            if (timerList.Count == 0)
            {// No need for a timer:
                if (timerRunning)
                {// Stop the timer:
                    timer.Stop();
                    timerRunning = false;
                }
            }
            else
            {// There are progress bars that need to be updated by the timer:
                if (!timerSetup)
                {// Timer was never set up, set it up:
                    timerSetup = true;
                    timer.Elapsed += new ElapsedEventHandler(onTimedEvent); // Event to call when timer fires.
                    timer.Interval = 100;                                   // Timer fires every 10th of a second.
                }
                if (!timerRunning)
                {// Start the timer:
                    timerRunning = true;
                    timer.Start();
                }
            }
        }

        // This event is called every time the timer fires:
        private static void onTimedEvent(object source, ElapsedEventArgs e)
        {// Timer fired:
            timer.Stop(); // While processing this event, stop the timer to prevent overlapping events.
            foreach (var handle in timerList)
            {// Process each progress bar that updates by the timer.
                try
                {
                    if (validHandle(handle))
                    {// Handle is valid:
                        var pbd = progressBars[handle]; // Get reference to progress bar's data.
                        if (!pbd.TimerPause && ++pbd.TimerTick > pbd.TimerTicks)
                        {// Timer for this progress bar is not paused and the number of ticks have been reached:
                            pbd.TimerTick = 0; // Reset timer tick count.
                            Update(handle); // Update the actual progress bar.
                            if (pbd.CurValue >= pbd.MaxValue) pbd.TimerPause = true; // Pause this progress bar's timer if maximum value reached.
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("onTimerEvent: " + ex.Message); } // Unexpected error.
            }
            timer.Start(); // Restart the timer.
        }

        private static int newHandle()
        {// Get a new handle to associate with the pregress bar's data:
            int handle = InvalidHandle; // Initialize as invalid.
            try
            {
                handle = progressBars.Count; // A free handle is always available between 0 and the number of progress bar elements in the dictionary.
                if (validHandle(handle))
                {// This handle is being used, find one that isn't:
                    for (int i = 0; i < handle; i++)
                    {// Test handle i:
                        if (validHandle(i)) continue; // This handle is being used.
                        handle = i; // Found an unused handle.
                        break;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("newHandle: " + ex.Message); } // Unexpected error.
            return handle; // Return the unused handle.
        }

        public static void Update(int handle, double? value = null)
        {// Update the progress bar:
            try
            {
                var pbd = progressBars[handle]; // Get reference to progress bar's data.
                if (value != null) pbd.CurValue = (double)value; // if value supplied, update current value with it.
                invoke(pbd); // Update progress bar.
                pbd.LastUpdate = DateTime.Now; // DateTime stamp last time progress bar was updated.

            }
            catch (Exception ex) { MessageBox.Show("Update: " + ex.Message); } // Unexpected error.
        }

        private static void invoke(ProgressBarData pbd)
        {// Invoke the progress bar's dispatcher to update the progress bar:
            try
            {
                pbd.ProgressBar.Dispatcher.Invoke(pbd.UpdateProgressBar,
                                                  System.Windows.Threading.DispatcherPriority.Background,
                                                  new object[] { ProgressBar.ValueProperty, pbd.CurValue }
                                                 );
            }
            catch (Exception ex) { MessageBox.Show("invoke: " + ex.Message); } // Unexpcted error.
        }

        private static bool validHandle(int handle)
        {// Return whether or not the handle is valid.
            return progressBars.ContainsKey(handle);
        }

        public static bool Complete(params int[] handles)
        {// Return whether or not all progress bars associated with the passed in handles have completed.
            int c = handles.Length;
            try
            {// Use try so that we don't have to call validHandle for each handle.
                foreach (int handle in handles)
                {
                    var pbd = progressBars[handle]; // Get reference to progress bar's data.
                    if (pbd.ProgressBar.Value >= pbd.ProgressBar.Maximum) c -= 1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Complete: " + ex.Message); } // Unexpected error.
            return c == 0;
        }

        public class curValue // I would like to make this a private class so that it is not seen, but doing so prevents it's intended use for "CurValue" below.
        {
            public double this[params int[] handles]
            {
                get
                {
                    if (handles.Length > 0 && validHandle(handles[0])) return progressBars[handles[0]].CurValue;
                    return -1;
                }
                set
                {
                    foreach (var handle in handles)
                    {
                        if (validHandle(handle))
                        {
                            var pbd = progressBars[handle]; // Get reference to progress bar's data.
                            pbd.CurValue = value;
                            if (pbd.TimerTicks == 0) Update(handle); // This progress bar is updated every time the current value changes.
                        }
                    }
                }
            }
        }
        public static curValue CurValue = new curValue(); // Use this to change the current value.  The form is pbu.CurValue[handle] = value.

        public static void ResetValue(params int[] handles)
        {// Sets the current value to the initial value:
            foreach (int handle in handles)
            {
                if (validHandle(handle))
                {
                    var pbd = progressBars[handle]; // Get reference to progress bar's data.
                    pbd.CurValue = pbd.InitialValue;
                    pbd.ProgressBar.Value = pbd.InitialValue;
                }
            }
        }

        public static void TimerPause(params int[] handles)
        {// Pauses the timer.
            foreach (var handle in handles)
            {
                if (validHandle(handle)) progressBars[handle].TimerPause = true;
            }
        }

        public static void TimerReset(params int[] handles)
        {// Reset the timer, unpause.
            foreach (var handle in handles)
            {
                if (validHandle(handle)) progressBars[handle].TimerPause = false;
            }
        }

        public static void TimerTicks(int handle, int timerTicks)
        {// Set the timer ticks value.
            if (validHandle(handle)) progressBars[handle].TimerTicks = timerTicks > 0 ? timerTicks : 0;
            timerSet();
        }

        public static void Remove(params int[] handles)
        {// Remove progress bar data from the dictionary and timer list:
            foreach (var handle in handles)
            {
                if (validHandle(handle))
                {
                    timerList.Remove(handle);
                    progressBars.Remove(handle);
                }
            }
        }

    }
}
