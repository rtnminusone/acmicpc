#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;

string[] S = Console.ReadLine().Split(' ');
Console.WriteLine(Math.Abs(long.Parse(S[0]) - long.Parse(S[1])));