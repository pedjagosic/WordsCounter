namespace Application.Extensions
{
    public static class StringExtensions
    {
        private static readonly string[] ValuesToReplaceInText = { ".", ",", "?", "!", ":" };
        private const string WordsSeparator = " ";
        
        public static int GetCountOfWordsFromText(this string text)
        {
            if (string.IsNullOrEmpty(text)) return 0;

            foreach (var value in ValuesToReplaceInText)
            {
                text = text.Replace(value, string.Empty);
            }

            var words = text.Trim().Split(WordsSeparator);
            return words.Length;
        }
    }
}