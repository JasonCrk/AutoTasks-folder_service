namespace Infrastructure.Persistence.Dapper.Extensions
{
    public static class ConfigurationExtension
    {
        public static string ToPascalCase(this string value)
        {
            return string.Join(
                string.Empty,
                value.Split('_').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower())
            );
        }
    }
}