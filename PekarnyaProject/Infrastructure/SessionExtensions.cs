using Microsoft.AspNetCore.Http;
using System.Text.Json;


namespace PekarnyaProject.Infrastructure
{


    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            // Додаємо опцію, щоб серіалізація була простішою
            var options = new JsonSerializerOptions { WriteIndented = true };
            session.SetString(key, JsonSerializer.Serialize(value, options));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value == null) return default;

            try
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            catch
            {
                return default;
            }
        }
    }
}