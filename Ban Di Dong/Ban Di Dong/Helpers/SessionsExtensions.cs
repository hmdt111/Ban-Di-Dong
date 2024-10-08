﻿using System.Text.Json;

namespace Ban_Di_Dong.Helpers
{
    public static class SessionsExtensions
    {
        public static void Set<T>(this ISession session,  string key, T value)
        {
            session.SetString(key,JsonSerializer.Serialize(value));
        }
        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
