using CadastrosBasicos.ManipulaArquivos;
using ProjBiltiful.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosBasicos
{

    public class MenuCadastros
    {
        public static void SubMenu()
        {
            string escolha;
            Console.WriteLine("Teste do banco = ");
            DBHelper.TesteConexao();
            Console.WriteLine("Esta tudo certo com o banco!");
            Console.ReadKey();
            do
            {

                Console.Clear();

                Console.WriteLine("=============== CADASTROS ===============");
                Console.WriteLine("1. Clientes / Fornecedores");
                Console.WriteLine("2. Produtos");
                Console.WriteLine("3. Matérias-Primas");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("0. Voltar ao menu anterior");
                Console.Write("\nEscolha: ");

                switch(escolha = Console.ReadLine())
                {
                    case "0":
                        break;

                    case "1":
                        SubMenuClientesFornecedores();
                        break;

                    case "2":
                        new Produto().Menu();
                        break;

                    case "3":
                        new MPrima().Menu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine("\nPressione ENTER para voltar ao menu");
                        break;
                }

            }while(escolha != "0");

        }

        public static void SubMenuClientesFornecedores()
        {
            string escolha;

            do
            {
                Console.Clear();

                Console.WriteLine("=============== CLIENTES / FORNECEDORES ===============");
                Console.WriteLine("1. Cadastar cliente");
                Console.WriteLine("2. Listar clientes");
                Console.WriteLine("3. Editar registro de cliente");
                Console.WriteLine("4. Bloquear/Desbloqueia cliente (Inadimplente)");
                Console.WriteLine("5. Localizar cliente");
                Console.WriteLine("6. Localizar cliente bloqueado");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("7. Cadastar fornecedor");
                Console.WriteLine("8. Listar fornecedores");
                Console.WriteLine("9. Editar registro de fornecedor");
                Console.WriteLine("10. Bloquear/Desbloqueia fornecedor");
                Console.WriteLine("11. Localizar fornecedor");
                Console.WriteLine("12. Localizar fornecedor bloqueado");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("0. Voltar ao menu anterior");
                Console.Write("\nEscolha: ");

                switch (escolha = Console.ReadLine())
                {
                    case "0":
                        break;

                    case "1":
                        RegistrarCliente();
                        break;

                    case "2":
                        Navegar();
                        break;

                    case "3":
                        EditarCliente();
                        break;

                    case "4":
                        //new Cliente().BloqueiaCadastro();
                        break;

                    case "5":
                        //new Cliente().Localizar();
                        break;

                    case "6":
                        //new Cliente().ClientesBloqueados();
                        break;

                    case "7":
                        //NovoFornecedor();
                        break;

                    case "8":
                        new Fornecedor().Navegar();
                        break;
                    case "9":
                        new Fornecedor().Editar();
                        break;
                    case "10":
                        new Fornecedor().BloqueiaFornecedor();
                        break;
                    case "11":
                        new Fornecedor().Localizar();
                        break;
                    case "12":
                        new Fornecedor().FornecedorBloqueado();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine("\n Pressione ENTER para voltar ao menu");
                        break;
                }

            } while (escolha != "0");
        }

        public static void RegistrarCliente()
        {
            Console.Clear();
            var controladorCliente = new ControladorCliente();
            bool flag;

            DateTime dataNasc;

            do
            {
                Console.Write("Data de nascimento: ");
                flag = DateTime.TryParse(Console.ReadLine(), out dataNasc);
            } while (flag != true);

            if (!Validacoes.CalculaData(dataNasc))
            {
                Console.WriteLine("Menor de 18 anos nao pode ser cadastrado");
                Console.ReadKey();
            }
            else
            {
                string cpf;
                string nome;
                char situacao;
                char sexo;
                do
                {
                    Console.Write("CPF: ");
                    cpf = Console.ReadLine();
                    if (!Validacoes.ValidarCpf(cpf)) Console.WriteLine("Digite um CPF valido!");
                } while (Validacoes.ValidarCpf(cpf.Length > 11 ? cpf.Remove('.').Remove('-') : cpf) == false);

                if (!controladorCliente.ClienteJaExiste(cpf))
                {
                    Console.Write("Nome: ");
                    nome = Console.ReadLine();
                    Console.Write("Genero (M - Masculino/ F - Feminino): ");
                    sexo = char.Parse(Console.ReadLine());
                    Console.Write("Situacao (A - Ativo/ I - Inativo): ");
                    situacao = char.Parse(Console.ReadLine());
                    controladorCliente.InserirCliente(new Cliente(cpf, nome, dataNasc, sexo, situacao));
                    Console.WriteLine("Cliente cadastrado com sucesso");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Cliente ja cadastrado!!");
                    Console.ReadKey();
                }
            }
        }

        private static void Navegar()
        {

            Console.WriteLine("============== Cliente ==============");
            var controladorCliente = new ControladorCliente();
            List<Cliente> clientes = controladorCliente.GetClientes();
            int opcao = 0, posicao = 0;
            bool flag = false;
            Console.WriteLine(clientes.First().CPF == null);
            if (clientes.First().CPF != null)
            { 
                do
                {
                    Console.Clear();
                    Console.WriteLine("============== Cliente ==============");

                    if (opcao == 0)
                    {
                        Console.WriteLine(clientes.ElementAt(posicao).ToString());
                    }
                    else if (opcao == 1)
                    {
                        if (posicao == clientes.Count - 1) posicao = clientes.Count - 1;
                        else posicao++;
                        Console.WriteLine(clientes.ElementAt(posicao));
                    }
                    else if (opcao == 2)
                    {
                        if (posicao == 0) posicao = 0;
                        else posicao--;
                        Console.WriteLine(clientes.ElementAt(posicao));
                    }
                    else if (opcao == 3)
                    {
                        posicao = 0;
                        Console.WriteLine(clientes.First());
                    }
                    else if (opcao == 4)
                    {
                        posicao = clientes.Count - 1;
                        Console.WriteLine(clientes.Last());
                    }

                    Console.WriteLine(@"
                                        1. Proximo 
                                        2. Anterior
                                        3. Primeiro
                                        4. Ultimo
                                        0. Voltar para menu anterior.");
                    do
                    {
                        flag = int.TryParse(Console.ReadLine(), out opcao);
                    } while (flag != true);

                } while (opcao != 0);
            }   
            else
            {
                Console.Clear();
                Console.WriteLine("Ainda nao tem nenhum cliente cadastrado");
                Console.WriteLine("Pressione enter para continuar...");
                Console.ReadKey();
            }
        }

        private static void EditarCliente()
        {
            char continuar;
            do
            {
                Console.Clear();
                Console.WriteLine("Somente algumas informacoes podem ser alterada como (Nome/Data de Nascimento/sexo/Situacao)");
                Console.WriteLine("Digite o CPF do cliente que deseja editar: ");
                Console.Write("CPF: ");
                string cpf = Console.ReadLine();

                var controladorCliente = new ControladorCliente();
                if (controladorCliente.ClienteJaExiste(cpf))
                {
                    Console.WriteLine("Digite qual informaçao do cliente deseja alterar: ");
                    Console.Write("\t1.Nome\n\t2.Data de Nascimento\n\t2.Sexo\n\t3.Ativar/Desativar cliente\nEscolha:");
                    string nome;
                    DateTime dataNasc;

                    char escolha = Char.Parse(Console.ReadLine());
                    if (escolha == '1')
                    {
                        Console.WriteLine("Nome: ");
                        nome = Console.ReadLine();
                        controladorCliente.AtualizarCliente(nome, cpf);
                    }
                    else if (escolha == '2')
                    {
                        Console.WriteLine("Data de nascimento: ");
                        dataNasc = DateTime.Parse(Console.ReadLine());
                        controladorCliente.AtualizarCliente(dataNasc, cpf);
                    }
                    else if (escolha == '3')
                    {
                        Console.WriteLine("Deseja alterar o sexo?\n\t1.S => (Sim)\n\t2.N => (Nao)");
                        bool decisaoSex = char.ToUpper(char.Parse(Console.ReadLine())) == 'S' ? true : false;
                        if (decisaoSex) controladorCliente.AtualizarCliente('1', cpf);
                    }
                    else if (escolha == '4')
                    {
                        Console.WriteLine("Desativar cliente?\n\t1.S => (Sim)\n\t2.N => (Nao)");
                        bool decisaoSit = char.ToUpper(char.Parse(Console.ReadLine())) == 'S' ? true : false;
                        if (decisaoSit) controladorCliente.AtualizarCliente('2', cpf);
                    }
                    continuar = '0';
                }
                else
                {
                    Console.WriteLine($"O cliente de CPF {cpf} não existe!");
                    Console.WriteLine("Digite \n\t1. para tentar novamente\n\t0.Para Sair");
                    continuar = Char.Parse(Console.ReadLine());
                }
            } while (continuar != '0');

            Console.WriteLine("Retornando ao menu...");
            Console.ReadKey();
        }

        public static Fornecedor RegistrarFornecedor(DateTime dFundacao)
        {
            string rSocial = "", cnpj = "";
            Read read = new Read();
            char situacao;
            do
            {
                Console.Write("CNPJ: ");
                cnpj = Console.ReadLine();
                cnpj = cnpj.Trim();
                cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            } while (Validacoes.ValidarCnpj(cnpj) == false);
            Fornecedor f = read.ProcurarFornecedor(cnpj);
            if (f == null)
            {
                Console.Write("Razao social: ");
                rSocial = Console.ReadLine().Trim().PadLeft(50, ' ');
                Console.Write("Situacao (A - Ativo/ I - Inativo): ");
                situacao = char.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Fornecedor ja cadastrado");
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
                return f;
            }
            return new Fornecedor(cnpj, rSocial, dFundacao, situacao);

        }
    }
}