using System;

public class PilaTransacciones
{
    public NodoPila Cima;

    public void Push(Cliente cliente)
    {
        NodoPila nuevo = new NodoPila();
        nuevo.DatoTransaccion = transaccion;
        nuevo.Siguiente = Cima;
        Cima =  nuevo;

    }

}