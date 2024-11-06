#pragma warning disable CS8600, CS8602, CS8604

using System;

Stack<int> stack1 = new Stack<int>();
Stack<int> stack2 = new Stack<int>();
int N = int.Parse(Console.ReadLine());
string[] S = Console.ReadLine().Split(' ');
int K = 1;

for (int i = N - 1; i >= 0; i--)
{
	stack1.Push(int.Parse(S[i]));
}

while (stack1.Count() != 0 || (stack2.Count() != 0 && stack2.Peek() == K))
{
	if (stack1.Count() != 0 && stack1.Peek() == K)
	{
		stack1.Pop();
		K++;
	}
	else if (stack2.Count() != 0 && stack2.Peek() == K)
	{
		stack2.Pop();
		K++;
	}
	else stack2.Push(stack1.Pop());
}

if (stack1.Count() == 0 && stack2.Count() == 0) Console.WriteLine("Nice");
else Console.WriteLine("Sad");