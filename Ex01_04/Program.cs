namespace Noy__Dana__Ex0_04
{
    public class Program
    {
        public static void Main()
        {
            string userInput = getString();

            System.Console.WriteLine("The details are:");
            printIsPalindrome(userInput);
            printDivByFourOrHowManyLowCase(userInput);
        }

        private static void printDivByFourOrHowManyLowCase(string i_userInput)
        {
            long intUserInput;

            if (isTheStringIsNumbers(i_userInput, out intUserInput))
            {
                bool isDivByFour = Program.isDivByFour(intUserInput);
                System.Console.WriteLine("The input string {0} devided by four.", isDivByFour ? "is" : "is not");
            }
            else
            {
                int countLowerCase = howManyLowerCaseLetters(i_userInput);
                System.Console.WriteLine("There are {0} lower case letters in the string", countLowerCase);
            }
        }

        private static bool isTheStringIsNumbers(string i_userInput, out long o_intUserInput)
        {
            return long.TryParse(i_userInput, out o_intUserInput);
        }

        private static string getString()
        {
            System.Console.Write("Please enter 10 characters in english letters or 10 numbers: ");
            string userInput = System.Console.ReadLine();

            if (!checkValid(userInput))
            {
                System.Console.WriteLine("Invalid input. Try again.");
                userInput = getString();
            }

            return userInput;
        }

        private static void printIsPalindrome(string i_userInput)
        {
            bool isPalindrome = Program.checkIsPalindrome(i_userInput, 0, i_userInput.Length - 1);

            System.Console.WriteLine("The input string {0} a palindrome.", isPalindrome ? "is" : "is not");
        }

        private static bool checkIsPalindrome(string i_userInput, int i_stringBegin, int i_stringEnd)
        {
            bool isPalindrome = true;
            if (i_stringBegin < i_stringEnd)
            {
                if (i_userInput[i_stringBegin] != i_userInput[i_stringEnd])
                {
                    isPalindrome = false;
                }
                else
                {
                    isPalindrome = checkIsPalindrome(i_userInput, i_stringBegin + 1, i_stringEnd - 1);
                }
            }

            return isPalindrome;
        }

        private static int howManyLowerCaseLetters(string i_userInput)
        {
            int countLowerLetters = 0;

            for (int i = 0; i < i_userInput.Length; i++)
            {
                if (char.IsLower(i_userInput[i]))
                {
                    countLowerLetters++;
                }
            }

            return countLowerLetters;
        }

        private static bool isDivByFour(long i_userInput)
        {
            return (i_userInput % 4 == 0);
        }

        private static bool checkValid(string i_userInput)
        {
            bool firstIsDigit = char.IsDigit(i_userInput[0]);
            bool firstIsLetter = char.IsLetter(i_userInput[0]);
            bool isValid = (i_userInput.Length == 10);

            for (int i = 0; i < i_userInput.Length && isValid; i++)
            {
                isValid = (firstIsDigit && char.IsDigit(i_userInput[i]) || firstIsLetter && char.IsLetter(i_userInput[i])
                                                                        || char.IsLetterOrDigit(i_userInput[i]));
            }

            return isValid;
        }
    }
}
