namespace LiveView.Core.Services
{
    public static class Json
    {
        public static T Deserialize<T>(string jsonText)
        {
#if NET462
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonText);
#else
            return System.Text.Json.JsonSerializer.Deserialize<T>(jsonText);
#endif
        }
    }
}
