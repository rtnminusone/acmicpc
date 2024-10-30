#pragma warning disable CS8600, CS8602, CS8604

using System;

int N = int.Parse(Console.ReadLine());
long R = 0;
Stack<int> stack = new Stack<int>();

for (int i = 0; i < N; i++)
{
	int K = int.Parse(Console.ReadLine());
	if (K == 0)
	{
		R -= stack.Pop();
	}
	else
	{
		stack.Push(K);
		R += K;
	}
}

Console.WriteLine(R);