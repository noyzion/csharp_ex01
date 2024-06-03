namespace Noy__Dana__Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            PrintDiamond(9, 5);
        }

        public static void PrintDiamond(int i_rows, int i_midOfDiamond)
        {
            if (i_rows == 0)
            {
                return;
            }

            System.Text.StringBuilder eachRow = new System.Text.StringBuilder();

            if (i_rows <= i_midOfDiamond)
            {
                eachRow.Append(' ', i_midOfDiamond - i_rows);
                eachRow.Append('*', i_rows * 2 - 1);
            }
            else
            {
                eachRow.Append(' ', i_rows - i_midOfDiamond);
                eachRow.Append('*', (i_rows - (i_rows % i_midOfDiamond * 2)) * 2 - 1);
            }

            System.Console.WriteLine(eachRow.ToString());
            PrintDiamond(i_rows - 1, i_midOfDiamond);
        }
    }
}



