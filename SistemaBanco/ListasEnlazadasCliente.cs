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

    public void ListarCliente()
    {
        NodoCliente? actual = Cabeza;
        while(actual != null)
        {
            Console.WriteLine($"Nombre: {actual.DatoCliente?.Nombre}  |  Documento: {actual.DatoCliente?.Id}  |  No Cuenta: {actual.DatoCliente?.NumeroCuenta}  |  Saldo: {actual.DatoCliente?.Saldo}");
            actual = actual.Siguiente;
        }
    }


    public int CantidadClientes()
    {
        NodoCliente? actual = Cabeza;
        int contador = 0;
        while(actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }


    public double SaldoTotal()
    {
        NodoCliente? actual = Cabeza;
        double ElSaldo = 0;
        while(actual != null)
        {
            ElSaldo += actual.DatoCliente!.Saldo;
            actual = actual.Siguiente;
        }
        return ElSaldo;
    }
}
