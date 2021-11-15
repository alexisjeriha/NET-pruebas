using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias m INNER JOIN planes p on m.id_plan = p.id_plan "
                   + " INNER JOIN especialidades e on p.id_especialidad = e.id_especialidad", SqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];

                    Plan pla = new Plan();
                    pla.ID = (int)drMaterias["id_plan"];
                    pla.Descripcion = (string)drMaterias["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drMaterias["id_especialidad"];
                    esp.Descripcion = (string)drMaterias["desc_especialidad"];

                    pla.Especialidad = esp;
                    mat.Plan = pla;
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return materias;
        }

        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("select * from materias m INNER JOIN planes p on m.id_plan = p.id_plan "
                    + "INNER JOIN especialidades e on p.id_especialidad = e.id_especialidad where id_materia=@id", SqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMateria.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];

                    Plan pla = new Plan();
                    pla.ID = (int)drMaterias["id_plan"];
                    pla.Descripcion = (string)drMaterias["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drMaterias["id_especialidad"];
                    esp.Descripcion = (string)drMaterias["desc_especialidad"];

                    pla.Especialidad = esp;

                    mat.Plan = pla;
                }

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return mat;
        }

        public bool ExisteMateria(int idPlan, string desc)
        {
            bool existeMate;
            try
            {
                OpenConnection();
                SqlCommand cmdExisteMate = new SqlCommand("select * from materias where "
                    + "id_plan=@idPlan and desc_materia=@desc", SqlConn);
                cmdExisteMate.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = desc;
                cmdExisteMate.Parameters.Add("@idPlan", SqlDbType.Int).Value = idPlan;
                existeMate = Convert.ToBoolean(cmdExisteMate.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return existeMate;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Materia mat)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE materias SET desc_materia=@desc, hs_semanales=@hsSem, hs_totales=@hsTot WHERE "
                    + "id_materia=@id and id_plan=@idPlan", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = mat.ID;
                cmdUpdate.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdUpdate.Parameters.Add("@hsSem", SqlDbType.Int).Value = mat.HSSemanales;
                cmdUpdate.Parameters.Add("@hsTot", SqlDbType.Int).Value = mat.HSTotales;
                cmdUpdate.Parameters.Add("@idPlan", SqlDbType.Int).Value = mat.Plan.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Materia mat)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into materias(desc_materia,hs_semanales,hs_totales,id_plan) " +
                "values(@desc,@hsSem,@hsTot,@idPlan) " +
                "select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdInsert.Parameters.Add("@hsSem", SqlDbType.Int).Value = mat.HSSemanales;
                cmdInsert.Parameters.Add("@hsTot", SqlDbType.Int).Value = mat.HSTotales;
                cmdInsert.Parameters.Add("@idPlan", SqlDbType.Int).Value = mat.Plan.ID;
                mat.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear una nueva materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Materia mat)
        {
            try
            {
                if (mat.State == BusinessEntity.States.Deleted)
                {
                    Delete(mat.ID);
                }
                else if (mat.State == BusinessEntity.States.New)
                {
                    Insert(mat);
                }
                else if (mat.State == BusinessEntity.States.Modified)
                {
                    Update(mat);
                }
                mat.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar guardar la materia", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<Materia> GetMateriasParaInscripcion(int IDPlan, int IDAlumno)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                OpenConnection();
                SqlCommand cmdGetMateriasParaInscripcion = new SqlCommand("select * from materias m INNER JOIN planes p on m.id_plan = p.id_plan "
                    + "INNER JOIN personas pe on pe.id_plan=p.id_plan WHERE id_persona=@idAlumno and pe.id_plan=@idPlan", SqlConn);
                cmdGetMateriasParaInscripcion.Parameters.Add("@idPlan", SqlDbType.Int).Value = IDPlan;
                cmdGetMateriasParaInscripcion.Parameters.Add("@idAlumno", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drMaterias = cmdGetMateriasParaInscripcion.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];

                    Plan pla = new Plan();
                    pla.ID = (int)drMaterias["id_plan"];
                    mat.Plan = pla;
                    materias.Add(mat);
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar las materias disponibles para el alumno.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return materias;
        }


    }
}
