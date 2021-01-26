using System;
using System.Linq;

namespace Domain.Entities
{
    public class TextEntity
    {
        private static readonly string[] ValuesToReplaceInText = { ".", ",", "?", "!", ":" };
        private const string WordsSeparator = " ";

        public string Id { get; private set; }
        public string Text { get; private set; }

        public TextEntity(string text)
        {
            Id = Guid.NewGuid().ToString();
            Text = text;
        }

        public int GetCountOfWordsFromText()
        {
            var text = Text;
            if (string.IsNullOrEmpty(text)) return 0;

            foreach (var value in ValuesToReplaceInText)
            {
                text = text.Replace(value, string.Empty);
            }

            var words = text.Trim().Split(WordsSeparator);
            return words.Count();
        }
    }
}
