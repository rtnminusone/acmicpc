#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;

int N = int.Parse(Console.ReadLine());
int C = 0;
int B = 0;
int curr = 666;

while (C < N)
{
	B = 0;
	int temp = curr;
	while (temp > 0)
	{
		if (temp % 10 == 6)
		{
			B++;
			if (B == 3)
			{
				C++;
				B = 0;
				break;
			}
		}
		else
		{
			B = 0;
		}
		temp /= 10;
	}
	curr++;
}

Console.WriteLine(curr - 1);