using System;
using System.IO;
using System.Xml.Serialization;

namespace RemoteInvitesControl
{
    class Serialize
    {
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//RemoteControlData.xml";

        public static void WriteXML(RemoteControlConfigModel model)
        {
            XmlSerializer writer = new XmlSerializer(typeof(RemoteControlConfigModel));

            FileStream file = File.Create(path);

            writer.Serialize(file, model);
            file.Close();
        }

        public static RemoteControlConfigModel ReadXML()
        {
            XmlSerializer reader = new XmlSerializer(typeof(RemoteControlConfigModel));

            StreamReader file = new StreamReader(path);

            RemoteControlConfigModel deserialized = (RemoteControlConfigModel)reader.Deserialize(file);
            file.Close();
            return deserialized;
        }
    }
}
