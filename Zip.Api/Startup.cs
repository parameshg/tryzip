using System;
using System.Net;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Zip.Api.Behaviours;
using Zip.Business;
using Zip.Business.Users.Queries.GetUserById;
using Zip.Database;
using Zip.Database.Repositories;

namespace Zip.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddMemoryCache();
            services.AddCors(options => options.AddPolicy("api", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation(i => i.RegisterValidatorsFromAssemblyContaining<GetUserByIdRequest>());

            services.AddDbContext<ZipDbContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetUserByIdRequest).Assembly);

            services.AddSwaggerGen(i => i.SwaggerDoc("v1", new Info() { Title = "Zip Api", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment environment)
        {
            app.UseCors("api");

            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    context.Response.ContentType = "application/json";

                    var feature = context.Features.Get<IExceptionHandlerFeature>();

                    if (feature != null)
                    {
                        var json = JsonConvert.SerializeObject(new ZipResponse()
                        {
                            Error = true,
                            Message = environment.IsDevelopment() ? feature.Error.Message : "Error occured while processing request"
                        });

                        await context.Response.WriteAsync(json);
                    }
                });
            });

            app.UseSwagger();

            app.UseSwaggerUI(i => i.SwaggerEndpoint("/swagger/v1/swagger.json", "Zip Api"));

            app.ApplicationServices.GetService<ZipDbContext>().Database.EnsureCreated();

            app.UseMvc();
        }
    }
}