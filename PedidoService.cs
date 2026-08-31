public class PedidoService
{
    static PedidoColecao pedidos = new PedidoColecao();
    private Validacao validacao;
    private ProdutoColecao produtos;
    private ClienteColecao clientes;

    public PedidoService(Validacao validacao, ProdutoColecao produtos, ClienteColecao clientes)
    {
        this.validacao = validacao;
        this.produtos = produtos;
        this.clientes = clientes;
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

    public List<Produto> ObterProduto(int? codigo = null)
    {
        if (codigo.HasValue)
        {
            return produtos
                .Where(produto => produto.Codigo == codigo)
                .ToList();
        }
        return produtos.ToList();
    }

    public void CadastrarPedido()
    {

        while (true)
        {
            int codigoPedido = validacao.ObterCodigo("Pedido");
            int codigoCliente = validacao.ObterCodigo("Cliente");
            Cliente? cliente = clientes.Find(cli => cli.Codigo == codigoCliente);
            bool opcao = true;

            PedidoItemColecao pedidoItems = new PedidoItemColecao();
            if (cliente != null)
            {
                Pedido pedido = new Pedido()
                {
                    Cliente = cliente,
                    Itens = pedidoItems
                };

                while (opcao)
                {
                    int codigoProduto = validacao.ObterCodigo("Produto");
                    Produto? produto = produtos.Find(Prod => Prod.Codigo == codigoProduto);
                    Console.Write("Digite a quantidade: ");
                    int quantidade = Convert.ToInt32(Console.ReadLine());
                    if (produto != null)
                    {
                        PedidoItem pedidoItem = new PedidoItem()
                        {
                            Produto = produto,
                            Quantidade = quantidade
                        };


                        Console.Write("Deseja adicionar um novo item no pedido? [S/N]: ");
                        string? escolha = Console.ReadLine();

                        pedidoItems.Add(pedidoItem);
                        if (escolha != null && escolha.Equals("s", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }
                        else if (escolha != null && escolha.Equals("n", StringComparison.OrdinalIgnoreCase))
                        {
                            opcao = false;
                            pedido.CodigoPedido = codigoPedido;

                            Console.WriteLine($"Código Pedido: {pedido.CodigoPedido}");
                            Console.WriteLine($"Código Cliente: {pedido.Cliente.Codigo}");
                            Console.WriteLine($"Código Cliente: {pedido.Cliente.Nome}");

                            foreach (var item in pedido.Itens)
                            {
                                Console.WriteLine($"Código do Produto: {item.Produto.Codigo}");
                                Console.WriteLine($"Descrição do Produto: {item.Produto.Descricao}");
                                Console.WriteLine($"Quantidade do Produto: {item.Quantidade}");
                            }

                            Console.WriteLine("Pedido cadastrado com sucesso.");

                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida. Tente Novamente!");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O produto informado não está cadastrado. Tente novamente.");
                    }

                }

                pedidos.Add(pedido);
            }
            else
            {
                Console.WriteLine("O cliente informado não está cadastrado. Tente novamente.");
            }

            break;
        }
    }
}