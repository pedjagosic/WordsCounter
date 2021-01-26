using System;

namespace Domain.Entities
{
    public class TextEntity
    {
        public string Id { get; private set; }
        public string Text { get; private set; }

        public TextEntity(string text)
        {
            Id = Guid.NewGuid().ToString();
            Text = text;
        }
    }
}
