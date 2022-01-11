using Microsoft.Extensions.Options;
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
    }
}
