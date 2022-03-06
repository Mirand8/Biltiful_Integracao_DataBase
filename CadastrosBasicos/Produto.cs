﻿using ManipulaArquivos;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CadastrosBasicos
{
    public class Produto
    {
        public string cbarras { get; set; }
        public string nome { get; set; }
        public decimal vvenda { get; set; }
        public DateTime uvenda { get; set; }
        public DateTime dcadastro { get; set; }
        public char situacao { get; set; }

        // nome arquivo: Cosmetico.dat

        public override string ToString()
        {
            return cbarras + nome + vvenda + uvenda + dcadastro + situacao;
        }

/*        public Produto()
        {
           
        }*/

        public void Cadastrar()
        {
            Produto produto = new Produto();

            char sit = 'A';
            string cod, nomeTemp;
            decimal venda = 0;
            bool flag = true;

            do
            {
                Console.Clear();
                Console.WriteLine("\n Cadastro de Produto\n");
                Console.Write(" Cod. Barras: 789");
                cod = Console.ReadLine();
                Console.Write(" Nome: ");
                nomeTemp = Console.ReadLine();
                Console.Write(" Valor da Venda: ");
                venda = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine(venda);
                Console.ReadKey();
                Console.Write(" Situacao (A / I): ");
                sit = char.Parse(Console.ReadLine().ToUpper());

                if ((cod == null) && (nomeTemp == null) && (venda < 1))
                {
                    Console.WriteLine(" Nenhum campo podera ser vazio.");
                    Console.WriteLine(" Pressione ENTER para voltar ao cadastro.");
                    Console.ReadKey();
                }
                else
                {
                    cod = "789" + cod;

                    if (cod.Length != 13)
                    {
                        Console.WriteLine(" Codigo invalido. Digite apenas os ultimos 10 numeros.");
                        Console.WriteLine(" Pressione ENTER para voltar ao cadastro.");
                        Console.ReadKey();
                    }
                    else if (nomeTemp.Length > 20)
                    {
                        Console.WriteLine(" Nome invalido. Digite apenas 20 caracteres.");
                        Console.WriteLine(" Pressione ENTER para voltar ao cadastro.");
                        Console.ReadKey();
                    }
                    else if ((venda < 1) || (venda > 99999))
                    {
                        Console.WriteLine(" Valor invalido. Apenas valores maior que 0 e menor que 999,99.");
                        Console.WriteLine(" Pressione ENTER para voltar ao cadastro.");
                        Console.ReadKey();
                    }
                    else if ((sit != 'A') && (sit != 'I'))
                    {
                        Console.WriteLine(" Situacao invalida.");
                        Console.WriteLine(" Pressione ENTER para voltar ao cadastro.");
                        Console.ReadKey();
                    }
                    else
                    {
                        flag = false;

                        produto.cbarras = cod;
                        produto.nome = nomeTemp;
                        produto.vvenda = venda;
                        //uvenda = ;
                        produto.dcadastro = DateTime.Now.Date;

                        GravarProduto(produto);

                        Console.WriteLine(" Cadastro do Materia-prima concluido com sucesso!");
                        Console.WriteLine(" PRessione ENTER para voltar ao menu");
                        Console.ReadKey();
                    }
                }

            } while (flag);
        }

        public void GravarProduto(Produto produto)
        {
            string caminhoInicial = Directory.GetCurrentDirectory();
            Console.WriteLine(caminhoInicial);

            string caminhoFinal = Path.Combine(caminhoInicial + "ProjBiltiful\\");
            Directory.CreateDirectory(caminhoFinal);

            string pastaProduto = Path.Combine(caminhoFinal, "Produto");
            Directory.CreateDirectory(pastaProduto);

            using (StreamWriter sw = new StreamWriter(pastaProduto))
            {
                sw.WriteLine(produto.ToString());
            }
        }

    }
}