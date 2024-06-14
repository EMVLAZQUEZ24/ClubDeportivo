/*
 * Created by SharpDevelop.
 * User: Soporte
 * Date: 21/05/2024
 * Time: 15:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.ComponentModel;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Club.
	/// </summary>
	/// 
	public class ClubCupoExcepcion : Exception {}
		
	public class Club
	{
		/* enumeracion para los dias del mes */
		private enum meses
		{
		    Enero,
		    Febrero,
		    Marzo,
		    Abril,
		    Mayo,
		    Junio,
		    Julio,
		    Agosto,
		    Septiembre,
		    Octubre,
		    Noviembre,
		    Diciembre
		}
		
		/* atributos */
		private static ArrayList deportes = new ArrayList();
        private static ArrayList entrenadores = new ArrayList();
		
		/* constructor */
		public Club()
		{
			deportes = new ArrayList();
			entrenadores = new ArrayList();
		}

        /* propiedades */
		public ArrayList Deportes
		{
			get { return deportes; }
		}

		public ArrayList Entrenadores
		{
			get { return entrenadores; }
		}

        /* metodos */

        /* Entrenadores -----------------------------------------------------------*/
        
        /* buscar si el entrenador existe o no en el arralylist de entrenadores */
       	public int BuscarEntrenador(int dni)
		{
			Entrenador ent;
			
			for(int i = 0; i < entrenadores.Count; i++)
			{	
				ent = (Entrenador)entrenadores[i];
				if(ent.Dni == dni)
				{
					return i;
				}
			}
			
			return -1;
		}
		
       	/* agrega entrenador al arraylist entrenadores*/
		public void AgregarEntrenador(string nombre, int dni)
		{
			entrenadores.Add(new Entrenador(nombre, dni));
		}
		
		/* elimina entrenador del arraylist entrenadores*/
		public void EliminarEntrenador(int indice)
		{
            entrenadores.RemoveAt(indice);
        }

		/* agrega entrenador al arraylist entrenadores*/
		public void AsignarEntrenadorADeporte(int indice, int dni)
		{
			foreach (Entrenador ent in entrenadores)
			{
				if(ent.Dni == dni)
				{
                    ((Deporte)deportes[indice]).AsignarEntrenador(dni);
                }
			}			
        }
		
		/* Deportes -----------------------------------------------------------*/
		
		/* verifica si el deporte ya fue cargado */
		public int ExisteDepYCat(string nombre, int categoria)
		{
			Deporte dep;
			
			for(int i = 0; i < deportes.Count; i++)
			{	
				dep = (Deporte)deportes[i];
				
				if((dep.Nombre == nombre) && (dep.Categoria == categoria))
				{
					return i;
				}
			}
			
			return -1;
		}
		
		/* verifica si el deporte tiene o no inscriptos/deportistas */
		public bool EstaVacioDeporte(int indice)
		{			
			if(((Deporte)deportes[indice]).Deportistas.Count > 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		
		/* agrega un deporte al arraylist deportes */		
		public void AgregarDeporte(string nombre, int categoria, int cupo, float cuota, float descuentoSocio, string dia, string hora)
		{
			deportes.Add(new Deporte(nombre, categoria, cupo, cuota, descuentoSocio, dia, hora));
			
		}
		
		/* elimina un deporte del arraylist deporte */
		public void EliminarDeporte(int indice)
		{			
			deportes.RemoveAt(indice);
		}
		
		/* retorna la cantidad de deportes cargados */
		public int TotalDeportes()
		{
			return deportes.Count;
		}
	
		/* retorna la lista de deportes cargados */
        public ArrayList ListaDeportes()
        {
            ArrayList lista = new ArrayList();
            bool existe = false;

            foreach (Deporte dep in deportes)
            {
                // verifico si el deporte ya esta en la lista
                existe = false;
                foreach (Deporte l in lista)
                {
                    if (l.Nombre == dep.Nombre)
                    {
                        existe = true;
						break;
                    }
                }

                if (existe == false)
                {
                    lista.Add(dep);
                }
            }

            return lista;
        }

        /* retorna la lista de deportes cargados por categoria */
        public ArrayList ListaCategoriaXDeporte(string deporte)
        {
            ArrayList lista = new ArrayList();
            bool existe = false;

            foreach (Deporte dep in deportes)
            {
                // verifico si el deporte y la categoria ya esta en la lista
                existe = false;
                foreach (Deporte l in lista)
                {
                    if ((l.Nombre == dep.Nombre) && (l.Categoria == dep.Categoria))
                    {
                        existe = true;
                    }
                }

                if ((existe == false) && (deporte == dep.Nombre))
                {
                    lista.Add(dep);
                }
            }
            return lista;
        }
        
        /* retorna la lista de inscriptos a un deporte */
        public ArrayList ListaInscPorDep(string deporte)
		{
        	ArrayList lista = new ArrayList();
        	ArrayList deportista = new ArrayList();
        	
			foreach (Deporte dep in deportes) 
			{
				if(dep.Nombre == deporte)
				{
					deportista = dep.ListaDeportistas();
					if(deportista.Count > 0){
						lista.Add(deportista);
					}
				}
			}
        	
        	return lista;
		}
		
        /* retorna la lista de inscriptos por deporte y categoria */
		public ArrayList ListaInscPorDepYCat(string deporte, int categoria)
		{
			ArrayList lista = new ArrayList();
			ArrayList deportista = new ArrayList();
			
			foreach (Deporte dep in deportes) 
			{
				if((dep.Nombre == deporte) && (dep.Categoria == categoria))
				{
					deportista = dep.ListaDeportistas();
					if(deportista.Count > 0){
						lista.Add(deportista);
					}					
				}
			}
			
			return lista;
		}
		
		/* retorna la lista total de inscriptos */
		public ArrayList ListaInscTotal()
		{
			ArrayList lista = new ArrayList();
			ArrayList deportista = new ArrayList();
			
			foreach (Deporte dep in deportes) 
			{
				deportista = dep.ListaDeportistas();
				if(deportista.Count > 0){
					lista.Add(deportista);
				}			
			}
			
			return lista;
		}
		
		/* retorna la lista de deudores */
		public ArrayList ListaDeudores()
		{
			DateTime ahora = DateTime.Now;
			DateTime nunca = new DateTime(2000, 1, 1, 0, 0, 0);
			ArrayList lista = new ArrayList();
			ArrayList datos;
						
            foreach (Deporte dep in deportes) 
            {
            	if(dep.Deportistas.Count > 0)
            	{
            		foreach (var ins in dep.Deportistas) 
					{
						datos = new ArrayList();

	            		if (ins is Socio)
	            		{
	            			if (DateTime.Compare(((Socio)ins).UltMesPago, nunca) == 0)
							{
								datos.Add(((Socio)ins).Nombre);
								datos.Add(((Socio)ins).Dni);
								datos.Add(((Socio)ins).Numero);
								datos.Add("-----");
								lista.Add(datos);
			               	}
			                else if (((Socio)ins).UltMesPago.Year < ahora.Year)
			                {
								datos.Add(((Socio)ins).Nombre);
								datos.Add(((Socio)ins).Dni);
								datos.Add(((Socio)ins).Numero);
								datos.Add((meses)(((Socio)ins).UltMesPago.Month));
								lista.Add(datos);
							}
			                else if (((Socio)ins).UltMesPago.Month < ahora.Month)
			                {
								datos.Add(((Socio)ins).Nombre);
								datos.Add(((Socio)ins).Dni);
								datos.Add(((Socio)ins).Numero);
								datos.Add((meses)(((Socio)ins).UltMesPago.Month));
								lista.Add(datos);
							}
	            		}
	            		else
	            		{
	            			if (DateTime.Compare(((Inscripto)ins).UltMesPago, nunca) == 0)
							{
								datos.Add(((Inscripto)ins).Nombre);
								datos.Add(((Inscripto)ins).Dni);
								datos.Add(-1);
								datos.Add("-----");
								lista.Add(datos);
		                    }
		                    else if (((Inscripto)ins).UltMesPago.Year < ahora.Year)
		                    {
								datos.Add(((Inscripto)ins).Nombre);
								datos.Add(((Inscripto)ins).Dni);
								datos.Add(-1);
								datos.Add((meses)(((Inscripto)ins).UltMesPago.Month));
								lista.Add(datos);
							}
		                    else if (((Inscripto)ins).UltMesPago.Month < ahora.Month)
		                    {
								datos.Add(((Inscripto)ins).Nombre);
								datos.Add(((Inscripto)ins).Dni);
								datos.Add(-1);
								datos.Add((meses)(((Inscripto)ins).UltMesPago.Month));
								lista.Add(datos);
							}
	            		}																					
	            	}					
            	}
			}
			
			return lista;
		}
		
		/* agrega un entrenador a un deporte */
		public void AgregarEntrenadorDeporte (int indiceDeporte, int indiceEntrenador)
		{
			((Deporte)deportes[indiceDeporte]).AsignarEntrenador(((Entrenador)entrenadores[indiceEntrenador]).Dni);
		}

		/* quita un entrenador de un deporte */
        public void QuitarEntrenadorDeporte (int indiceDeporte, int indiceEntrenador)
        {
            ((Deporte)deportes[indiceDeporte]).RemoverEntrenador();
        }
	
        /* busca el entrenador por dni */
        public int BuscarEntrenadorDeporte (int dni)
        {
			for (int i = 0; i < deportes.Count; i++)
			{
				if (((Deporte)deportes[i]).EntrenadorDni == dni)
				{
					return i;
				}
			}
			return -1;
        }
	
        /* verifica si hay cupo */
        public int CupoInscripto(int indice)
		{
			return ((Deporte)deportes[indice]).CupoLibre;
		}
		
        /* verifica si el dni ya esta inscripto */
		public bool ExisteInscripto(int dni)
		{
			foreach (Deporte dep in deportes) 
			{
				if (dep.ExisteDeportista(dni) != -1)
				{
					return true;
				}
			}
			
			return false;
		}		
		
		/* inscribe a un nuevo inscripto/deportista */
		public int NuevoInscripto(int indiceDeporte, string nombre, int dni, int edad, int categoria, int nroSocio)
		{	
			if(ExisteInscripto(dni) == false)
			{
				if (CupoInscripto(indiceDeporte) == 0){
					return 0;
				} 
				else{
					((Deporte)deportes[indiceDeporte]).AgregarDeportista(nombre, dni, edad, categoria, nroSocio);
					return 1;
				}	
				
			}
			else{
				return -1;
			}
		}
		
		/* borra un inscripto/deportista */
		public int BorrarInscripto(int dni)
		{
			int indice = 0;
			
			foreach (Deporte dep in deportes) {
				if((indice = dep.ExisteDeportista(dni)) != -1)
				{
					dep.EliminarDeportista(indice);									
					return 1;
				}
			}

			return -1;			
		}
		
		/* devuelve el valor de la cuota */
		public double VerValorCuota(int dni)
		{
			int indice = 0;
			
			foreach (Deporte dep in deportes) {
				if((indice = dep.ExisteDeportista(dni)) != -1)
				{
                    return dep.ValorCuota(dni);
				}
			}
			
			return -1;
		}
		
		/* se genera el pago de la cuota */
		public bool PagarCuota(int dni)
		{
			int indice = 0;
			
			foreach (Deporte dep in deportes) {
				if((indice = dep.ExisteDeportista(dni)) != -1)
				{
					return dep.PagoCuota(dni);
				}
			}
			
			return false;
		}
	}
}
