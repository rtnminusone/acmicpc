#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

StringBuilder sb = new StringBuilder();

while (true)
{
	string S = Console.ReadLine();
	if (S == ".") break;
	Stack<char> stack = new Stack<char>();
	bool E = true;

	for (int i = 0; i < S.Length && E; i++)
	{
		switch (S[i])
		{
			case '('	:
				stack.Push(S[i]);
				continue;
			case '['	:
				stack.Push(S[i]);
				continue;
			case ')'	:
				if (stack.Count() != 0 && stack.Pop() == '(') continue;
				E = false;
				sb.AppendLine("no");
				break;
			case ']'	:
				if (stack.Count() != 0 && stack.Pop() == '[') continue;
				E = false;
				sb.AppendLine("no");
				break;
			case '.'	:
				E = false;
				if (stack.Count() == 0) sb.AppendLine("yes");
				else sb.AppendLine("no");
				break;
			default		:
				continue;
		}
	}
}

Console.WriteLine(sb);