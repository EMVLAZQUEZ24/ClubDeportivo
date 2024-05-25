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
	public class Club
	{
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

        /* metodos */

        /* Entrenadores -----------------------------------------------------------*/
       public int buscarEntrenador(int dni)
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
		
		public void agregarEntrenador(string nombre, int dni)
		{
			entrenadores.Add(new Entrenador(nombre, dni));
		}
		
		public void eliminarEntrenador(int indice)
		{
            entrenadores.RemoveAt(indice);
        }

		public void agregarEntrenador(int indice, int dni)
		{
			foreach (Entrenador ent in entrenadores)
			{
				if(ent.Dni == dni)
				{
                    ((Deporte)deportes[indice]).asignarEntrenador(ent);
                }
			}			
        }
		
		/* Deportes -----------------------------------------------------------*/
		public int existeDepYCat(string nombre, int categoria)
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
		
		public bool estaVacioDeporte(int indice)
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
				
		public void agregarDeporte(string nombre, int categoria, int cupo, float cuota, float descuentoSocio, string dia, string hora)
		{
			deportes.Add(new Deporte(nombre, categoria, cupo, cuota, descuentoSocio, dia, hora));
			
		}
		
		public void eliminarDeporte(int indice)
		{			
			deportes.RemoveAt(indice);
		}
		
		public int totalDeportes()
		{
			return deportes.Count;
		}

        public ArrayList listaDeportes()
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

        public ArrayList listaCategoriaXDeporte(string deporte)
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
        
        public void listaInscPorDep(string deporte)
		{
			foreach (Deporte dep in deportes) {
				if(dep.Nombre == deporte)
				{
					dep.listaDeportistas();
				}
			}
		}
		
		public void listaInscPorDepYCat(string deporte, int categoria)
		{
			foreach (Deporte dep in deportes) {
				if((dep.Nombre == deporte) && (dep.Categoria == categoria))
				{
					dep.listaDeportistas();
				}
			}
		}
		
		public void listaInscTotal()
		{
			foreach (Deporte dep in deportes) {
				dep.listaDeportistas();
			}
		}
		
		public void listaDeudores()
		{
			DateTime ahora = DateTime.Now;
			int mesActual = ahora.Month;

            foreach (Deporte dep in deportes) {
				foreach (Inscripto ins in dep.Deportistas) {
					if (ins.UltMesPago == 0)
					{
						Console.WriteLine("{0} - Aún no a abonado ninguna cuota.", ins.Nombre);
                    }
                    else if (ins.UltMesPago != mesActual){
						Console.WriteLine("{0} - Ultimo mes de pago: {1}", ins.Nombre, (meses)ins.UltMesPago);
					}
				}
			}
		}
		
		public void agregarEntrenadorDeporte (int indiceDeporte, int indiceEntrenador)
		{
			((Deporte)deportes[indiceDeporte]).asignarEntrenador((Entrenador)entrenadores[indiceEntrenador]);
		}

        public void quitarEntrenadorDeporte (int indiceDeporte, int indiceEntrenador)
        {
            ((Deporte)deportes[indiceDeporte]).removerEntrenador();
        }

        public int buscarEntrenadorDeporte (int dni)
        {
			for (int i = 0; i < deportes.Count; i++)
			{
				if (((Deporte)deportes[i]).Entrenador.Dni == dni)
				{
					return i;
				}
			}
			return -1;
        }

        public int cupoInscripto(int indice)
		{
			return ((Deporte)deportes[indice]).CupoLibre;
		}
		
		public bool existeInscripto(int dni)
		{
			foreach (Deporte dep in deportes) 
			{
				if (dep.existeDeportista(dni) != -1)
				{
					return true;
				}
			}
			
			return false;
		}		
		
		public void nuevoInscripto(int indiceDeporte, string nombre, int dni, int edad, int categoria, int nroSocio)
		{	
			if(existeInscripto(dni) == false)
			{
				if (cupoInscripto(indiceDeporte) == 0){
					throw new clubCupoExcepcion("Lamentablemente ya no hay cupo.");
				} 
				else{
					((Deporte)deportes[indiceDeporte]).agregarDeportista(nombre, dni, edad, categoria, nroSocio);
					Console.WriteLine("{0} inscripto correctamente", nombre);
				}	
			}
			else{
				Console.WriteLine("{0} ya se encuentra inscripto", nombre);
			}
		}
		
		public void borrarInscripto(int dni)
		{
			int indice = 0;
			
			foreach (Deporte dep in deportes) {
				if((indice = dep.existeDeportista(dni)) != -1)
				{
					dep.eliminarDeportista(indice);
					Console.WriteLine("Baja realizada con exito.");
				
					return;
				}
			}
			Console.WriteLine("DNI no encontrado");
		}
		
		public void verValorCuota(int dni)
		{
			int indice = 0;
			
			foreach (Deporte dep in deportes) {
				if((indice = dep.existeDeportista(dni)) != -1)
				{
                    Console.WriteLine("El valor de la cuota es de ${0}", dep.valorCuota(dni));                    
				}
			}
		}
		
		public bool pagarCuota(int dni)
		{
			int indice = 0;
			
			foreach (Deporte dep in deportes) {
				if((indice = dep.existeDeportista(dni)) != -1)
				{
					return dep.pagoCuota(dni);
				}
			}
			
			return false;
		}
	}
}
