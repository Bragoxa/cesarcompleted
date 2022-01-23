using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cesarkeyword
{
    class Program
    {
        static void deleteLetter(ref List<string> list, string elem)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == elem)
                {
                    list.RemoveAt(i);
                }
            }
        }
        static void sortArray(ref List<string> list)
        {
            list.Sort();
        }

        static int findindexof(string element, List<string> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (element == array[i])
                {
                    return i;
                }

            }
            return 0;
        }

        static void Main(string[] args)
        {
            List<string> letterdictionary = new List<string> { "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            List<string> letterdictionary2 = new List<string> { "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            List<string> alph = new List<string> { "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            int key;
            string keyword;
            string message;
            string result;
            string file = @"Test.txt";
            int s;
            var newmes = new List<string>();
            

            Console.Write("Чтобы зашифровать сообщение - введите 1, для зашифровки из текста - 2: ");
            int choose = Int32.Parse(Console.ReadLine());
            if (choose == 1)
            {
                message = Console.ReadLine();
                key = int.Parse(Console.ReadLine());
                keyword = Console.ReadLine();
                encrypt();
            }
            if (choose == 2)
            {
                encrypt_t();
            }
            void encrypt()
            {
                Console.WriteLine(message);

                for (int i = key; i < key + keyword.Length; i++)
                {
                    letterdictionary2[i % 32] = keyword[i - key].ToString();
                    deleteLetter(ref letterdictionary, keyword[i - key].ToString());

                }
                for (int i = 0; i < letterdictionary2.Count - keyword.Length; i++)
                {

                    sortArray(ref letterdictionary);
                    letterdictionary2[(i + key + keyword.Length) % 32] = letterdictionary[0];
                    deleteLetter(ref letterdictionary, letterdictionary[0]);

                }

                //void input()
                //{
                //    for (int i = 0; i < letterdictionary2.Count; i++)
                //    {
                //        if (message.Contains(letterdictionary2[i].ToString()))
                //        {
                //            Console.Write(letterdictionary[i]);
                //        }
                //    }
                //}

                char[] charStr = message.ToCharArray();

                for (int i = 0; i < message.Length; i++)
                {
                    if (alph.Contains(charStr[i].ToString()))
                    {
                        charStr[i] = letterdictionary2[findindexof(charStr[i].ToString(), alph)].ToCharArray()[0];


                    }
                }
                result = new string(charStr);
                //input();
                Console.WriteLine(result);
            }
            void encrypt_t() 
            {
                string message = File.ReadAllText(@"Test.txt");
                key = 3;
                keyword = "лом";

                for (int i = key; i < key + keyword.Length; i++)
                {
                    letterdictionary2[i % 32] = keyword[i - key].ToString();
                    deleteLetter(ref letterdictionary, keyword[i - key].ToString());

                }
                for (int i = 0; i < letterdictionary2.Count - keyword.Length; i++)
                {

                    sortArray(ref letterdictionary);
                    letterdictionary2[(i + key + keyword.Length) % 32] = letterdictionary[0];
                    deleteLetter(ref letterdictionary, letterdictionary[0]);

                }

                //void input()
                //{
                //    for (int i = 0; i < letterdictionary2.Count; i++)
                //    {
                //        if (message.Contains(letterdictionary2[i].ToString()))
                //        {
                //            Console.Write(letterdictionary[i]);
                //        }
                //    }
                //}

                char[] charStr = message.ToCharArray();

                for (int i = 0; i < message.Length; i++)
                {
                    if (alph.Contains(charStr[i].ToString()))
                    {
                        charStr[i] = letterdictionary2[findindexof(charStr[i].ToString(), alph)].ToCharArray()[0];


                    }
                }
                result = new string(charStr);
                //input();
                File.WriteAllText("result.txt", result);
                Console.WriteLine(result);
            }
        }
    }
}
