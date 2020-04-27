using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace PigLatin
{
    class Program
    {
        static char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        static void Main(string[] args)
        {

            bool repeat = true;

            while (repeat)
            {

                string input = CheckIfLetters("Enter some text to translate to Pig Latin:");

                Console.WriteLine();
                Console.WriteLine();


                Console.WriteLine(input);

                string redo = Console.ReadLine();



                

                repeat = RepeatProgram(redo);
            }

            Console.WriteLine("Goodbye!");


        }

        public static string CheckIfLetters(string message)
        {
            while (true)
            {

                Console.WriteLine(message);

                string response = Console.ReadLine().Trim();

               

                string[] words = response.Split();

                foreach (string pigWord in words)
                {

                    Match match = Regex.Match(pigWord, "[^a-zA-Z ']");

                    if ((message == null) || (message == ""))
                    {
                        Console.WriteLine("You didn't enter anything! Please try again:");
                        continue;

                    }
                    else if (match.Success)
                    {

                        Console.Write(pigWord + " ");
                      

                    }
                    else
                    {
                        Translate(pigWord);


                    }

                }
                return ("Type y to try again");
              

            }
        }




        public static bool RepeatProgram(string answer)
        {

            if (answer == "y")
            {
                return true;

            }

            return false;

        }

        public static void Translate(string word)
        {
            int index = word.IndexOfAny(vowels);

            if ((index < 0) && (word == ""))
            {
                Console.WriteLine("You didn't enter anything!");
            }
            else if (index < 0)
            {
                Console.Write(word + " ");
            }
            else
            {

                string vowelSuff = "way";

                string conSuff = "ay";

                bool upper = false;

                int numCaps = 0;

                numCaps = CheckCaps(word);

                upper = numCaps == word.Length;

                int[] capsInd = new int[numCaps];

                if (upper)
                {
                    vowelSuff = vowelSuff.ToUpper();

                    conSuff = conSuff.ToUpper();
                }
                else if ((numCaps > 0) && (numCaps < word.Length))
                {
                    capsInd = GetLocationoOfCaps(word, numCaps);



                }



                string vWord = (word + vowelSuff);

                string beg = word.Substring(0, index);

                string restOf = word.Substring(index);

                string translate = restOf + beg + conSuff;

                char[] arWord = new char[translate.Length];








                if (index == 0)
                {


                    Console.Write(vWord + " ");

                }
                else
                {
                    if (numCaps == word.Length)
                    {

                        Console.Write(translate + " ");

                    }
                    else
                    {



                        foreach (int i in capsInd)
                        {
                            int capCounter = 0;



                            foreach (Char c in translate)
                            {

                                if (capCounter == i)
                                {
                                    arWord[capCounter] = Char.ToUpper(c);


                                }
                                else
                                {
                                    arWord[capCounter] = Char.ToLower(c);
                                }

                                capCounter++;
                            }



                        }
                    }

                    if (numCaps == 0)
                    {

                        Console.Write(translate);
                    }
                    else
                    {

                        foreach (Char a in arWord)
                        {
                            Console.Write(a);

                        }
                        Console.Write(" ");
                        //Console.Write(translate + " ");
                    }
                }

            }



        }

        public static int CheckCaps(string word)
        {
            bool isCap;
            int caps = 0;

            foreach (Char c in word)
            {

                isCap = Char.IsUpper(c);

                if (isCap)
                {
                    caps++;
                }


            }

            return caps;
        }

        public static int[] GetLocationoOfCaps(string word, int numCaps)
        {
            int[] caps = new int[numCaps];

            bool isCap;

            int index = 0;

            int arPosition = -1;

            

            foreach (Char c in word)
            {

                isCap = Char.IsUpper(c);

                if (isCap)
                {
                    arPosition++;

                   index = word.IndexOf(c);

                    caps[arPosition] = index;

                   
                    

                }

            }

            return caps;

        }
    }
}
