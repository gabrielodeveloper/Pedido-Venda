public class Program
{
    static ClienteColecao clientes = new ClienteColecao();
    static ProdutoColecao produtos = new ProdutoColecao();
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
    public static void ExibirMenuProduto()
    {
        Console.WriteLine("\n=== Selecionar Produto ===\n");
        Console.WriteLine("1 - Cadastrar Produto");
        Console.WriteLine("2 - Consultar Produto");
        Console.WriteLine("3 - Consultar Produto Por Código");
        Console.WriteLine("4 - Alterar Produto");
        Console.WriteLine("5 - Excluir");
    }

    public static void Main(string[] args)
    {
        Validacao validacao = new Validacao();
        ClienteService clienteService = new ClienteService(clientes, validacao);
        ProdutoService produtoService = new ProdutoService(validacao, produtos);

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
                            clienteService.CadastrarCliente();
                            break;
                        case 2:
                            clienteService.ConsultarCliente();
                            break;
                        case 3:
                            clienteService.ConsultarClientePorCodigo();
                            break;
                        case 4:
                            clienteService.AlterarCliente();
                            break;
                        case 5:
                            clienteService.ExcluirCliente();
                            break;
                    }
                    break;
                case 2:
                    ExibirMenuProduto();
                    int acaoProduto = Convert.ToInt32(Console.ReadLine());

                    switch (acaoProduto)
                    {
                        case 1:
                            produtoService.CadastrarProduto();
                            break;
                        case 2:
                            produtoService.ConsultarProdutos();
                            break;
                        case 3:
                            produtoService.ConsultarProdutoPorCodigo();
                            break;
                        case 4:
                            produtoService.AlterarProduto();
                            break;
                        case 5:
                            produtoService.ExcluirProduto();
                            break;
                    }
                    break;
            }
        }
        ExibirMenuPrincipal();
        opcao = Convert.ToInt32(Console.ReadLine());
    }
}