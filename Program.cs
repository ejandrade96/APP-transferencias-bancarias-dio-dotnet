﻿using System;
using System.Collections.Generic;
using APP_transferencias_bancarias_dio_dotnet.Enum;
using APP_transferencias_bancarias_dio_dotnet.Modelos;

namespace DIO.Bank
{
  class Program
  {
    static List<Conta> Contas = new List<Conta>();
    
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarContas();
            break;
          case "2":
            InserirConta();
            break;
          case "3":
            Transferir();
            break;
          case "4":
            Sacar();
            break;
          case "5":
            Depositar();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadLine();
    }

    private static void Depositar()
    {
      Console.Write("Digite o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser depositado: ");
      double valor = double.Parse(Console.ReadLine());

      Contas[indiceConta].Depositar(valor);
    }

    private static void Sacar()
    {
      Console.Write("Digite o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser sacado: ");
      double valorSaque = double.Parse(Console.ReadLine());

      Contas[indiceConta].Sacar(valorSaque);
    }

    private static void Transferir()
    {
      Console.Write("Digite o número da conta de origem: ");
      int indiceContaOrigem = int.Parse(Console.ReadLine());

      Console.Write("Digite o número da conta de destino: ");
      int indiceContaDestino = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser transferido: ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      Contas[indiceContaOrigem].Transferir(valorTransferencia, Contas[indiceContaDestino]);
    }

    private static void InserirConta()
    {
      Console.WriteLine("Inserir nova conta");

      Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
      int entradaTipoConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o Nome do Cliente: ");
      string entradaNome = Console.ReadLine();

      Console.Write("Digite o saldo inicial: ");
      double entradaSaldo = double.Parse(Console.ReadLine());

      Console.Write("Digite o crédito: ");
      double entradaCredito = double.Parse(Console.ReadLine());

      Conta conta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                    saldo: entradaSaldo,
                    credito: entradaCredito,
                    nome: entradaNome);

      Contas.Add(conta);
    }

    private static void ListarContas()
    {
      Console.WriteLine("Listar contas");

      if (Contas.Count == 0)
      {
        Console.WriteLine("Nenhuma conta cadastrada.");
        return;
      }

      for (int i = 0; i < Contas.Count; i++)
      {
        Conta conta = Contas[i];
        Console.Write("#{0} - ", i);
        Console.WriteLine(conta);
      }
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Banco DIO a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar contas");
      Console.WriteLine("2- Inserir nova conta");
      Console.WriteLine("3- Transferir");
      Console.WriteLine("4- Sacar");
      Console.WriteLine("5- Depositar");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}