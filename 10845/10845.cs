#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

public class myQueue
{
	private int[] data;
	private int pos;
	private int rear;

	public myQueue()
	{
		this.data = new int[10000];
		this.pos = -1;
		this.rear = -1;
	}

	public bool full()
	{
		return this.pos != this.rear && this.pos % 10000 == this.rear % 10000;
	}

	public bool push(int dat)
	{
		if (full()) return false;
		this.data[++this.rear] = dat;
		return true;
	}

	public int pop()
	{
		if (empty() == 1) return -1;
		return this.data[++this.pos];
	}

	public int size()
	{
		return this.rear - this.pos;
	}

	public int empty()
	{
		if (this.pos == this.rear) return 1;
		else return 0;
	}

	public int front()
	{
		if (empty() == 1) return -1;
		return this.data[(this.pos + 1) % 10000];
	}

	public int back()
	{
		if (empty() == 1) return -1;
		return this.data[this.rear % 10000];
	}

	static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());

		StringBuilder sb = new StringBuilder();
		myQueue myqueue = new myQueue();

		for (int i = 0; i < N; i++)
		{
			String s = Console.ReadLine();

			if (s[0] == 'p')
			{
				if (s[1] == 'u')
				{
					string[] strTok = s.Split(' ');
					myqueue.push(int.Parse(strTok[1]));
				}
				else sb.AppendLine(myqueue.pop() + "");
			}
			else if (s[0] == 'f') sb.AppendLine(myqueue.front() + "");
			else if (s[0] == 'b') sb.AppendLine(myqueue.back() + "");
			else if (s[0] == 's') sb.AppendLine(myqueue.size() + "");
			else  sb.AppendLine(myqueue.empty() + "");
		}

		Console.WriteLine(sb);
	}
}