namespace ProyectoFinalDAMAgil2324.Services.Correoelectronico
{
    public interface ICorreoelectronicoService
    {

		Task<Models.Correoelectronico> GetCorreoElectronico(string email, string clave);

		//Sirve guardar un usuario en la bbdd
		Task<Models.Correoelectronico> SaveCorreoElectronico(Models.Correoelectronico correo);

	}
}
