using kpullopaxiComplementariuo.Modelos;

namespace kpullopaxiComplementariuo.Vistas;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void btnIngresar_Clicked(object sender, EventArgs e)
    {
        var usuario = txtUsuario.Text;
        var contrasena = txtContrasena.Text;
        EstudiantesLogin login =  App.repo.GetLogin(usuario);
        if (login == null)
        {
            DisplayAlert("ALERTA", "Usuarios o contrseña Incorrectas", "Cerrar");
        }
        else
        {
            if (login.CONTRASENA == contrasena)
            {
                Navigation.PushAsync(new Vistas.Principal());
            }
            else
            {
                DisplayAlert("ALERTA", "Usuarios o contrseña Incorrectas", "Cerrar");
            }
        }
      

    }
}