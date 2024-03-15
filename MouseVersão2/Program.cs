using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Dicionário para armazenar os mouses com defeitos
        Dictionary<string, List<int>> defeitos = new Dictionary<string, List<int>>()
        {
            {"Necessita da esfera", new List<int>()},
            {"Necessita de limpeza", new List<int>()},
            {"Necessita troca do cabo ou conector", new List<int>()},
            {"Quebrado ou inutilizado", new List<int>()}
        };

        // Lista para armazenar os mouses sem defeitos
        List<int> mousesSemDefeito = new List<int>();

        while (true)
        {
            Console.WriteLine("Digite o número de identificação do mouse (ou 0 para encerrar):");
            int numeroIdentificacao = Convert.ToInt32(Console.ReadLine());

            // Verifica se o programa deve ser encerrado
            if (numeroIdentificacao == 0)
                break;

            Console.WriteLine("Digite o tipo de defeito:");
            Console.WriteLine("1- Necessita da esfera");
            Console.WriteLine("2- Necessita de limpeza");
            Console.WriteLine("3- Necessita troca do cabo ou conector");
            Console.WriteLine("4- Quebrado ou inutilizado");

            int tipoDefeito = Convert.ToInt32(Console.ReadLine());

            // Adiciona o mouse à lista correspondente
            switch (tipoDefeito)
            {
                case 1:
                    defeitos["Necessita da esfera"].Add(numeroIdentificacao);
                    break;
                case 2:
                    defeitos["Necessita de limpeza"].Add(numeroIdentificacao);
                    break;
                case 3:
                    defeitos["Necessita troca do cabo ou conector"].Add(numeroIdentificacao);
                    break;
                case 4:
                    defeitos["Quebrado ou inutilizado"].Add(numeroIdentificacao);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha um tipo de defeito válido.");
                    break;
            }

            // Verifica se o mouse não possui defeitos
            if (!defeitos.ContainsKey(numeroIdentificacao.ToString()))
                mousesSemDefeito.Add(numeroIdentificacao);
        }

        // Imprime os mouses sem defeitos
        Console.WriteLine("---- Identificação dos mouses sem defeito ----");
        if (mousesSemDefeito.Count == 0)
            Console.WriteLine("Nenhum");
        else
        {
            foreach (int id in mousesSemDefeito)
                Console.Write(id + " ");
            Console.WriteLine();
        }
        Console.WriteLine("Total: " + mousesSemDefeito.Count);

        // Imprime os mouses com defeitos
        foreach (var defeito in defeitos)
        {
            Console.WriteLine($"---- Identificação dos mouses que {defeito.Key.ToLower()} ----");
            if (defeito.Value.Count == 0)
                Console.WriteLine("Nenhum");
            else
            {
                foreach (int id in defeito.Value)
                    Console.Write(id + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Total: " + defeito.Value.Count + " mouses");
        }
    }
}
