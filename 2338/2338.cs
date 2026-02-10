#pragma warning disable CS8604

using System.Numerics;

BigInteger N = BigInteger.Parse(Console.ReadLine());
BigInteger M = BigInteger.Parse(Console.ReadLine());
Console.WriteLine((N + M) + "\n" + (N - M) + "\n" + (N * M));