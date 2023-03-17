namespace PasswordGenerator
{
    internal class Program
    {
        static readonly Random Random = new Random();
        static void Main(string[] args)
        {
            
            if (!IsValid(args))
            {
                ShowHelpText();
                return;
            }
            string pattern = GetPattern(Int32.Parse(args[0]), args[1]);
            Console.WriteLine(pattern);
            while (pattern.Length >= 1)
            {
                int randomIndex = Random.Next(0, pattern.Length - 1);
               
                char charToBeRemoved = pattern[randomIndex];
                
                //char charToBeRemoved = pattern[pattern.Length - 1];
                //pattern = pattern.Remove(pattern.Length - 1);
                
                pattern = pattern.Remove(randomIndex, 1);
                
                if (charToBeRemoved == 'l') WriteRandomLowerCaseLetter();
                else if (charToBeRemoved == 'L') WriteRandomUpperCaseLetter();
                else if (charToBeRemoved == 'd') WriteRandomDigit();
                else if (charToBeRemoved == 's') WriteRandomSpecialCharacter();
            }
        }

        static void ShowHelpText()
        {
            Console.WriteLine("PasswordGenerator");
            Console.WriteLine("\tOptions:\n\t- l = lower case letter\n\t- L = upper case letter\n\t- d = digit\n\t- s = special character (!\"#¤%&/(){}[]");
            Console.WriteLine("Example: PasswordGenerator 14 lLssdd\n\t\tMin. 1 lower case\n\t\tMin. 1 upper case");
            Console.WriteLine("\n\t\tMin. 2 special characters\n\t\tMin. 2 digits");
        }

        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        static bool IsOnlyLDOrS(string str)
        {
            foreach (char c in str)
            {
                if(!(c == 'L' || c == 'l' || c == 'd' || c == 's'))
                    return false;
            }

            return true;
        }

        static bool IsValid(string[] arguments)
        {
            if (Int32.Parse(arguments[0]) < arguments[1].Length) return false;
            if (arguments.Length < 1 || !IsDigitsOnly(arguments[0]) || !IsOnlyLDOrS(arguments[1]))
            {
                
                return false;
            }
            return true;
            
        }
        static string GetPattern(int length, string pattern) 
        {
            string s;
            char[] chars = new char[length];
            for(int i = 0; i < pattern.Length; i++) 
            {
                chars[i] = pattern[i];
               
            }
            for (int j = pattern.Length; j < length; j++)
            {
                chars[j] = 'l';
            }
            s = new string(chars);
            return s;
        }

        static void WriteRandomLowerCaseLetter() 
        {
            char letter = GetRandomLetter('a', 'z');
            Console.WriteLine(letter);
        }

        static void WriteRandomUpperCaseLetter()
        {
            char letter = GetRandomLetter('A', 'Z');
            Console.WriteLine(letter);
        }

        static void WriteRandomDigit()
        {
            int randomDigit = Random.Next(0, 9);
            Console.WriteLine(randomDigit);
        }

        static void WriteRandomSpecialCharacter()
        {
            //char sign = GetRandomLetter('!', '&');
            //Console.WriteLine(sign);

            string specialCharacters = "!\"#¤%&/(){}[]";
            int randomDigit = Random.Next(0, 13);
            Console.WriteLine(specialCharacters[randomDigit]);

        }


        static char GetRandomLetter(char min, char max)
        {
            return (char)Random.Next(min, max);
        }




    }
}