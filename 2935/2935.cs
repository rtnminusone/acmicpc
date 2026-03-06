#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Numerics;

BigInteger A = BigInteger.Parse(Console.ReadLine());
string S = Console.ReadLine();
if (S.Equals("*")) Console.WriteLine(A * BigInteger.Parse(Console.ReadLine()));
else Console.WriteLine(A + BigInteger.Parse(Console.ReadLine()));