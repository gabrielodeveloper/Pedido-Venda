public class Program
{
    static ClienteColecao clientes = new ClienteColecao();
    static ProdutoColecao produtos = new ProdutoColecao();
    static List<PedidoItem> itens = new List<PedidoItem>();
    static Cliente cliente = new Cliente();
    static Produto produto = new Produto();
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
        Console.WriteLine("5 - Excluir Cliente");
        Console.WriteLine("6 - Voltar para o menu principal");
    }
    public static void ExibirMenuProduto()
    {
        Console.WriteLine("\n=== Selecionar Produto ===\n");
        Console.WriteLine("1 - Cadastrar Produto");
        Console.WriteLine("2 - Consultar Produto");
        Console.WriteLine("3 - Consultar Produto Por Código");
        Console.WriteLine("4 - Alterar Produto");
        Console.WriteLine("5 - Excluir Produto");
        Console.WriteLine("6 - Voltar Para o Menu Principal");
    }
    public static void ExibirPedidoVenda()
    {
        Console.WriteLine("\n=== Selecionar Pedido Venda ===\n");
        Console.WriteLine("1 - Cadastrar Pedido");
        Console.WriteLine("2 - Consultar Pedido");
        Console.WriteLine("3 - Consultar Pedido Por Código");
        Console.WriteLine("4 - Alterar Pedido");
        Console.WriteLine("5 - Excluir Pedido");
        Console.WriteLine("6 - Voltar Para o Menu Principal");
    }
    public static void Main(string[] args)
    {
        Validacao validacao = new Validacao();
        ClienteService clienteService = new ClienteService(clientes, validacao);
        ProdutoService produtoService = new ProdutoService(validacao, produtos);
        PedidoService pedidoService = new PedidoService(validacao, produtos, clientes, cliente, produto, itens);

        ExibirMenuPrincipal();
        try
        {
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
                            case 6:
                                ExibirMenuPrincipal();
                                opcao = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Opção inválida. Tente novamente!");
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
                            case 6:
                                ExibirMenuPrincipal();
                                opcao = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Opção inválida. Tente novamente!");
                                break;
                        }
                        break;
                    case 3:
                        ExibirPedidoVenda();
                        int acaoPedido = Convert.ToInt32(Console.ReadLine());
                        switch (acaoPedido)
                        {
                            case 1:
                                pedidoService.CadastrarPedido();
                                break;
                            case 2:
                                //produtoService.ConsultarProdutos();
                                break;
                            case 3:
                                // produtoService.ConsultarProdutoPorCodigo();
                                break;
                            case 4:
                                // produtoService.AlterarProduto();
                                break;
                            case 5:
                                // produtoService.ExcluirProduto();
                                break;
                            case 6:
                                ExibirMenuPrincipal();
                                opcao = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Opção inválida. Tente novamente!");
                                break;
                        }
                        break;
                }
            }
            ExibirMenuPrincipal();
            opcao = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível cadastrar o produto. Detalhe: {ex.Message}");
            ExibirMenuPrincipal();
        }
    }
}