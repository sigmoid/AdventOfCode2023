using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day1
{
    public class Trebuchet
    {
        public void SolveTrebuchet(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);

            int res = 0;

            string line = sr.ReadLine();
            while (line != null)
            {
                int firstDigit = '#';
                for (int i = 0; i < line.Length; i++)
                {
                    char current = line[i];

                    int? currentDigit = findDigitString(line, i);
                    if (currentDigit != null)
                    {
                        firstDigit = currentDigit.Value;
                        break;
                    }
                    if (char.IsNumber(current))
                    {
                        firstDigit = current - '0';
                        break;
                    }
                }

                int lastDigit = '#';
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    char current = line[i];

                    int? currentDigit = findDigitString(line, i);
                    if (currentDigit != null)
                    {
                        lastDigit = currentDigit.Value;
                        break;
                    }
                    if (char.IsNumber(current))
                    {
                        lastDigit = current - '0';
                        break;
                    }
                }

                if (firstDigit == '#' || lastDigit == '#')
                    throw new Exception("Failed to find digits");

                int currentNum = 10 * firstDigit + lastDigit;

                Console.WriteLine(currentNum);

                res += currentNum;

                line = sr.ReadLine();
            }

            Console.WriteLine("Result: " + res.ToString());
        }

        private int? findDigitString(string s, int i)
        {
            Dictionary<string, int> digits = new Dictionary<string, int> {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine" , 9} };

            foreach (var digit in digits.Keys)
            {
                int digitLengthLeft = digit.Length;

                if (digitLengthLeft > s.Length - i)
                    continue;

                for (int idx = i; idx < s.Length; idx++)
                {
                    if (s[idx] == digit[idx - i])
                        digitLengthLeft--;
                    else
                        break;

                    if (digitLengthLeft == 0)
                        return digits[digit];
                }
            }

            return null;
        }

    }
}
