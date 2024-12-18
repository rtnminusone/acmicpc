#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

StringBuilder sb = new StringBuilder();
string[] S = new string[2];

S[0] = Console.ReadLine();
S[1] = Console.ReadLine();
int K = int.Parse(Console.ReadLine());

Console.WriteLine(int.Parse(S[0]) + int.Parse(S[1]) - K);
sb.Append(S[0] + S[1]);
Console.WriteLine(int.Parse(sb.ToString()) - K);