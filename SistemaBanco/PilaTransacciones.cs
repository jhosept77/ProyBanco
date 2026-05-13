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


    public void HistorialTran(int id)
    {
        NodoPila? actual = Cima;
        int contador = 0;
        while(actual != null)
        {
            if(actual.DatoTransaccion!.clienteTrans.Id == id)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{actual.DatoTransaccion.Tipo} de {actual.DatoTransaccion.Monto}");
                Console.ResetColor();
                contador++;
            }
            actual = actual.Siguiente;
        }
        if(contador == 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("No hay transacciones registradas para este cliente");
            Console.ResetColor();
        }
    }

}