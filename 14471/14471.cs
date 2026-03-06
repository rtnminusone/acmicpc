#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<int, int> PQ = new PriorityQueue<int, int>();

string[] S = Console.ReadLine().Split();
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);
int R = 0;
for (int i = 0; i < M; i++)
{
	S = Console.ReadLine().Split();
	int n = int.Parse(S[0]);
	if (n >= N) R++;
	else PQ.Enqueue(n, -n);
}
int R2 = 0;
while (R < M - 1)
{
	R2 += N - PQ.Dequeue();
	R++;
}

Console.WriteLine(R2);