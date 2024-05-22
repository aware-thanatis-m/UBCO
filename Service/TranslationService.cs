using Microsoft.VisualBasic;
using UBCOWeb.Service.Interfaces;

namespace UBCOWeb.Service
{
    public class TranslationService : ITranslationService
    {
        public TranslationService() { }

        public string TranslationText(string input) 
        { 
            string result = "UBCO ";
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException($"'{nameof(input)}' cannot be null or empty.", nameof(input));
            }

            string allLetters = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";
            string lettersLower = "bcdfghjklmnpqrstvwxyz";
            string lettersUpper = "BCDFGHJKLMNPQRSTVWXYZ";

            foreach (char item in input)
            {
                if ("aeiouAEIOU".Contains(item))
                {
                    //do double time
                    result += item;
                    result += item;
                }
                else if(char.IsLetter(item) && allLetters.Contains(item))
                {
                    var lettersStr = char.IsUpper(item) ? lettersUpper : lettersLower;
                    int index = lettersStr.IndexOf(item);
                    result += lettersStr[(index + 1) % lettersStr.Length];
                }
                else
                {
                    result += item;
                }
            }

            result += CountWords(input);
            return result;

        }


        private static string CountWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "0";
            return Convert.ToString(input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length);
        }
    }
}
