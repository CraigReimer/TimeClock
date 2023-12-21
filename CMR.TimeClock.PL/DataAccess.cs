using System.Xml.Serialization;

namespace CMR.TimeClock.PL
{
    public static class DataAccess
    {
        // fields
        private static string _xmlFilePath = String.Empty;


        // properties
        public static string XMLFilePath
        {
            get => _xmlFilePath;
            set
            {
                if (_xmlFilePath != value)
                {
                    _xmlFilePath = value;                 
                }
            }
        }



        // methods
        public static void SaveToXML(Type type, object o)
        {
            if (XMLFilePath == String.Empty) { throw new Exception("XMLFilePath was not specified"); }

            StreamWriter writer = new(XMLFilePath);
            XmlSerializer serializer = new(type);
            serializer.Serialize(writer, o);
            writer.Close();
        }

        public static object LoadFromXML(Type type)
        {
            if (XMLFilePath == String.Empty) { throw new Exception("XMLFilePath was not specified"); }

            StreamReader reader = new(XMLFilePath);
            XmlSerializer serializer = new(type);
            object obj = serializer.Deserialize(reader)!;
            reader.Close();
            return obj;
        }


    }
}