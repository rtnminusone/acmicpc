#pragma warning disable CS8600, CS8602, CS8604

string[] s = Console.ReadLine().Split();
int i = int.Parse(s[0]);
int j = int.Parse(s[1]);
int[] r = new int[i];
int tmp;

for (int k = 0; k < i; k++) {
	r[k] = k + 1;
}

for (int k = 0; k < j; k++) {
	s = Console.ReadLine().Split();
	tmp = r[int.Parse(s[0]) - 1];
	r[int.Parse(s[0]) - 1] = r[int.Parse(s[1]) - 1];
	r[int.Parse(s[1]) - 1] = tmp;
}

for (int k = 0; k < i; k++) {
	Console.Write(r[k] + " ");
}