#pragma warning disable CS8600, CS8602, CS8604

char[] s = Console.ReadLine().ToCharArray();
int l = s.Length - 1;
int r = 1;

for (int i = 0; i < s.Length / 2; i++) {
	if (s[i] != s[l]) {
		r = 0;
		break;
	}
	l--;
}

Console.WriteLine(r);