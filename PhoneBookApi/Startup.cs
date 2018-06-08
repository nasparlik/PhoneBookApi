using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PhoneBookApi.Core;
using PhoneBookApi.Persistence;

namespace PhoneBookApi
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
            services.AddMvc();
            services.AddDbContext<PhoneBookDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper();

            //Add Authentication Services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = "https://test-projects.eu.auth0.com/";
                options.Audience = "http://localhost:4402/api/";
            });

            //TEST ACCESS TOKEN
            //key : Authorization
            //Value: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik16QXdSa05HTVRWQ01ERTVNekJEUWpRNFJESkNOVGcwTVRCRE1qZ3pSVGxDTmpjM1FqZEdRZyJ9.eyJpc3MiOiJodHRwczovL3Rlc3QtcHJvamVjdHMuZXUuYXV0aDAuY29tLyIsInN1YiI6IjhXelFhNTc4akFQRTF4b1ZWM0trRUtuajhKbVJZMkkyQGNsaWVudHMiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQ0MDIvYXBpLyIsImlhdCI6MTUyODQ0OTA2MCwiZXhwIjoxNTI4NTM1NDYwLCJhenAiOiI4V3pRYTU3OGpBUEUxeG9WVjNLa0VLbmo4Sm1SWTJJMiIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.BSgbIkgWa9mgpDtt-m1DjE5rQu8rdg0Dh7YUeULUBjONl-Dc4hFM4fjyAEBpyv8XgLZ8MWEFtnPWVB0pRG7806uSVq5EDLuYC52tXrxZQWAy9We_tZURTZaxNRZZew33ruAy0PG6tcDwkgJRd3Q5jaBgsGh-h2TqRt_yVO-u-wKkOnjM8039vQewVOo78bUmSnMy-029IpRKvEFOEZ-zU9ghhuIhsTHZCyYCD5rFempDrpSrHN6IkC_i95ME2hoaMZTY-1k0D7_dzYLq04WoZX-0hqyANoMLV0NEo1uJxL05VIp26xEzHYkw-xdLSXTy_ub7kKwj-Wu5fW7qbVziTw
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //  Enable authentication middleware
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
