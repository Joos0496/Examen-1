using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen___1
{
    internal class ClsMenu
    {
        public static ClsEmpleados[] arregloEmpleados = new ClsEmpleados[0];
        public static ClsEmpleados[] cant = new ClsEmpleados[] { };
        public static void EjecutarMenu()
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1 - Agregar Empleado");
                Console.WriteLine("2 - Consultar Empleado");
                Console.WriteLine("3 - Modificar Empleado");
                Console.WriteLine("4 - Borrar Empleado");
                Console.WriteLine("5 - Inicializar Arreglos");
                Console.WriteLine("6 - Reportes");
                Console.WriteLine("Digite una opcion");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        AgregarEmpleado();
                        break;
                    case 2:
                        Console.Clear();
                        ConsultarEmpleado();

                        break;
                    case 3:
                        Console.Clear();
                        ModificarEmpleado();
                        break;
                    case 4:
                        Console.Clear();
                        BorrarEmpleado();
                        break;
                    case 5:
                        Console.Clear();
                        InicializarArreglos();
                        break;
                    case 6:
                        Console.Clear();
                        Reportes();
                        break;

                    default:
                        break;

                }


            } while (opcion != 7);


        }
        public static void SubMenu()
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("Reportes");
                Console.WriteLine("1 - Consultar empleado");
                Console.WriteLine("2 - Listar todos los empleados");
                Console.WriteLine("3 - Mostrar el promedio de los salarios");
                Console.WriteLine("4 - Mostrar el salario más alto y el más bajo de todos los empleados");
                Console.WriteLine("Digite una opcion");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        ConsultarEmpleado();
                        break;
                    case 2:
                        Console.Clear();
                        ConsultarListaEmpleados();
                        break;
                    case 3:
                        Console.Clear();
                        PromedioSalarios();
                        break;
                    case 4:
                        Console.Clear();
                        CalcularSalarioMenorySalarioMayor();
                        break;
                    default:
                        break;

                }


            } while (opcion != 5);


        }
        static void AgregarEmpleado()
        {
            Console.Write("Ingrese la cedula: ");
            string cedula = Console.ReadLine();
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la direccion: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingrese el telefono: ");
            string telefono = Console.ReadLine();
            Console.Write("Ingrese el salario: ");
            double salario = double.Parse(Console.ReadLine());

            Array.Resize(ref arregloEmpleados, arregloEmpleados.Length + 1);
            ClsEmpleados empleado = new ClsEmpleados(cedula, nombre, direccion, telefono, salario);
            arregloEmpleados[arregloEmpleados.Length - 1] = empleado;


            Console.WriteLine("El empleado ha sido agregado");
        }
        public static void ConsultarListaEmpleados()
        {
            Console.WriteLine("Lista de Empleados:");
            for (int i = 0; i < arregloEmpleados.Length; i++)
            {
                Console.WriteLine($"Cedula: {arregloEmpleados[i].Cedula}");
                Console.WriteLine($"Nombre: {arregloEmpleados[i].Nombre}");
                Console.WriteLine($"Direccion: {arregloEmpleados[i].Direccion}");
                Console.WriteLine($"Telefono: {arregloEmpleados[i].Telefono}");
                Console.WriteLine($"Salario: {arregloEmpleados[i].Salario}");
                Console.WriteLine();
            }
        }
        public static void ConsultarEmpleado()
        {
            Console.Write("Ingrese el numero de cedula: ");
            string cedula = Console.ReadLine();

            ClsEmpleados empleados = arregloEmpleados.FirstOrDefault(item => item.Cedula == cedula);
            if (empleados == null)
            {
                Console.WriteLine("El empleado no esta registrado");
            }
            else
            {
                Console.WriteLine($"Cedula: {empleados.Cedula}");
                Console.WriteLine($"Nombre: {empleados.Nombre}");
                Console.WriteLine($"Direccion: {empleados.Direccion}");
                Console.WriteLine($"Telefono: {empleados.Telefono}");
                Console.WriteLine($"Salario: {empleados.Salario}");
                Console.WriteLine();
            }
        }
        public static void ModificarEmpleado()
        {
            Console.Write("Ingrese el numero de cedula: ");
            string cedula = Console.ReadLine();
            ClsEmpleados empleado_a_editar = Array.Find(arregloEmpleados, empleado => empleado.Cedula == cedula);
            if (empleado_a_editar == null)
            {
                Console.WriteLine("El empleado no esta registrado");
            }
            else
            {
                Console.Write("Ingrese el nombre: ");
                empleado_a_editar.Nombre = Console.ReadLine();
                Console.Write("Ingrese la direccion: ");
                empleado_a_editar.Direccion = Console.ReadLine();
                Console.Write("Ingrese el telefono: ");
                empleado_a_editar.Telefono = Console.ReadLine();
                Console.Write("Ingrese el salario: ");
                empleado_a_editar.Salario = double.Parse(Console.ReadLine());
                Console.WriteLine("Empleado ha sido actualizado");
            }

        }
        public static void BorrarEmpleado()
        {
            Console.Write("Ingrese el numero de cedula: ");
            string cedula = Console.ReadLine();
            ClsEmpleados eliminarempleado = Array.Find(arregloEmpleados, empleado => empleado.Cedula == cedula);
            if (eliminarempleado == null)
            {
                Console.WriteLine("El empleado no esta registrado");
            }
            else
            {
                int indiceEmpl = Array.FindIndex(arregloEmpleados, empleados => empleados.Cedula == eliminarempleado.Cedula);
                arregloEmpleados = arregloEmpleados.Where((empleado, indice) => indice != indiceEmpl).ToArray();
                Console.WriteLine("El empleado ha sido eliminado");
            }
        }
        public static void Reportes()
        {
            SubMenu();
        }
        public static void InicializarArreglos()
        {
            arregloEmpleados = new ClsEmpleados[] { };
            Console.WriteLine("Lista de empleados ha sido limpiada.");
        }
        public static void PromedioSalarios()
        {

            double sum = 0.0;
            int count = arregloEmpleados.Length;
            for (int i = 0; i < arregloEmpleados.Length; i++)
            {
                sum += arregloEmpleados[i].Salario;
            }
            double promedioSalarios = sum/count;

            Console.WriteLine($"El promedio de los salarios registrados es: {promedioSalarios}");
        }
        public static void CalcularSalarioMenorySalarioMayor()
        {
            ClsEmpleados salarioMenor = arregloEmpleados.OrderBy(empleado => empleado.Salario).First();
            ClsEmpleados salarioMayor = arregloEmpleados.OrderByDescending(empleado => empleado.Salario).First();

            Console.WriteLine($"El empleado con el salario menor es: {salarioMenor.Nombre} , su salario es de: {salarioMenor.Salario}");
            Console.WriteLine($"El empleado con el salario mayor es: {salarioMayor.Nombre} , su salario es de: {salarioMayor.Salario}");
        }

    }


}
