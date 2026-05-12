using System;

public class Banco()
{
    public ListasEnlazadasCliente? clientes;
    public ColaAtencion? cola;
    public PilaTransacciones? historial;



    public void RegistraCliente(string nombre, int id, int numeroCuenta, double saldo)
    {
        Cliente? existe = clientes!.BuscarCliente(id);
        if(existe != null)
        {
            Console.WriteLine("Cliente existente !!");
            return;
        }
        Cliente nuevo = new Cliente(nombre, id, numeroCuenta, saldo);
        clientes.IngresarCliente(nuevo);
    }


    public void ListarClientes()
    {
        clientes!.ListarCliente();
    }


    public Cliente? BuscarCliente(int id)
    {
        return clientes!.BuscarCliente(id);
    }
    

    public int TostalClientes()
    {
        return clientes!.CantidadClientes();
    }


    public double TotalDinero()
    {
        return clientes!.SaldoTotal();
    }


    public void MostrarCola()
    {
        cola!.RecorrerCola();
    }

    
    public void Despositar(int id, double monto)
    {
        Cliente? clitemp = clientes!.BuscarCliente(id);
        if(clitemp == null)
        {
           Console.WriteLine("Cliente no encontrado");
           return;
        }
        clitemp.Saldo += monto;

        Transaccion newtran = new Transaccion(clitemp, "Deposito", monto);
        historial!.Push(newtran);

    }


    public void Retirar(int id, double monto)
    {
        Cliente? clitemp = clientes!.BuscarCliente(id);
        if(clitemp == null)
        {
           Console.WriteLine("Cliente no encontrado");
           return;
        }
        if(clitemp.Saldo < monto)
        {
            Console.WriteLine("SALDO INSUFICIENTE !!");
            return;
        }
        clitemp.Saldo -= monto;

        Transaccion newtran = new Transaccion(clitemp, "Retiro", monto);
        historial!.Push(newtran);
    }



    public double ConsultarSaldo(int id)
    {
        Cliente? salcli = clientes!.BuscarCliente(id);
        
    }
}