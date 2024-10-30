#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

public class Stack
{
	int[] S;
	int top;

	public Stack()
	{
		S = new int[1000000];
		top = 0;
	}

	public bool push(int x)
	{
		if (!isFull())
		{
			S[top++] = x;
			return true;
		}
		return false;
	}

	public int pop()
	{
		if (isEmpty() != 1) return S[--top];
		return -1;
	}

	public bool isFull()
	{
		return S.Length <= top;
	}

	public int isEmpty()
	{
		if (top <= 0) return 1;
		return 0;
	}

	public int size()
	{
		return top;
	}

	public int Top()
	{
		if (isEmpty() != 1) return S[top - 1];
		return -1;
	}
}

class Program
{
	public static void Main(string[] args)
	{
		Stack stack = new Stack();
		int N = int.Parse(Console.ReadLine());
		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split(' ');

			if (S.Length != 1)
			{
				stack.push(int.Parse(S[1]));
			}
			else
			{
				switch (S[0])
				{
					case "2"	:
						sb.AppendLine(stack.pop() + "");
						break;
					case "3"	:
						sb.AppendLine(stack.size() + "");
						break;
					case "4"	:
						sb.AppendLine(stack.isEmpty() + "");
						break;
					case "5"	:
						sb.AppendLine(stack.Top() + "");
						break;
					default		: break;
				}
			}
		}
		Console.WriteLine(sb);
	}
}