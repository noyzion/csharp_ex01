namespace Noy__Dana__Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            int diamondHeight = getDiamondHeight();

            Noy__Dana__Ex01_02.Program.PrintDiamond(diamondHeight, diamondHeight / 2 + 1);
        }

        private static int getDiamondHeight()
        {
            System.Console.Write("Please enter the height of the diamond: ");
            string inputDiamondHeight = System.Console.ReadLine();
            int intDiamondHeight;

            System.Console.WriteLine();

            if (!checkValidility(inputDiamondHeight, out intDiamondHeight))
            {
                System.Console.WriteLine("Invalid input. Try again.");
                intDiamondHeight = getDiamondHeight();
            }

            if (intDiamondHeight % 2 == 0)
            {
                intDiamondHeight++;
            }

            return intDiamondHeight;
        }

        private static bool checkValidility(string i_Height, out int io_diamondHeight)
        {
            return (int.TryParse(i_Height, out io_diamondHeight) && io_diamondHeight > 0);
        }
    }
}
