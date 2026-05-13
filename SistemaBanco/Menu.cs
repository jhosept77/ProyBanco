using System;

public class Menu
{
    Banco banco = new Banco();


    public void Iniciar()
{
    int opcion = 0;
    while(opcion != 13)
    {
        Console.WriteLine("1. Registrar cliente");
        Console.WriteLine("2. Listar clientes");
        Console.WriteLine("3. Buscar cliente");
        Console.WriteLine("4. Agregar turno");
        Console.WriteLine("5. Atender siguiente");
        Console.WriteLine("6. Depositar");
        Console.WriteLine("7. Retirar");
        Console.WriteLine("8. Consultar saldo");
        Console.WriteLine("9. Deshacer transaccion");
        Console.WriteLine("10. Mostrar cola");
        Console.WriteLine("11. Total clientes");
        Console.WriteLine("12. Total dinero");
        Console.WriteLine("13. Salir");

        Console.Write("Elige una opcion: ");
        opcion = int.Parse(Console.ReadLine()!);

        switch(opcion)
        {
            case 1:
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine()!;
                Console.Write("Documento: ");
                    try
                    {
                        int id = int.Parse(Console.ReadLine()!);
                        Console.Write("Saldo inicial: ");
                        double saldo = double.Parse(Console.ReadLine()!);
                        banco.RegistraCliente(nombre, id, saldo);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("CLIENTE REGISTRADO CON EXITO !!");
                        Console.ResetColor();
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("DOCUMENTO INVALIDO !!");
                        Console.ResetColor();
                    }
                break;
                

                
            case 2:
                banco.ListarClientes();
                break;



            case 3:
                try{
                Console.Write("Ingrese documento a buscar: ");
                int idBusc = int.Parse(Console.ReadLine()!);
                Cliente? busc = banco.BuscarCliente(idBusc)!;
                if(busc == null)
                    {
                        Console.WriteLine("Cliente no encontrado");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Nombre: {busc.Nombre} | No Cuenta: {busc.NumeroCuenta} | Saldo: {busc.Saldo}");
                    }
                }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("DOCUMENTO INVALIDO !!");
                        Console.ResetColor();
                    }
                break;
            



            case 4:
                try{
                Console.Write("Ingrese documento a agregar turno: ");
                int idAgre = int.Parse(Console.ReadLine()!);
                banco.AgregarTurno(idAgre);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TURNO AGREGADO CON EXITO !!");
                Console.ResetColor();
                }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("DOCUMENTO INVALIDO !!");
                        Console.ResetColor();
                    }
                break;




            
            case 5:
                banco.AtenderSiguiente();
                break;




            case 6:
                try{
                Console.Write("Ingresa documento del cliente: ");
                int idDep = int.Parse(Console.ReadLine()!);
                Console.Write("Ingrese monto a depositar: ");
                double MonDep = double.Parse(Console.ReadLine()!);
                banco.Despositar(idDep, MonDep);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DEPOSITO EXITOSO !!");
                Console.ResetColor();
                }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("DOCUMENTO INVALIDO !!");
                        Console.ResetColor();
                    }
                break;




            case 7:
                try{
                Console.Write("Ingresa documento del cliente: ");
                int idRet = int.Parse(Console.ReadLine()!);
                Console.Write("Ingrese monto a retirar: ");
                double MonRet = double.Parse(Console.ReadLine()!);
                banco.Retirar(idRet, MonRet);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("RETIRO EXITOSO !!");
                Console.ResetColor();
                }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("DOCUMENTO INVALIDO !!");
                        Console.ResetColor();
                    }
                break;




            case 8:
                try{
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Ingresa documento del cliente: ");
                Console.ResetColor();
                int idSald = int.Parse(Console.ReadLine()!);
                double saldoActual = banco.ConsultarSaldo(idSald);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Saldo actual: {saldoActual}");
                Console.ResetColor();
                }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("DOCUMENTO INVALIDO !!");
                        Console.ResetColor();
                    }
                break;




            case 9:
                banco.DeshacerTransaccion();
                break;




            case 10:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("COLA DE ATENCION");
                Console.ResetColor();
                banco.MostrarCola();
                break;




            case 11:
            Console.WriteLine($"Total clientes: {banco.TostalClientes()}");
            break;





            case 12:
            Console.WriteLine($"Total dinero: {banco.TotalDinero()}");
            break;




            case 13:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Terminado !!");
                Console.ResetColor();
                break;



            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("opcion invalida intente de nuevo");
                Console.ResetColor();
                break;

        }
    }
}
}