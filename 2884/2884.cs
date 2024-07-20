#pragma warning disable CS8600, CS8602, CS8604

string[] s = Console.ReadLine().Split();
int i = int.Parse(s[0]);
int j = int.Parse(s[1]);

if (j < 45) {
	if (i == 0) i = 24;
	i--;
	j += 60;
}

Console.WriteLine(i + " " + (j-45));