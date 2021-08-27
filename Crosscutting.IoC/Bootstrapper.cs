using Microsoft.EntityFrameworkCore;
using Data.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Services;
using Domain.Service.Services;
using Domain.Model.Interfaces.Repositories;
using Data.Repositories;

namespace Crosscutting.IoC
{
    public static class Bootstrapper
    {

        public static void RegisterServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PresentationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PresentationContext")));

            services.AddTransient<IProfessorService, ProfessorService>();
            services.AddTransient<IProfessorRepository, ProfessorRepository>();
            services.AddTransient<IAlunoService, AlunoService>();
            services.AddTransient<IAlunoRepository, AlunoRepository>();

        }
    }
}
