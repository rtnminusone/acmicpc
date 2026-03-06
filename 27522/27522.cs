#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<string, (int, int, int)> PQ = new PriorityQueue<string, (int, int, int)>();
Dictionary<string, int> D = new Dictionary<string, int>();

D["B"] = 0;
D["R"] = 0;
for (int i = 0; i < 8; i++)
{
	string[] S = Console.ReadLine().Split();
	string[] S2 = S[0].Split(":");
	PQ.Enqueue(S[1], (int.Parse(S2[0]), int.Parse(S2[1]), int.Parse(S2[2])));
}
int[] T = new int[8] { 10, 8, 6, 5, 4, 3, 2, 1 };
for (int i = 0; i < 8; i++)
{
	D[PQ.Dequeue()] += T[i];
}

Console.WriteLine(D["R"] > D["B"] ? "Red" : "Blue");