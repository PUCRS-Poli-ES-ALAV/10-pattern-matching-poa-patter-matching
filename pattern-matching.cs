using System;

// ## O problema
// Dadas duas strings, s1 e s2, verificar a posição da primeira ocorrência de se s2 em s1, se existir.
// Assim, se s1 = "ABCDCBDCBDACBDABDCBADF" e s1 = "ADF" o retorno seria 19.

// ## Enunciado 1
// 1. Faça um algortimo que resolva o problema acima.
//    1. teste-o para strings de diversos tamanhos, até strings grandes (ambas as strings >500.000 caracteres). Conte o número de iterações e de instruções.
//    1. qual a complexidade, no pior caso?

// TODO: Rodar com dotnet run --project pattern.csproj -p:StartupObject=PatternMatching
public class PatternMatching
{
    public static void Main()
    {
        int position = IsS2InS1("ABCDCBDCBDACBDABDCBADF", "ADF");
        if (position != -1)
        {
            Console.WriteLine($"S2 found in S1 at position: {position}");
        }
        else
        {
            Console.WriteLine("S2 not found in S1.");
        }
    }

    public static int IsS2InS1(String S1, String S2)
    {
        int position = -1;

        for (int i = 0; i < S1.Length; i++)
        {
            if (S1[i] == S2[0]) {
                int j = 1;
                while (j < S2.Length && S1[i + j] == S2[j])
                {
                    j++;
                }
                if (j == S2.Length)
                {
                    position = i;
                    break;
                }
            }
        }
        return position;
    }
}