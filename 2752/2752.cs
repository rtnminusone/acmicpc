#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static PriorityQueue<int, int> PQ = new PriorityQueue<int, int>();

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < 3; i++)
		{
			PQ.Enqueue(int.Parse(S[i]), int.Parse(S[i]));
		}

		for (int i = 0; i < 3; i++)
		{
			Console.Write(PQ.Dequeue() + " ");
		}
	}
}