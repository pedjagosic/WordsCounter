using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shared.Enumerations
{
    public class TextType
    {
        public string Id { get; set; }
        public string DisplayText { get; set; }

        private TextType(string id, string displayText)
        {
            Id = id;
            DisplayText = displayText;
        }

        public static TextType TextCountFromFile => new TextType("1", "Text count from file");
        public static TextType TextCountFromDb => new TextType("2", "Text count from db");
        public static TextType TextCountFromInput => new TextType("3", "Text count from input");

        public static IEnumerable<T> GetAll<T>() where T : TextType 
            => typeof(T).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public).Select(f => f.GetValue(null)).Cast<T>();

        public static TextType FromId(string id)
        {
            try
            {
                return GetAll<TextType>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                return new TextType("-1", "Unknown text type.");
            }
        }

    }
}