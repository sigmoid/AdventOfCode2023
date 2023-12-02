// See https://aka.ms/new-console-template for more information
using AdventOfCode2023.Day1;
using AdventOfCode2023.Day2;

CubeConundrum solution = new CubeConundrum();

Console.WriteLine("Input File Path to Cube Conundrum Input:");
var filepath = Console.ReadLine();
solution.SolvePart2(filepath);
