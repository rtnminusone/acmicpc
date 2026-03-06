#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<string, string> PQ1 = new PriorityQueue<string, string>();
PriorityQueue<char, int> PQ2 = new PriorityQueue<char, int>();

for (int i = 0; i < 3; i++)
{
	string[] S = Console.ReadLine().Split();
	PQ1.Enqueue(S[1][^2..], S[1][^2..]);
	PQ2.Enqueue(S[2][0], -int.Parse(S[0]));
}

Console.WriteLine(PQ1.Dequeue() + PQ1.Dequeue() + PQ1.Dequeue());
Console.WriteLine(PQ2.Dequeue().ToString() + PQ2.Dequeue() + PQ2.Dequeue());