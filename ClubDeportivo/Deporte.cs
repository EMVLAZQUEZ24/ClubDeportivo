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
			//deportistasSocios = new ArrayList();
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
		public int existeDeportista(int dni)
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
		
		public void agregarDeportista(string nombre, int dni, int edad, int categoria, int nroSocio)
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
		
		public void eliminarDeportista(int indice)
		{
			deportistas.RemoveAt(indice);
		}
		
		public void asignarEntrenador(Entrenador ent)
		{
			this.entrenador = ent;
		}

        public void removerEntrenador()
        {
            this.entrenador = null;
        }

        public void listaDeportistas()
		{
			foreach (var ins in deportistas) {
                if (ins is Socio)
				{
                    Console.WriteLine("Nombre: {0}, DNI: {1}, Edad: {2}, Número de Socio: {3}", ((Socio)ins).Nombre, ((Socio)ins).Dni, ((Socio)ins).Edad, ((Socio)ins).Numero);
                }
				else
				{
                    Console.WriteLine("Nombre: {0}, DNI: {1}, Edad: {2}, Número de Socio: -----", ((Inscripto)ins).Nombre, ((Inscripto)ins).Dni, ((Inscripto)ins).Edad);
                }
                    
			}
		}		
		
		public float valorCuota(int dni)
		{
			foreach (var ins in deportistas) 
			{
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
		
		public bool pagoCuota(int dni)
		{
            DateTime ahora = DateTime.Now;
            int mesActual = ahora.Month;

            foreach (Inscripto ins in deportistas) {
				if(ins.Dni == dni)
				{
					ins.UltMesPago = mesActual;
					
					return true;
				}
			}
			
			return false;
		}
	}
}
