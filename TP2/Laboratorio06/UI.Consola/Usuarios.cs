using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic UsuarioNegocio;



        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            int opc;
            bool val = false;

            WriteLine("\nBienvenido Usuario, a continuacion, seleccione:\n");

            do
            {
                do
                {
                    Console.Clear();
                    WriteLine("1– Listado General");
                    WriteLine("2– Consulta");
                    WriteLine("3– Agregar");
                    WriteLine("4- Modificar");
                    WriteLine("5- Eliminar");
                    WriteLine("6- Salir");
                    WriteLine("\n Ingrese una opcion (1-6):");

                    opc = int.Parse(Console.ReadLine());

                    if (opc > 0 && opc < 7)
                    {
                        val = true;
                    }
                    else
                    {
                        WriteLine("\n               !!\nLa opcion ingresada no es valida\n(presione Enter para continuar)");
                        ReadLine();
                    }

                    Clear();

                } while (val == false);

                switch (opc)
                {
                    case 1:
                        ListadoGeneral();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Agregar();
                        break;
                    case 4:
                        Modificar();
                        break;
                    case 5:
                        Eliminar();
                        break;
                    case 6:
                        WriteLine("Gracias vuelva prontos");
                        break;
                }
            } while (opc != 6);

            ReadKey();

        }
        public void ListadoGeneral()
        {
            try
            {
                Clear();
                foreach (Usuario usr in UsuarioNegocio.GetAll())
                {
                    MostrarDatos(usr);
                }
            }
            catch (FormatException fe)
            {
                WriteLine();
                WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                WriteLine();
                WriteLine(e.Message);
            }
            finally
            {
                WriteLine("Presione una tecla para continuar");
                ReadKey();
            }
        }
        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");

            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una techa para continuar");
                Console.ReadKey();
            }
        }
        public void Agregar()
        {
            Usuario usuario = new Usuario();

            Clear();
            Write("Ingrese Nombre: ");
            usuario.Nombre = ReadLine();
            Write("Ingrese Apellido: ");
            usuario.Apellido = ReadLine();
            Write("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = ReadLine();
            Write("Ingrese Clave: ");
            usuario.Clave = ReadLine();
            Write("Ingrese Email: ");
            usuario.EMail = ReadLine();
            Write("Ingrese Habilitacion de Usuario (1-Si / Otro-No): ");
            usuario.Habilitado = (ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            WriteLine();
            WriteLine("ID: {0}", usuario.ID);


        }
        public void Modificar()
        {
            try
            {
                Clear();
                Write("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(ReadLine());
                Usuario usr = UsuarioNegocio.GetOne(ID);
                Write("Ingrese Nombre: ");
                usr.Nombre = ReadLine();
                Write("Ingrese Apellido: ");
                usr.Apellido = ReadLine();
                Write("Ingrese Nombre de Usuario: ");
                usr.NombreUsuario = ReadLine();
                Write("Ingrese Clave: ");
                usr.Clave = ReadLine();
                Write("Ingrese Email: ");
                usr.EMail = ReadLine();
                Write("Ingrese Habilitacion de Usuario (1-Si / Otro-No): ");
                usr.Habilitado = (ReadLine() == "1");
                usr.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usr);

            }
            catch (FormatException fe)
            {
                WriteLine();
                WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                WriteLine();
                WriteLine(e.Message);
            }
            finally
            {
                WriteLine("Presione una tecla para continuar");
                ReadKey();
            }
        }
        public void Eliminar()
        {
            try
            {
                Clear();
                Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                WriteLine();
                WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                WriteLine();
                WriteLine(e.Message);
            }
            finally
            {
                WriteLine("Presione una tecla para continuar");
                ReadKey();
            }
        }
        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\t Nombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.EMail);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
          
        }

    }
}
