using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> situacoes = new Dictionary<string, int>()
        {
            {"Necessita da esfera", 0},
            {"Necessita de limpeza", 0},
            {"Necessita troca do cabo ou conector", 0},
            {"Quebrado ou inutilizado", 0}
        };

        int quantidadeTotal = 0;

        while (true)
        {
            Console.WriteLine("Digite o número de identificação do mouse (ou 0 para encerrar):");
            int numeroIdentificacao = Convert.ToInt32(Console.ReadLine());

            if (numeroIdentificacao == 0)
                break;

            Console.WriteLine("Digite o tipo de defeito:");
            Console.WriteLine("1- Necessita da esfera");
            Console.WriteLine("2- Necessita de limpeza");
            Console.WriteLine("3- Necessita troca do cabo ou conector");
            Console.WriteLine("4- Quebrado ou inutilizado");

            int tipoDefeito = Convert.ToInt32(Console.ReadLine());

            switch (tipoDefeito)
            {
                case 1:
                    situacoes["Necessita da esfera"]++;
                    break;
                case 2:
                    situacoes["Necessita de limpeza"]++;
                    break;
                case 3:
                    situacoes["Necessita troca do cabo ou conector"]++;
                    break;
                case 4:
                    situacoes["Quebrado ou inutilizado"]++;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha um tipo de defeito válido.");
                    break;
            }

            quantidadeTotal++;
        }

        Console.WriteLine($"Quantidade de mouses: {quantidadeTotal}");
        Console.WriteLine("Situação: Quantidade Percentual");

        foreach (KeyValuePair<string, int> situacao in situacoes)
        {
            double percentual = (double)situacao.Value / quantidadeTotal * 100;
            Console.WriteLine($"{situacao.Key}: {situacao.Value} {percentual}%");
        }
    }
}
