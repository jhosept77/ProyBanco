using System;

public class Cliente
{
    public String Nombre {get; set;}
    public int Id {get; set;}
    public int NumeroCuenta {get; set;}
    public double Saldo {get; set;}


    public Cliente(String nombre, int id, int numerocuenta, double saldo)
    {
        Nombre = nombre;
        Id = id;
        NumeroCuenta = numerocuenta;
        Saldo = saldo;
    }
}

