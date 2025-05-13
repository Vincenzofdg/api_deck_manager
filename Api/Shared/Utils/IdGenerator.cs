namespace Api.Shared.Utils;

public static class IdGenerator
{
    public static string GenerateUniqueId()
    {
        string dayMonthYear = DateTime.Now.ToString("ddMMyy");
        string randomChars = GenerateRandomString(6);
        string time = DateTime.Now.ToString("HHmmss");

        return $"{dayMonthYear}-{randomChars}-{time}";
    }

    private static string GenerateRandomString(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random random = new ();
        return new string([.. Enumerable.Range(0, length).Select(_ => chars[random.Next(chars.Length)])]);
    }
}
