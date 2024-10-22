#pragma warning disable CS8600, CS8602, CS8604

using System;

long N = long.Parse(Console.ReadLine());

if (N == 1 || N == 2) Console.WriteLine(0);
else Console.WriteLine(N * (N - 1) * (N - 2) / 6);
Console.WriteLine(3);