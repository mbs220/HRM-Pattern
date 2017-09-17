using MBS.HR.Patterns.BusinessLayer;
using MBS.HR.Patterns.BusinessModel;
using MBS.HR.Patterns.PatternRepository.AbstractFactory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://stackoverflow.com/a/23017892
namespace MBS.HR.Patterns.JsonConfig
{
    class PerOrganSettingFactoryJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            //return objectType == typeof(DefaultImplementation);
            return typeof(PerOrganSettingFactory).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load the JSON for the Result into a JObject
            JObject jo = JObject.Load(reader);

            // Read the properties which will be used as constructor parameters
            //var code = jo["Organ"].ToObject<Enums.Organ>();
            IssueInitialModel format = jo["InitialValue"].ToObject<IssueInitialModel>();


            var result = Activator.CreateInstance(objectType,/* code,*/ format);

            // Construct the Result object using the non-default constructor
            ////Result result = new Result(code, format);

            // (If anything else needs to be populated on the result object, do that here)

            // Return the result
            return result;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
