//-----------------------------------------------------------------------
// <copyright file="DataAccess.cs" company="Craig Reimer">
//     Copyright (c) Craig Reimer. All rights reserved.
// </copyright>
// <title>TimeClock</title>
// <summary>A simple time clock for logging in and out times.</summary>
// <author>Craig Reimer</author>
// <firstPublish>12-7-2023</firstPublish>
// <lastUpdate>01-02-2024</lastUpdate>
//-----------------------------------------------------------------------

namespace CMR.TimeClock.PL
{
    using System.Xml.Serialization;

    public static class DataAccess
    {
        // fields
        private static string xmlFilePath = string.Empty;

        // properties
        public static string XMLFilePath
        {
            get => xmlFilePath;
            set
            {
                if (xmlFilePath != value)
                {
                    xmlFilePath = value;
                }
            }
        }

        // methods
        public static void SaveToXML(Type type, object o)
        {
            if (XMLFilePath == string.Empty) { throw new Exception("XMLFilePath was not specified"); }

            StreamWriter writer = new (XMLFilePath);
            XmlSerializer serializer = new (type);
            serializer.Serialize(writer, o);
            writer.Close();
        }

        public static object LoadFromXML(Type type)
        {
            if (XMLFilePath == string.Empty) { throw new Exception("XMLFilePath was not specified"); }

            StreamReader reader = new (XMLFilePath);
            XmlSerializer serializer = new (type);
            object obj = serializer.Deserialize(reader)!;
            reader.Close();

            return obj;
        }
    }
}