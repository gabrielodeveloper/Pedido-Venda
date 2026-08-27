public class Pedido
{
    public int CodigoPedido { get; set; }
    public required Cliente Cliente;
    public required List<PedidoItem> Itens { get; set; } = new();
}