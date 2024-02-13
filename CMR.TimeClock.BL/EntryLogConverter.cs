//-----------------------------------------------------------------------
// <copyright file="DataAccess.cs" company="Craig Reimer">
//     Copyright (c) Craig Reimer. All rights reserved.
// </copyright>
// <title>TimeClock</title>
// <summary>A simple time clock for logging in and out times.</summary>
// <author>Craig Reimer</author>
// <firstPublish>12-7-2023</firstPublish>
// <lastUpdate>01-10-2024</lastUpdate>
//-----------------------------------------------------------------------
namespace CMR.TimeClock.BL
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A JSON converter for the <see cref="EntryLog"/> class.
    /// </summary>
    public class EntryLogConverter : JsonConverter<EntryLog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntryLogConverter"/> class.
        /// </summary>
        public EntryLogConverter()
        {
        }

        /// <summary>
        /// A method to convert a JSON object to a <see cref="EntryLog"/> object.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="hasExistingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override EntryLog? ReadJson(JsonReader reader, Type objectType, EntryLog? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            // Load JObject from the reader
            JObject jObject = JObject.Load(reader);

            // Create a new EntryLog instance or use an existing one if available
            EntryLog entryLog = existingValue ?? new EntryLog();

            // Deserialize other properties marked with [JsonProperty]
            entryLog.LogCreationDate = (DateTime)jObject["LogCreationDate"];
            entryLog.CurrentFilePath = (string)jObject["CurrentFilePath"];
            entryLog.LastSaved = (DateTime)jObject["LastSaved"];

            // Deserialize TimeEntries array
            JArray timeEntriesArray = (JArray)jObject["TimeEntries"];
            foreach (JToken timeEntryToken in timeEntriesArray)
            {
                TimeEntry timeEntry = new TimeEntry
                {
                    TimeIn = (DateTime)timeEntryToken["StartTime"],
                    TimeOut = (DateTime)timeEntryToken["EndTime"],
                    IsLogged = (bool)timeEntryToken["IsLogged"],
                    EntryType = ((string)timeEntryToken["EntryType"] == "0")
                    ? TimeEntry.TimeType.Working : TimeEntry.TimeType.Training,
                };

                entryLog.Add(timeEntry);
            }

            return entryLog;
        }

        /// <summary>
        /// A method to convert a <see cref="EntryLog"/> object to a JSON object.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, EntryLog? value, JsonSerializer serializer)
        {
            var jObject = new JObject();

            // Serialize other properties marked with [JsonProperty]
            jObject.Add("LogCreationDate", new JValue(value.LogCreationDate));
            jObject.Add("CurrentFilePath", new JValue(value.CurrentFilePath));
            jObject.Add("LastSaved", new JValue(value.LastSaved));

            // Convert the list of TimeEntry objects to a JArray
            var timeEntriesArray = new JArray();
            foreach (var timeEntry in value)
            {
                var timeEntryObject = new JObject();
                timeEntryObject.Add("StartTime", new JValue(timeEntry.TimeIn));
                timeEntryObject.Add("EndTime", new JValue(timeEntry.TimeOut));
                timeEntryObject.Add("IsLogged", new JValue(timeEntry.IsLogged));
                timeEntryObject.Add("EntryType", new JValue(timeEntry.EntryType));

                timeEntriesArray.Add(timeEntryObject);
            }

            jObject.Add("TimeEntries", timeEntriesArray);

            // Write the JObject to the writer
            jObject.WriteTo(writer);
        }
    }
}
