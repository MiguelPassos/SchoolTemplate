using Microsoft.Extensions.Options;
using SchoolEntities;
using SchoolRepository.Configuration;
using SchoolRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SchoolRepository.Services
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(IOptions<SchoolConfigOptions> options) : base(options) { }

        public DataTable GetUserData(string login, string password)
        {
            using (var conn = new SqlConnection(_config.Value.LocalConnection))
            {
                try
                {
                    using (var cmd = new SqlCommand("SP_GET_USER_DATA_ACCESS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@LOGIN", login);
                        cmd.Parameters.AddWithValue("@SENHA", password);

                        conn.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            using (var dt = new DataTable())
                            {
                                dt.Load(reader);
                                return dt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
        }

        public DataTable GetUserData(string document)
        {
            using (var conn = new SqlConnection(_config.Value.LocalConnection))
            {
                try
                {
                    using (var cmd = new SqlCommand("SP_GET_USER_DATA_BY_DOC", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@CPF", document);

                        conn.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            using (var dt = new DataTable())
                            {
                                dt.Load(reader);
                                return dt;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
        }

        public void RegisterNewUser(Usuario user, string doc) 
        {
            using (var conn = new SqlConnection(_config.Value.LocalConnection))
            {
                try
                {
                    using (var cmd = new SqlCommand("SP_INSERT_NEW_USER_ACCESS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@CPF", doc);
                        cmd.Parameters.AddWithValue("@LOGIN", user.Login);
                        cmd.Parameters.AddWithValue("@SENHA", user.Senha);
                        cmd.Parameters.AddWithValue("@TOKEN", user.Token);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
        }
    }
}
