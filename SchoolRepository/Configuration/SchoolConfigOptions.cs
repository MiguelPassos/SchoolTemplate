using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRepository.Configuration
{
    public class SchoolConfigOptions
    {
        public string LocalConnection { get; set; }

        public string ProdConnection { get; set; }

        public string HomolConnection { get; set; }
    }
}
