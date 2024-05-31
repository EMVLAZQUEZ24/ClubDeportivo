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
                        AsignarEntrenador(club);
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
			Console.WriteLine(" 8 - Eliminar un Enrenador.");
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
			int dni, edad, categoria, nroSocio, selDeporte, contador;
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

				
                /* se muestra una lista de los deportes ya cargados para que el usuario elija una de las opciones */
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
				
                /* se ingresa el inscripto en el deporte seleccionado y si la opcion es incorrecta vuelve a pedir que seleccione nuevamente */
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
				dni = int.Parse(Console.ReadLine());				
				club.BorrarInscripto(dni);
				
				Console.WriteLine("");
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
				
				/* verifico si el deporte y la categoria ya existe antes de agregarla */				
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
		
		/* borrar un deporte */
		public static void BorrarDeporte(Club club)
		{
			int contador, selDeporte;
			
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
				
                /* se verifica que no haya inscriptos en el deporte antes de borrar */
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
		
		/* submenu para mostrar lista de inscriptos y deudores */
		public static void SubMenuListas(Club club)
		{
			string selec;
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

                        selDeporte = int.Parse(Console.ReadLine());

                        while ((selDeporte < 1) || (selDeporte > listaDep.Count))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("ERROR en la selección del deporte. Vuelva a intentarlo.\n");
                            selDeporte = int.Parse(Console.ReadLine());
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
											dato++;
											break;
											
										case 3:
											nroSocio = (int)d;
											break;
									}
								}
								
								if(nroSocio == -1)
								{
									Console.WriteLine("Nombre: {0}, DNI: {1}, Número de Socio: -----", nombre, dni);
								}
								else{
									Console.WriteLine("Nombre: {0}, DNI: {1}, Número de Socio: {2}", nombre, dni, nroSocio);
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
				dni = int.Parse(Console.ReadLine());				
				
				if(club.ExisteInscripto(dni) == true)
				{
					Console.WriteLine("El valor de la cuota es de ${0}\n", club.VerValorCuota(dni)); 
					
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
                dni = int.Parse(Console.ReadLine());
				
                /* verifica si el entrenador ya existe o no antes de darlo de alta */
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
                dni = int.Parse(Console.ReadLine());

                /* busca si el entrenador existe y luego lo borrar de la lista de entrenadores y del deporte */
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

        /* asigna un entrenador a un deporte */
        public static void AsignarEntrenador(Club club)
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

                    club.AsignarEntrenadorADeporte(selDeporte - 1, dni);

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