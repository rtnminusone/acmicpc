#pragma warning disable CS8600, CS8602, CS8604

char[] s = Console.ReadLine().ToCharArray();
int r = 0;

foreach (char c in s) {
	if ('A' <= c && c <= 'C') r += 3;
	else if ('D' <= c && c <= 'F') r += 4;
	else if ('G' <= c && c <= 'I') r += 5;
	else if ('J' <= c && c <= 'L') r += 6;
	else if ('M' <= c && c <= 'O') r += 7;
	else if ('P' <= c && c <= 'S') r += 8;
	else if ('T' <= c && c <= 'V') r += 9;
	else r += 10;
}

Console.WriteLine(r);