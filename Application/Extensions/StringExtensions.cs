using System.Text.RegularExpressions;

namespace Application.Extensions
{
    public static class StringExtensions
    {
        private static readonly string[] ValuesToReplaceInText = { ".", ",", "?", "!", ":" };
        private const string WordsSeparator = " ";
        
        public static int GetCountOfWordsFromText(this string text)
        {
            foreach (var value in ValuesToReplaceInText)
            {
                text = text.Replace(value, string.Empty);
            }
            if (string.IsNullOrEmpty(text.Trim())) return 0;
            
            var regex = new Regex("[ ]{2,}", RegexOptions.None);     
            text = regex.Replace(text, " ");

            var words = text.Trim().Split(WordsSeparator);
            return words.Length;
        }
    }
}