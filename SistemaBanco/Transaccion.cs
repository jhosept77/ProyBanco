using System;

public class Transaccion
{
    public Cliente clienteTrans;
    public String Tipo;
    public double Monto;


    public Transaccion (Cliente cliente, String tipo, double monto)
    {
        clienteTrans = cliente;
        Tipo = tipo;
        Monto = monto;
    }
}

