public class Program
{
    static ClienteColecao clientes = new ClienteColecao();
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
    public static void Main(string[] args)
    {
        ClienteValidacao clienteValidacao = new ClienteValidacao();
        ClienteService service = new ClienteService(clientes, clienteValidacao);

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
                            service.CadastrarCliente();
                            break;
                        case 2:
                            service.ConsultarCliente();
                            break;
                        case 3:
                            service.ConsultarClientePorCodigo();
                            break;
                        case 4:
                            service.AlterarCliente();
                            break;
                        case 5:
                            service.ExcluirCliente();
                            break;
                    }
                    break;
            }
        }
        ExibirMenuPrincipal();
        opcao = Convert.ToInt32(Console.ReadLine());
    }
}