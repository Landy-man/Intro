using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Backend;

namespace DAL
{
    public class Serialize
    {
        /* 
         * input:  E_Mart_Store object
         * output: byte array
         * action: serialization
         */

        public byte[] SerializeObjectToByteArray(E_Mart_Store p)
        {
            if (p == null)
            {
                throw new ArgumentNullException();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(E_Mart_Store));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream))
                {
                    serializer.Serialize(xmlWriter, p);//writing the serialized data onto memoryStream

                    return memoryStream.ToArray();//returns an memory string converted to a byteArray
                }
            }
        }


        /* 
         * input:  byte array
         * output: E_Mart_Store
         * action: deserialization
         */

        public E_Mart_Store DeserializeByteArrayToObject(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException();
            }

            E_Mart_Store p;

            XmlSerializer serializer = new XmlSerializer(typeof(E_Mart_Store));


            using (MemoryStream memoryStream = new MemoryStream(bytes))//entering data from byte array to memory stream
            {

                memoryStream.Position = 0;

                p = (E_Mart_Store)serializer.Deserialize(memoryStream);//deserializing data from memory stream into p

                return p;

            }
        }
    }
}
