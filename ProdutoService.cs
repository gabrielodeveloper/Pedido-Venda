public class ProdutoService
{
    private Validacao validacao;
    private ProdutoColecao produtos;
    public ProdutoService(Validacao validacao, ProdutoColecao produtos)
    {
        this.validacao = validacao;
        this.produtos = produtos;
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
    public void ExibirProduto(Produto produto)
    {
        Console.WriteLine($"Código: {produto.Codigo}");
        Console.WriteLine($"Descrição: {produto.Descricao}");
        Console.WriteLine($"Preço: {produto.Preco}");
        Console.WriteLine($"Estoque: {produto.Estoque}");
        Console.WriteLine($"Ativo: {produto.Ativo}\n");
    }
    public void CadastrarProduto()
    {
        Produto produto = new Produto();
        Console.WriteLine("=== Cadastrar Produto ===");

        while (true)
        {
            Console.Write("Digite o código do produto: ");
            int codigo = validacao.ObterCodigo();
            bool codigoExiste = produtos.Any(produto => produto.Codigo == codigo);

            if (codigoExiste)
            {
                Console.WriteLine("Este código já está em uso. Tente novamente.");
                continue;
            }
            produto.Codigo = codigo;
            break;
        }

        produto.Descricao = validacao.ObterDescricaoProduto();
        produto.Preco = validacao.ObterPrecoValido();
        produto.Estoque = validacao.ObterEstoqueValido();
        produto.Ativo = validacao.ObterProdutoAtivo();

        produtos.Add(produto);
        Console.WriteLine("\nProduto cadastrado com sucesso!\n");
    }
    public void ConsultarProdutos()
    {
        var produtosEncontrados = ObterProduto();
        Console.WriteLine("\n=== Consultar Produtos ===\n");

        foreach (var produto in produtosEncontrados)
        {
            ExibirProduto(produto);
        }
    }
    public void ConsultarProdutoPorCodigo()
    {
        Console.Write("\nDigite o código do produto desejado: ");

        int codigo = validacao.ObterCodigo();
        var produtosEncontrados = ObterProduto(codigo);

        Console.Write("Digite o código do produto: ");
        if (!produtosEncontrados.Any())
        {
            Console.WriteLine("Produto não encontrado!");
            return;
        }
        Produto produto = produtosEncontrados[0];
        ExibirProduto(produto);
    }
    public void AlterarProduto()
    {
        int codigo = validacao.ObterCodigo();

        Produto? produto = produtos.Find(prod => prod.Codigo == codigo);

        if (produto != null)
        {
            produto.Descricao = validacao.ObterDescricaoProduto();
            produto.Preco = validacao.ObterPrecoValido();
            produto.Estoque = validacao.ObterEstoqueValido();
            produto.Ativo = validacao.ObterProdutoAtivo();
            Console.WriteLine("\nProduto alterado com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Produto não encontrado. Tente Novamente!");
            return;
        }
    }
    public void ExcluirProduto()
    {
        int codigo = validacao.ObterCodigo();
        var produtoEncontrado = ObterProduto(codigo);

        Console.Write("\nVocê realmente deseja excluir este produto? ex:[S/N] ");
        string? opcao = Console.ReadLine();

        Produto? produto = produtoEncontrado[0];
        
        if (produto != null)
        {
            if (opcao != null && opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                produtos.Remove(produto);
                Console.WriteLine("Produto excluido com sucesso.");
            }
            else if (opcao != null && opcao.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            else
            {
                Console.WriteLine("A opção digitada é inválido!");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }
}