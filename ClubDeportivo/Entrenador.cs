/*
 * Created by SharpDevelop.
 * User: Soporte
 * Date: 21/05/2024
 * Time: 9:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of Entrenador.
	/// </summary>
	public class Entrenador:Persona
	{
		/* atributos */
		
		/* constructor */
		public Entrenador(string nombre, int dni):base(nombre, dni)
		{
			this.nombre = nombre;
			this.dni = dni;
		}
		
		/* propiedades */

		/* metodos */

	}
}
