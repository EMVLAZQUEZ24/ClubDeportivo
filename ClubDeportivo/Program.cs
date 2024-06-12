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
			
			/* se crean deportes para cuestiones de prueba */			
			club.AgregarDeporte("Futbol", 2010, 1, 1250, 10, "Miercoles", "18:00");			
			club.AgregarDeporte("Voley", 2011, 16, 1000, 15, "Sabados", "17:00");
            club.AgregarDeporte("Voley", 2012, 16, 1000, 15, "Martes", "16:00");
            club.AgregarDeporte("Voley", 2013, 16, 1000, 15, "Jueves", "17:00");
            club.AgregarDeporte("Tenis", 2015, 10, 1500, 5, "Jueves", "18:00");
            club.AgregarDeporte("Tenis", 2014, 10, 1500, 5, "Viernes", "14:00");
            club.AgregarDeporte("Futbol", 2011, 24, 1250, 10, "Miercoles", "18:00");
            club.AgregarDeporte("Futbol", 2012, 24, 1250, 10, "Lunes", "10:00");
			
            /* Menu principal */
            do
			{
				Menu();
				
				switch(selec = Console.ReadLine().ToUpper())
				{
					/* inscribir */
					case "1":
						InscribirMenu(club);
						break;
					
					/* borrar inscriptcion */
					case "2":
						BorrarInscriptoMenu(club);
						break;
					
					/* agregar deporte */						
					case "3":
						AgregarDeporte(club);
						break;
					
					/* borrar deporte */
					case "4":
						BorrarDeporte(club);
						break;
						
					/* submenu para mostrar inscriptos y deudores */
					case "5":
						SubMenuListas(club);
						break;
					
					/* pago de la cuota */
					case "6":
						PagoCuota(club);
						break;
					
					/* alta entrenador */
                    case "7":
                        AltaEntrenador(club);
                        break;
				
                    /* baja entrenador */
                    case "8":
                        BajaEntrenador(club);
                        break;

                    /* asignar entrenador a un deporte */
                    case "9":
                        SeleccionarEntrenador(club);
                        break;
					
                    /* salir de la aplicacion */
					case "X":
						break;
					
					/* mensaje de error el ingresar una opcion incorrecta */
					default:
                        Console.WriteLine("Opción incorrecta. Vuelva a intentarlo.");
                        Console.Write("Presione cualquier tecla para continuar ...");
                        Console.ReadKey(true);
                        break;
                }
				
			}while(selec != "X");			
		}
		
		
		/* menu */
		public static void Menu()
		{
			Console.Clear();
			Console.BackgroundColor = ConsoleColor.Blue;
        	Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("                                                                                                    ");
			Console.WriteLine("                                         Club Deportivo AYP                                         ");
			Console.WriteLine("                                                                                                    ");
        	Console.ResetColor();			
			Console.WriteLine("");
			Console.BackgroundColor = ConsoleColor.DarkGray;
        	Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("                                                Menú                                                ");
			Console.ResetColor();
			Console.WriteLine("");
			Console.WriteLine(" 1 - Inscribir Niño/a a un Deporte.");
			Console.WriteLine(" 2 - Eliminar Niño/a a un Deporte.");
			Console.WriteLine(" 3 - Agregar Deporte."); 
			Console.WriteLine(" 4 - Eliminar Deporte.");
			Console.WriteLine(" 5 - Ver Lista de Inscriptos y Deudores.");
			Console.WriteLine(" 6 - Pago de Cuota.");			 
			Console.WriteLine(" 7 - Ingresar un nuevo Entrenador.");			
			Console.WriteLine(" 8 - Eliminar un Entrenador.");
            Console.WriteLine(" 9 - Asignar Entrenador a un Deporte.");
            Console.WriteLine(" X - Salir.");
			Console.WriteLine("");
			Console.WriteLine("Seleccione una opción:");
		}
		
		/* submenu */
		public static void SubMenuInscriptos()
		{
			Console.Clear();
			Console.BackgroundColor = ConsoleColor.Blue;
        	Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("                                                                                                    ");
			Console.WriteLine("                                         Club Deportivo AYP                                         ");
			Console.WriteLine("                                                                                                    ");
        	Console.ResetColor();			
			Console.WriteLine("");
			Console.BackgroundColor = ConsoleColor.DarkGray;
        	Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("                                    Menú de Inscriptos y Deudores                                   ");
			Console.ResetColor();
			Console.WriteLine("");
			Console.WriteLine(" 1 - Lista de Inscriptos por Deporte.");
			Console.WriteLine(" 2 - Lista de Inscriptos por Deporte y Categoría.");
			Console.WriteLine(" 3 - Lista de Inscriptos Totales.");
			Console.WriteLine(" 4 - Lista de Deudores.");
			Console.WriteLine(" 9 - Volver al menu principal.");
			Console.WriteLine("");
			Console.WriteLine("Seleccione una opción:");
		}
		
		/* menu de inscripcion */
		public static void InscribirMenu(Club club)
		{
			string nombreApellido = "";
			bool reintento = false;
			int dni, edad, categoria, nroSocio, selDeporte, contador, indiceEntrenador, resultado;
			ArrayList lista = new ArrayList();
			
			do{
				Console.Clear();
				Console.BackgroundColor = ConsoleColor.Blue;
        		Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                                                                                    ");
				Console.WriteLine("                                         Club Deportivo AYP                                         ");
				Console.WriteLine("                                                                                                    ");
        		Console.ResetColor();
				Console.WriteLine("");
				Console.BackgroundColor = ConsoleColor.DarkGray;
	        	Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                             Inscripción                                            ");
				Console.ResetColor();
				Console.WriteLine("");
				Console.WriteLine("Ingrese Nombre y Apellido.");
				nombreApellido = Console.ReadLine().Trim();
                nombreApellido = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreApellido);


                Console.WriteLine("Ingrese el DNI.");
				while(int.TryParse(Console.ReadLine(), out dni) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
				Console.WriteLine("Ingrese la edad.");
				while(int.TryParse(Console.ReadLine(), out edad) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
				Console.WriteLine("Ingrese la categoría.");
				while(int.TryParse(Console.ReadLine(), out categoria) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
				Console.WriteLine("Es Socio? S/N.");			
				if(Console.ReadLine().ToUpper() == "S")
				{
					Console.WriteLine("Ingrese el número de socio.");
					while(int.TryParse(Console.ReadLine(), out nroSocio) == false)
					{
						Console.WriteLine("");
						Console.BackgroundColor = ConsoleColor.DarkRed;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
						Console.ResetColor();
						Console.WriteLine("");
					}	
				} 
				else
				{
					nroSocio = 0;
				}
				
				Console.WriteLine("Selecione el deporte de la siguiente lista.");
                Console.WriteLine("");

				
                /* se muestra una lista de los deportes ya cargados para que el usuario elija una de las opciones */
                contador = 1;
                foreach (Deporte dep in club.Deportes)
                {
					if(dep.EntrenadorDni == 0)
					{
                        Console.WriteLine("{0} - Deporte:{1}, Categoria: {2}, Entrenador: SIN ASIGNAR AÚN, Día: {3}, Hora: {4}", contador, dep.Nombre, dep.Categoria,  dep.dia, dep.hora);
                    }
					else
					{
                        /* se obtiene el nombre del entrenado para agregarlo a la lista */
						indiceEntrenador = club.BuscarEntrenador(dep.EntrenadorDni);
						Console.WriteLine("{0} - Deporte:{1}, Categoría: {2}, Entrenador: {3}, Día: {4}, Hora: {5}", contador, dep.Nombre, dep.Categoria, ((Entrenador)club.Entrenadores[indiceEntrenador]).Nombre, dep.dia, dep.hora);
                    }
                    contador++;
                }

                Console.WriteLine("");
                Console.WriteLine("Deporte:");
				
                /* se ingresa el inscripto en el deporte seleccionado y si la opcion es incorrecta vuelve a pedir que seleccione nuevamente */
				while(int.TryParse(Console.ReadLine(), out selDeporte) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}	

                while ((selDeporte < 1) || (selDeporte > club.Deportes.Count))
                {
                    Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
        			Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.");
					Console.ResetColor();
					Console.WriteLine("");

					while(int.TryParse(Console.ReadLine(), out selDeporte) == false)
					{
						Console.WriteLine("");
						Console.BackgroundColor = ConsoleColor.DarkRed;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
						Console.ResetColor();
						Console.WriteLine("");
					}
                }

				resultado = club.NuevoInscripto(selDeporte - 1, nombreApellido, dni, edad, categoria, nroSocio);

				try
				{
					if (resultado == 0){
						throw new ClubCupoExcepcion();
					} 
					else if (resultado == 1)
					{
						Console.WriteLine("");
						Console.BackgroundColor = ConsoleColor.DarkGreen;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("{0} inscripto correctamente.", nombreApellido);
						Console.ResetColor();
						Console.WriteLine("");
					}
					else
					{
						Console.WriteLine("");
						Console.BackgroundColor = ConsoleColor.DarkRed;
        				Console.ForegroundColor = ConsoleColor.White;
						Console.Write("{0} ya se encuentra inscripto.", nombreApellido);
						Console.ResetColor();
						Console.WriteLine("");
					}	
				}
				catch(ClubCupoExcepcion)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
        			Console.ForegroundColor = ConsoleColor.White;
					Console.Write("Lamentablemente ya no hay cupo.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				catch(Exception e)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
        			Console.ForegroundColor = ConsoleColor.White;
					Console.Write("Error: {0}", e);
					Console.ResetColor();
					Console.WriteLine("");
				}

				Console.WriteLine("");
				Console.WriteLine("¿Desea continuar con la inscripción? S/N");
				
			} while(Console.ReadLine().ToUpper() == "S");							
		}
		
		/* borrar inscripto */
		public static void BorrarInscriptoMenu(Club club)
		{
			int dni;
			
			do{
				Console.Clear();
				Console.BackgroundColor = ConsoleColor.Blue;
        		Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                                                                                    ");
				Console.WriteLine("                                         Club Deportivo AYP                                         ");
				Console.WriteLine("                                                                                                    ");
        		Console.ResetColor();
				Console.WriteLine("");
				Console.BackgroundColor = ConsoleColor.DarkRed;
        		Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                         Borrar Inscripción                                         ");
				Console.ResetColor();
				Console.WriteLine("");
				Console.WriteLine("Ingrese el número de DNI.");
				while(int.TryParse(Console.ReadLine(), out dni) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}				
				
				if(club.BorrarInscripto(dni) != -1)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkGreen;
        			Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("Baja realizada con exito.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				else
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
        			Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("DNI no encontrado");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
				Console.WriteLine("¿Desea borrar a alguien mas? S/N");
				
			} while (Console.ReadLine().ToUpper() == "S");
		}
		
		/* agregar deporte */
		public static void AgregarDeporte(Club club)
		{
			string nombre, dia, hora;
			int categoria, cupo, indice;
			float cuota, descuentoSocio;
			
			do{
				Console.Clear();
				Console.BackgroundColor = ConsoleColor.Blue;
        		Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                                                                                    ");
				Console.WriteLine("                                         Club Deportivo AYP                                         ");
				Console.WriteLine("                                                                                                    ");
        		Console.ResetColor();
				Console.WriteLine("");
				Console.BackgroundColor = ConsoleColor.DarkGray;
        		Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                           Agregar Deporte                                          ");
				Console.ResetColor();
				Console.WriteLine("");
				Console.WriteLine("Ingrese el nombre del Deporte.");
				nombre = Console.ReadLine();
				
				Console.WriteLine("Ingrese la categoría del Deporte.");
				while(int.TryParse(Console.ReadLine(), out categoria) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
				Console.WriteLine("Ingrese el cupo.");
				while(int.TryParse(Console.ReadLine(), out cupo) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
				Console.WriteLine("Ingrese el dia en que se realiza el Deporte.");
				dia = Console.ReadLine();
				
				Console.WriteLine("Ingrese el horario en que se realiza el Deporte.");
				hora = Console.ReadLine();
				
				Console.WriteLine("Ingrese el valor de la cuota.");
				while(float.TryParse(Console.ReadLine(), out cuota) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
				Console.WriteLine("Ingrese el porcentaje de descuento para Socios.");
				while(float.TryParse(Console.ReadLine(), out descuentoSocio) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
				/* verifico si el deporte y la categoria ya existe antes de agregarla */				
				if((indice = club.ExisteDepYCat(nombre, categoria)) != -1)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
        			Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("El deporte \"{0}\" y la categoria {1} ya existe.", nombre, categoria);
					Console.ResetColor();
					Console.WriteLine("");
				}
				else
				{
					club.AgregarDeporte(nombre, categoria, cupo, cuota, descuentoSocio, dia, hora);

					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkGreen;
        			Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("El deporte se agrego correctamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
				Console.WriteLine("¿Desea agregar otro Deporte? S/N");				
			} while (Console.ReadLine().ToUpper() == "S");
		}
		
		/* borrar un deporte */
		public static void BorrarDeporte(Club club)
		{
			int contador, selDeporte, indiceEntrenador;
			
			do{
				Console.Clear();
				Console.BackgroundColor = ConsoleColor.Blue;
        		Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                                                                                    ");
				Console.WriteLine("                                         Club Deportivo AYP                                         ");
				Console.WriteLine("                                                                                                    ");
        		Console.ResetColor();
				Console.WriteLine("");
				Console.BackgroundColor = ConsoleColor.DarkRed;
        		Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                          Eliminar Deporte                                          ");
				Console.ResetColor();
				Console.WriteLine("");
                
                Console.WriteLine("Selecione el deporte a eliminar de la siguiente lista.");
                Console.WriteLine("");
				
                /* se muestra la lista de deportes cargados */
				contador = 1;
				foreach (Deporte dep in club.Deportes)
				{
                    if (dep.EntrenadorDni == 0)
                    {
                        Console.WriteLine("{0} - Deporte:{1}, Categoría: {2}, Entrenador: NO TIENE , Día: {3}, Hora: {4}", contador, dep.Nombre, dep.Categoria, dep.dia, dep.hora);
                    }
                    else
                    {
                        /* se obtiene el nombre del entrenado para agregarlo a la lista */
						indiceEntrenador = club.BuscarEntrenador(dep.EntrenadorDni);
						Console.WriteLine("{0} - Deporte:{1}, Categoría: {2}, Entrenador: {3}, Día: {4}, Hora: {5}", contador, dep.Nombre, dep.Categoria, ((Entrenador)club.Entrenadores[indiceEntrenador]).Nombre, dep.dia, dep.hora);
                    }
					contador++;
                }

                Console.WriteLine("");
                Console.WriteLine("Eliminar:");
				while(int.TryParse(Console.ReadLine(), out selDeporte) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
                /* se verifica que no haya inscriptos en el deporte antes de borrar */
                while ((selDeporte < 1) || (selDeporte > club.Deportes.Count))
                {
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
        			Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.");
					Console.ResetColor();
					Console.WriteLine("");

					while(int.TryParse(Console.ReadLine(), out selDeporte) == false)
					{
						Console.WriteLine("");
						Console.BackgroundColor = ConsoleColor.DarkRed;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
						Console.ResetColor();
						Console.WriteLine("");
					}
                }

                if (club.EstaVacioDeporte(selDeporte - 1) == true)
                {
                    club.EliminarDeporte(selDeporte - 1);

					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkGreen;
        			Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("El deporte elimino correctamente.");
					Console.ResetColor();
					Console.WriteLine("");
                }
                else
                {
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
        			Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("El deporte que intenta eliminar tiene inscriptos y NO SE PUEDE ELIMINAR.");
					Console.ResetColor();
					Console.WriteLine("");
                }
				
				Console.WriteLine("¿Desea borrar algún reporte mas? S/N");
				
			} while (Console.ReadLine().ToUpper() == "S");
		}
		
		/* submenu para mostrar lista de inscriptos y deudores */
		public static void SubMenuListas(Club club)
		{
			string selec, mes = "";			
			int selDeporte, selCategoria;
			
			ArrayList lista = new ArrayList();
			ArrayList listaDep = new ArrayList();
            ArrayList listaCat = new ArrayList();
            int contador = 1;
			
			do{				
				SubMenuInscriptos();
				
				switch(selec = Console.ReadLine())
				{
					/* lista de inscriptos por deporte */
					case "1":
                        Console.WriteLine("");
                        Console.WriteLine("Selecione el deporte.");
                        Console.WriteLine("");
                        listaDep = club.ListaDeportes();
						
                        /* lista de deportes cargados */
                        contador = 1;
                        foreach (Deporte dep in listaDep)
						{
							Console.WriteLine("{0} - {1}", contador, dep.Nombre);
							contador++;
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Deporte:");
						while(int.TryParse(Console.ReadLine(), out selDeporte) == false)
						{
							Console.WriteLine("");
							Console.BackgroundColor = ConsoleColor.DarkRed;
							Console.ForegroundColor = ConsoleColor.White;
							Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
							Console.ResetColor();
							Console.WriteLine("");
						}

                        while ((selDeporte < 1) || (selDeporte > listaDep.Count))
                        {
                            Console.WriteLine("");
							Console.BackgroundColor = ConsoleColor.DarkRed;
        					Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.");
							Console.ResetColor();
							Console.WriteLine("");

							while(int.TryParse(Console.ReadLine(), out selDeporte) == false)
							{
								Console.WriteLine("");
								Console.BackgroundColor = ConsoleColor.DarkRed;
								Console.ForegroundColor = ConsoleColor.White;
								Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
								Console.ResetColor();
								Console.WriteLine("");
							}
                        }
						
                        Console.Clear();
						Console.BackgroundColor = ConsoleColor.Blue;
        				Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("                                                                                                    ");
						Console.WriteLine("                                         Club Deportivo AYP                                         ");
						Console.WriteLine("                                                                                                    ");
        				Console.ResetColor();
						Console.WriteLine("");
						Console.BackgroundColor = ConsoleColor.DarkGray;
        				Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("                                   Lista de Inscriptos por Deporte                                  ");
						Console.ResetColor();
						
						lista = club.ListaInscPorDep(((Deporte)listaDep[selDeporte - 1]).Nombre);
						
						if(lista.Count > 0)
						{
							Console.WriteLine("");
							Console.WriteLine("Inscriptos a {0}:", ((Deporte)listaDep[selDeporte - 1]).Nombre);
							Console.WriteLine("");
						
							foreach(var lipd in lista)
							{
								foreach(var ld in (ArrayList)lipd)
								{
									string nombre = "";
									int dni = 0, edad = 0, nroSocio = 0;
									
									int dato = 0;
									
									foreach(var d in (ArrayList)ld)
									{
										switch (dato)
										{
											case 0:
												nombre = (string)d;
												dato++;
												break;
												
											case 1:
												dni = (int)d;
												dato++;
												break;
											
											case 2:
												edad = (int)d;
												dato++;
												break;
											
											case 3:
												nroSocio = (int)d;
												dato++;
												break;
										}
									}
									if(nroSocio == -1)
									{
										Console.WriteLine("Nombre: {0}, DNI: {1}, Edad: {2}, Número de Socio: -----", nombre, dni, edad);
									}
									else{
										Console.WriteLine("Nombre: {0}, DNI: {1}, Edad: {2}, Número de Socio: {3}", nombre, dni, edad, nroSocio);
									}
								}						
							}
						}
						else
						{
							Console.WriteLine("");
							Console.WriteLine("No hay inscriptos en {0}.", ((Deporte)listaDep[selDeporte - 1]).Nombre);
						}
                        
                        Console.WriteLine("");
                        Console.Write("Pulse una tecla para continuar . . . ");
                        Console.ReadKey(true);
                        break;
					
                    /* lista de inscriptos por deportes y categoria */
					case "2":
                        Console.WriteLine("Selecione el deporte.");
                        Console.WriteLine("");
                        listaDep = club.ListaDeportes();
						
                        /* lista de deportes y categorias cargados */
                        contador = 1;
                        foreach (Deporte dep in listaDep)
                        {
                            Console.WriteLine("{0} - {1}", contador, dep.Nombre);
                            contador++;
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Deporte:");

						while(int.TryParse(Console.ReadLine(), out selDeporte) == false)
						{
							Console.WriteLine("");
							Console.BackgroundColor = ConsoleColor.DarkRed;
							Console.ForegroundColor = ConsoleColor.White;
							Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
							Console.ResetColor();
							Console.WriteLine("");
						}

                        while ((selDeporte < 1) || (selDeporte > listaDep.Count))
                        {
                            Console.WriteLine("");
							Console.BackgroundColor = ConsoleColor.DarkRed;
        					Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.");
							Console.ResetColor();
							Console.WriteLine("");

							while(int.TryParse(Console.ReadLine(), out selDeporte) == false)
							{
								Console.WriteLine("");
								Console.BackgroundColor = ConsoleColor.DarkRed;
								Console.ForegroundColor = ConsoleColor.White;
								Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
								Console.ResetColor();
								Console.WriteLine("");
							}
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

						while(int.TryParse(Console.ReadLine(), out selCategoria) == false)
						{
							Console.WriteLine("");
							Console.BackgroundColor = ConsoleColor.DarkRed;
							Console.ForegroundColor = ConsoleColor.White;
							Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
							Console.ResetColor();
							Console.WriteLine("");
						}

                        while ((selCategoria < 1) || (selCategoria > listaCat.Count))
                        {
                            Console.WriteLine("");
							Console.BackgroundColor = ConsoleColor.DarkRed;
        					Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.");
							Console.ResetColor();
							Console.WriteLine("");

							while(int.TryParse(Console.ReadLine(), out selCategoria) == false)
							{
								Console.WriteLine("");
								Console.BackgroundColor = ConsoleColor.DarkRed;
								Console.ForegroundColor = ConsoleColor.White;
								Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
								Console.ResetColor();
								Console.WriteLine("");
							}
                        }

                        // impresion de la lista de inscriptos
                        Console.Clear();
						Console.BackgroundColor = ConsoleColor.Blue;
        				Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("                                                                                                    ");
						Console.WriteLine("                                         Club Deportivo AYP                                         ");
						Console.WriteLine("                                                                                                    ");
        				Console.ResetColor();
						Console.WriteLine("");
						Console.BackgroundColor = ConsoleColor.DarkGray;
        				Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("                             Lista de Inscriptos por Deporte y Categoria                            ");
						Console.ResetColor();
                        
                        lista = club.ListaInscPorDepYCat(((Deporte)listaDep[selDeporte - 1]).Nombre, ((Deporte)listaCat[selCategoria - 1]).Categoria);
                        
                        if(lista.Count > 0)
                        {
                        	Console.WriteLine("");
                        	Console.WriteLine("Inscriptos a {0} en la categoría {1}:", ((Deporte)listaDep[selDeporte - 1]).Nombre, ((Deporte)listaCat[selCategoria - 1]).Categoria);
                        	Console.WriteLine("");
                        
                        	foreach(var lipdyc in lista)
							{
								foreach(var ld in (ArrayList)lipdyc)
								{
									string nombre = "";
									int dni = 0, edad = 0, nroSocio = 0;
									
									int dato = 0;
									
									foreach(var d in (ArrayList)ld)
									{
										switch (dato)
										{
											case 0:
												nombre = (string)d;
												dato++;
												break;
												
											case 1:
												dni = (int)d;
												dato++;
												break;
											
											case 2:
												edad = (int)d;
												dato++;
												break;
											
											case 3:
												nroSocio = (int)d;
												break;
										}
									}
									if(nroSocio == -1)
									{
										Console.WriteLine("Nombre: {0}, DNI: {1}, Edad: {2}, Número de Socio: -----", nombre, dni, edad);
									}
									else{
										Console.WriteLine("Nombre: {0}, DNI: {1}, Edad: {2}, Número de Socio: {3}", nombre, dni, edad, nroSocio);
									}
								}						
							}
                        }
                        else
                        {
                        	Console.WriteLine("");
                        	Console.WriteLine("No hay inscriptos en {0} en la categoría {1}.", ((Deporte)listaDep[selDeporte - 1]).Nombre, ((Deporte)listaCat[selCategoria - 1]).Categoria);
                        }
                                                                        
                        Console.WriteLine("");
                        Console.Write("Pulse una tecla para continuar . . . ");
                        Console.ReadKey(true);
                        break;
					
					/* lista del total de inscriptos */                        
					case "3":
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Blue;
        				Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("                                                                                                    ");
						Console.WriteLine("                                         Club Deportivo AYP                                         ");
						Console.WriteLine("                                                                                                    ");
        				Console.ResetColor();
						Console.WriteLine("");
						Console.BackgroundColor = ConsoleColor.DarkGray;
        				Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("                                     Lista Total de Inscriptos                                      ");
						Console.ResetColor();
                        
                        lista = club.ListaInscTotal();
                        
                        if(lista.Count > 0)
                        {
                        	Console.WriteLine("");
                        	Console.WriteLine("Inscriptos:");
                        	Console.WriteLine("");
                        
                        	foreach(var lipdyc in lista)
							{
								foreach(var ld in (ArrayList)lipdyc)
								{
									string nombre = "";
									int dni = 0, edad = 0, nroSocio = 0;
									
									int dato = 0;
									
									foreach(var d in (ArrayList)ld)
									{
										switch (dato)
										{
											case 0:
												nombre = (string)d;
												dato++;
												break;
												
											case 1:
												dni = (int)d;
												dato++;
												break;
											
											case 2:
												edad = (int)d;
												dato++;
												break;
											
											case 3:
												nroSocio = (int)d;
												break;
										}
									}
									if(nroSocio == -1)
									{
										Console.WriteLine("Nombre: {0}, DNI: {1}, Edad: {2}, Número de Socio: -----", nombre, dni, edad);
									}
									else{
										Console.WriteLine("Nombre: {0}, DNI: {1}, Edad: {2}, Número de Socio: {3}", nombre, dni, edad, nroSocio);
									}
								}						
							}
                        }
                        else
                        {
                        	Console.WriteLine("");
                        	Console.WriteLine("No hay inscriptos aún.");
                        }
                        
                                                
                        Console.WriteLine("");
                        Console.Write("Pulse una tecla para continuar . . . ");
                        Console.ReadKey(true);
                        break;
					
					/* lista de deudores que llevan mas de un mes sin pagar la cuota */                        
					case "4":
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Blue;
        				Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("                                                                                                    ");
						Console.WriteLine("                                         Club Deportivo AYP                                         ");
						Console.WriteLine("                                                                                                    ");
	        			Console.ResetColor();
						Console.WriteLine("");
						Console.BackgroundColor = ConsoleColor.DarkRed;
        				Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("                                         Lista de Deudores                                          ");
						Console.ResetColor();						
						
                        lista = club.ListaDeudores();
                        
                        if(lista.Count > 0)
                        {
                        	Console.WriteLine("");
                        	Console.WriteLine("Deudores:");
                        	Console.WriteLine("");
                        
                        	foreach(var ld in lista)
							{
	                        	string nombre = "";
								int dni = 0, nroSocio = 0;
								int dato = 0;
									
								foreach(var d in (ArrayList)ld)
								{
									switch (dato)
									{
										case 0:
											nombre = (string)d;
											dato++;
											break;
												
										case 1:
											dni = (int)d;
											dato++;
											break;
										
										case 2:
											nroSocio = (int)d;											
											dato++;
											break;
											
										case 3:
											mes = (string)d;
											break;
									}
								}
								
								if(nroSocio == -1)
								{
									Console.WriteLine("Nombre: {0}, DNI: {1}, Número de Socio: -----, Ultimo mes de pago: {2}", nombre, dni, mes);
								}
								else{
									Console.WriteLine("Nombre: {0}, DNI: {1}, Número de Socio: {2}, Ultimo mes de pago: {3}", nombre, dni, nroSocio, mes);
								}
							}
                        }
                        else
                        {
                        	Console.WriteLine("");
                        	Console.WriteLine("No hay deudores.");
                        }
                        
                                              
                        Console.WriteLine("");
                        Console.Write("Pulse una tecla para continuar . . . ");
                        Console.ReadKey(true);
                        break;
			
                    /* volver al menu principal */
					case "9":
						break;
					
					/* mensaje de error por opcion incorrecta */
					default:
                        Console.WriteLine("Opción incorrecta. Vuelva a intentarlo.");
                        Console.Write("Pulse una tecla para continuar . . . ");
                        Console.ReadKey(true);
                        break;
				}                
            } while (selec != "9");
		}
		
		/* pago de la cuota */
		public static void PagoCuota(Club club)
		{
			int dni;
			
			do{
				Console.Clear();
				Console.BackgroundColor = ConsoleColor.Blue;
	        	Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                                                                                    ");
				Console.WriteLine("                                         Club Deportivo AYP                                         ");
				Console.WriteLine("                                                                                                    ");
	        	Console.ResetColor();
				Console.WriteLine("");
				Console.BackgroundColor = ConsoleColor.DarkGray;
        		Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                             Pagar Cuota                                            ");
				Console.ResetColor();
				Console.WriteLine("");
				
				Console.WriteLine("Ingrese el número de DNI.");
				while(int.TryParse(Console.ReadLine(), out dni) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}			
				
				if(club.ExisteInscripto(dni) == true)
				{
					Console.WriteLine("El valor de la cuota es de ${0}", club.VerValorCuota(dni)); 
					Console.WriteLine("");
					Console.WriteLine("¿Se procede a registrar el pago? S/N");
					
					if(Console.ReadLine().ToUpper() == "S"){
						if(club.PagarCuota(dni))
						{
							Console.WriteLine("");
							Console.BackgroundColor = ConsoleColor.DarkGreen;
        					Console.ForegroundColor = ConsoleColor.White;
							Console.WriteLine("Pago realizado.");
							Console.ResetColor();
							Console.WriteLine("");
						}
					}
				}
				else
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
        			Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("¡El DNI ingresado no existe!");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
				Console.WriteLine("¿Desea ingresar otro pago? S/N");
				
			} while (Console.ReadLine().ToUpper() == "S");
		}
		
		/* alta de un nuevo entrenador */
		public static void AltaEntrenador(Club club)
		{
			string nombre;
            int dni;

            do
            {
                Console.Clear();
               	Console.BackgroundColor = ConsoleColor.Blue;
	        	Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                                                                                    ");
				Console.WriteLine("                                         Club Deportivo AYP                                         ");
				Console.WriteLine("                                                                                                    ");
	        	Console.ResetColor();
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.DarkGray;
        		Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                         Ingresar Entrenador                                        ");
                Console.ResetColor();
                Console.WriteLine("");

                Console.WriteLine("Ingrese el nombre del Entrenador.");
                nombre = Console.ReadLine().Trim();
                nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombre);

                Console.WriteLine("Ingrese el número de DNI.");
				while(int.TryParse(Console.ReadLine(), out dni) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}
				
                /* verifica si el entrenador ya existe o no antes de darlo de alta */
                if (club.BuscarEntrenador(dni) == -1)
                {
                    club.AgregarEntrenador(nombre, dni);

					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkGreen;
        			Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("Entrenador ingresado corectamente.");
					Console.ResetColor();
					Console.WriteLine("");
                }
                else
                {
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
        			Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Entrenador ya ingresado.");
					Console.ResetColor();
					Console.WriteLine("");
                }

                Console.WriteLine("¿Desea ingresar otro Entrenador? S/N");

            } while (Console.ReadLine().ToUpper() == "S");
        }

		/* dar de baja un entrenador */
        public static void BajaEntrenador(Club club)
        {
            int dni, indiceDep, indiceEntrenador;

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Blue;
	        	Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                                                                                    ");
				Console.WriteLine("                                         Club Deportivo AYP                                         ");
				Console.WriteLine("                                                                                                    ");
	        	Console.ResetColor();
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.DarkRed;
        		Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                         Eliminar Entrenador                                        ");
                Console.ResetColor();
                Console.WriteLine("");

                Console.WriteLine("Ingrese el número de DNI.");
				while(int.TryParse(Console.ReadLine(), out dni) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}

                /* busca si el entrenador existe y luego lo borrar de la lista de entrenadores y del deporte */
                if ((indiceEntrenador = club.BuscarEntrenador(dni)) != -1)
                {
                    club.EliminarEntrenador(indiceEntrenador);

                    if ((indiceDep = club.BuscarEntrenadorDeporte(dni)) != -1)
					{
                        club.QuitarEntrenadorDeporte(indiceDep, dni);
                    }					
                    
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkGreen;
	        		Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Entrenador eliminado correctamete.");
					Console.ResetColor();
					Console.WriteLine("");
                }
                else
                {
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
	        		Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("El DNI ingresado no corresponde a ningun Entrenador.");
					Console.ResetColor();
					Console.WriteLine("");
                }

                Console.WriteLine("¿Desea eliminar otro Entrenador? S/N");

            } while (Console.ReadLine().ToUpper() == "S");
        }

        /* asigna un entrenador a un deporte */
        public static void SeleccionarEntrenador(Club club)
        {
            int dni, selDeporte;
            int contador = 1;

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Blue;
	        	Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("                                                                                                    ");
				Console.WriteLine("                                         Club Deportivo AYP                                         ");
				Console.WriteLine("                                                                                                    ");
	        	Console.ResetColor();
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.DarkRed;
        		Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                         Asignar Entrenador                                         ");
                Console.ResetColor();
                Console.WriteLine("");

                Console.WriteLine("Ingrese el número de DNI.");
				while(int.TryParse(Console.ReadLine(), out dni) == false)
				{
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
					Console.ResetColor();
					Console.WriteLine("");
				}

                if (club.BuscarEntrenador(dni) != -1)
                {
                    Console.WriteLine("Selecione el deporte que se le asignara.");
                    Console.WriteLine("");

                    contador = 1;
                    foreach (Deporte dep in club.Deportes)
                    {
						if (dep.EntrenadorDni == 0)
						{
                            Console.WriteLine("{0} - Deporte:{1}, Categoria: {2}, Día: {3}, Hora: {4}", contador, dep.Nombre, dep.Categoria, dep.dia, dep.hora);
                            contador++;
                        }                        
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Deporte:");

					while(int.TryParse(Console.ReadLine(), out selDeporte) == false)
					{
						Console.WriteLine("");
						Console.BackgroundColor = ConsoleColor.DarkRed;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
						Console.ResetColor();
						Console.WriteLine("");
					}

                    while ((selDeporte < 1) || (selDeporte > club.Deportes.Count))
                    {
                        Console.WriteLine("");
						Console.BackgroundColor = ConsoleColor.DarkRed;
	        			Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.");
						Console.ResetColor();
						Console.WriteLine("");

						while(int.TryParse(Console.ReadLine(), out selDeporte) == false)
						{
							Console.WriteLine("");
							Console.BackgroundColor = ConsoleColor.DarkRed;
							Console.ForegroundColor = ConsoleColor.White;
							Console.WriteLine("ERROR: No se ingreso un numero. Reintente nuevamente.");
							Console.ResetColor();
							Console.WriteLine("");
						}
                    }

                    club.AsignarEntrenadorADeporte(selDeporte - 1, dni);

					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkGreen;
	        		Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Entrenador asignado correctamente.");
					Console.ResetColor();
					Console.WriteLine("");
                }
                else
                {
					Console.WriteLine("");
					Console.BackgroundColor = ConsoleColor.DarkRed;
	        		Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("El DNI ingresado no corresponde a ningun Entrenador.");
					Console.ResetColor();
					Console.WriteLine("");
                }

                Console.WriteLine("¿Desea asignar otro Entrenador? S/N");

            } while (Console.ReadLine().ToUpper() == "S");
        }
    }
}