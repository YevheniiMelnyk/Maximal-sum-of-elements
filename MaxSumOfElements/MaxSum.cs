using System.Globalization;

namespace MaxSumOfElements
{
    public class MaxSum
    {
        private readonly CultureInfo _culture = CultureInfo.CreateSpecificCulture("en-US");
        private List<int> _invalidRowNumbers = new();
        private Dictionary<int, double> _rowWithMaxSum = new();
        public MaxSum(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                throw new ArgumentNullException("Invalid file path or file doesn't exist.");
            }

            string[] stringsFromFile;

            stringsFromFile = File.ReadAllLines(filePath);

            ParseRows(stringsFromFile);
        }

        private void ParseRows(string[] rows)
        {
            if (rows == null)
            {
                throw new NullReferenceException("Rows cannot be null.");
            }

            _rowWithMaxSum = new();

            double maxSum = double.MinValue;
            int maxSumRowNumber = 0;

            int rowNumber = 0;

            foreach (var str in rows)
            {
                rowNumber++;

                double tempRowSum = 0;
                bool isCorrectNumber = true;

                var splitedRow = str.Split(',');

                foreach (var row in splitedRow)
                {
                    double tempSum;
                    isCorrectNumber = double.TryParse(row, NumberStyles.Float, _culture, out tempSum);

                    if (isCorrectNumber)
                    {
                        tempRowSum += tempSum;
                    }
                    else
                    {
                        _invalidRowNumbers.Add(rowNumber);
                        break;
                    }
                }

                if (isCorrectNumber && (tempRowSum > maxSum || (tempRowSum < 0 && maxSum < 0 && tempRowSum > maxSum)))
                {
                    maxSum = tempRowSum;
                    maxSumRowNumber = rowNumber;
                }
            }

            if (maxSumRowNumber != 0)
            {
                _rowWithMaxSum.Add(maxSumRowNumber, maxSum);
            }
        }

        public Dictionary<int, double> GetMaxSumRowWithNumberDictionary()
        {
            return _rowWithMaxSum;
        }

        public void PrintMaxSumRowWithNumber()
        {
            Console.WriteLine();

            if(_rowWithMaxSum.Any())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Concat("Valid row with the highest sum: №", _rowWithMaxSum.Keys.First(),
                    ", row sum: ", _rowWithMaxSum.Values.First().ToString(_culture)));
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File doesn't include valid rows.");
                Console.ResetColor();
            }
        }

        public void PrintInvalidRowsWithNumbers()
        {
            Console.WriteLine();

            if (_invalidRowNumbers.Count > 0)
            {
                string str = _invalidRowNumbers.Count > 1 ? "Invalid row numbers: " : "Invalid row number: ";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{str}" + string.Join(", ", _invalidRowNumbers));
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The file does not contain any broken rows.");
                Console.ResetColor();
            }
        }
    }
}
