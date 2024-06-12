/*
 * Created by SharpDevelop.
 * User: Soporte
 * Date: 21/05/2024
 * Time: 9:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Inscripto.
	/// </summary>
	public class Inscripto : Persona
	{
		/* atributos */
		protected int edad;
		protected int categoria;
		protected DateTime ultMesPago;
		
		/* constructor */
		public Inscripto(string nombre, int dni, int edad, int categoria) : base(nombre, dni)
		{
			this.edad = edad;
			this.categoria = categoria;
			ultMesPago = new DateTime(2000, 1, 1, 0, 0, 0); // año, mes dia, hora, min, seg
		}
		
		/* propiedades */
		public int Edad{
			get { return edad; }
		}
		
		public int Categoria{
			get { return categoria; }
		}
		
		public DateTime UltMesPago{
			get { return ultMesPago; }
			set { ultMesPago = value; }
		}
		
		/* metodos */
	}
}
