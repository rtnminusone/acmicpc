#pragma warning disable CS8600, CS8602, CS8604

string[] s = Console.ReadLine().Split();
int i = int.Parse(s[0]);
int j = int.Parse(s[1]);
int[] r = new int[i];
int m, n, tmp;

for (int k = 0; k < i; k++) {
	r[k] = k + 1;
}

for (int k = 0; k < j; k++) {
	s = Console.ReadLine().Split();
	m = int.Parse(s[0]);
	n = int.Parse(s[1]);
	for (int l = 0; l < (int.Parse(s[1]) - int.Parse(s[0]) + 1) / 2; l++) {
		tmp = r[m - 1];
		r[m - 1] = r[n - 1];
		r[n - 1] = tmp;
		m++;
		n--;
	}
}

for (int k = 0; k < i; k++) {
	Console.Write(r[k] + " ");
}