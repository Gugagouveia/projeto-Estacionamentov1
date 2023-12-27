using Estacionamento;
using DesafioFundamentos.Models;

class Estacionamento
{
    private decimal precoInicial;
    private decimal precoPorHora;
    private System.Collections.Generic.List<string> veiculos;

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
        veiculos = new System.Collections.Generic.List<string>();
    }

    public void AdicionarVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo:");
        string placa = Console.ReadLine();
        veiculos.Add(placa);
        Console.WriteLine($"Veículo com placa {placa} adicionado ao estacionamento.");
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo a ser removido:");
        string placa = Console.ReadLine();

        if (veiculos.Contains(placa))
        {
            Console.WriteLine($"Digite a quantidade de horas que o veículo com placa {placa} permaneceu estacionado:");
            double horasEstacionado = Convert.ToDouble(Console.ReadLine());
            decimal valorCobrado = precoInicial + (decimal)horasEstacionado * precoPorHora;
            Console.WriteLine($"Valor a ser cobrado: R${valorCobrado:F2}");
            veiculos.Remove(placa);
        }
        else
        {
            Console.WriteLine($"Veículo com placa {placa} não encontrado no estacionamento.");
        }
    }

    public void ListarVeiculos()
    {
        if (veiculos.Count > 0)
        {
            Console.WriteLine("Veículos estacionados:");
            foreach (var placa in veiculos)
            {
                Console.WriteLine(placa);
            }
        }
        else
        {
            Console.WriteLine("Não há veículos estacionados.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!\n" +
                          "Digite o preço inicial:");
        decimal precoInicial = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Agora digite o preço por hora:");
        decimal precoPorHora = Convert.ToDecimal(Console.ReadLine());

        // Instancia a classe Estacionamento, já com os valores obtidos anteriormente
        Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

        string opcao = string.Empty;
        bool exibirMenu = true;

        // Realiza o loop do menu
        while (exibirMenu)
        {
            Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");

            switch (Console.ReadLine())
            {
                case "1":
                    es.AdicionarVeiculo();
                    break;

                case "2":
                    es.RemoverVeiculo();
                    break;

                case "3":
                    es.ListarVeiculos();
                    break;

                case "4":
                    exibirMenu = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }

        Console.WriteLine("O programa se encerrou");
    }
}
