using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SportSystemAPI.Context;
using SportSystemAPI.Data.Item;
using SportSystemAPI.Data.User;
using SportSystemAPI.Data.Cart;
using SportSystemAPI.Data.Workout;
using SportSystemAPI.Data.WorkoutRegistration;
using SportSystemAPI.Data.Subscription;

namespace SportSystemAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SportSystemAPI", Version = "v1" });
            });

            services.AddDbContext<SportSystemContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("SportSystem")));

            services.AddScoped<IItemRepo, SqlItemRepo>();
            services.AddScoped<ICartRepo, SqlCartRepo>();
            services.AddScoped<IUserRepo, SqlUserRepo>();
            services.AddScoped<IWorkoutRepo, SqlWorkoutRepo>();
            services.AddScoped<IWorkoutRegistrationRepo, SqlWorkoutRegistrationRepo>();
            services.AddScoped<ISubRepo, SqlSubRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SportSystemAPI v1"));

                app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
