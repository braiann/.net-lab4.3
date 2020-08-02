using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            dsUniversidad miUniversidad = new dsUniversidad();

            dsUniversidad.dtAlumnosDataTable dtAlumnos = new dsUniversidad.dtAlumnosDataTable();
            dsUniversidad.dtCursosDataTable dtCursos = new dsUniversidad.dtCursosDataTable();
            dsUniversidad.dtAlumnosRow rowAlumno = dtAlumnos.NewdtAlumnosRow();

            rowAlumno.Apellido = "Perez";
            rowAlumno.Nombre = "Juan";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);

            dsUniversidad.dtCursosRow rowCurso = dtCursos.NewdtCursosRow();
            rowCurso.Curso = "Informatica";
            dtCursos.AdddtCursosRow(rowCurso);

            dsUniversidad.dtAlumnos_CursosDataTable dtAlumnos_Cursos = new dsUniversidad.dtAlumnos_CursosDataTable();
            dsUniversidad.dtAlumnos_CursosRow rowAlumnosCursos = dtAlumnos_Cursos.NewdtAlumnos_CursosRow();
            dtAlumnos_Cursos.AdddtAlumnos_CursosRow(rowAlumno, rowCurso.IDCurso);

            rowAlumno = dtAlumnos.NewdtAlumnosRow();
            rowAlumno.Nombre = "Marcelo";
            rowAlumno.Apellido = "Perez";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);

            dtAlumnos_Cursos.AdddtAlumnos_CursosRow(rowAlumno, rowCurso.IDCurso);
        }
    }
}
