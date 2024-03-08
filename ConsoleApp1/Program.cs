// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
int[] tab = { 1, 2, 3, 4, 5 };
Console.Write(GetAvg(tab));

return;

//xd
//xdddd222

static double GetAvg(int[] tab)
{
    int sum = 0;
    for (int i = 0; i < tab.Length; i++)
    {
        sum += tab[i];
    }

    return sum / tab.Length;
}