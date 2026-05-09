using System;

public class ColaAtencion
{
    NodoCola? frente;
    NodoCola? fin;

    public void Atender(Cliente cliente)
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
}