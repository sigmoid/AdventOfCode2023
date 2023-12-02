using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day2
{
    public class CubeConundrum
    {
        internal class Game 
        {
            public int NumRed;
            public int NumGreen;
            public int NumBlue;
        }
        public void SolvePart1(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);

            int res = 0;

            int maxRedCubes = 12;
            int maxGreenCubes = 13;
            int maxBlueCubes = 14;

            string line = sr.ReadLine();
            int currentGame = 1;

            while (line != null)
            {
                string processedLine = line.Substring(line.IndexOf(':') + 1).Trim();
                string[] games = processedLine.Split(';');

                bool currentGamePossible = true;

                foreach (var game in games)
                {
                    var currentGameCounts = ReadGame(game.Trim());

                    if (currentGameCounts.NumRed > maxRedCubes 
                        || currentGameCounts.NumBlue > maxBlueCubes 
                        || currentGameCounts.NumGreen > maxGreenCubes)
                    {
                        currentGamePossible = false;
                        break;
                    }
                }

                if (currentGamePossible)
                    res += currentGame;

                currentGame++;
                line = sr.ReadLine();
            }

            Console.WriteLine("Result: " + res);
        }

		public void SolvePart2(string filePath)
		{
			StreamReader sr = new StreamReader(filePath);

			int res = 0;

			string line = sr.ReadLine();

			while (line != null)
			{
				string processedLine = line.Substring(line.IndexOf(':') + 1).Trim();
				string[] games = processedLine.Split(';');

				int maxRedCubes = 0;
				int maxGreenCubes = 0;
				int maxBlueCubes = 0;

				foreach (var game in games)
				{


					var currentGameCounts = ReadGame(game.Trim());

                    maxRedCubes = Math.Max(maxRedCubes, currentGameCounts.NumRed);
                    maxBlueCubes = Math.Max(maxBlueCubes, currentGameCounts.NumBlue);
                    maxGreenCubes = Math.Max(maxGreenCubes, currentGameCounts.NumGreen);
				}

                var power = maxRedCubes * maxBlueCubes * maxGreenCubes;

                res += power;

				line = sr.ReadLine();
			}

			Console.WriteLine("Result: " + res);
		}


		private Game ReadGame(string game)
        {
            Game res = new Game();

            string[] parts = game.Split(' ');

            Stack<string> partStack = new Stack<string>();

            foreach (var item in parts)
            {
                partStack.Push(item.Trim(','));
            }

            while (partStack.Count > 0)
            {
                var color = partStack.Pop();
                var number = int.Parse(partStack.Pop());

                switch (color) {
                    case "red":
                        res.NumRed = number;
                        break;

                    case "green":
                        res.NumGreen = number;
                        break;

                    case "blue":
                        res.NumBlue = number;
                        break;
                }
            }


            return res;
        }
    }
}
