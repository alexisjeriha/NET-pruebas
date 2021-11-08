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
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos c INNER JOIN materias m on c.id_materia = m.id_materia "
                   + " INNER JOIN planes p on p.id_plan = m.id_plan INNER JOIN comisiones co on c.id_comision = co.id_comision", SqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCursos["id_curso"];

                    Materia mat = new Materia();
                    mat.ID = (int)drCursos["id_materia"];
                    mat.Descripcion = (string)drCursos["desc_materia"];
                    mat.HSSemanales = (int)drCursos["hs_semanales"];
                    mat.HSTotales = (int)drCursos["hs_totales"];

                    Plan pla = new Plan();
                    pla.Id = (int)drCursos["id_plan"];
                    mat.Plan = pla;

                    Comision com = new Comision();
                    com.IdComision = (int)drCursos["id_comision"];
                    com.DescComision = (string)drCursos["desc_comision"];
                    com.AnioEspecialidad = (int)drCursos["anio_especialidad"];
                    com.Plan = pla;

                    curso.Comision = com;
                    curso.Materia = mat;
                    cursos.Add(curso);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso curso = new Curso();
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos c INNER JOIN materias m on c.id_materia = m.id_materia"
                   + " INNER JOIN planes p on p.id_plan = m.id_plan INNER JOIN especialidades e on e.id_especialidad = p.id_especialidad"
                   + " INNER JOIN comisiones co on c.id_comision = co.id_comision where id_curso=@id"
                   , SqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];

                    Materia mat = new Materia();
                    mat.ID = (int)drCursos["id_materia"];
                    mat.Descripcion = (string)drCursos["desc_materia"];
                    mat.HSSemanales = (int)drCursos["hs_semanales"];
                    mat.HSTotales = (int)drCursos["hs_totales"];

                    Comision com = new Comision();
                    com.ID = (int)drCursos["id_comision"];
                    com.DescComision = (string)drCursos["desc_comision"];
                    com.AnioEspecialidad = (int)drCursos["anio_especialidad"];

                    Plan pla = new Plan();
                    pla.ID = (int)drCursos["id_plan"];
                    pla.Descripcion = (string)drCursos["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drCursos["id_especialidad"];
                    esp.Descripcion = (string)drCursos["desc_especialidad"];

                    pla.Especialidad = esp;
                    com.Plan = pla;
                    curso.Materia = mat;
                    curso.Comision = com;
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return curso;
        }

        public bool ExisteCurso(int idMat, int idCom, int anio)
        {
            bool existe;
            try
            {
                OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select * from cursos where "
                    + "id_materia=@idMat and id_comision=@idCom and anio_calendario=@anio", SqlConn);
                cmdGetOne.Parameters.Add("@idMat", SqlDbType.Int).Value = idMat;
                cmdGetOne.Parameters.Add("@idCom", SqlDbType.Int).Value = idCom;
                cmdGetOne.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return existe;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_plan=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE cursos SET id_comision=@idCom, id_materia=@idMat, anio_calendario=@anio, cupo=@cupo "
                    + "WHERE id_curso=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdUpdate.Parameters.Add("@idCom", SqlDbType.Int).Value = curso.Comision.ID;
                cmdUpdate.Parameters.Add("@idMat", SqlDbType.Int).Value = curso.Materia.ID;
                cmdUpdate.Parameters.Add("@anio", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdUpdate.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into cursos(id_materia,id_comision,anio_calendario,cupo) " +
                "values(@idMat,@idCom,@anio,@cupo) " +
                "select @@identity", SqlConn);
                cmdInsert.Parameters.Add("@idMat", SqlDbType.Int).Value = curso.Materia.ID;
                cmdInsert.Parameters.Add("@idCom", SqlDbType.Int).Value = curso.Comision.ID;
                cmdInsert.Parameters.Add("@anio", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdInsert.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear un nuevo curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
