#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public class Heap
	{
		public int size;
		public int[] data;

		public Heap()
		{
			this.size = 0;
			this.data = new int[3];
		}

		public void Push(int data)
		{
			this.data[this.size] = data;

			int parent = (this.size - 1) / 2;
			int child = this.size++;

			while (child > 0 && this.data[parent] > this.data[child])
			{
				this.Swap(parent, child);

				child = parent;
				parent = (child - 1) / 2;
			}
		}

		public int Pop()
		{
			int result = this.data[0];

			this.data[0] = this.data[this.size-- - 1];
			int parent = 0;
			int child = parent * 2 + 1;
			child += child + 1 < this.size && this.data[child] > this.data[child + 1] ? 1 : 0;

			while (child < this.size && this.data[parent] > this.data[child])
			{
				this.Swap(parent, child);
				parent = child;
				child = parent * 2 + 1;
				child += child + 1 < this.size && this.data[child] > this.data[child + 1] ? 1 : 0;
			}

			return result;
		}

		public void Swap(int a, int b)
		{
			int tmp = this.data[a];
			this.data[a] = this.data[b];
			this.data[b] = tmp;
		}
	}

	public static Heap heap = new Heap();

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < 3; i++)
		{
			heap.Push(int.Parse(S[i]));
		}
		int[] R = new int[3];
		for (int i = 0; i < 3; i++)
		{
			R[i] = heap.Pop();
		}
		S[0] = Console.ReadLine();
		for (int i = 0; i < 3; i++)
		{
			Console.Write(R[S[0][i] - 'A'] + " ");
		}
	}
}