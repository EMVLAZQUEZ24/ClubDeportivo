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
		private int edad;
		private int categoria;
		private int ultMesPago;
		
		/* constructor */
		public Inscripto(string nombre, int dni, int edad, int categoria) : base(nombre, dni)
		{
			this.edad = edad;
			this.categoria = categoria;
			ultMesPago = 0;			
		}
		
		/* propiedades */
		public int Edad{
			get { return edad; }
		}
		
		public int Categoria{
			get { return categoria; }
		}
		
		public int UltMesPago{
			get { return ultMesPago; }
			set { ultMesPago = value; }
		}
		
		/* metodos */
		/*MÉTODO PARA SABER LA EDAD, CATEGORÍA Y ÚLTIMO MES DE PAGO DE UNA PERSONA INSCRIPTA*/
		/*MÉTODO SUJETO A MODIFICACIONES*/
		private void InformacionInscripto(){
			Console.WriteLine("Edad " + edad + "\n" + "Categoría " + categoria + "\n" + "Último mes de pago del inscripto " + ultMesPago);
		}
	}
}
