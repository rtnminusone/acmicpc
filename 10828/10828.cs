#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

public class myStack
{
	private int[] data;
	private int pos;

	public myStack()
	{
		this.data = new int[10000];
		this.pos = -1;
	}

	public bool push(int dat)
	{
		if (this.pos == 9999) return false;
		this.data[++this.pos] = dat;
		return true;
	}

	public int pop()
	{
		if (this.pos == -1) return -1;
		int rtn = this.data[this.pos];
		this.data[this.pos--] = -1;
		return rtn;
	}

	public int size()
	{
		return this.pos + 1;
	}

	public int empty()
	{
		if (this.pos == -1) return 1;
		else return 0;
	}

	public int top()
	{
		if (this.pos == -1) return -1;
		return this.data[this.pos];
	}

	static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());

		StringBuilder sb = new StringBuilder();
		myStack mystack = new myStack();

		for (int i = 0; i < N; i++)
		{
			String s = Console.ReadLine();

			if (s[0] == 'p')
			{
				if (s[1] == 'u')
				{
					string[] strTok = s.Split(' ');
					mystack.push(int.Parse(strTok[1]));
				}
				else sb.AppendLine(mystack.pop() + "");
			}
			else if (s[0] == 't') sb.AppendLine(mystack.top() + "");
			else if (s[0] == 's') sb.AppendLine(mystack.size() + "");
			else  sb.AppendLine(mystack.empty() + "");
		}

		Console.WriteLine(sb);
	}
}