namespace Noy__Dana__Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            int binaryNumber1 = int.Parse(getBinaryWord());
            int binaryNumber2 = int.Parse(getBinaryWord());
            int binaryNumber3 = int.Parse(getBinaryWord());

            printStatistics(binaryNumber1, binaryNumber2, binaryNumber3);
        }

        private static void printStatistics(int i_binaryNumber1, int i_binaryNumber2, int i_binaryNumber3)
        {
            int minNumber, maxNumber;
            int decimalNumber1 = covertToDecimal(i_binaryNumber1);
            int decimalNumber2 = covertToDecimal(i_binaryNumber2);
            int decimalNumber3 = covertToDecimal(i_binaryNumber3);

            PrintByAscendingOrder(decimalNumber1, decimalNumber2, decimalNumber3, out minNumber, out maxNumber);
            System.Console.WriteLine("The statistics of the input: ");
            printAverageOfOneAndZero(i_binaryNumber1, i_binaryNumber2, i_binaryNumber3);
            printNumOfPowOfTwo(i_binaryNumber1, i_binaryNumber2, i_binaryNumber3);
            printNumOfAscendingOrderInNums(decimalNumber1, decimalNumber2, decimalNumber3);
            System.Console.WriteLine("The biggest number is {0}, and the smallest number is {1}", maxNumber, minNumber);
        }

        private static void printNumOfAscendingOrderInNums(int i_decimalNumber1, int i_decimalNumber2, int i_decimalNumber3)
        {
            int numOfPowOfAscending = 0;

            checkIfAndCountAscendingOrder(i_decimalNumber1, ref numOfPowOfAscending);
            checkIfAndCountAscendingOrder(i_decimalNumber2, ref numOfPowOfAscending);
            checkIfAndCountAscendingOrder(i_decimalNumber3, ref numOfPowOfAscending);
            System.Console.WriteLine("There is {0} numbers that are by ascending order", numOfPowOfAscending);
        }

        private static void checkIfAndCountAscendingOrder(int i_decimalNumber, ref int o_numOfAscending)
        {
            int lastNumber = i_decimalNumber % 10;
            bool isAscending = true;

            while (i_decimalNumber != 0 && isAscending)
            {
                i_decimalNumber /= 10;
                isAscending = (lastNumber > (i_decimalNumber % 10));
                lastNumber = i_decimalNumber % 10;
            }

            if (isAscending)
            {
                o_numOfAscending++;
            }
        }

        private static void printNumOfPowOfTwo(int i_binaryNumber1, int i_binaryNumber2, int i_binaryNumber3)
        {
            int numOfPowOfTwo = 0;

            checkIfAndCountPowOfTwo(i_binaryNumber1, ref numOfPowOfTwo);
            checkIfAndCountPowOfTwo(i_binaryNumber2, ref numOfPowOfTwo);
            checkIfAndCountPowOfTwo(i_binaryNumber3, ref numOfPowOfTwo);
            System.Console.WriteLine("There is {0} numbers that are a power of two", numOfPowOfTwo);
        }

        private static void checkIfAndCountPowOfTwo(int i_binaryNumber, ref int o_numOfPowOfTwo)
        {
            int numOfOnes = 9 - countNumOfZeros(i_binaryNumber);

            if (numOfOnes == 1)
            {
                o_numOfPowOfTwo++;
            }
        }

        private static void printAverageOfOneAndZero(int i_binaryNumber1, int i_binaryNumber2, int i_binaryNumber3)
        {
            float avgOnes = ((9 - countNumOfZeros(i_binaryNumber1)) + (9 - countNumOfZeros(i_binaryNumber2)) + (9 - countNumOfZeros(i_binaryNumber3))) / 3f;
            float avgZeros = (countNumOfZeros(i_binaryNumber1) + countNumOfZeros(i_binaryNumber2) + countNumOfZeros(i_binaryNumber3)) / 3f;

            System.Console.WriteLine("The average number of zeros is {0}", avgZeros);
            System.Console.WriteLine("The average number of ones is {0}", avgOnes);
        }

        private static int countNumOfZeros(int i_binaryNumber)
        {
            int countZero = 0;

            for (int i = 0; i < 9; i++)
            {
                if (i_binaryNumber % 10 == 0)
                {
                    countZero++;
                }
                i_binaryNumber /= 10;
            }

            return countZero;
        }

        private static string getBinaryWord()
        {
            System.Console.WriteLine("Please insert a 9 digits binary number: ");
            string binaryWord = System.Console.ReadLine();

            if (!validNumberCheck(binaryWord))
            {
                System.Console.WriteLine("Invalid input. Try again.");
                binaryWord = getBinaryWord();
            }

            return binaryWord;
        }

        private static bool validNumberCheck(string i_binaryWord)
        {
            bool validNumber = (i_binaryWord.Length == 9);

            for (int i = 0; i < 9 && validNumber; i++)
            {
                validNumber = (i_binaryWord[i] == '0' || i_binaryWord[i] == '1');
            }

            return validNumber;
        }

        private static int covertToDecimal(int i_binaryNumber)
        {
            int powOfTwo = 1;
            int decimalResult = 0;

            for (int i = 0; i < 9; i++)
            {
                decimalResult += (i_binaryNumber % 10) * powOfTwo;
                powOfTwo *= 2;
                i_binaryNumber /= 10;
            }

            return decimalResult;
        }

        private static void PrintByAscendingOrder(int i_decimalNumber1, int i_decimalNumber2,
                                                 int i_decimalNumber3, out int o_minNumber, out int o_maxNumber)
        {
            int min = System.Math.Min(System.Math.Min(i_decimalNumber1, i_decimalNumber2), i_decimalNumber3);
            int max = System.Math.Max(System.Math.Max(i_decimalNumber1, i_decimalNumber2), i_decimalNumber3);
            int mid = i_decimalNumber1 + i_decimalNumber2 + i_decimalNumber3 - min - max;

            System.Console.WriteLine("The decimal numbers by ascending order:");
            System.Console.WriteLine(@"{0}
{1}
{2}", min, mid, max);
            o_minNumber = min;
            o_maxNumber = max;
        }
    }
}