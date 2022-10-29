using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Shop.Api.Models;
using Shop.Api.Models.Common;
using Shop.Api.Services.Sales;
using Shop.Api.Services.Sales.Contract;
using Shop.Api.Services.Security;
using Shop.Api.Services.Security.Contract;

namespace Shop.Api
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
            services.AddControllers();
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            #region"Token Config"
            var tokenSetting = Configuration.GetSection("TokenInfo");

            services.Configure<TokenInfo>(tokenSetting);

            var tokenInfo = tokenSetting.Get<TokenInfo>();

            var key = Encoding.ASCII.GetBytes(tokenInfo.SigningKey);

            services.AddAuthentication(jb =>
            {
                jb.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                jb.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jb => 
            {
                jb.RequireHttpsMetadata = false;
                jb.SaveToken = true;
                jb.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key), 
                    ValidateIssuer=false,
                    ValidateAudience = false,
                };
            });
            #endregion

            services.AddDbContext<ShopContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("ShopDatabase")));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISaleService, SaleService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
                     

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
    }
}
