using Java.Util;
using kpullopaxiComplementariuo.Modelos;

namespace kpullopaxiComplementariuo.Vistas;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
        List<Estudiantes> estudiantes = App.repo.GetEstudiantes();
        ListaEstudiantes.ItemsSource = estudiantes;
    }


    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        App.repo.AddEstudiante(txtNombre.Text, txtApellido.Text, txtVurso.Text, txtParalelo.Text, float.Parse(txtNota.Text));
        statusMessaje.Text = App.repo.StatusMessage;
        List<Estudiantes> estudiantes = App.repo.GetEstudiantes();
        ListaEstudiantes.ItemsSource = estudiantes;
        txtNombre.Text ="";
        txtApellido.Text ="";
        txtVurso.Text = "";
        txtParalelo.Text = "";
        txtNota.Text ="";
    }

    private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Estudiantes)e.SelectedItem;
        Navigation.PushAsync(new Vistas.ActualizarEliminar(objEstudiante));
    }
}