using SchoolRepository.Configuration;
using SchoolRepository.Inte3rfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRepository.Services
{
    public class HomeRepository : IHomeRepository
    {
        private readonly IOptions<SchoolConfigOptions> _config;

        public HomeRepository(IOptions<SchoolConfigOptions> options) => _config = options;

        public void Teste()
        {
            string x = _config.Value.LocalConnection;
        }
    }
}
