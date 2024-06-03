namespace Noy__Dana__Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            int userInput = int.Parse(getStringNumber());

            printDetails(userInput);
        }

        private static void printDetails(int i_number)
        {
            System.Console.WriteLine("The details are:");
            System.Console.WriteLine("There are {0} digits that are smaller than the first digit", howManySmallerThanFirstDigit(i_number));
            System.Console.WriteLine("There are {0} digits that are devided by 3", howManyDigitsDivBy3(i_number));
            System.Console.WriteLine("The biggest digit is {0}", bigDigitInNumber(i_number));
            System.Console.WriteLine("The average of the digits is {0}", digitAverage(i_number));
        }

        private static float digitAverage(int i_number)
        {
            int sumDigits = 0;

            for (int i = 0; i < 8; i++)
            {
                sumDigits += i_number % 10;
                i_number /= 10;
            }

            return sumDigits / 8f;
        }

        private static int bigDigitInNumber(int i_number)
        {
            int maxDigit = i_number % 10;

            for (int i = 0; i < 7; i++)
            {
                i_number /= 10;
                maxDigit = System.Math.Max(maxDigit, i_number % 10);
            }

            return maxDigit;
        }

        private static int howManyDigitsDivBy3(int i_number)
        {
            int countDivByThree = 0;

            for (int i = 0; i < 8; i++)
            {
                if ((i_number % 10) % 3 == 0)
                {
                    countDivByThree++;
                }

                i_number /= 10;
            }

            return countDivByThree;
        }

        private static int howManySmallerThanFirstDigit(int i_number)
        {
            int firstDigit = i_number % 10;
            int countSmallerThanFirstDigit = 0;

            for (int i = 0; i < 7; i++)
            {
                i_number /= 10;
                if (i_number % 10 < firstDigit)
                {
                    countSmallerThanFirstDigit++;
                }
            }

            return countSmallerThanFirstDigit;
        }

        private static string getStringNumber()
        {
            System.Console.Write("Please enter an eight-digit number: ");
            string userInput = System.Console.ReadLine();

            if (!checkValid(userInput))
            {
                System.Console.WriteLine("Invalid input. Try again.");
                userInput = getStringNumber();
            }

            return userInput;
        }

        private static bool checkValid(string i_userInput)
        {
            bool isValid = (i_userInput.Length == 8);

            for (int i = 0; i < i_userInput.Length && isValid; i++)
            {
                isValid = char.IsDigit(i_userInput[i]);
            }

            return isValid;
        }
    }
}
