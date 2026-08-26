public class Validacao
{
    private bool IsCpf(string cpf)
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
    public int ObterCodigo(string objeto)
    {
        while (true)
        {
            Console.Write($"Digite o código do {objeto}: ");
            string? codigoDigitado = Console.ReadLine();

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
            return codigo;
        }
    }
    public string ObterNomeCliente()
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

            return nome;
        }
    }
    public string ObterCPFValido()
    {

        while (true)
        {
            Console.Write("Digite o CPF do cliente: ");
            string? CPFDigitado = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(CPFDigitado))
            {
                Console.WriteLine("O CPF deve ser informado. Tente novamente.");
                continue;
            }

            if (!string.IsNullOrEmpty(CPFDigitado))
            {

                if (!IsCpf(CPFDigitado))
                {
                    Console.WriteLine("CPF informado inválido. Tente novamente.");
                    continue;
                }
            }
            return CPFDigitado;
        }
    }
    public string ObterDescricaoProduto()
    {
        while (true)
        {
            Console.Write("Digite a descrição do produto: ");
            string? descricao = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(descricao))
            {
                Console.WriteLine("A descrição do produto não pode ser vazio.");
                continue;
            }

            return descricao;
        }
    }
    public decimal ObterPrecoValido()
    {
        while (true)
        {
            Console.Write("Digite o valor do produto: ");
            string? precoInformado = Console.ReadLine();

            if (!decimal.TryParse(precoInformado, out decimal preco))
            {
                Console.WriteLine("O valor informado é inválido. Tente Novamente!");
                continue;
            }

            if (preco < 0)
            {
                Console.WriteLine("O valor informado não pode ser negativo!");
                continue;
            }

            return preco;
        }
    }

    public int ObterEstoqueValido()
    {
        while (true)
        {
            Console.Write("Digite a quantidade de estoque do produto: ");
            string? estoqueInformado = Console.ReadLine();

            if (!int.TryParse(estoqueInformado, out int estoque))
            {
                Console.WriteLine("A quantidade informada do produto é inválida. Tente Novamente!");
                continue;
            }

            if (estoque < 0)
            {
                Console.WriteLine("A quantidade não pode ser negativa.");
                continue;
            }

            return estoque;
        }
    }

    public bool ObterProdutoAtivo()
    {
        while (true)
        {
            Console.Write("Ativo (true/false): ");
            string? situacao = Console.ReadLine();

            if(!bool.TryParse(situacao, out bool ativo))
            {
                Console.WriteLine("O valor informado é inválido. Tente Novamente.");
                continue;
            }

            return ativo;
        }
    }
}