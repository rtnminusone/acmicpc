#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<(int, int), (int, int)> PQ1 = new PriorityQueue<(int, int), (int, int)>();
PriorityQueue<(int, int), (int, int)> PQ2 = new PriorityQueue<(int, int), (int, int)>();

int N = int.Parse(Console.ReadLine());
for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split();
	int a = int.Parse(S[0]);
	int b = int.Parse(S[1]);
	PQ1.Enqueue((a, b), (a, b));
}
for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split();
	int a = int.Parse(S[0]);
	int b = int.Parse(S[1]);
	PQ2.Enqueue((a, b), (a, b));
}

var (p1, q1) = PQ1.Dequeue();
var (p2, q2) = PQ2.Dequeue();

Console.WriteLine((p2 - p1) + " " + (q2 - q1));