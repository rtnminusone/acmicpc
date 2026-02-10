#pragma warning disable CS8600, CS8602, CS8604

using System.Numerics;

string[] S = Console.ReadLine().Split();
BigInteger N = BigInteger.Parse(S[0]);
BigInteger M = BigInteger.Parse(S[1]);
Console.WriteLine((N / M) + "\n" + (N % M));