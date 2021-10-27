using AutoMapper;
using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Services;
using InvoiceApi.Database;
using InvoiceApi.Database.Interfaces;
using InvoiceApi.Database.Reporsitories;
using InvoiceApi.Infrastructure.Profiles;
using InvoiceApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using InvoiceApi.Common.Interfaces.Mappers;
using InvoiceApi.Services;

namespace InvoiceApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(option =>
            {
                option.SlidingExpiration = true;
            });

            services.AddDbContext<InvoiceDbContext>();
            services.AddControllers();
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InvoiceApi", Version = "v1" });
            });
            RegisterServices(services);
            ConfigureAutoMapper(services);
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new ItemProfile());
                mc.AddProfile(new MyCompanyProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InvoiceApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../../Invoice";
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            app.UseCors(
                options => options.WithOrigins("https://localhost:44398/", "https://localhost:5001/").AllowAnyMethod()
            );

            var dbContext = new InvoiceDbContext();
            dbContext.Database.Migrate();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMapUserService, MapUserService>();
            services.AddScoped<ITokenizer, Tokenizer>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailsService, GmailSmtpEmailsService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IMapItemService, MapItemService>();
            services.AddScoped<IMapMyCompanyService, MapMyCompanyService>();
            services.AddScoped<IMyCompanyService, MyCompanyService>();
            services.AddScoped<IMyCompanyRepository, MyCompanyRepository>();
        }
    }
}
