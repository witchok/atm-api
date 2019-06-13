using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATMBankDAL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper.Mappers;
using AutoMapper;
using ATMBankWebAPI.Mapping;
using Microsoft.AspNetCore.Cors.Infrastructure;
using ATMBankDAL.Data.DataInitialization;
using ATMBankWebAPI.Filters;
using ATMBankDAL.Data.Repositories.Cards;
using ATMBankWebAPI.Services;

namespace ATMBankWebAPI
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _env = env;
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc(config =>
            {
                config.Filters.Add(new ATMExceptionFilter());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddDbContextPool<ATMBankContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ATMConnection"),
                                    o => o.EnableRetryOnFailure())
                                    .UseLazyLoadingProxies()
                                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.
                                                                        QueryClientEvaluationWarning)));
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICardService, CardService>();
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseCors("SiteCorsPolicy");
        }
    }
}
