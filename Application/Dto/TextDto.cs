namespace Application.Dto
{
    public class TextDto
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public TextDto(string id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}