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
    public class BaseRepository : IBaseRepository
    {
        public readonly IOptions<SchoolConfigOptions> _config;

        public BaseRepository(IOptions<SchoolConfigOptions> options)
        {
            _config = options;
        }

        public DataTable GetUserMenu(int idUser) 
        {
            using (var conn = new SqlConnection(_config.Value.LocalConnection))
            {
                try
                {
                    using (var cmd = new SqlCommand("SP_GET_USER_MENU", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@IDUSUARIO", idUser);

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
