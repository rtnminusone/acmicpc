#pragma warning disable CS8600, CS8602, CS8604

using System.Text;

int i = int.Parse(Console.ReadLine());
StringBuilder sb = new StringBuilder();

for (int j = 0; j < i; j++) {
	char[] s = Console.ReadLine().ToCharArray();
	sb.Append(s[0]);
	sb.Append(s[s.Length - 1] + "\n");
}

Console.WriteLine(sb);