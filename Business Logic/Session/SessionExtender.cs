using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Business_Logic.Session
{
    public static class SessionExtender
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            
            var data = JsonSerializer.Serialize<T>(value);
            session.SetString(key,data );
        }

        public static T Get<T>(this ISession session, string key)
        {
            
            var value = session.GetString(key);
            var data= JsonSerializer.Deserialize<T>(value);
            return value == null ? default : data;
        }
    }
}
