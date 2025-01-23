#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

StringBuilder sb = new StringBuilder();
int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++)
{
	LinkedList<char> Q = new LinkedList<char>();
	string S = Console.ReadLine();
	for (int j = 0; j < S.Length; j++)
	{
		if (S[j] == 'R' && j > 0 && Q.Count > 0)
		{
			if (Q.Last.Value == 'R')
			{
				Q.RemoveLast();
				continue;
			}
			else Q.AddLast(S[j]);
		}
		else Q.AddLast(S[j]);
	}

	int M = int.Parse(Console.ReadLine());
	StringBuilder temp = new StringBuilder(Console.ReadLine());
	temp.Remove(temp.Length - 1, 1);
	temp.Remove(0, 1);
	string[] T = temp.ToString().Split(',');
	LinkedList<string> D = new LinkedList<string>();

	for (int j = 0; j < M; j++)
	{
		D.AddLast(T[j]);
	} 

	bool R = false;
	bool E = false;
	while (Q.Count != 0)
	{
		var P = Q.First.Value;
		Q.RemoveFirst();
		if (P == 'R' && D.Count != 0) R = !R;
		else if (P == 'D')
		{
			if (D.Count == 0)
			{
				E = true;
				sb.AppendLine("error");
				break;
			}
			else if (R) D.RemoveLast();
			else D.RemoveFirst();
		}
	}

	if (!E)
	{
		sb.Append("[");
		while (D.Count != 0)
		{
			string P;
			if (R)
			{
				P = D.Last.Value;
				D.RemoveLast();
			}
			else
			{
				P = D.First.Value;
				D.RemoveFirst();
			}
			sb.Append(P + ",");
		}
		if (sb[sb.Length - 1] == ',') sb.Remove(sb.Length - 1, 1);
		sb.AppendLine("]");
	}
}

Console.WriteLine(sb);