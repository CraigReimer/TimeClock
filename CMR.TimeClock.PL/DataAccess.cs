using System.Xml.Serialization;

namespace CMR.TimeClock.PL
{
    public static class DataAccess
    {
        // properties
        public static string XMLFilePath
        {
            get => _xmlFilePath;
            set
            {
                if (_xmlFilePath != value)
                {
                    _xmlFilePath = value;

                    // Get the directory where the .exe is located
                    string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    // Construct the file path for the XML file
                    _xmlFilePath = Path.Combine(exeDirectory, value); 

                    // Perform additional actions if needed
                    // For example, checking if the file exists or creating a new file
                }
            }
        }
        private static string _xmlFilePath = String.Empty;



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