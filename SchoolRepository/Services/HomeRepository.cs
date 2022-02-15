using SchoolRepository.Configuration;
using SchoolRepository.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SchoolRepository.Services
{
    public class HomeRepository : BaseRepository, IHomeRepository
    {
        public HomeRepository(IOptions<SchoolConfigOptions> options) : base(options) { }

        public DataTable GetRandomEmployeesProfiles()
        {
            using (var conn = new SqlConnection(_config.Value.LocalConnection))
            {
                try
                {
                    using (var cmd = new SqlCommand("SP_GET_RANDOM_EMPLOYEES_PROFILES", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

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
