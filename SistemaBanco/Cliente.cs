using System;

public class Cliente
{
    public String Nombre {get; set;}
    public int Id {get; set;}
    public string NumeroCuenta {get; set;}
    public double Saldo {get; set;}


    public Cliente(String nombre, int id, double saldo)
    {
        Nombre = nombre;
        Id = id;
        Saldo = saldo;


        Random rand = new Random();
        string numeroCuenta = "";
        for(int i = 0; i < 16; i++)

    {
        numeroCuenta += rand.Next(0, 10);
    }
    NumeroCuenta = numeroCuenta;

    }
}

