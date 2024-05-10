using System.Security.Cryptography;
using System.Text;

namespace ProyectoFinalDAMAgil2324.Services
{
	public class Utilidades
	{
		//Este metodo recibe una clave que el usuario defina y la encripta.
		public static string EncriptarClave(string clave)
		{

			StringBuilder sb = new StringBuilder();

			using (SHA256 hash = SHA256.Create())
			{
				Encoding enc = Encoding.UTF8;

				byte[] result = hash.ComputeHash(enc.GetBytes(clave));

				foreach (byte b in result)
					sb.Append(b.ToString("x2"));
			}

			return sb.ToString();

		}

	}
}