#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Queue
{
	int S;
	int[] N;
	int top;
	int bottom;

	public Queue()
	{
		this.S = 2000000;
		this.N = new int[S];
		this.top = -1;
		this.bottom = -1; 
	}

	public void Push(int x)
	{
		this.N[++this.top % S] = x;
	}

	public int Pop()
	{
		if (this.Empty() == 1) return -1;
		return this.N[++this.bottom % S];
	}

	public int Size()
	{
		return this.top - this.bottom;
	}

	public int Empty()
	{
		if (this.Size() == 0) return 1;
		return 0;
	}

	public int Front()
	{
		if (this.Empty() == 1) return -1;
		return this.N[(this.bottom + 1) % S];
	}

	public int Back()
	{
		if (this.Empty() == 1) return -1;
		return this.N[this.top % S];
	}
}

class Program
{
	public static void Main(string[] args)
	{
		Queue que = new Queue();
		StringBuilder sb = new StringBuilder();

		int N = int.Parse(Console.ReadLine());

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split(' ');

			if (S.Length > 1) que.Push(int.Parse(S[1]));
			else
			{
				switch (S[0])
				{
					case "pop"		:
						sb.AppendLine(que.Pop() + "");
						break;
					case "size"		:
						sb.AppendLine(que.Size() + "");
						break;
					case "empty"	:
						sb.AppendLine(que.Empty() + "");
						break;
					case "front"	:
						sb.AppendLine(que.Front() + "");
						break;
					case "back"		:
						sb.AppendLine(que.Back() + "");
						break;
				}
			}
		}
		Console.WriteLine(sb);
	}
}