public class PedidoService
{
    private Validacao validacao;
    private ProdutoColecao produtos;
    private ClienteColecao clientes;
    private Cliente cliente;
    private Produto produto;
    private List<PedidoItem> itens;

    public PedidoService(Validacao validacao, ProdutoColecao produtos, ClienteColecao clientes, Cliente cliente, Produto produto, List<PedidoItem> itens)
    {
        this.validacao = validacao;
        this.produtos = produtos;
        this.clientes = clientes;
        this.cliente = cliente;
        this.produto = produto;
        this.itens = itens;
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
        Pedido cadastrarPedido = new Pedido()
        {
            Cliente = cliente,
            Itens = itens
        };

        PedidoItem pedidoItem = new PedidoItem()
        {
            Produto = produto
        };

        PedidoColecao pedidos = new PedidoColecao();

        while (true)
        {
            int codigoPedido = validacao.ObterCodigo("Pedido");
            int codigoCliente = validacao.ObterCodigo("Cliente");
            var clienteEncontrado = ObterCliente(codigoCliente);
            int codigoProduto = validacao.ObterCodigo("Produto");
            var produtoEncontrado = ObterProduto(codigoProduto);

            Console.Write("Digite a quantidade do produto solicitado: ");
            string? quantidade = Console.ReadLine();

            if (!int.TryParse(quantidade, out int quantidadeItem))
            {
                Console.WriteLine("A quantidade informada é inválida.");
                continue;
            }

            if (quantidadeItem < 0)
            {
                Console.WriteLine("A quantidade informada não pode ser negativa.");
                continue;
            }

            cadastrarPedido.CodigoPedido = codigoPedido;
            cadastrarPedido.Cliente = clienteEncontrado[0];
            pedidoItem.Produto = produtoEncontrado[0];
            pedidoItem.Quantidade = quantidadeItem;
            pedidos.Add(cadastrarPedido);
            Console.WriteLine($"\nCódigo Pedido: {cadastrarPedido.CodigoPedido}");
            Console.WriteLine($"\nCódigo Cliente: {cadastrarPedido.Cliente.Codigo}");
            Console.WriteLine($"Nome: {cadastrarPedido.Cliente.Nome}");
            Console.WriteLine($"Código Produto: {pedidoItem.Produto.Codigo}");
            Console.WriteLine($"Descrição: {pedidoItem.Produto.Descricao}");
            Console.WriteLine($"Preço: {pedidoItem.Produto.Preco}");
            Console.WriteLine($"Quantidade: {pedidoItem.Quantidade}");
            Console.WriteLine($"Ativo: {pedidoItem.Produto.Ativo}\n");
            Console.WriteLine("Pedido criado com sucesso.");
            break;

        }

    }
}