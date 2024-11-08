#pragma warning disable CS8600, CS8602, CS8604

using System;

Queue<int> Q = new Queue<int>();
int N = int.Parse(Console.ReadLine());

for (int i = 1; i <= N; i++)
{
	Q.Enqueue(i);
}

while (Q.Count != 1)
{
	Q.Dequeue();
	Q.Enqueue(Q.Dequeue());
}

Console.WriteLine(Q.Dequeue());