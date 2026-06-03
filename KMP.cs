using System;

// ## Enunciado 3
// 4. O algoritmo de Knuth-Morris-Pratt utiliza um vetor auxiliar (LPS - Longest Proper Prefix) para resolver o problema de busca de padrões em string. O algoritmo está dado abaixo.

// ```javascript
// // KMP pattern searching algorithm 

// class KMP_String_Matching { 
// 	void KMPSearch(String pat, String txt) 
// 	{ 
// 		int M = pat.length(); 
// 		int N = txt.length(); 

// 		// cria lps[] que vai guardar o maior 
// 		// valor prefixo sufixo para o padrão 
// 		int lps[] = new int[M]; 
// 		int j = 0; // index for pat[] 

// 		// Calcula lps[] 
// 		computeLPSArray(pat, M, lps); 

// 		int i = 0; // index for txt[] 
// 		while (i < N) { 
// 			if (pat.charAt(j) == txt.charAt(i)) { 
// 				j++; 
// 				i++; 
// 			} 
// 			if (j == M) { 
// 				System.out.println("Found pattern "
// 								+ "at index " + (i - j)); 
// 				j = lps[j - 1]; 
// 			} 

// 			// mismatch após j matches 
// 			else if (i < N && pat.charAt(j) != txt.charAt(i)) { 
// 				// Não faz match dos caracteres lps[0..lps[j-1]], 
// 				// não é necesssário, eles combinarão 
// 				if (j != 0) 
// 					j = lps[j - 1]; 
// 				else
// 					i = i + 1; 
// 			} 
// 		} 
// 	} 

// 	void computeLPSArray(String pat, int M, int lps[]) 
// 	{ 
// 		// tamanho do maior prefixo sufixo anterior 
// 		int len = 0; 
// 		int i = 1; 
// 		lps[0] = 0; // lps[0] is always 0 

// 		// loop calcula lps[i] for i = 1 to M-1 
// 		while (i < M) { 
// 			if (pat.charAt(i) == pat.charAt(len)) { 
// 				len++; 
// 				lps[i] = len; 
// 				i++; 
// 			} 
// 			else // (pat[i] != pat[len]) 
// 			{ 
// 				if (len != 0) { 
// 					len = lps[len - 1]; 
// 				} 
// 				else // if (len == 0) 
// 				{ 
// 					lps[i] = len; 
// 					i++; 
// 				} 
// 			} 
// 		} 
// 	} 
// ```

// TODO: Rodar com dotnet run --project pattern.csproj -p:StartupObject=KMP
public class KMP
{
    public static void Main()
    {
        int position = KMPSearch("ADF", "ABCDCBDCBDACBDABDCBADF");
        if (position != -1)
        {
            Console.WriteLine($"S2 found in S1 at position: {position}");
        }
        else
        {
            Console.WriteLine("S2 not found in S1.");
        }
    }

    public static int KMPSearch(String pat, String txt)
    {
        int M = pat.Length;
        int N = txt.Length;

        int[] lps = new int[M];
        ComputeLPSArray(pat, M, lps);

        int i = 0; // index for txt[]
        int j = 0; // index for pat[]
        while (i < N)
        {
            if (pat[j] == txt[i])
            {
                j++;
                i++;
            }
            if (j == M)
            {
                return i - j; // Found pattern at index (i - j)
            }
            else if (i < N && pat[j] != txt[i])
            {
                if (j != 0)
                    j = lps[j - 1];
                else
                    i = i + 1;
            }
        }
        return -1; // No occurrence found
    }

    private static void ComputeLPSArray(String pat, int M, int[] lps)
    {
        int len = 0; // length of the previous longest prefix suffix
        lps[0] = 0; // lps[0] is always 0

        int i = 1;
        while (i < M)
        {
            if (pat[i] == pat[len])
            {
                len++;
                lps[i] = len;
                i++;
            }
            else
            {
                if (len != 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i] = len;
                    i++;
                }
            }
        }
    }
}

// 5. Implemente o algoritmo acima, para resolver o mesmo problema anterior.

//    5.1. Teste-o para strings grandes (>500.000 caracteres); 
   
//    5.2. Conte o número de iterações e de instruções.
   
// Qual a complexidade, no pior caso?