using System;
using System.Collections.Generic;

class Mouse
{
    public int Id { get; set; }
    public List<string> Defeitos { get; set; }

    public Mouse(int id)
    {
        Id = id;
        Defeitos = new List<string>();
    }
}

class Program
{
    static List<Mouse> mouses = new List<Mouse>();

    static void Main(string[] args)
    {
        MostrarMensagemDeBoasVindas();

        while (true)
        {
            Console.WriteLine("\nDigite o número de identificação do mouse (ou 0 para encerrar):");
            int numeroIdentificacao;
            if (!int.TryParse(Console.ReadLine(), out numeroIdentificacao))
            {
                Console.WriteLine("Número de identificação inválido. Por favor, insira um número inteiro válido.");
                continue;
            }

            if (numeroIdentificacao == 0)
                break;

            if (MouseCadastrado(numeroIdentificacao))
            {
                Console.WriteLine("O mouse com este identificador já está cadastrado.");
                continue;
            }

            Mouse mouse = new Mouse(numeroIdentificacao);

            MostrarOpcoesDefeitos();

            int tipoDefeito;
            if (!int.TryParse(Console.ReadLine(), out tipoDefeito) || tipoDefeito < 1 || tipoDefeito > 4)
            {
                Console.WriteLine("Opção inválida. Por favor, escolha um tipo de defeito válido.");
                continue;
            }

            switch (tipoDefeito)
            {
                case 1:
                    mouse.Defeitos.Add("Necessita da esfera");
                    break;
                case 2:
                    mouse.Defeitos.Add("Necessita de limpeza");
                    break;
                case 3:
                    mouse.Defeitos.Add("Necessita troca do cabo ou conector");
                    break;
                case 4:
                    mouse.Defeitos.Add("Quebrado ou inutilizado");
                    break;
            }

            mouses.Add(mouse);
            Console.WriteLine("Mouse cadastrado com sucesso!");
        }

        MostrarRelatorio();
        MostrarResumo();
    }

    static void MostrarMensagemDeBoasVindas()
    {
        Console.WriteLine("Bem-vindo ao sistema de cadastro de mouses!");
        Console.WriteLine("Por favor, insira as informações dos mouses abaixo.");
    }

    static void MostrarOpcoesDefeitos()
    {
        Console.WriteLine("\nDigite o tipo de defeito:");
        Console.WriteLine("1- Necessita da esfera");
        Console.WriteLine("2- Necessita de limpeza");
        Console.WriteLine("3- Necessita troca do cabo ou conector");
        Console.WriteLine("4- Quebrado ou inutilizado");
    }

    static bool MouseCadastrado(int id)
    {
        foreach (var mouse in mouses)
        {
            if (mouse.Id == id)
                return true;
        }
        return false;
    }

    static void MostrarRelatorio()
    {
        Console.WriteLine("\nRelatório:");
        // Gerar relatório conforme requisitos anteriores
    }

    static void MostrarResumo()
    {
        Console.WriteLine("\nRelatório - Resumo");
        Console.WriteLine($"Quantidade de mouses cadastrados: {mouses.Count}");
        Console.WriteLine($"% de mouses sem defeito: {CalcularPercentual("Nenhum")}%");
        Console.WriteLine($"% de mouses com apenas um defeito: {CalcularPercentualComUmDefeito()}%");
    }

    static double CalcularPercentual(string tipoDefeito)
    {
        int count = 0;
        foreach (var mouse in mouses)
        {
            if (mouse.Defeitos.Count == 0 && tipoDefeito == "Nenhum")
                count++;
            foreach (var defeito in mouse.Defeitos)
            {
                if (defeito == tipoDefeito)
                {
                    count++;
                    break;
                }
            }
        }
        return (double)count / mouses.Count * 100;
    }

    static double CalcularPercentualComUmDefeito()
    {
        int count = 0;
        foreach (var mouse in mouses)
        {
            if (mouse.Defeitos.Count == 1)
                count++;
        }
        return (double)count / mouses.Count * 100;
    }
}
