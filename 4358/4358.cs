#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

Dictionary<string, double> D = new Dictionary<string, double>();
StringBuilder sb = new StringBuilder();
string S = "";
int N = 0;

while ((S = Console.ReadLine()) != null)
{
	N++;
	if (D.ContainsKey(S)) D[S]++;
	else D[S] = 1;
}

List<string> K = new List<string>(D.Keys);
foreach (var k in K)
{
	D[k] = Math.Round(D[k] / N * 100, 4);
}

foreach (var d in D.OrderBy(d => d.Key))
{
	sb.AppendLine(d.Key + " " + String.Format("{0:F4}", d.Value));
}

Console.WriteLine(sb);