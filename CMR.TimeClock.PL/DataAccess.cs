using System.Xml.Serialization;

namespace CMR.TimeClock.PL
{
    public static class DataAccess
    {
        // properties
        public static string XMLFilePath { get; set; } = String.Empty;



        // methods
        public static void SaveToXML(Type type, object o)
        {
            if (XMLFilePath == String.Empty) { throw new Exception("XMLFilePath was not specified"); }

            StreamWriter writer = new StreamWriter(XMLFilePath);
            XmlSerializer serializer = new XmlSerializer(type);
            serializer.Serialize(writer, o);
            writer.Close();
        }

        public static object LoadFromXML(Type type)
        {
            if (XMLFilePath == String.Empty) { throw new Exception("XMLFilePath was not specified"); }

            StreamReader reader = new StreamReader(XMLFilePath);
            XmlSerializer serializer = new XmlSerializer(type);
            object obj = serializer.Deserialize(reader)!;
            reader.Close();
            return obj;
        }


    }
}