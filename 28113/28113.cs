#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

string[] S = Console.ReadLine().Split();
if (int.Parse(S[1]) == int.Parse(S[2])) Console.WriteLine("Anything");
else if (int.Parse(S[1]) < int.Parse(S[2])) Console.WriteLine("Bus");
else Console.WriteLine("Subway");