#pragma warning disable CS8600, CS8602, CS8604

string S = Console.ReadLine();
int R = 0, digit = 1;
int bit = 'A' - 10;
for (int i = S.Length - 1; i >= 0; i--, digit *= 16)
{
	if ('0' <= S[i] && S[i] <= '9') R += (S[i] - '0') * digit;
	else R += (S[i] - bit) * digit;
}
Console.WriteLine(R);