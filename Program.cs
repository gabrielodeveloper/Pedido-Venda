public class Program
{
    static ClienteColecao clientes = new ClienteColecao();
    public static void ExibirMenuPrincipal()
    {
        Console.WriteLine("\n=== Menu Principal ===\n");
        Console.WriteLine("1 - Cliente");
        Console.WriteLine("2 - Produto");
        Console.WriteLine("3 - Venda");
    }

    public static void ExibirMenuCliente()
    {
        Console.WriteLine("\n=== Selecionar Cliente ===\n");
        Console.WriteLine("1 - Cadastrar Cliente");
        Console.WriteLine("2 - Consultar Cliente");
        Console.WriteLine("3 - Consultar Cliente Por Código");
        Console.WriteLine("4 - Alterar Cliente");
        Console.WriteLine("5 - Excluir");
    }
    private static bool IsCpf(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        cpf = cpf.Trim().Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;

        for (int j = 0; j < 10; j++)
            if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                return false;

        string tempCpf = cpf.Substring(0, 9);
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        string digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
    }

    public static void CadastrarCliente()
    {
        Cliente cliente = new Cliente();
        string? linha;

        Console.WriteLine("\n=== Cadastrar Cliente ===\n");

        while (true)
        {
            Console.Write("Digite o código do cliente: ");
            linha = Console.ReadLine();

            if (!int.TryParse(linha, out int codigo))
            {
                Console.WriteLine("O código informado é inválido. Tente novamente!");
                continue;
            }

            if (codigo < 0)
            {
                Console.WriteLine("O código informado não pode ser negativo.");
                continue;
            }

            cliente.Codigo = codigo;
            break;
        }

        while (true)
        {
            Console.Write("Digite o nome do cliente: ");
            string? nome = Console.ReadLine();

            if (nome == null)
            {
                Console.WriteLine("O nome do cliente não pode ser vazio.");
                continue;
            }
            cliente.Nome = nome;
            break;
        }

        while (true)
        {
            Console.Write("Digite o CPF do cliente: ");
            linha = Console.ReadLine();

            if (!string.IsNullOrEmpty(linha))
            {

                if (!IsCpf(linha))
                {
                    Console.WriteLine("CPF informado inválido. Tente novamente.");
                    continue;
                }
                cliente.CPF = linha;
            }

            break;
        }

        Console.WriteLine("\nCliente Cadastrado com sucesso.");

        clientes.Add(cliente);
    }

    public static void ConsultarCliente()
    {
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"\nCódigo: {cliente.Codigo}");
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"CPF: {cliente.CPF}");
        }
    }

    public static void ConsultarClientePorCodigo()
    {
        string? codigoDigitado;

        while (true)
        {
            Console.Write("\nDigite o código do cliente: ");
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

            foreach (var cliente in clientes)
            {
                if (cliente.Codigo == codigo)
                {
                    Console.WriteLine($"\nCódigo: {cliente.Codigo}");
                    Console.WriteLine($"Nome: {cliente.Nome}");
                    Console.WriteLine($"CPF: {cliente.CPF}");
                    break;
                }
                else
                {
                    Console.WriteLine("\nCliente não encontrado.");
                    break;
                }

            }
            break;

        }
    }

    public static void Main(string[] args)
    {

        ExibirMenuPrincipal();
        int opcao = Convert.ToInt32(Console.ReadLine());

        while (opcao > 0)
        {
            switch (opcao)
            {
                case 1:
                    ExibirMenuCliente();
                    int acaoCliente = Convert.ToInt32(Console.ReadLine());

                    switch (acaoCliente)
                    {
                        case 1:
                            CadastrarCliente();
                            break;
                        case 2:
                            ConsultarCliente();
                            break;
                        case 3:
                            ConsultarClientePorCodigo();
                            break;
                    }
                    break;
            }
        }

    }
}