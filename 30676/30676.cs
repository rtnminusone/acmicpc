#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		if (620 <= N && N <= 780) Console.WriteLine("Red");
		else if (590 <= N && N < 620) Console.WriteLine("Orange");
		else if (570 <= N && N < 590) Console.WriteLine("Yellow");
		else if (495 <= N && N < 570) Console.WriteLine("Green");
		else if (450 <= N && N < 495) Console.WriteLine("Blue");
		else if (425 <= N && N < 450) Console.WriteLine("Indigo");
		else Console.WriteLine("Violet");
	}
}