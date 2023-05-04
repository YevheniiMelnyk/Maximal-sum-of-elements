using MaxSumOfElements;
internal class Program
{
    //private static readonly string _FilePath = Path.Combine("..", "..", "..", "DataFile", "data.txt");

    private static void Main(string[] args)
    {
        string filePath = string.Empty;

        if (args.Length > 0)
        {
            filePath = args[0];

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine(); 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid file path or file doesn't exist.");
                Console.ResetColor();
                Console.WriteLine();

                filePath = IsFileExist();
            }
        }
        else
        {
            filePath = IsFileExist();
        }        

        MaxSum maxSum = new(filePath);
        maxSum.PrintMaxSumRowWithNumber();
        maxSum.PrintInvalidRowsWithNumbers();
    }

    private static string IsFileExist()
    {
        Console.Write("Enter valid path to file: ");
        string filePath = Console.ReadLine();

        bool result = File.Exists(filePath);

        while (!result)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Invalid file path or file doesn't exist.");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Please valid correct path: ");
            filePath = Console.ReadLine();
            result = File.Exists(filePath);
        }

        return filePath;
    }
}