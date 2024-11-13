#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Deque
{
	int[] N;
	int MAX;
	int front;
	int back;

	public Deque()
	{
		this.MAX = 2000000;
		this.N = new int[MAX];
		this.front = 0;
		this.back = 0;
	}

	public void IF(int x)
	{
		N[AdjFront(--this.front)] = x;
	}

	public void IB(int x)
	{
		N[this.back] = x;
		AdjBack(++this.back);
	}

	public int PF()
	{
		if (Size() == 0) return -1;
		int ret = N[this.front];
		AdjFront(++this.front);
		return ret;
	}

	public int PB()
	{
		if (Size() == 0) return -1;
		return N[AdjBack(--this.back)];
	}

	public int Empty()
	{
		if (this.back - this.front == 0) return 1;
		return 0;
	}

	public int Size()
	{
		if (this.front > this.back) return this.back - this.front + MAX;
		return this.back - this.front;
	}

	public int Top()
	{
		if (Size() != 0)
		{
			if (this.back > 0) return N[(this.back - 1) % MAX];
			return N[MAX - 1];
		}
		return -1;
	}

	public int Bottom()
	{
		if (Size() != 0) return N[this.front % MAX];
		return -1;
	}

	public int AdjFront(int front)
	{
		if (front < 0) this.front = MAX - 1;
		else if (front >= MAX) this.front = 0;
		else this.front = front;
		return this.front;
	}

	public int AdjBack(int back)
	{
		if (back < 0) this.back = MAX - 1;
		else if (back >= MAX) this.back = 0;
		else this.back = back;
		return this.back;
	}
}

class Program
{
	public static void Main(string[] args)
	{
		Deque deq = new Deque();
		int N = int.Parse(Console.ReadLine());
		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split(' ');

			switch (S[0])
			{
				case "1":
					deq.IF(int.Parse(S[1]));
					break;
				case "2":
					deq.IB(int.Parse(S[1]));
					break;
				case "3":
					sb.AppendLine(deq.PF() + "");
					break;
				case "4":
					sb.AppendLine(deq.PB() + "");
					break;
				case "5":
					sb.AppendLine(deq.Size() + "");
					break;
				case "6":
					sb.AppendLine(deq.Empty() + "");
					break;
				case "7":
					sb.AppendLine(deq.Bottom() + "");
					break;
				case "8":
					sb.AppendLine(deq.Top() + "");
					break;
			}
		}
		Console.WriteLine(sb);
	}
}