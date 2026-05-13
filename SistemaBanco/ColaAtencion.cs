using System;

public class ColaAtencion
{
    NodoCola? frente;
    NodoCola? fin;

    public void Encolar (Cliente cliente)
    {
        NodoCola nuevo = new NodoCola();
        nuevo.DatoCliente = cliente;
        nuevo.Siguiente = null;

        if(fin == null)
        {
            frente = fin = nuevo;
        }
        else
        {
            fin.Siguiente = nuevo;
            fin = nuevo;
        }
    }

    public Cliente? Atender()
    {
        if(frente == null)
        {
            return null;
        }
        else
        {
            Cliente? temp = frente.DatoCliente;
            frente = frente.Siguiente;
            return temp;
        }
         
    }

    public Cliente? MostrarCliente()
    {
        if(frente == null)
        {
            return null;
        }
        else
        {
            Cliente? VerCli = frente.DatoCliente;
            return VerCli;
        }
    }

    public void RecorrerCola()
    {
        NodoCola? actual = frente;
        while(actual != null)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Nombre: {actual.DatoCliente!.Nombre} | Id: {actual.DatoCliente!.Id} | Cuenta: {actual.DatoCliente!.NumeroCuenta} | Saldo: {actual.DatoCliente!.Saldo}");
            Console.ResetColor();
            actual = actual.Siguiente;
        }
    }
}