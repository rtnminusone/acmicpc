#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

int result = 0;

for (int i = 3; i >= 1; i--)
{
	string S = Console.ReadLine();
	int.TryParse(S, out result);
	if (result != 0)
	{
		result += i;
		break;
	}
}

if (result % 3 == 0 && result % 5 == 0) Console.WriteLine("FizzBuzz");
else if (result % 3 == 0) Console.WriteLine("Fizz");
else if (result % 5 == 0) Console.WriteLine("Buzz");
else Console.WriteLine(result);