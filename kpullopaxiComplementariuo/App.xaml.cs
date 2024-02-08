namespace kpullopaxiComplementariuo
{
    public partial class App : Application
    {
        public static EstudianteRepository repo { get; set; }
        public App(EstudianteRepository estdusianteRepo)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.Login() );
            repo = estdusianteRepo;
            repo.AddEstudiantesLogin();
        }
    }
}