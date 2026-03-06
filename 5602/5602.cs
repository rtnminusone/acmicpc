#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<int, (int, int)> PQ = new PriorityQueue<int, (int, int)>();

string[] S = Console.ReadLine().Split();
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);
int[] T = new int[M];
for (int i = 0; i < N; i++)
{
	S = Console.ReadLine().Split();
	for (int j = 0; j < M; j++)
	{
		if (S[j] == "1") T[j]++;
	}
}
for (int i = 0; i < M; i++)
{
	PQ.Enqueue(i + 1, (-T[i], i));
}
for (int i = 0; i < M; i++)
{
	Console.Write(PQ.Dequeue() + " ");
}