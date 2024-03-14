// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
int[] tab = { 1, 2, 3, 4, 5 };
Console.WriteLine(GetAvg(tab));
Console.WriteLine(GetMax(tab));

return;

//xd
//xdddd222

static double GetAvg(int[] tab)
{
    int sumo = 0;
    for (int i = 0; i < tab.Length; i++)
    {
        sumo += tab[i];
    }

    return sumo / tab.Length;
}

static int GetMax(int[] tab)
{
    int max = tab[0];
    for (int i = 1; i < tab.Length; i++)
    {
        if (tab[i] > max) max = tab[i];
    }
    return max;
}