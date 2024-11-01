using Application.IService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly IConfiguration _configuration;

        public EnvironmentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? GetTestVariable()
        {
            return _configuration["MY_TEST_VARIABLE"];
        }
        
        
    }
}
