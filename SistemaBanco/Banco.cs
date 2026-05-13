using System;

public class Banco()
{
    public ListasEnlazadasCliente clientes = new ListasEnlazadasCliente();
    public ColaAtencion cola = new ColaAtencion();
    public PilaTransacciones historial = new PilaTransacciones();



    public bool RegistraCliente(string nombre, int id, double saldo)
    {
        Cliente? existe = clientes!.BuscarCliente(id);
        if(existe != null)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("CLIENTE EXISTENTE !!");
            Console.ResetColor();
            return false;
        }
        Cliente nuevo = new Cliente(nombre, id, saldo);
        clientes.IngresarCliente(nuevo);
        return true;
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
           Console.ForegroundColor = ConsoleColor.DarkMagenta;
           Console.WriteLine("Cliente no encontrado");
           Console.ResetColor();
           return;
        }
        clitemp.Saldo += monto;

        Transaccion newtran = new Transaccion(clitemp, "Deposito", monto);
        historial!.Push(newtran);

    }


    public bool Retirar(int id, double monto)
    {
        Cliente? clitemp = clientes!.BuscarCliente(id);
        if(clitemp == null)
        {
           Console.ForegroundColor = ConsoleColor.DarkMagenta;
           Console.WriteLine("Cliente no encontrado");
           Console.ResetColor();
           return false;
        }
        if(clitemp.Saldo < monto)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("SALDO INSUFICIENTE !!");
            Console.ResetColor();
            return false;
        }
        clitemp.Saldo -= monto;

        Transaccion newtran = new Transaccion(clitemp, "Retiro", monto);
        historial!.Push(newtran);
        return true;
    }



    public double ConsultarSaldo(int id)
    {
        Cliente? salcli = clientes!.BuscarCliente(id);
        if(salcli == null)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Cliente no encontrado");
            Console.ResetColor();
            return 0;
        }
        return salcli.Saldo;
    }


    public void AgregarTurno(int id)
    {
        Cliente? clicola = clientes!.BuscarCliente(id);
        if(clicola == null)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Cliente no encontrado");
            Console.ResetColor();
            return;
        }
        cola!.Encolar(clicola);
    }


    public void AtenderSiguiente()
    {
        Cliente? clieTend = cola!.Atender();
        if(clieTend == null)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("No hay clientes para atender");
            Console.ResetColor();
            return;
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Atendiendo a: {clieTend.Nombre}");
        Console.ResetColor();
    }


    public void DeshacerTransaccion()
    {
        Transaccion? ultima = historial!.BuscTransac();
        if(ultima == null)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("No hay transacciones para deshacer");
            Console.ResetColor();
            return;
        }
        if(ultima.Tipo == "Deposito")
        {
            ultima.clienteTrans.Saldo -= ultima.Monto;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Deshaciendo {ultima.Tipo} de {ultima.clienteTrans.Nombre} por {ultima.Monto}");
            Console.ResetColor();
        }
        else
        {
            ultima.clienteTrans.Saldo += ultima.Monto;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Deshaciendo {ultima.Tipo} de {ultima.clienteTrans.Nombre} por {ultima.Monto}");
            Console.ResetColor();
        }

    }



    public void HistorialTransacciones()
    {
            
            Console.Write("Ingrese Documento de cliente: ");
            int IdHis = int.Parse(Console.ReadLine()!);
            historial.HistorialTran(IdHis);
        
    }
}