public class Pedido
{
    public int CodigoPedido { get; set; }
    public required Cliente Cliente { get; set; }
    public required List<PedidoItem> Itens { get; set; }
}