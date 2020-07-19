using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Lab4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtAlumnos = new DataTable("Alumnos");

            DataColumn dtColIDAlumno = new DataColumn("IDAlumno", typeof(int));
            dtColIDAlumno.ReadOnly = true;
            dtColIDAlumno.AutoIncrement = true;
            dtColIDAlumno.AutoIncrementSeed = 0;
            dtColIDAlumno.AutoIncrementStep = 1;
            DataColumn dtColNombre = new DataColumn("Apellido", typeof(string));
            DataColumn dtColApellido = new DataColumn("Nombre", typeof(string));
            dtAlumnos.Columns.Add(dtColApellido);
            dtAlumnos.Columns.Add(dtColNombre);
            dtAlumnos.Columns.Add(dtColIDAlumno);
            dtAlumnos.PrimaryKey = new DataColumn[] { dtColIDAlumno };

            DataRow rwAlumno = dtAlumnos.NewRow();
            rwAlumno[dtColApellido] = "Perez";
            rwAlumno[dtColNombre] = "Juan";
            dtAlumnos.Rows.Add(rwAlumno);

            DataRow rwAlumno2 = dtAlumnos.NewRow();
            rwAlumno2["Apellido"] = "Perez";
            rwAlumno2["Nombre"] = "Marcelo";
            dtAlumnos.Rows.Add(rwAlumno2);

            DataTable dtCursos = new DataTable("Cursos");
            DataColumn dtColIDCurso = new DataColumn("IDCurso", typeof(int));
            dtColIDCurso.ReadOnly = true;
            dtColIDCurso.AutoIncrement = true;
            dtColIDCurso.AutoIncrementSeed = 1;
            dtColIDCurso.AutoIncrementStep = 1;
            DataColumn dtColCurso = new DataColumn("Curso", typeof(string));
            dtCursos.Columns.Add(dtColIDCurso);
            dtCursos.Columns.Add(dtColCurso);
            dtCursos.PrimaryKey = new DataColumn[] { dtColIDCurso };

            DataRow rwCurso = dtCursos.NewRow();
            rwCurso[dtColCurso] = "Informática";
            dtCursos.Rows.Add(rwCurso);

            DataSet dsUniversidad = new DataSet();
            dsUniversidad.Tables.Add(dtAlumnos);
            dsUniversidad.Tables.Add(dtCursos);

            DataTable dtAlumnos_Cursos = new DataTable("Alumnos_Cursos");
            DataColumn dtCol_ac_IDAlumno = new DataColumn("IDAlumno", typeof(int));
            DataColumn dtCol_ac_IDCurso = new DataColumn("IDCurso", typeof(int));
            dtAlumnos_Cursos.Columns.Add(dtCol_ac_IDAlumno);
            dtAlumnos_Cursos.Columns.Add(dtCol_ac_IDCurso);

            dsUniversidad.Tables.Add(dtAlumnos_Cursos);

            DataRelation relAlumno_ac = new DataRelation("Alumno_Cursos", dtColIDAlumno, dtCol_ac_IDAlumno);
            DataRelation relCurso_ac = new DataRelation("Curso_Alumnos", dtColIDCurso, dtCol_ac_IDCurso);
            dsUniversidad.Relations.Add(relAlumno_ac);
            dsUniversidad.Relations.Add(relCurso_ac);

            DataRow rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos[dtCol_ac_IDAlumno] = 0;
            rwAlumnosCursos[dtCol_ac_IDCurso] = 1;
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);

            rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos[dtCol_ac_IDAlumno] = 1;
            rwAlumnosCursos[dtCol_ac_IDCurso] = 1;
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);

            Console.Write("Por favor, ingrese el nombre del curso: ");
            string materia = Console.ReadLine();
            Console.WriteLine("Listado de alumnos del curso " + materia);
            DataRow[] row_CursoInf = dtCursos.Select("Curso = '" + materia + "'");
            foreach (DataRow rowCu in row_CursoInf)
            {
                DataRow[] row_AlumnosInf = rowCu.GetChildRows(relCurso_ac);
                foreach (DataRow rowAl in row_AlumnosInf)
                {
                    Console.WriteLine(
                        rowAl.GetParentRow(relAlumno_ac)[dtColApellido].ToString()
                        + ", " +
                        rowAl.GetParentRow(relAlumno_ac)[dtColNombre].ToString()
                        );
                }
            }
            Console.ReadLine();
        }
    }
}
