﻿using CadastrosBasicos.ManipulaArquivos;
using System;

namespace CadastrosBasicos
{
    public class Cliente
    {
        public Write write { get; set; }
        public string cpf { get; private set; }
        public string nome { get; private set; }
        public DateTime dnascimento { get; private set; }
        public char sexo { get; private set; }
        public DateTime ucompra { get; set; }
        public DateTime dcadastro { get; private set; }
        public char situacao { get; set; }
        public Cliente()
        {
            if (CPF())
            {
                nome = Nome();
                dnascimento = DNascimento();
                if (Validacoes.CalcudaData(dnascimento))
                {
                    cpf = nome.Replace(".", "");
                    cpf = nome.Replace("-", "");
                    sexo = Sexo();
                    ucompra = DateTime.Now;
                    dcadastro = DateTime.Now;
                    situacao = Situacao();
                }
            }
        }
        public bool CPF()
        {
            bool flag = false;
            string value = " ";
            do
            {
                Console.Write("CPF: ");
                value = Console.ReadLine().Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");
                if (value.Length <= 14)
                {
                    if (Validacoes.ValidarCpf(value))
                        flag = true;
                    else
                    {
                        Console.WriteLine("CPF invalido!");
                        continue;
                    }
                }

            } while (flag != true);
            cpf = value;
            return true;
        }
        public string Nome()
        {
            string nome;
            bool flag = false;
            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine().Trim().PadLeft(50,'`') ;
                if (nome.Length <= 50) 
                {
                    flag = true;
                }
            } while (flag != true);
            return nome;
        }
        public DateTime DNascimento()
        {
            DateTime nascimento;
            bool flag = false;
            do
            {
                Console.Write("Nascimento (dd/mm/aaaa): ");
                flag = DateTime.TryParse(Console.ReadLine().Trim(), out nascimento);

                if (flag == false)
                    Console.WriteLine("Data incorreta!");
            } while (flag != true);

            bool value = Validacoes.CalcudaData(nascimento);

            if (value == false)
            {
                Console.WriteLine("Nao pode cadastrar pessoas com menos de 18 anos no sistema!");
                return nascimento;
            }
            else
                return nascimento;
        }
        public char Sexo()
        {
            Char genero;
            bool flag = false;

            do
            {
                Console.Write("Sexo (M/F): ");
                flag = char.TryParse(Console.ReadLine().ToUpper().Trim(), out genero);
                if (flag == false)
                    Console.Write("Genero incorreto, tente novamente");

            } while (flag != true);

            return genero;
        }
        public char Situacao()
        {
            char sit;
            bool flag = false;
            do
            {
                Console.Write("usuario (A – Ativo ou I – Inativo): ");
                flag = char.TryParse(Console.ReadLine().ToUpper().Trim(), out sit);
                if (flag != true)
                    Console.WriteLine("Insira um valor correto");

            } while (flag != true);
            return sit;
        }

    }
}
