using System;

// ## Enunciado 2

// 2. O algoritmo de Rabin-Karp utiliza uma função hash para resolver o problema de busca de padrões em string. O algoritmo está dado abaixo.
 
// ```javascript
// private int search(String pat, String txt) {
//    int M = pat.length();
//    int N = txt.length();
//    long patHash = hash(pat, M);

//    for (int i = 0; i <= N - M; i++) {
//       long txtHash = hash(txt.subtring(i, i+M), M);
//       if (patHash == txtHash)
//          return i; // ocorrência? colisão?
//    }
//    return N; // nenhuma ocorrência
// }
// ```

// O hash pode ser calculado utilizando o algoritmo de Horner.
// Algoritmo de Horner para calcular o hash de uma string s[0..M-1]:

// ```javascript
// //
// //Notação: o padrão tem M caracteres, o texto tem N caracteres, o alfabeto tem R caracteres  (0 … R−1) 
// //              Q é o módulo para o cálculo do Hash.
// //              Qual o valor de Q?  Escolha Q igual a um primo grande para minimizar a chance de colisões.
// //                       Por exemplo: o maior primo que possa ser representado com um int

// private long hash(String s, int M) {
//    long h = 0;
//    for (int j = 0; j < M; j++)
//       h = (h * R + s.charAt(j)) % Q;
//    return h;
// }
// ```

// TODO: Rodar com dotnet run --project pattern.csproj -p:StartupObject=RabinKarp
public class RabinKarp
{
    private const int R = 256; // Alfabeto de 256 caracteres
    private const long Q = 101; // Um primo grande para minimizar colisões

    public static void Main()
    {
        int position = Search("ADF", "ABCDCBDCBDACBDABDCBADF");
        if (position != -1)
        {
            Console.WriteLine($"S2 found in S1 at position: {position}");
        }
        else
        {
            Console.WriteLine("S2 not found in S1.");
        }
    }

    public static int Search(String pat, String txt)
    {
        int M = pat.Length;
        int N = txt.Length;
        long patHash = Hash(pat, M);

        for (int i = 0; i <= N - M; i++)
        {
            long txtHash = Hash(txt.Substring(i, M), M);
            if (patHash == txtHash)
                return i; // ocorrência? colisão?
        }
        return -1; // nenhuma ocorrência
    }

    private static long Hash(String s, int M)
    {
        long h = 0;
        for (int j = 0; j < M; j++)
            h = (h * R + s[j]) % Q;
        return h;
    }
}

// 3. Implemente o algoritmo acima, para resolver o mesmo problema anterior.

//    3.1. teste-o para strings grandes (>500.000 caracteres). Conte o número de iterações e de instruções.
   
//    3.2. qual a complexidade, no pior caso?