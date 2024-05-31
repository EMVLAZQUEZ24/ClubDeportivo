/*
 * Created by SharpDevelop.
 * User: Soporte
 * Date: 21/05/2024
 * Time: 9:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Deporte.
	/// </summary>
	public class Deporte
	{
		/* atributos */
		public string nombre;
		public Entrenador entrenador;		
		public int categoria;
		public int cupo;
		public int cupoLibre;
		public ArrayList deportistas;
		public float cuota;
		public float descuentoSocio;
		public string dia;
		public string hora;
		
		/* contructor */
		public Deporte(string nombre, int categoria, int cupo, float cuota, float descuentoSocio, string dia, string hora)
		{
			this.nombre = nombre;
			this.categoria = categoria;
			this.cuota = cuota;
			this.cupo = cupo;
			this.cupoLibre = cupo;
			this.descuentoSocio = descuentoSocio/100;
			this.dia = dia;
			this.hora = hora;
			deportistas = new ArrayList();
		}
		
		/* propiedades */
		public Entrenador Entrenador
		{
			get { return entrenador; }
			set { entrenador = value; }
		}
		
		public string Nombre
		{
			get { return nombre; }
		}
		
		public int Categoria
		{
			get { return categoria; }
		}
		
		public int Cupo
		{
			get { return cupo; }
		}
		
		public int CupoLibre
		{
			get { return cupoLibre; }
		}
		
		public float Cuota
		{
			get { return cuota; }
		}
		
		public float CuotaSocio
		{
			get { return cuota - (cuota * descuentoSocio); }
		}
		
		public float DescuentoSocio
		{
			get { return descuentoSocio; }
		}
		
		public string Dia
		{
			get { return dia; }
		}
		
		public string Hora
		{
			get { return hora; }
		}
		
		public ArrayList Deportistas
		{
			get { return deportistas; }
		}
		
		/* metodos */
		
		/* verifica si el dni ya fue inscripto o no */
		public int ExisteDeportista(int dni)
		{
			Inscripto dep;
			
			for(int i = 0; i < deportistas.Count; i++)
			{	
				dep = (Inscripto)deportistas[i];
				
				if(dep.Dni == dni)
				{
					return i;
				}
			}
			
			return -1;
		}		
		
		/* agrega un nuevo inscripto/deportista */
		public void AgregarDeportista(string nombre, int dni, int edad, int categoria, int nroSocio)
		{	
			if(nroSocio == 0)
			{
				deportistas.Add(new Inscripto (nombre, dni, edad, categoria));
			}
			else
			{
				deportistas.Add(new Socio (nombre, dni, edad, categoria, nroSocio));
			}
			
			cupoLibre -= 1;			
		}
		
		/* elimina un inscripto/deportista */
		public void EliminarDeportista(int indice)
		{
			deportistas.RemoveAt(indice);
		}
		
		/* asigna un enrtenador al deporte */
		public void AsignarEntrenador(Entrenador ent)
		{
			this.entrenador = ent;
		}
		
		/* remueve el entrenador */
        public void RemoverEntrenador()
        {
            this.entrenador = null;
        }

        /* lista de inscriptos/deportistas  */
        public ArrayList ListaDeportistas()
		{
        	ArrayList lista = new ArrayList();
        	
			foreach (var ins in deportistas) 
			{
        		ArrayList deportista = new ArrayList();
        		
                if (ins is Socio)
				{
                	deportista.Add(((Socio)ins).Nombre);
                	deportista.Add(((Socio)ins).Dni);
                	deportista.Add(((Socio)ins).Edad);
                	deportista.Add(((Socio)ins).Numero);
                	lista.Add(deportista);
                }
				else
				{
					deportista.Add(((Inscripto)ins).Nombre);
                	deportista.Add(((Inscripto)ins).Dni);
                	deportista.Add(((Inscripto)ins).Edad);
                	deportista.Add(-1);
                	lista.Add(deportista);
                }
			}
        	
        	return lista;
		}		
		
        /* devuelve el valor de la cuota */
		public float ValorCuota(int dni)
		{
			foreach (var ins in deportistas) 
			{
				/* verifica si ins es del tipo socio o inscripto para saber si hacere el descuento o no */
                if (ins is Socio)
                {
					if(((Socio)ins).Dni == dni)
					{
						return cuota - (cuota * descuentoSocio);
					}
				}
				else
				{
					if(((Inscripto)ins).Dni == dni)
					{
						return cuota;
					}				
				}
			}
			
			return 0;
		}
		
		/* pago de la cuota */
		public bool PagoCuota(int dni)
		{
			/* se toma la fecha actual del la PC */
            DateTime ahora = DateTime.Now;

            foreach (Inscripto ins in deportistas) {
				if(ins.Dni == dni)
				{
					ins.UltMesPago = ahora;
					
					return true;
				}
			}
			
			return false;
		}
	}
}
