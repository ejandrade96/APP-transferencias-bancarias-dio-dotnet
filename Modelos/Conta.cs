using System;
using APP_transferencias_bancarias_dio_dotnet.Enum;

namespace APP_transferencias_bancarias_dio_dotnet.Modelos
{
  public class Conta
  {
    private TipoConta _tipoConta;
    private double _saldo;
    private double _credito;
    private string _nome;

    public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
    {
      this._tipoConta = tipoConta;
      this._saldo = saldo;
      this._credito = credito;
      this._nome = nome;
    }

    public bool Sacar(double valor)
    {
      if (this._saldo - valor < (-this._credito * -1))
      {
        Console.WriteLine("Saldo insuficiente!");
        return false;
      }

      this._saldo -= valor;
      Console.WriteLine($"Saldo atual da conta de {this._nome} é {this._saldo}");
      return true;
    }

    public void Depositar(double valor)
    {
      this._saldo += valor;

      Console.WriteLine($"Saldo atual da conta de {this._nome} é {this._saldo}");
    }

    public void Transferir(double valor, Conta contaDestino)
    {
      if (this.Sacar(valor))
        contaDestino.Depositar(valor);
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "TipoConta " + this._tipoConta + " | ";
      retorno += "Nome " + this._nome + " | ";
      retorno += "Saldo " + this._saldo + " | ";
      retorno += "Crédito " + this._credito;
      return retorno;
    }
  }
}