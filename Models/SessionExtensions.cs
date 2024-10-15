using System.Text.Json;

namespace M7_DataTransfer.Models
{
    public static class SessionExtensions
    {
        // SetObject() serializes a given object into a JSON string and stores in the session using the key parameter. 
        // Parameters (session = the session object, key = key used to store the serialized object, value, object to be serialized and stored in the session with 'T' allowing it to work with any type).
        public static void SetObject<T>(this ISession session, string key, T value)
        { session.SetString(key, JsonSerializer.Serialize(value)); }

        // GetObject() retrieves a JSON string from a session, deserializes it into an object of whatever type (T) and returns it.
        public static T? GetObject<T>(this ISession session, string key)
        {
            var json = session.GetString(key);
            return (string.IsNullOrEmpty(json)) ? default(T) : JsonSerializer.Deserialize<T>(json);
        }
    }
}
