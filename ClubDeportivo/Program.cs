/*
 * Created by SharpDevelop.
 * User: Soporte
 * Date: 21/05/2024
 * Time: 9:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Globalization;
using System.Net;

namespace ClubDeportivo
{
	class Program
	{
		
		
		public static void Main(string[] args)
		{
			string selec = "";
			Club club;
			club=new Club();
            //INSTANCIACIÓN PARA AGREGAR UN DEPORTE	
			club.AgregarDeporte("Futbol", 2010, 24, 1250, 10, "Miercoles", "18:00");			
			club.AgregarDeporte("Voley", 2011, 16, 1000, 15, "Sabados", "17:00");
            club.AgregarDeporte("Voley", 2012, 16, 1000, 15, "Martes", "16:00");
            club.AgregarDeporte("Voley", 2013, 16, 1000, 15, "Jueves", "17:00");
            club.AgregarDeporte("Tenis", 2015, 10, 1500, 5, "Jueves", "18:00");
            club.AgregarDeporte("Tenis", 2015, 10, 1500, 5, "Viernes", "14:00");
            club.AgregarDeporte("Futbol", 2011, 24, 1250, 10, "Miercoles", "18:00");
            club.AgregarDeporte("Futbol", 2012, 24, 1250, 10, "Lunes", "10:00");

            //MENÚ DEL PROGRAMA
            do
			{
				menu();
				
				switch(selec = Console.ReadLine().ToUpper())
				{
					case "1":
						inscribirMenu(club);
						break;
					
					case "2":
						borrarInscriptoMenu(club);
						break;
						
					case "3":
						agregarDeporte(club);
						break;
						
					case "4":
						borrarDeporte(club);
						break;
						
					case "5":
						subMenuListas(club);
						break;
					
					case "6":
						pagoCuota(club);
						break;

                    case "7":
                        altaEntrenador(club);
                        break;

                    case "8":
                        bajaEntrenador(club);
                        break;

                    case "9":
                        asignarEntrenador(club);
                        break;

					case "X":
						break;

					default:
                        Console.WriteLine("Opción incorrecta. Vuelva a intentarlo.");
                        Console.Write("Presione cualquier tecla para continuar ...");
                        Console.ReadKey(true);
                        break;
                }
				
			}while(selec != "X");			
		}
		
		//MENÚ DEL PROGRAMA
		public static void menu()
		{
           
			Console.Clear();
			Console.WriteLine("****************************************************************************************************");
			Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
			Console.WriteLine("****************************************************************************************************");
			Console.WriteLine("");
			Console.WriteLine("----------------------------------------------- Menú -----------------------------------------------");
			Console.WriteLine("");
			Console.WriteLine(" 1 - Inscribir Niño/a a un Deporte.");
			Console.WriteLine(" 2 - Eliminar Niño/a a un Deporte.");
			Console.WriteLine(" 3 - Agregar Deporte.");
			Console.WriteLine(" 4 - Eliminar Deporte.");
			Console.WriteLine(" 5 - Ver Lista de Inscriptos y Deudores.");
			Console.WriteLine(" 6 - Pago de Cuota.");			
			Console.WriteLine(" 7 - Ingresar un nuevo Entrenador.");			
			Console.WriteLine(" 8 - Eliminar un Enrenador.");
            Console.WriteLine(" 9 - Asignar Entrenador a un Deporte.");
            Console.WriteLine(" X - Salir.");
			Console.WriteLine("");
			Console.WriteLine("Seleccione una opción:");
		}
		//MENÚ PARA INSCRIPTOS
		public static void subMenuInscriptos()
		{
			Console.Clear();
			Console.WriteLine("****************************************************************************************************");
			Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
			Console.WriteLine("****************************************************************************************************");
			Console.WriteLine("");
			Console.WriteLine("----------------------------------- Menú de Inscriptos y Deudores ----------------------------------");
			Console.WriteLine("");
			Console.WriteLine(" 1 - Lista de Inscriptos por Deporte.");
			Console.WriteLine(" 2 - Lista de Inscriptos por Deporte y Categoría.");
			Console.WriteLine(" 3 - Lista de Inscriptos Totales.");
			Console.WriteLine(" 4 - Lista de Deudores.");
			Console.WriteLine(" 9 - Volver al menu principal.");
			Console.WriteLine("");
			Console.WriteLine("Seleccione una opción:");
		}
		
        //PARA INSCRIBIR A UNA PERSONA
		public static void inscribirMenu(Club club)
		{
			string nombreApellido = "";
			int dni, edad, categoria, nroSocio, selDeporte, contador;
			ArrayList lista = new ArrayList();
			
			do{
				Console.Clear();
				Console.Clear();
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("");
				Console.WriteLine("-------------------------------------------- Inscripción -------------------------------------------");
				Console.WriteLine("");
				Console.WriteLine("Ingrese Nombre y Apellido.");
				nombreApellido = Console.ReadLine().Trim();
                nombreApellido = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreApellido);


                //INFORMACIÓN REQUERIDA PARA INSCRIBRIR A UNA PERSONA
                Console.WriteLine("Ingrese el DNI.");
				dni = int.Parse(Console.ReadLine());
				
				Console.WriteLine("Ingrese la edad.");
				edad = int.Parse(Console.ReadLine());
				
				Console.WriteLine("Ingrese la categoría.");
				categoria = int.Parse(Console.ReadLine());
				
				Console.WriteLine("Es Socio? S/N.");			
				if(Console.ReadLine().ToUpper() == "S")
				{
					Console.WriteLine("Ingrese el número de socio.");
					nroSocio = int.Parse(Console.ReadLine());	
				} 
				else
				{
					nroSocio = 0;
				}
				
				Console.WriteLine("Selecione el deporte de la siguiente lista.");
                Console.WriteLine("");


                contador = 1;
                foreach (Deporte dep in club.Deportes)
                {
					if(dep.Entrenador == null)
					{
                        Console.WriteLine("{0} - Deporte:{1}, Categoria: {2}, Entrenador: SIN ASIGNAR AÚN, Día: {3}, Hora: {4}", contador, dep.Nombre, dep.Categoria,  dep.dia, dep.hora);
                    }
					else
					{
                        Console.WriteLine("{0} - Deporte:{1}, Categoria: {2}, Entrenador: {3}, Día: {4}, Hora: {5}", contador, dep.Nombre, dep.Categoria, dep.Entrenador.Nombre, dep.dia, dep.hora);
                    }
                    contador++;
                }

                Console.WriteLine("");
                Console.WriteLine("Deporte:");

                selDeporte = int.Parse(Console.ReadLine());

                while ((selDeporte < 1) || (selDeporte > club.Deportes.Count))
                {
                    Console.WriteLine("");
                    Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.\n");
                    selDeporte = int.Parse(Console.ReadLine());
                }

                club.NuevoInscripto(selDeporte - 1, nombreApellido, dni, edad, categoria, nroSocio);

				Console.WriteLine("");				
				Console.WriteLine("¿Desea continuar con la inscripción? S/N");
				
			} while(Console.ReadLine().ToUpper() == "S");							
		}
		//MENÚ PARA BORRAR A UNA PERSONA INSCRIPTA
		public static void borrarInscriptoMenu(Club club)
		{
			int dni;
			
			do{
				Console.Clear();
				Console.Clear();
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("");
				Console.WriteLine("---------------------------------------- Borrar Inscripción ----------------------------------------");
				Console.WriteLine("");
				Console.WriteLine("Ingrese el número de DNI.");
				dni = int.Parse(Console.ReadLine());				
				club.borrarInscripto(dni);
				
				Console.WriteLine("");
				Console.WriteLine("¿Desea borrar a alguien mas? S/N");
				
			} while (Console.ReadLine().ToUpper() == "S");
		}
		//AGREGA UN DEPORTE
		public static void AgregarDeporte(Club club)
		{
			string nombre, dia, hora;
			int categoria, cupo, indice;
			float cuota, descuentoSocio;
			
			do{
				Console.Clear();
				Console.Clear();
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("");
				Console.WriteLine("------------------------------------------ Agregar Deporte -----------------------------------------");
				Console.WriteLine("");
				Console.WriteLine("Ingrese el nombre del Deporte.");
				nombre = Console.ReadLine();
				
				Console.WriteLine("Ingrese la categoría del Deporte.");
				categoria = int.Parse(Console.ReadLine());
				
				Console.WriteLine("Ingrese el cupo.");
				cupo = int.Parse(Console.ReadLine());
				
				Console.WriteLine("Ingrese el dia en que se realiza el Deporte.");
				dia = Console.ReadLine();
				
				Console.WriteLine("Ingrese el horario en que se realiza el Deporte.");
				hora = Console.ReadLine();
				
				Console.WriteLine("Ingrese el valor de la cuota.");
				cuota = float.Parse(Console.ReadLine());
				
				Console.WriteLine("Ingrese el porcentaje de descuento para Socios.");
				descuentoSocio = float.Parse(Console.ReadLine());
								
				if((indice = club.ExisteDepYCat(nombre, categoria)) != -1)
				{
					Console.WriteLine("El deporte \"{0}\" y la categoria {1} ya existe.", nombre, categoria);
				}
				else
				{
					club.AgregarDeporte(nombre, categoria, cupo, cuota, descuentoSocio, dia, hora);
					Console.WriteLine("El deporte se agrego correctamente.");
				}
				
				Console.WriteLine("");
				Console.WriteLine("¿Desea agregar otro Deporte? S/N");				
			} while (Console.ReadLine().ToUpper() == "S");
		}
		//BORRA UN DEPORTE
		public static void borrarDeporte(Club club)
		{
			int contador, selDeporte;
			
			do{
				Console.Clear();
				Console.Clear();
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("");
				Console.WriteLine("----------------------------------------- Eliminar Deporte -----------------------------------------");
				Console.WriteLine("");
                
                Console.WriteLine("Selecione el deporte a eliminar de la siguiente lista.");
                Console.WriteLine("");

				contador = 1;
				foreach (Deporte dep in club.Deportes)
				{
                    if (dep.Entrenador == null)
                    {
                        Console.WriteLine("{0} - Deporte:{1}, Categoría: {2}, Entrenador: NO TIENE , Día: {3}, Hora: {4}", contador, dep.Nombre, dep.Categoria, dep.dia, dep.hora);
                    }
                    else
                    {
                        Console.WriteLine("{0} - Deporte:{1}, Categoría: {2}, Entrenador: {3}, Día: {4}, Hora: {5}", contador, dep.Nombre, dep.Categoria, dep.Entrenador.Nombre, dep.dia, dep.hora);
                    }
					contador++;
                }

                Console.WriteLine("");
                Console.WriteLine("Eliminar:");
                selDeporte = int.Parse(Console.ReadLine());

                while ((selDeporte < 1) || (selDeporte > club.Deportes.Count))
                {
                    Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.\n");
                    selDeporte = int.Parse(Console.ReadLine());
                }

                if (club.EstaVacioDeporte(selDeporte - 1) == true)
                {
                    club.EliminarDeporte(selDeporte - 1);
                    Console.WriteLine("El deporte elimino correctamente.");
                }
                else
                {
                    Console.WriteLine("El deporte que intenta eliminar tiene inscriptos y NO SE PUEDE ELIMINAR");
                }
				
				Console.WriteLine("");
				Console.WriteLine("¿Desea borrar algún reporte mas? S/N");
				
			} while (Console.ReadLine().ToUpper() == "S");
		}
		
		public static void subMenuListas(Club club)
		{
			string selec;
			int selDeporte, selCategoria;

			ArrayList listaDep = new ArrayList();
            ArrayList listaCat = new ArrayList();
            int contador = 1;
			
			do{				
				subMenuInscriptos();
				
				switch(selec = Console.ReadLine())
				{
					case "1":
                        Console.WriteLine("");
                        Console.WriteLine("Selecione el deporte.");
                        Console.WriteLine("");
                        listaDep = club.ListaDeportes();

                        contador = 1;
                        foreach (Deporte dep in listaDep)
						{
							Console.WriteLine("{0} - {1}", contador, dep.Nombre);
							contador++;
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Deporte:");

                        selDeporte = int.Parse(Console.ReadLine());

                        while ((selDeporte < 1) || (selDeporte > listaDep.Count))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.\n");
                            selDeporte = int.Parse(Console.ReadLine());
                        }
						
						Console.Clear();
						Console.WriteLine("Lista de inscriptos a {0}.", ((Deporte)listaDep[selDeporte - 1]).Nombre);
                        club.ListaInscPorDep(((Deporte)listaDep[selDeporte - 1]).Nombre);
                        Console.WriteLine("");
                        Console.Write("Pulse una tecla para continuar . . . ");
                        Console.ReadKey(true);
                        break;
					
					case "2":
						// seleccion del deporte
                        Console.WriteLine("Selecione el deporte.");
                        Console.WriteLine("");
                        listaDep = club.ListaDeportes();

                        contador = 1;
                        foreach (Deporte dep in listaDep)
                        {
                            Console.WriteLine("{0} - {1}", contador, dep.Nombre);
                            contador++;
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Deporte:");

                        selDeporte = int.Parse(Console.ReadLine());

                        while ((selDeporte < 1) || (selDeporte > listaDep.Count))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.\n");
                            selDeporte = int.Parse(Console.ReadLine());
                        }

                        // seleccion de la categoría
                        Console.WriteLine("");
                        Console.WriteLine("Selecione la categoría.");
                        Console.WriteLine("");
                        listaCat = club.ListaCategoriaXDeporte(((Deporte)listaDep[selDeporte - 1]).Nombre);

                        contador = 1;
                        foreach (Deporte dep in listaCat)
                        {
                            Console.WriteLine("{0} - {1}, Categoría: {2}", contador, dep.Nombre, dep.Categoria);
                            contador++;
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Categoría:");

                        selCategoria = int.Parse(Console.ReadLine());

                        while ((selCategoria < 1) || (selCategoria > listaCat.Count))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.\n");
                            selCategoria = int.Parse(Console.ReadLine());
                        }

                        // impresion de la lista de inscriptos
                        Console.Clear();
                        Console.WriteLine("Lista de inscriptos a {0} en la categoría {1}", ((Deporte)listaDep[selDeporte - 1]).Nombre, ((Deporte)listaCat[selCategoria - 1]).Categoria);
                        club.ListaInscPorDepYCat(((Deporte)listaDep[selDeporte - 1]).Nombre, ((Deporte)listaCat[selCategoria - 1]).Categoria);
                        Console.WriteLine("");
                        Console.Write("Pulse una tecla para continuar . . . ");
                        Console.ReadKey(true);
                        break;
						
					case "3":
                        Console.Clear();
                        Console.WriteLine("Lista de todos los inscriptos.");
						club.ListaInscTotal();
                        Console.WriteLine("");
                        Console.Write("Pulse una tecla para continuar . . . ");
                        Console.ReadKey(true);
                        break;
						
					case "4":
                        Console.Clear();
                        Console.WriteLine("Lista de deudores.");
						club.ListaDeudores();
                        Console.WriteLine("");
                        Console.Write("Pulse una tecla para continuar . . . ");
                        Console.ReadKey(true);
                        break;

					case "9":
						break;

					default:
                        Console.WriteLine("Opción incorrecta. Vuelva a intentarlo.");
                        break;
				}                
            } while (selec != "9");
		}
		/*MODIFICACIÓN DE CAMELCASE
        public staticvoid pagoCuota(Club Club*/
		public static void PagoCuota(Club club)
		{
			int dni;
			
			do{
				Console.Clear();
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
				Console.WriteLine("****************************************************************************************************");
				Console.WriteLine("");
				Console.WriteLine("-------------------------------------------- Pagar Cuota -------------------------------------------");
				Console.WriteLine("");
				
				Console.WriteLine("Ingrese el número de DNI.");
				dni = int.Parse(Console.ReadLine());				
				//club.pagarCuota(dni);
				
				if(club.ExisteInscripto(dni) == true)
				{
					club.VerValorCuota(dni);
					
					Console.WriteLine("¿Se procede a registrar el pago? S/N");
					
					if(Console.ReadLine().ToUpper() == "S"){
						if(club.PagarCuota(dni))
						{
							Console.WriteLine("Pago realizado.");
						}
					}
				}
				else
				{
					Console.WriteLine("¡El DNI ingresado no existe!");
				}
				
				Console.WriteLine("");
				Console.WriteLine("¿Desea ingresar otro pago? S/N");
				
			} while (Console.ReadLine().ToUpper() == "S");
		}

		public static void altaEntrenador(Club club)
		{
			string nombre;
            int dni;

            do
            {
                Console.Clear();
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------- Ingresar Entrenador ---------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("Ingrese el nombre del Entrenador.");
                nombre = Console.ReadLine().Trim();
                nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombre);

                Console.WriteLine("Ingrese el número de DNI.");
                dni = int.Parse(Console.ReadLine());

                if (club.BuscarEntrenador(dni) == -1)
                {
                    club.AgregarEntrenador(nombre, dni);

                    Console.WriteLine("Entrenador ingresado corectamente.");
                }
                else
                {
                    Console.WriteLine("Entrenador ya ingresado.");
                }

                Console.WriteLine("");
                Console.WriteLine("¿Desea ingresar otro Entrenador? S/N");

            } while (Console.ReadLine().ToUpper() == "S");
        }

        public static void bajaEntrenador(Club club)
        {
            int dni, indiceDep, indiceEntrenador;

            do
            {
                Console.Clear();
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------- Eliminar Entrenador ---------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("Ingrese el número de DNI.");
                dni = int.Parse(Console.ReadLine());

                if ((indiceEntrenador = club.BuscarEntrenador(dni)) != -1)
                {
                    club.EliminarEntrenador(indiceEntrenador);

                    if ((indiceDep = club.BuscarEntrenadorDeporte(dni)) != -1)
					{
                        club.QuitarEntrenadorDeporte(indiceDep, dni);
                    }					
                    
                    Console.WriteLine("Entrenador eliminado correctamete.");
                }
                else
                {
                    Console.WriteLine("El DNI ingresado no corresponde a ningun Entrenador.");
                }

                Console.WriteLine("");
                Console.WriteLine("¿Desea eliminar otro Entrenador? S/N");

            } while (Console.ReadLine().ToUpper() == "S");
        }

        public static void asignarEntrenador(Club club)
        {
            int dni, selDeporte;
            int contador = 1;

            do
            {
                Console.Clear();
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("****                                     Club Deportivo AYP                                     ****");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------- Asignar Entrenador ----------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("Ingrese el número de DNI.");
                dni = int.Parse(Console.ReadLine());

                if (club.BuscarEntrenador(dni) != -1)
                {
                    Console.WriteLine("Selecione el deporte que se le asignara.");
                    Console.WriteLine("");

                    contador = 1;
                    foreach (Deporte dep in club.Deportes)
                    {
						if (dep.Entrenador == null)
						{
                            Console.WriteLine("{0} - Deporte:{1}, Categoria: {2}, Día: {3}, Hora: {4}", contador, dep.Nombre, dep.Categoria, dep.dia, dep.hora);
                            contador++;
                        }                        
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Deporte:");

                    selDeporte = int.Parse(Console.ReadLine());

                    while ((selDeporte < 1) || (selDeporte > club.Deportes.Count))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.\n");
                        selDeporte = int.Parse(Console.ReadLine());
                    }

                    club.AgregarEntrenador(selDeporte - 1, dni);

                    Console.WriteLine("Entrenador asignado correctamente.");
                }
                else
                {
                    Console.WriteLine("El DNI ingresado no corresponde a ningun Entrenador.");
                }

                Console.WriteLine("");
                Console.WriteLine("¿Desea ingresar otro Entrenador? S/N");

            } while (Console.ReadLine().ToUpper() == "S");
        }
    }
}
/*ARREGLE LO DEL CamelCase*/
/*CAMELCASE SUJETO A MODIFICACIONES*/