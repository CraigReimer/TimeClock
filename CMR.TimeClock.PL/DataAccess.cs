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

    /// <summary>
    /// Data Access. Provides methods to save and load data from XML files.
    /// </summary>
    public static class DataAccess
    {
        // fields
        private static string xmlFilePath = string.Empty;

        // properties

        /// <summary>
        /// Gets or sets the XML file path for saving or loading data.
        /// </summary>
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

        /// <summary>
        /// Saves an object to an XML file.
        /// </summary>
        /// <param name="type">The type of object to save. In this case, EntryLog.</param>
        /// <param name="o">The object to be saved. In this case, the entryLog.</param>
        /// <exception cref="Exception">XML File Path not specified.</exception>
        public static void SaveToXML(Type type, object o)
        {
            if (XMLFilePath == string.Empty)
            {
                throw new Exception("XMLFilePath was not specified");
            }

            StreamWriter writer = new (XMLFilePath);
            XmlSerializer serializer = new (type);
            serializer.Serialize(writer, o);
            writer.Close();
        }

        /// <summary>
        /// Loads an object from an XML file.
        /// </summary>
        /// <param name="type">The type of object to save. In this case, EntryLog.</param>
        /// <returns>The retrieved object.</returns>
        /// <exception cref="Exception">XML File Path not specified.</exception>
        public static object LoadFromXML(Type type)
        {
            if (XMLFilePath == string.Empty)
            {
                throw new Exception("XMLFilePath was not specified");
            }

            StreamReader reader = new (XMLFilePath);
            XmlSerializer serializer = new (type);
            object obj = serializer.Deserialize(reader) !;
            reader.Close();

            return obj;
        }
    }
}