using kpullopaxiComplementariuo.Modelos;

namespace kpullopaxiComplementariuo.Vistas;

public partial class ActualizarEliminar : ContentPage
{
	Estudiantes est = new Estudiantes();
	public ActualizarEliminar(Estudiantes estudiante)
	{
		InitializeComponent();
		txtNombre.Text = estudiante.Nombre;
		txtApellido.Text = estudiante.Apellido;
		txtVurso.Text = estudiante.Curso;
		txtParalelo.Text = estudiante.Paralelo;
		txtNota.Text =  estudiante.NOTA_FINAL.ToString();
		est = estudiante;
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
		est.Nombre = txtNombre.Text;
		est.Apellido= txtApellido.Text;
		est.Curso = txtVurso.Text;
		est.Paralelo = txtParalelo.Text;
		est.NOTA_FINAL = float.Parse(txtNota.Text);

        App.repo.UpdateEstudiante(est);
        Navigation.PushAsync(new Vistas.Principal());

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        App.repo.DeleteEstudiante(est);
        Navigation.PushAsync(new Vistas.Principal());
    }
}