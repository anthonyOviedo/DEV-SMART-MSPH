﻿using Business.Base;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Data;
using static Business.Utilities.Functions;

namespace Business.Services 
{
    class ComplainService : BaseService, IDisposable
    {

        #region Definition of Properties
        public long cantidad { get; set; }
        #endregion
        #region Definition of Constructors
        public ComplainService() : base()
        {

        }
        #endregion

        #region Definition of Public Methods
        public List<Complain> Lista(string user_Id)
        {
            List<Complain> complains = new List<Complain>();
            DataSet data;
            string query;

            try
            {
                connection.Open();

                query = "CALL Complain_list ('" + user_Id.Trim() + "')";

                data = connection.SelectData(query);

                if (data == null || data.Tables.Count == 0)
                    VerifyMessage("Ocurrió un error durante la transacción por favor inténtelo de nuevo");

                foreach (DataRow row in data.Tables[0].Rows)
                {
                    complains.Add(new Complain()
                    {
                        Complain_Id = int.Parse(row["Complain_Id"].ToString()),
                        Description = row["Description"].ToString(),
                        state = int.Parse(row["state"].ToString()),
                        employee = int.Parse(row["employee"].ToString()),
                        
                    });
                }

                this.cantidad = long.Parse(data.Tables[1].Rows[0]["Cantidad"].ToString());

                return complains;
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
