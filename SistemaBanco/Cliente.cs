using System;

public class Cliente
{
    String Nombre {get; set;}
    int Id {get; set;}
    int NumeroCuenta {get; set;}
    double Saldo {get; set;}


    public Cliente(String nombre, int id, int numerocuenta, double saldo)
    {
        Nombre = nombre;
        Id = id;
        NumeroCuenta = numerocuenta;
        Saldo = saldo;
    }
}

