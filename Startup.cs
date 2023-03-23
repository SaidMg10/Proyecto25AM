using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM
{
    public class Startup
    {
        private readonly string _Mis_politicas = "MyCors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) 
        {
            // Add services to the container.
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Inyeccion de dependencias
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<IClienteServices, ClienteServices>();
            services.AddTransient<IDepartamentoServices, DepartamentoServices>();
            services.AddTransient<IFacturaServices, FacturaServices>();
            services.AddTransient<IPuestoServices, PuestoServices>();
            services.AddTransient<IRolServices, RolServices>();
            services.AddTransient<IEmpleadosServices, EmpleadosServices>();


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            //agregar politicas

            services.AddCors(options =>
            {
                options.AddPolicy(name: _Mis_politicas, builder =>
                {
                    //builder.WithOrigins("www.panchito.com");
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "locvalhost")
                    .AllowAnyHeader().AllowAnyMethod();
                });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(_Mis_politicas);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
