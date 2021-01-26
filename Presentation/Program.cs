using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Presentation.Helpers;
using Shared.Enumerations;

namespace Presentation
{
    public static class Program
    {
        private const string FileNameToken = "#file_name_stamp";
        private const string FilesDirectoryPath = @"Files\";
        private const string RequestUri = "api/text";
        private const string BaseAddress = "https://localhost:5001/";
        private static readonly string FilePath = @$"{FilesDirectoryPath}{FileNameToken}";
        //private static readonly HttpClient Client = new HttpClient();

        static void Main(string[] args)
        {
            //Run();
            ConsoleHelper.DisplayMainMenu();

            Console.ReadLine();
        }

        private static void Run()
        {
            while (true)
            {
                var text = string.Empty;
                var selectedTypeId = GetSelectedTypeId();
                if (selectedTypeId != TextType.TextCountFromDb.Id) text = GetTextContent(selectedTypeId);

                RunAsync(selectedTypeId, text).GetAwaiter().GetResult();
            }
        }


        private static string GetTextContent(string selectedTypeId)
        {
            var text = string.Empty;
            if (selectedTypeId == TextType.TextCountFromFile.Id)
                text = GetTextFromFile();

            if (selectedTypeId == TextType.TextCountFromInput.Id)
                text = GetTextFromInput();
            return text;
        }

        private static string GetTextFromFile()
        {
            PrintListOfFiles();
            var fileExist = false;
            var filePath = string.Empty;

            while (!fileExist)
            {
                Console.WriteLine("Enter file name:");
                var fileName = Console.ReadLine();
                filePath = FilePath.Replace(FileNameToken, fileName);
                fileExist = File.Exists(filePath);
            }

            var fileContent = File.ReadAllText(filePath);
            return fileContent;
        }

        private static void PrintListOfFiles()
        {
            var files = Directory.GetFiles(FilesDirectoryPath);
            Console.WriteLine("List of files:");
            foreach (var file in files)
            {
                Console.WriteLine($"{Path.GetFileName(file)}");
            }
        }

        private static string GetTextFromInput()
        {
            Console.WriteLine("Enter text:");
            var enteredText = Console.ReadLine();

            return enteredText;
        }

        private static string GetSelectedTypeId()
        {
            var isValidType = false;
            var selectedTypeId = string.Empty;

            while (!isValidType)
            {
                PrintTypes();
                selectedTypeId = Console.ReadLine();
                var allTypes = TextType.GetAll<TextType>();
                isValidType = allTypes.Select(x => x.Id).Contains(selectedTypeId);
            }

            return selectedTypeId;
        }

        private static void PrintTypes()
        {
            Console.WriteLine($"1 {TextType.TextCountFromFile.DisplayText}");
            Console.WriteLine($"2 {TextType.TextCountFromDb.DisplayText}");
            Console.WriteLine($"3 {TextType.TextCountFromInput.DisplayText}");
        }

        static async Task RunAsync(string textTypeId, string text)
        {
            using var client = new HttpClient {BaseAddress = new Uri(BaseAddress)};
            var response = await client.GetAsync(String.Format(
                $"{RequestUri}?typeId={textTypeId}&text={text}&id={1}"));
            var numberOfWords = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"{TextType.FromId(textTypeId).DisplayText}: {numberOfWords}");
            Console.WriteLine("Press Enter.");
            Console.ReadLine();
        }
    }
}