using kpullopaxiComplementariuo.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kpullopaxiComplementariuo
{
    public class EstudianteRepository
    {

        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<EstudiantesLogin>();
            conn.CreateTable<Estudiantes>();
        }

        public EstudianteRepository(string bdPath)
        {
            _dbPath = bdPath;
        }

        public void AddEstudiantesLogin()
        {
            int result = 0;
            try
            {
                Init();


                EstudiantesLogin login = new EstudiantesLogin() { USUARIO = "ADMIN", CONTRASENA = "123" };
                result = conn.Insert(login);

               
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al insertar", "", ex.Message);
            }
        }
        public EstudiantesLogin GetLogin(string usuario)
        {
            
                Init();
                return conn.Table<EstudiantesLogin>().Where(e => e.USUARIO == usuario).FirstOrDefault();
            
            
        }

        public void AddEstudiante(string nombre, string apellido, string curso, string paralelo, float nota)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");
                if (string.IsNullOrEmpty(apellido))
                    throw new Exception("Apellido requerido");
                if (string.IsNullOrEmpty(curso))
                    throw new Exception("Curso requerido");
                if (string.IsNullOrEmpty(paralelo))
                    throw new Exception("Paralelo requerido");
            

                Estudiantes estudiante = new Estudiantes() { Nombre = nombre, Apellido= apellido, Curso=curso, Paralelo = paralelo, NOTA_FINAL=nota };
                result = conn.Insert(estudiante);

                StatusMessage = string.Format("Estudiante Insertado", result, nombre);
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al insertar", nombre, ex.Message);
            }
        }

        public List<Estudiantes> GetEstudiantes()
        {
            try
            {
                Init();
                return conn.Table<Estudiantes>().ToList();
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al mostar los datos", ex.Message);
            }

            return new List<Estudiantes>();
        }

        public void UpdateEstudiante(Estudiantes estudiante)
        {
            int result = 0;
            try
            {

                result = conn.Update(estudiante);

                StatusMessage = string.Format("Persona Actualizada", result, estudiante);
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al actualizar", estudiante, ex.Message);
            }
        }

        public void DeleteEstudiante(Estudiantes estudiante)
        {
            int result = 0;
            try
            {

                result = conn.Delete(estudiante);

                StatusMessage = string.Format("Persona eliminada", result, estudiante);
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al eliminar", estudiante, ex.Message);
            }
        }
    }
}
