using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kpullopaxiComplementariuo.Modelos
{
    [Table("ESTUDIANTES_LOGIN")]
    public class EstudiantesLogin
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(25)]
        public string USUARIO { get; set; }

        [MaxLength(15)]
        public string CONTRASENA { get; set; }
    }
}
