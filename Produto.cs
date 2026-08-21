public class Produto
{
    public int Codigo { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public Decimal Preco { get; set; }
    public int Estoque { get; set; }
    public bool Ativo { get; set; }
}