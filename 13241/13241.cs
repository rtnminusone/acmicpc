#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;

string[] S = Console.ReadLine().Split(' ');
long A = long.Parse(S[0]);
long B = long.Parse(S[1]);
long SUM = A * B;
long result;

if (A < B)
{
	long temp = A;
	A = B;
	B = temp;
}

while (true)
{
	result = A % B;
	if (result == 0) break;

	A = B;
	B = result;
}

Console.WriteLine(SUM / B);