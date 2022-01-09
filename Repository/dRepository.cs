using Dapper;
using Rinku.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinku.Repository
{
    public class dRepository<T> 
        //: IRepository<T> where T : class
    {

        public string GetConnection()
        {
            var connection = "Server=PCJUAN;Database=Rinku;Trusted_Connection=True;";
            return connection;
        }
        private DynamicParameters CrearParametros(string[] Parametros, string[] Variables)
        {
            var sparam = "";
            var svalor = "";
            var paramNew = new DynamicParameters();
            for (var i = 0; i < Parametros.Length; i++)
            {
                sparam = Parametros[i];
                svalor = Variables[i];
                paramNew.Add(sparam, svalor);
            }

            return paramNew;
        }
        public string BuscarReg(string NameProc,string[] storedParam, string[] cVariables)// int id, string folio = null)
        {
            string valorR="";
            using (SqlConnection con = new SqlConnection( this.GetConnection()))
            {
                try
                {
                    con.Open();
                    //------------------Crea los parametros para el stored
                    var param = new DynamicParameters();
                    param = CrearParametros(storedParam, cVariables);
                    //-----------------------------------
                    valorR=con.Query<string>(NameProc, param, null, true, 0, CommandType.StoredProcedure).First();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return valorR;
            }
        }
        public async Task<IEnumerable> BDListaCombo(string NomStored, string[] storedParam, string[] cVariables)
        {
            IEnumerable lLista;
            using (SqlConnection con = new SqlConnection(this.GetConnection()))
            {
                try
                {
                    //------------------Crea los parametros para el stored
                    var param = new DynamicParameters();
                    param = CrearParametros(storedParam, cVariables);
                    //-----------------------------------
                    lLista = await con.QueryAsync<T>(NomStored, param: param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return lLista;
            }

        }
        public async Task<int> BDAddAsync(string NomStored, string[] storedParam, string[] cVariables)
        {
            int Regresar = 1;
            using (SqlConnection con = new SqlConnection(this.GetConnection()))
            {
                await con.OpenAsync();
                SqlTransaction sqltrans = null;
                try
                {
                    //------------------Crea los parametros para el stored
                    var param = new DynamicParameters();
                    param = CrearParametros(storedParam, cVariables);
                    //-----------------------------------
                    sqltrans = con.BeginTransaction();

                    await con.ExecuteAsync(NomStored, param, sqltrans, 0, CommandType.StoredProcedure);

                    sqltrans.Commit();
                }
                catch (Exception ex)
                {
                    Regresar = -1;
                    sqltrans.Rollback();
                    con.Close();
                }
                finally
                {
                    sqltrans.Dispose();
                    con.Close();
                }
                return Regresar;
            }

        }
        public async Task<List<T>> BDListaDatos(string NameProc, string[] storedParam, string[] cVariables)
        {
            IEnumerable<T> result;
            using (SqlConnection con = new SqlConnection(this.GetConnection()))
            {
                con.Open();
                try
                {
                    //------------------Crea los parametros para el stored
                    var param = new DynamicParameters();
                    param = CrearParametros(storedParam, cVariables);
                    //-----------------------------------
                    result = await con.QueryAsync<T>(NameProc, param: param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return result.ToList();
            }

        }
        public int BDAccionReg(string NameProc, string[] storedParam, string[] cVariables)
        {
            int Regreso = 1;
            using (SqlConnection con = new SqlConnection(this.GetConnection()))
            {
                con.Open();
                SqlTransaction sqltrans = null;
                try
                {
                    sqltrans = con.BeginTransaction();
                    //------------------Crea los parametros para el stored
                    var param = new DynamicParameters();
                    param = CrearParametros(storedParam, cVariables);
                    //-----------------------------------
                    con.Execute(NameProc, param, sqltrans, 0, CommandType.StoredProcedure);

                    sqltrans.Commit();
                }
                catch (Exception ex)
                {
                    Regreso = -1;
                    sqltrans.Rollback();
                    con.Close();
                    throw ex;
                }
                finally
                {
                    sqltrans.Dispose();
                    con.Close();
                }
                return Regreso;
            }

        }


    }
}
