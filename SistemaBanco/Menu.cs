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
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine()!);
                Console.Write("Numero de cuenta: ");
                int cuenta = int.Parse(Console.ReadLine()!);
                Console.Write("Saldo inicial: ");
                double saldo = double.Parse(Console.ReadLine()!);
                banco.RegistraCliente(nombre, id, cuenta, saldo);
                break;
                
            case 2:
                banco.ListarClientes();
                break;

            case 3:
                Console.Write("Ingrese ID a buscar: ");
                int idBusc = int.Parse(Console.ReadLine()!);
                Cliente? busc = banco.BuscarCliente(idBusc)!;
                if(busc == null)
                    {
                        Console.WriteLine("Cliente no encontrado");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Nombre: {busc.Nombre} | Saldo: {busc.Saldo}");
                    }
                break;
            
            case 4:
                Console.Write("Ingrese un ID a agregar turno: ");
                int idAgre = int.Parse(Console.ReadLine()!);
                banco.AgregarTurno(idAgre);
                break;

            
            case 5:
                banco.AtenderSiguiente();
                break;


            case 6:
                Console.Write("Ingresa un ID de cliente");
                int idDep = int.Parse(Console.ReadLine()!);
                Console.Write("Ingrese monto a depositar");
                double MonDep = double.Parse(Console.ReadLine()!);
                banco.Despositar(idDep, MonDep);
                break;


            case 7:
                Console.Write("Ingresa un ID de cliente");
                int idRet = int.Parse(Console.ReadLine()!);
                Console.Write("Ingrese monto a retirar");
                double MonRet = double.Parse(Console.ReadLine()!);
                banco.Retirar(idRet, MonRet);
                break;


            case 8:
                Console.Write("Ingresa un ID de cliente");
                int idSald = int.Parse(Console.ReadLine()!);
                banco.ConsultarSaldo(idSald);
                break;


            case 9:
                banco.DeshacerTransaccion();
                break;


            case 10:
                banco.MostrarCola();
                break;


            case 11:
            Console.WriteLine($"Total clientes: {banco.TostalClientes()}");
            break;



            case 12:
            Console.WriteLine($"Total dinero: {banco.TotalDinero()}");
            break;


            case 13:
                Console.Write("Terminado !!");
                break;

            default:
                Console.WriteLine("opcion invalida intente de nuevo");
                break;

        }
    }
}
}