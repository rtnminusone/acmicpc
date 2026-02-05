#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public static int N;
	public static int MAX = 10000;

	public class Deque
	{
		public int front;
		public int back;
		public int size;

		public int[] data;

		public Deque()
		{
			this.front = 0;
			this.back = MAX - 1;
			this.size = 0;
			this.data = new int[MAX];
		}

		public void PushFront(int data)
		{
			if (this.size == 0)
			{
				this.front = 1;
				this.back = 0;
			}
			if (--this.front < 0) this.front = MAX - 1;
			this.data[this.front] = data;
			this.size++;
		}

		public void PushBack(int data)
		{
			if (this.size == 0)
			{
				this.front = 0;
				this.back = -1;
			}
			if (++this.back >= MAX) this.back = 0;
			this.data[this.back] = data;
			this.size++;
		}

		public int PopFront()
		{
			int result = -1;

			if (this.size != 0)
			{
				result = this.data[this.front++];
				if (this.front >= MAX) this.front = 0;
				this.size--;
			}

			return result;
		}

		public int PopBack()
		{
			int result = -1;

			if (this.size != 0)
			{
				result = this.data[this.back--];
				if (this.back < 0) this.back = MAX - 1;
				this.size--;
			}

			return result;
		}

		public int Size()
		{
			return this.size;
		}

		public int Empty()
		{
			if (this.size == 0) return 1;
			return 0;
		}

		public int Front()
		{
			return this.size == 0 ? -1 : data[this.front];
		}

		public int Back()
		{
			return this.size == 0 ? -1 : data[this.back];
		}
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		Deque D = new Deque();
		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			if (S.Length == 1)
			{
				if (S[0].Equals("pop_front"))
				{
					sb.AppendLine(D.PopFront().ToString());
				}
				else if (S[0].Equals("pop_back"))
				{
					sb.AppendLine(D.PopBack().ToString());
				}
				else if (S[0].Equals("size"))
				{
					sb.AppendLine(D.Size().ToString());
				}
				else if (S[0].Equals("empty"))
				{
					sb.AppendLine(D.Empty().ToString());
				}
				else if (S[0].Equals("front"))
				{
					sb.AppendLine(D.Front().ToString());
				}
				else
				{
					sb.AppendLine(D.Back().ToString());
				}
			}
			else
			{
				int value = int.Parse(S[1]);
				if (S[0].Equals("push_front"))
				{
					D.PushFront(value);
				}
				else
				{
					D.PushBack(value);
				}
			}
		}

		Console.WriteLine(sb.ToString());
	}
}