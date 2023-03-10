namespace MyFirstSite.Helpers
{
    public static class IdHelper
    {
        public static int GetRandomId()
        {
            var random = new Random();
            return random.Next(1, int.MaxValue);
        }
    }
}
