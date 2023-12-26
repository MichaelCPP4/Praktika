using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bred
{
    public class Converter
    {
        private static string alphabet = "1234567890"; // цифры

        protected static List<int> numberList = new List<int>();
        public static List<int> ConvertLettersToNumbers(string word)
        {
            foreach (char letter in word)
            {
                int index = alphabet.IndexOf(letter); // Получаем индекс символа в алфавите
                if (index != -1)
                {
                    int adjustedIndex = index - 5; // Приводим индекс к диапазону от -16 до 16
                    numberList.Add(adjustedIndex);
                }
            }

            return numberList;
        }
    }

    public class RussianAlphabetConverter : Converter
    {
        private static string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private static string alphabet2 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public static new List<int> ConvertLettersToNumbers(string word)
        {
            foreach (char letter in word)
            {
                int index = alphabet.IndexOf(letter); // Получаем индекс символа в алфавите
                if (index != -1) // Для букв высокого регистра
                {
                    int adjustedIndex = index - 16; // Приводим индекс к диапазону от -16 до 16
                    numberList.Add(adjustedIndex);
                }
                else // Для букв нижнего регистра
                {
                    index = alphabet2.IndexOf(letter);
                    if(index != -1)
                    {
                        int adjustedIndex = index - 16; // Приводим индекс к диапазону от -16 до 13
                        numberList.Add(adjustedIndex);
                    }
                }
            }

            return numberList;
        }
    }
}