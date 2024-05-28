/*
 * Created by SharpDevelop.
 * User: Soporte
 * Date: 21/05/2024
 * Time: 9:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Persona.
	/// </summary>
	public class Persona
	{
		/* atributos */
		protected string nombre;
		protected int dni;
		
		/* constructor */
		public Persona(string nombre, int dni)
		{
			this.nombre = nombre;
			this.dni = dni;
		}
		
		/* propiedades */
		public string Nombre{
			get { return nombre; }
		}
		
		public int Dni{
			get { return dni; }
		}
		
		/* metodos */
		/*MÉTODO PARA SABER LA INFORMACIÓN Y DNI DE LA PERSONA*/
		/*MÉTODO SUJETO A MODIFICACIONES*/
		protected void InformacionPersona(){
			Console.WriteLine("Nombre " + nombre + "DNI " + dni);
			
		}
	}
}
