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
    }
}
