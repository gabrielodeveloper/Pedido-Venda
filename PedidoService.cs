public class PedidoService
{
    private Validacao validacao;
    private ProdutoColecao produtos;
    private ClienteColecao clientes;
    private Cliente cliente;
    private Produto produto;
    private PedidoItem pedidoItem;

    public PedidoService(Validacao validacao, ProdutoColecao produtos, ClienteColecao clientes, Cliente cliente, Produto produto, PedidoItem pedidoItem)
    {
        this.validacao = validacao;
        this.produtos = produtos;
        this.clientes = clientes;
        this.cliente = cliente;
        this.produto = produto;
        this.pedidoItem = pedidoItem;
    }
    
    public void CadastrarPedido()
    {

        int codigoPedido = validacao.ObterCodigo("Pedido");
        int codigoCliente = validacao.ObterCodigo("Cliente");
        int codigoProduto = validacao.ObterCodigo("Produto");

        Console.Write("Digite a quantidade do produto solicitado: ");
        string? quantidade = Console.ReadLine();





    }
}