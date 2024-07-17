//-----------------------------------------------------------------------
// <copyright file="DataAccess.cs" company="Craig Reimer">
// Copyright (c) Craig Reimer. All rights reserved.
// </copyright>
// <title>TimeClock</title>
// <summary>A simple time clock for logging in and out times.</summary>
// <author>Craig Reimer</author>
// <firstPublish>12-7-2023</firstPublish>
// <lastUpdate>01-10-2024</lastUpdate>
//-----------------------------------------------------------------------

namespace CMR.TimeClock.PL
{
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Data Access. Provides methods to save and load data from XML files.
    /// </summary>
    public static class DataAccess
    {
        // fields
        private static string filePath = string.Empty;

        // properties

        /// <summary>
        /// Gets or sets the XML file path for saving or loading data.
        /// </summary>
        public static string FilePath
        {
            get => filePath;
            set
            {
                if (filePath != value)
                {
                    filePath = value;
                }
            }
        }

        // methods

        /// <summary>
        /// Serializes and writes an object to an XML file.
        /// </summary>
        /// <param name="type">The type of object to save.</param>
        /// <param name="o">The object to be saved.</param>
        /// <exception cref="Exception">XML File Path not specified.</exception>
        public static void SaveToXML(Type type, object o)
        {
            if (FilePath == string.Empty)
            {
                throw new Exception("FilePath was not specified");
            }

            StreamWriter writer = new (FilePath);
            XmlSerializer serializer = new (type);
            serializer.Serialize(writer, o);
            writer.Close();
        }

        /// <summary>
        /// Deserializes an object from an XML file.
        /// </summary>
        /// <param name="type">The type of object to deserialize.</param>
        /// <returns>A deserialized object.</returns>
        /// <exception cref="Exception">File Path not specified.</exception>
        public static object LoadFromXML(Type type)
        {
            if (FilePath == string.Empty)
            {
                throw new Exception("FilePath was not specified");
            }

            StreamReader reader = new (FilePath);
            XmlSerializer serializer = new (type);
            object result = serializer.Deserialize(reader) !;
            reader.Close();

            return result;
        }

        /// <summary>
        /// Serializes and writes an object to a JSON file.
        /// </summary>
        /// <param name="type">The type of object to save.</param>
        /// <param name="o">The object to be saved.</param>
        /// <param name="converter">A converter to define the JSON serialization process.</param>
        /// <exception cref="Exception">File Path not specified.</exception>
        public static void SaveToJSON(Type type, object o, JsonConverter converter)
        {
            if (FilePath == string.Empty)
            {
                throw new Exception("FilePath was not specified");
            }

            using (var fileStream = new FileStream(FilePath, FileMode.Create))
            using (var streamWriter = new StreamWriter(fileStream))
            using (var writer = new JsonTextWriter(streamWriter))
            {
                // Serialize the object using JsonSerializer with the custom converter
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(converter);
                serializer.Serialize(writer, o, type);
            }
        }

        /// <summary>
        /// Deserializes an object from a JSON file.
        /// </summary>
        /// <param name="type">The type of object to deserialize.</param>
        /// <param name="converter">A converter to define the deserialization process.</param>
        /// <returns>A deserialized object.</returns>
        /// <exception cref="Exception">File Path not specified.</exception>
        public static object LoadFromJSON(Type type, JsonConverter converter)
        {
            if (FilePath == string.Empty)
            {
                throw new Exception("FilePath was not specified");
            }

            object result;

            using (var fileStream = new FileStream(FilePath, FileMode.Open))
            using (var streamReader = new StreamReader(fileStream))
            using (var reader = new JsonTextReader(streamReader))
            {
                // Deserialize the JSON using JsonSerializer with the custom converter
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(converter);
                result = serializer.Deserialize(reader, type);
            }

            return result;
        }
    }
}