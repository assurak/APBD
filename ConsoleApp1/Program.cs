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
<<<<<<< HEAD
<<<<<<< HEAD
    int sum = 0;
    for (int i = 0; i < tab.Length; i++)
    {
        sum += tab[i];
    }

    return sum / tab.Length;
=======
    int sumo = 0;
=======
    int sum = 0;
>>>>>>> feature-new
    for (int i = 0; i < tab.Length; i++)
    {
        sum += tab[i];
    }

<<<<<<< HEAD
    return sumo / tab.Length;
>>>>>>> feature-new
=======
    return sum / tab.Length;
>>>>>>> feature-new
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