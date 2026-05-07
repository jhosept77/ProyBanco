using System;

public class ListasEnlazadasCliente
{
    NodoCliente  Cabeza;

    public void IngresarCliente(Cliente cliente)
    {
        NodoCliente nuevo = new NodoCliente();
        nuevo.DatoCliente = cliente;
        nuevo.Siguiente = Cabeza;
        Cabeza = nuevo;

    }
}
