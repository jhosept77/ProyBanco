using System;

public class Banco()
{
    public ListasEnlazadasCliente clientes = new ListasEnlazadasCliente();
    public ColaAtencion cola = new ColaAtencion();
    public PilaTransacciones historial = new PilaTransacciones();



    public void RegistraCliente(string nombre, int id, double saldo)
    {
        Cliente? existe = clientes!.BuscarCliente(id);
        if(existe != null)
        {
            Console.WriteLine("Cliente existente !!");
            return;
        }
        Cliente nuevo = new Cliente(nombre, id, saldo);
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
        if(salcli == null)
        {
            Console.WriteLine("Cliente no encontrado");
            return 0;
        }
        return salcli.Saldo;
    }


    public void AgregarTurno(int id)
    {
        Cliente? clicola = clientes!.BuscarCliente(id);
        if(clicola == null)
        {
            Console.WriteLine("Cliente no encontrado");
            return;
        }
        cola!.Encolar(clicola);
    }


    public void AtenderSiguiente()
    {
        Cliente? clieTend = cola!.Atender();
        if(clieTend == null)
        {
            Console.WriteLine("No hay clientes para atender");
            return;
        }
        Console.WriteLine($"Atendiendo a: {clieTend.Nombre}");
    }


    public void DeshacerTransaccion()
    {
        Transaccion? ultima = historial!.BuscTransac();
        if(ultima == null)
        {
            Console.WriteLine("No hay transacciones para deshacer");
            return;
        }
        if(ultima.Tipo == "Deposito")
        {
            ultima.clienteTrans.Saldo -= ultima.Monto;
            Console.WriteLine($"Deshaciendo {ultima.Tipo} de {ultima.clienteTrans.Nombre} por {ultima.Monto}");
        }
        else
        {
            ultima.clienteTrans.Saldo += ultima.Monto;
            Console.WriteLine($"Deshaciendo {ultima.Tipo} de {ultima.clienteTrans.Nombre} por {ultima.Monto}");
        }

    }
}