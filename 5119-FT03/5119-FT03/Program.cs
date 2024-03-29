﻿using System;
using System.Collections.Generic;

namespace _5119_FT03
{
    class Program
    {
        static int id;
        static List<Contacto> cont = new List<Contacto>();

        enum Opcao { Inserir = 1, Listar = 2, Fechar = 3 };
        enum chooseId { Continuar = 1, Sair = 0 };

        static int Menu()
        {
            int aux = 0;
            Console.WriteLine("Qual a opção pretendida?");
            foreach (Opcao val in Enum.GetValues(typeof(Opcao)))
            {
                Console.WriteLine(++aux + " - " + val);
            }
            return LerValor();
        }

        static int MenuId()
        {
            int aux = -1;
            Console.WriteLine("Prentede saber a idade?\n");
            foreach (chooseId val in Enum.GetValues(typeof(chooseId)))
            {
                Console.WriteLine(++aux + " - " + val);
            }
            return LerValor();
        }

        static void saberIdade()
        {  
            try
            {
                Console.WriteLine("ID pretendido:\n");
                id = int.Parse(Console.ReadLine());
                Contacto c = cont.Find(x => x.getId() == id);
                Console.WriteLine(c.calcIdade());
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("!!!Insira um numero.!!!");
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("!!!Insira um numero.!!!");
            }
 
        }

        static int LerValor()
        {
            int val = 0;
            bool flag = false;
            do
            {
                try
                {
                    val = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valor incorrecto, digite novamente:");
                    flag = false;
                }
            } while (!flag);
            return val;
        }




        static void listar()
        {
            Console.Clear();

            foreach (Contacto contac in cont)
            {
                Console.WriteLine(contac.ToString());
            }
            Console.WriteLine();
            int op1;
            do {
                op1 = MenuId();
                if (op1 == (int)chooseId.Continuar)
                {
                    saberIdade();
                }
            } while (op1 != (int)chooseId.Sair);
        }


        static void inserir()
        {
            Console.WriteLine("Insira ID: \n");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o Nome:\n");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira o telefone:\n");
            string tel = Console.ReadLine();
            Console.WriteLine("Insira o email:\n");
            string email = Console.ReadLine();
            Console.WriteLine("Insira a data da nascimento:\n");
            Data d1 = new Data();
            int ano = int.Parse(Console.ReadLine());
            int mes = int.Parse(Console.ReadLine());
            int dia = int.Parse(Console.ReadLine());
            d1.setAno(ano);
            d1.setMes(mes);
            d1.setDia(dia);
            cont.Add(new Contacto(id, nome, tel, email, d1));
        }


        static void Main(string[] args)
        {
            int op;
            do {
                op = Menu();
 
                switch (op)
                {
                    case 1:
                        inserir();
                        break;
                    case 2:
                        listar();
                        
                        break;
                }

            } while (op != (int)Opcao.Fechar);


        }

    }
}