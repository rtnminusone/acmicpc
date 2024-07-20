#pragma warning disable CS8600, CS8602, CS8604

int i = int.Parse(Console.ReadLine());

for (int j = int.Parse(Console.ReadLine()); j != 0; j--) {
	string[] s = Console.ReadLine().Split();
	i -= int.Parse(s[0]) * int.Parse(s[0]); 
}

if (i == 0) Console.WriteLine("Yes");
else Console.WriteLine("No");