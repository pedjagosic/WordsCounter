using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Dto;
using Newtonsoft.Json;
using Shared.Enumerations;

namespace Presentation.Helpers
{
    public static class ConsoleHelper
    {
        private const string FilesDirectoryPath = @"Files\";
        private const string RequestUriGet = "api/text/get";
        private const string RequestUriGetAll = "api/text/getall";
        private const string BaseAddress = "https://localhost:5001/";

        public static void Run()
        {
            while (true)
            {
                var selectedTypeId = GetSelectedTypeId();
                var result = GetTextContentOrTextId(selectedTypeId);

                RunAsync(selectedTypeId, result).GetAwaiter().GetResult();
            }
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

        private static string GetTextContentOrTextId(string selectedTypeId)
        {
            var result = string.Empty;
            if (selectedTypeId == TextType.TextCountFromFile.Id)
                result = GetTextFromFile();

            if (selectedTypeId == TextType.TextCountFromInput.Id)
                result = GetTextFromInput();

            if (selectedTypeId == TextType.TextCountFromDb.Id)
                result = GetTextId();
            
            return result;
        }

        private static string GetTextId()
         => PrintAllTextsFromDbAndGetSingleIdAsync().GetAwaiter().GetResult();
        
        private static async Task<string> PrintAllTextsFromDbAndGetSingleIdAsync()
        {
            var texts = await GetAllTextsFromDbAsync();
            Console.WriteLine($"Select text from db (1-{texts.Count}):");
            var indexes = new string[texts.Count];
            for (var i = 0; i < texts.Count; i++)
            {
                indexes[i] = (i + 1).ToString();
                Console.WriteLine($"{indexes[i]}. {texts[i].Text}");
            }

            var index = string.Empty;
            while (!indexes.Contains(index))
            {
                index = Console.ReadLine();
            }

            return texts[int.Parse(index) - 1].Id;
        }

        private static string GetTextFromFile()
        {
            var files = PrintListOfFiles();
            var indexes = GetIndexes(files);

            var fileContent = string.Empty;

            var option = string.Empty;
            while (!indexes.Contains(option))
            {
                option = Console.ReadLine();
            }
            var index = int.Parse(option);
            
            var filePath = files[index - 1];
            using var sr = File.OpenText(filePath);
            while (sr.ReadLine() != null)
            {
                fileContent = File.ReadAllText(filePath);
            }

            return fileContent;
        }

        private static string[] GetIndexes(string[] stringArray)
        {
            var indexes = new string[stringArray.Length];
            for (var i = 0; i < stringArray.Length; i++)
            {
                indexes[i] = (i + 1).ToString();
            }

            return indexes;
        }

        private static string[] PrintListOfFiles()
        {
            var files = Directory.GetFiles(FilesDirectoryPath);
            Console.WriteLine($"List of files (1-{files.Length}):");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
            }

            return files;
        }

        private static string GetTextFromInput()
        {
            Console.WriteLine("Enter text:");
            var enteredText = Console.ReadLine();

            return enteredText;
        }

        static async Task RunAsync(string textTypeId, string result)
        {
            using var client = new HttpClient {BaseAddress = new Uri(BaseAddress)};
            var response = await client.GetAsync(string.Format(
                $"{RequestUriGet}?typeId={textTypeId}&text={result}&id={result}"));
            var numberOfWords = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"{TextType.FromId(textTypeId).DisplayText}: {numberOfWords}");
            Console.WriteLine("Press Enter.");
            Console.ReadLine();
        }

        static async Task<List<TextDto>> GetAllTextsFromDbAsync()
        {
            using var client = new HttpClient {BaseAddress = new Uri(BaseAddress)};
            var response = await client.GetAsync($"{RequestUriGetAll}");
            var allTextsFromDbJson = await response.Content.ReadAsStringAsync();

            var allTextsFromDb = JsonConvert.DeserializeObject<List<TextDto>>(allTextsFromDbJson);
            return allTextsFromDb;
        }
        
        private static void PrintTypes()
        {
            Console.WriteLine($"1. {TextType.TextCountFromFile.DisplayText}");
            Console.WriteLine($"2. {TextType.TextCountFromDb.DisplayText}");
            Console.WriteLine($"3. {TextType.TextCountFromInput.DisplayText}");
        }
    }
}