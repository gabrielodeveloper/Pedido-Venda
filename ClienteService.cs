public class ClienteService
{

    private ClienteValidacao clienteValidacao;
    private ClienteColecao clientes;

    public ClienteService(ClienteColecao clientes, ClienteValidacao clienteValidacao)
    {
        this.clientes = clientes;
        this.clienteValidacao = clienteValidacao;
    }
    public List<Cliente> ObterCliente(int? codigo = null)
    {
        if (codigo.HasValue)
        {
            return clientes
            .Where(cliente => cliente.Codigo == codigo.Value)
            .ToList();
        }
        return clientes.ToList();
    }
    public void CadastrarCliente()
    {
        Cliente cliente = new Cliente();
        Console.WriteLine("\n=== Cadastrar Cliente ===\n");

        while (true)
        {
            int codigo = clienteValidacao.ObterCodigo();
            bool codigoExiste = clientes.Any(cli => cli.Codigo == codigo);

            if (codigoExiste)
            {
                Console.WriteLine("Este código já está em uso. Tente novamente.");
                continue;
            }

            cliente.Codigo = codigo;
            break;
        }

        cliente.Nome = clienteValidacao.ObterNomeCliente();
        cliente.CPF = clienteValidacao.ObterCPFValido();

        Console.WriteLine("\nCliente Cadastrado com sucesso.");
        clientes.Add(cliente);
    }
    public void ExbirCliente(Cliente cliente)
    {
        Console.WriteLine($"\nCódigo: {cliente.Codigo}");
        Console.WriteLine($"Nome: {cliente.Nome}");
        Console.WriteLine($"CPF: {cliente.CPF}");
    }
    public void ConsultarCliente()
    {
        var clientesEncontrados = ObterCliente();
        Console.WriteLine("\n\n===== CLIENTES CADASTRADOS =====");

        foreach (var cliente in clientesEncontrados)
        {
            ExbirCliente(cliente);
        }
    }
    public void ConsultarClientePorCodigo()
    {
        Console.Write("\nDigite o código do cliente: ");

        int codigo = clienteValidacao.ObterCodigo();
        var clienteEncontrado = ObterCliente(codigo);

        if (!clienteEncontrado.Any())
        {
            Console.WriteLine("\nCliente não encontrado.");
            return;
        }
        Cliente cliente = clienteEncontrado[0];
        ExbirCliente(cliente);
    }
    public void AlterarCliente()
    {
        string? codigoDigitado;

        while (true)
        {
            Console.Write("\nDigite o código do cliente que deseja alterar: ");
            codigoDigitado = Console.ReadLine();

            if (!int.TryParse(codigoDigitado, out int codigo))
            {
                Console.WriteLine("O código informado é inválido. Tente novamente!");
                continue;
            }

            if (codigo < 0)
            {
                Console.WriteLine("O código informado não pode ser negativo.");
                continue;
            }

            Cliente? cliente = clientes.Find(cli => cli.Codigo == codigo);

            if (cliente != null)
            {
                while (true)
                {
                    Console.Write("Digite o nome do cliente: ");
                    string? nome = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nome))
                    {
                        Console.WriteLine("O nome do cliente não pode ser vazio.");
                        continue;
                    }
                    cliente.Nome = nome;
                    break;
                }

                Console.WriteLine("\nCliente alterado com sucesso.");
                break;
            }
            else
            {
                Console.WriteLine("Cliente não encontrado. \n");
            }
        }
    }
    public void ExcluirCliente()
    {
        string? codigoDigitado;

        while (true)
        {
            Console.Write("\nDigite o código do cliente que deseja excluir: ");
            codigoDigitado = Console.ReadLine();

            if (!int.TryParse(codigoDigitado, out int codigo))
            {
                Console.WriteLine("O código informado é inválido. Tente novamente!");
                continue;
            }

            if (codigo < 0)
            {
                Console.WriteLine("O código informado não pode ser negativo.");
                continue;
            }

            Console.Write("\nVocê realmente deseja excluir este cliente? ex:[S/N] \n");
            string? opcao = Console.ReadLine();

            Cliente? cliente = clientes.Find(cli => cli.Codigo == codigo);

            if (cliente != null)
            {
                if (opcao != null && opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                {

                    clientes.Remove(cliente);
                    Console.WriteLine("Cliente excluído com sucesso!");
                    break;
                }
                else if (opcao != null && opcao.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente!");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado. \n");
            }
        }
    }
}