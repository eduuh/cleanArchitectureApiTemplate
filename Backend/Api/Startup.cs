using System;
using System.IO;
using Api.Middleware;
using Domain;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;
using Application;

namespace Api {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ICropal Developer Portal i was ",
                    Description = "Icropal Backend api",
                    Version = "V1",
                    Contact = new OpenApiContact
                    {
                        Name = "Icropal LTD",
                        Email = "icropal.com",
                        Url = null
                    }
                });

                c.IncludeXmlComments(GetXmlCommentsPath());
                c.CustomSchemaIds(x => x.ToString());

            });

            services.AddDbContext<IcropalDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction: sqloptions =>
                {
                    sqloptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                })
                );

        
            services.AddMediatR (typeof(Login.Handler).Assembly);

            services.AddMvc()
                .AddFluentValidation (cfg => cfg.RegisterValidatorsFromAssemblyContaining<Login> ())
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            // configuring Indentity for the applicatins
            var builder = services.AddIdentityCore<Domain.User> ();
            var identitybuilder = new IdentityBuilder (builder.UserType, builder.Services);
            identitybuilder.AddEntityFrameworkStores<IcropalDbContext> ();
            identitybuilder.AddSignInManager<SignInManager<Domain.User>> ();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Icropal Api");
                c.RoutePrefix = string.Empty;
            });
             

            if (env.IsDevelopment ()) {
                // app.UseDeveloperExceptionPage ();
            } else {

                app.UseHsts ();
            }
            app.UseAuthentication ();
            app.UseHttpsRedirection ();
            app.UseMvc ();
        }

        private string GetXmlCommentsPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Api.xml");
        }
    }
}