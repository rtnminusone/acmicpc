#pragma warning disable CS8602, CS8604

using System.Text;

StringBuilder sb = new StringBuilder();

char[,] c = new char[5, 5]
{
    {'@', ' ', ' ', ' ', '@'},
    {'@', ' ', ' ', ' ', '@'},
    {'@', '@', '@', '@', '@'},
    {'@', ' ', ' ', ' ', '@'},
    {'@', '@', '@', '@', '@'}
};

int N = int.Parse(Console.ReadLine());

for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < N; j++)
    {
        for (int k = 0; k < 5; k++)
        {
            for (int l = 0; l < N; l++)
            {
                sb.Append(c[i, k]);
            }
        }
        sb.Append('\n');
    }
}

Console.WriteLine(sb);