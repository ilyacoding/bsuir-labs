﻿using Newtonsoft.Json;
using Command;

namespace Serializer
{
    public class Serializer
    {
        public ICommand Deserialize(string str)
        {
            return JsonConvert.DeserializeObject<ICommand>(str, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public string Serialize(Response response)
        {
            return JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });
        }
    }
}
