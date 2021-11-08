using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones a INNER JOIN personas p on a.id_alumno=p.id_persona "
                    + "INNER JOIN cursos c on c.id_curso=a.id_curso INNER JOIN planes pl on pl.id_plan=p.id_plan INNER JOIN materias m on m.id_materia = c.id_materia " +
                    "INNER JOIN comisiones com on com.id_comision = c.id_comision where p.tipo_persona=1", SqlConn);
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];

                    Persona per = new Persona();
                    per.ID = (int)drInscripciones["id_persona"];
                    per.Nombre = (string)drInscripciones["nombre"];
                    per.Apellido = (string)drInscripciones["apellido"];
                    per.Email = (string)drInscripciones["email"];
                    per.Direccion = (string)drInscripciones["direccion"];
                    per.Telefono = (string)drInscripciones["telefono"];
                    per.FechaNacimiento = (DateTime)drInscripciones["fecha_nac"];
                    per.Legajo = (int)drInscripciones["legajo"];
                    switch ((int)drInscripciones["tipo_persona"])
                    {
                        case 1:
                            per.Tipo = "Alumno";
                            break;
                        case 2:
                            per.Tipo = "Docente";
                            break;
                    }
                    Plan pla = new Plan();
                    pla.ID = (int)drInscripciones["id_plan"];
                    per.Plan = pla;

                    Curso cur = new Curso();
                    cur.ID = (int)drInscripciones["id_curso"];
                    cur.AnioCalendario = (int)drInscripciones["anio_calendario"];

                    Materia mat = new Materia();
                    mat.Descripcion = (string)drInscripciones["desc_materia"];
                    cur.Materia = mat;

                    Comision com = new Comision();
                    com.DescComision = (string)drInscripciones["desc_comision"];
                    cur.Comision = com;

                    ins.Alumno = per;
                    ins.Curso = cur;

                    inscripciones.Add(ins);
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de las inscripciones de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return inscripciones;
        }

        public List<AlumnoInscripcion> GetRegulares()
        {
            List<AlumnoInscripcion> inscriptos = GetAll();
            List<AlumnoInscripcion> regulares = inscriptos.FindAll(i => i.Condicion == "Regular");
            return regulares;
        }
        public List<AlumnoInscripcion> GetAprobados()
        {
            List<AlumnoInscripcion> inscriptos = GetAll();
            List<AlumnoInscripcion> aprobado = inscriptos.FindAll(i => i.Condicion == "Aprobado");
            return aprobado;
        }
        public List<AlumnoInscripcion> GetLibres()
        {
            List<AlumnoInscripcion> inscriptos = GetAll();
            List<AlumnoInscripcion> libre = inscriptos.FindAll(i => i.Condicion == "Libre");
            return libre;
        }
        public List<AlumnoInscripcion> GetAll(int IDAlumno)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones a INNER JOIN personas p on a.id_alumno=p.id_persona "
                    + "INNER JOIN cursos c on c.id_curso=a.id_curso INNER JOIN planes pl on pl.id_plan=p.id_plan " +
                    "INNER JOIN materias m on m.id_materia=c.id_materia INNER JOIN comisiones co on co.id_comision=c.id_comision" +
                    " where id_alumno=@IDAlumno", SqlConn);
                cmdInscripciones.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];

                    Persona per = new Persona();
                    per.ID = (int)drInscripciones["id_persona"];
                    per.Nombre = (string)drInscripciones["nombre"];
                    per.Apellido = (string)drInscripciones["apellido"];
                    per.Email = (string)drInscripciones["email"];
                    per.Direccion = (string)drInscripciones["direccion"];
                    per.Telefono = (string)drInscripciones["telefono"];
                    per.FechaNacimiento = (DateTime)drInscripciones["fecha_nac"];
                    per.Legajo = (int)drInscripciones["legajo"];
                    switch ((int)drInscripciones["tipo_persona"])
                    {
                        case 1:
                            per.Tipo = "Alumno";
                            break;
                        case 2:
                            per.Tipo = "Docente";
                            break;

                    }
                    Plan pla = new Plan();
                    pla.ID = (int)drInscripciones["id_plan"];
                    per.Plan = pla;

                    Curso cur = new Curso();
                    cur.ID = (int)drInscripciones["id_curso"];
                    cur.AnioCalendario = (int)drInscripciones["anio_calendario"];
                    Comision com = new Comision();
                    com.DescComision = (string)drInscripciones["desc_comision"];
                    Materia mat = new Materia();
                    mat.Descripcion = (string)drInscripciones["desc_materia"];
                    cur.Comision = com;
                    cur.Materia = mat;

                    ins.Alumno = per;
                    ins.Curso = cur;

                    inscripciones.Add(ins);
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de las inscripciones del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();
            try
            {
                OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones a INNER JOIN personas p on a.id_alumno=p.id_persona "
                    + "INNER JOIN cursos c on c.id_curso=a.id_curso INNER JOIN planes pl on pl.id_plan=p.id_plan" +
                    " where id_inscripcion=@id", SqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                if (drInscripciones.Read())
                {
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];

                    Persona per = new Persona();
                    per.ID = (int)drInscripciones["id_persona"];
                    per.Nombre = (string)drInscripciones["nombre"];
                    per.Apellido = (string)drInscripciones["apellido"];
                    per.Email = (string)drInscripciones["email"];
                    per.Direccion = (string)drInscripciones["direccion"];
                    per.Telefono = (string)drInscripciones["telefono"];
                    per.FechaNacimiento = (DateTime)drInscripciones["fecha_nac"];
                    per.Legajo = (int)drInscripciones["legajo"];
                    switch ((int)drInscripciones["tipo_persona"])
                    {
                        case 1:
                            per.Tipo = "Alumno";
                            break;
                        case 2:
                            per.Tipo = "Docente";
                            break;
                    }
                    Plan pla = new Plan();
                    pla.ID = (int)drInscripciones["id_plan"];
                    per.Plan = pla;

                    Curso cur = new Curso();
                    cur.ID = (int)drInscripciones["id_curso"];

                    ins.Alumno = per;
                    ins.Curso = cur;
                }

                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de la inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return ins;
        }

        public bool ExisteInscripcion(int idAlu, int idCur)
        {
            bool existeInscripcion;
            try
            {
                OpenConnection();
                SqlCommand cmdExisteInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_alumno=@idAlu and id_curso=@idCur", SqlConn);
                cmdExisteInscripcion.Parameters.Add("@idAlu", SqlDbType.Int).Value = idAlu;
                cmdExisteInscripcion.Parameters.Add("@idCur", SqlDbType.Int).Value = idCur;
                existeInscripcion = Convert.ToBoolean(cmdExisteInscripcion.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la Inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return existeInscripcion;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE alumnos_inscripciones SET condicion=@condicion, nota=@nota "
                   + "WHERE id_inscripcion=@id and id_alumno=@idAlumno and id_curso=@idCurso", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmdUpdate.Parameters.Add("@idAlumno", SqlDbType.Int).Value = inscripcion.Alumno.ID;
                cmdUpdate.Parameters.Add("@idCurso", SqlDbType.Int).Value = inscripcion.Curso.ID;
                cmdUpdate.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into alumnos_inscripciones(id_alumno,id_curso,condicion,nota) " +
                "values(@idAlumno,@idCurso,@condicion,@nota) " +
                "select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@idAlumno", SqlDbType.Int).Value = inscripcion.Alumno.ID;
                cmdInsert.Parameters.Add("@idCurso", SqlDbType.Int).Value = inscripcion.Curso.ID;
                cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdInsert.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                inscripcion.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear nueva inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.New)
            {
                Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }
    }
}
