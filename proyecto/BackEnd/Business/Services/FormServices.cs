using Business.Base;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Data;
using static Business.Utilities.Functions;

namespace Business.Services
{
    public class FormServices : BaseService, IDisposable
    {
        
        
        #region Definition of Public Methods CRUD
       
        //allForms
        public List<Form> Lista(int departmet_id)
        {
            List<Form> forms = new List<Form>();
            DataSet data;
            string query;

            try
            {
                connection.Open();

                query = "exec FormList" + departmet_id.ToString();//busquedas por tipo

                data = connection.SelectData(query);

                if (data == null || data.Tables.Count == 0)
                    VerifyMessage("Ocurrió un error durante la transacción por favor inténtelo de nuevo");

                return forms;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //add
        public void addForm(Form form)
        {
            string query;

            try
            {
                connection.Open();
                connection.BeginTransaction();

               /* query = "CALL UsuarioRegistro (" + "" + user.persona.persona_Id.ToString() + ",'" + user.persona.nombre.Trim() + "','" +
                            user.persona.apellido1.Trim() + "','" + user.persona.apellido2.Trim() + "','" + user.persona.correo.Trim() +
                            "','" + user.persona.telefono.Trim() + "'," + user.usuario_Id.ToString() + ",'" + user.nombre.Trim() + "','" +
                             user.password.Trim() + "'," + user.rol.ToString() + ")";
                */
                //connection.Execute(query);


                connection.CommitTransaction();
            }
            catch (Exception ex)
            {
                connection.RollBackTransaction();
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //delete
        public void deleteForm(string formId)
        {
            string query;

            try
            {
                connection.Open();
                connection.BeginTransaction();

                query = "exec deleteForm'" + formId + "'";

                connection.Execute(query);
                connection.CommitTransaction();
            }
            catch (Exception ex)
            {
                connection.RollBackTransaction();
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //update
        public void updateForm(string nombre, string departmentId, string FormType,DateTime dateRegistered,string html)
        {
            string query;

            try
            {
                connection.Open();
                connection.BeginTransaction();

                query = "exec FormUpdate '" + usuario_Id + "'" +
                        ",'" + password + "','" + newPassword + "'";

                connection.Execute(query);
                connection.CommitTransaction();
            }
            catch (Exception ex)
            {
                connection.RollBackTransaction();
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion


        #region Implements Interface IDisposable
        public void Dispose()
        {
            if (connection != null)
                connection.Close();

            connection = null;
        }
        #endregion

    }
}

