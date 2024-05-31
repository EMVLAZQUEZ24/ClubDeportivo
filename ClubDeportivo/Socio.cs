/*
 * Created by SharpDevelop.
 * User: Soporte
 * Date: 29/05/2024
 * Time: 9:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Socio.
	/// </summary>
	public class Socio : Inscripto
	{
		/* atributos */
		private int numero;
		
		/* constructor */
		public Socio(string nombre, int dni, int edad, int categoria, int numero) : base (nombre, dni, edad, categoria)
		{
			this.numero = numero;
		}
		
		/* propiedades */
		public int Numero{
			get { return numero; }
		}
	}
}


