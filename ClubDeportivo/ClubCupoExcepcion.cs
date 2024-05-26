/*
 * Created by SharpDevelop.
 * User: Soporte
 * Date: 23/05/2024
 * Time: 12:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ClubDeportivo
{
	/// <summary>
	/// Description of clubCupoExcepcion.
	/// </summary>
	public class clubCupoExcepcion : Exception
	{
		public string motivo;

		public clubCupoExcepcion(string m)
		{
			motivo = m;
		}
	}
}
