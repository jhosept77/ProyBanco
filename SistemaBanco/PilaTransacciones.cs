using System;

public class PilaTransacciones
{
    public NodoPila? Cima;

    public void Push(Transaccion transaccion)
    {
        NodoPila nuevo = new NodoPila();
        nuevo.DatoTransaccion = transaccion;
        nuevo.Siguiente = Cima!;
        Cima =  nuevo;

    }

    public Transaccion BuscTransac()
    {
     if(Cima == null)
        {
            return null!;
        }
     Transaccion Temp = Cima.DatoTransaccion!;
     Cima = Cima.Siguiente;
     return Temp;   
    }

    public Transaccion ConsultarUltima()
    {
        if(Cima == null)
        {
            return null!;
        }
        return Cima.DatoTransaccion!;
    }

    public bool VerificaVacio()
    {
        return Cima == null;
    }

}