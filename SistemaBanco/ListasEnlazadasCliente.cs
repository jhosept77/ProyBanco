using System;

public class ListasEnlazadasCliente
{
    NodoCliente?  Cabeza;

    public void IngresarCliente(Cliente cliente)
    {
        NodoCliente nuevo = new NodoCliente();
        nuevo.DatoCliente = cliente;
        nuevo.Siguiente = Cabeza;
        Cabeza = nuevo;

    }

    public Cliente? BuscarCliente(int id)
    {
        NodoCliente? actual = Cabeza;
        while(actual != null)
        {
            if(actual.DatoCliente!.Id == id)
            {
                return actual.DatoCliente;
            }
            actual = actual.Siguiente;
        }
        return null;
    }

}
