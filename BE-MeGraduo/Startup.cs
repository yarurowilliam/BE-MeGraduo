using BE_MeGraduo.Persistence.Context;
using BE_MeGraduo.Repositories.DocenteRepositories;
using BE_MeGraduo.Repositories.DocenteRepositories.Implementation;
using BE_MeGraduo.Repositories.EstudianteRepositories;
using BE_MeGraduo.Repositories.EstudianteRepositories.Implementation;
using BE_MeGraduo.Repositories.FacultadRepositories;
using BE_MeGraduo.Repositories.FacultadRepositories.Implementation;
using BE_MeGraduo.Repositories.LoginRepositories;
using BE_MeGraduo.Repositories.LoginRepositories.Implementation;
using BE_MeGraduo.Repositories.ModalidadRepositories;
using BE_MeGraduo.Repositories.ModalidadRepositories.Implementation;
using BE_MeGraduo.Repositories.PersonaRepositories;
using BE_MeGraduo.Repositories.PersonaRepositories.Implementation;
using BE_MeGraduo.Repositories.ProgramaRepositories;
using BE_MeGraduo.Repositories.ProgramaRepositories.Implementation;
using BE_MeGraduo.Repositories.ProyectoDeGradoRepositories;
using BE_MeGraduo.Repositories.ProyectoDeGradoRepositories.Implementation;
using BE_MeGraduo.Repositories.RolRepositories;
using BE_MeGraduo.Repositories.RolRepositories.Implementation;
using BE_MeGraduo.Repositories.SedeRepositories;
using BE_MeGraduo.Repositories.SedeRepositories.Implementation;
using BE_MeGraduo.Repositories.SubModalidadRepositories;
using BE_MeGraduo.Repositories.SubModalidadRepositories.Implementation;
using BE_MeGraduo.Repositories.UsuarioRepositories;
using BE_MeGraduo.Repositories.UsuarioRepositories.Implementation;
using BE_MeGraduo.Repositories.UsuarioRolRepositories;
using BE_MeGraduo.Repositories.UsuarioRolRepositories.Implementation;
using BE_MeGraduo.Services.DocenteServices;
using BE_MeGraduo.Services.DocenteServices.Implementation;
using BE_MeGraduo.Services.EstudianteServices;
using BE_MeGraduo.Services.EstudianteServices.Implementation;
using BE_MeGraduo.Services.FacultadServices;
using BE_MeGraduo.Services.FacultadServices.Implementation;
using BE_MeGraduo.Services.LoginServices;
using BE_MeGraduo.Services.LoginServices.Implementation;
using BE_MeGraduo.Services.ModalidadServices;
using BE_MeGraduo.Services.ModalidadServices.Implementation;
using BE_MeGraduo.Services.PersonaServices;
using BE_MeGraduo.Services.PersonaServices.Implementation;
using BE_MeGraduo.Services.ProgramaServices;
using BE_MeGraduo.Services.ProgramaServices.Implementation;
using BE_MeGraduo.Services.ProyectoDeGradoServices;
using BE_MeGraduo.Services.ProyectoDeGradoServices.Implementation;
using BE_MeGraduo.Services.RolServices;
using BE_MeGraduo.Services.RolServices.Implementation;
using BE_MeGraduo.Services.SedeServices;
using BE_MeGraduo.Services.SedeServices.Implementation;
using BE_MeGraduo.Services.SubModalidadService;
using BE_MeGraduo.Services.SubModalidadService.Implementation;
using BE_MeGraduo.Services.UsuarioRolServices;
using BE_MeGraduo.Services.UsuarioRolServices.Implementation;
using BE_MeGraduo.Services.UsuarioServices;
using BE_MeGraduo.Services.UsuarioServices.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace BE_MeGraduo
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddDbContext<AplicationDbContext>(options =>
			//	options.UseMySql(Configuration.GetConnectionString("Conexion")));
			services.AddDbContext<AplicationDbContext>(opt =>
				opt.UseSqlServer(Configuration.GetConnectionString("connection_db")));

			#region ['Configuracion de Interfaces e implementaciones]
			services.AddScoped<IUsuarioRepository, UsuarioRepository>();
			services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRolRepository, UsuarioRolRepository>();
            services.AddScoped<IUsuarioRolService, UsuarioRolService>();
            services.AddScoped<ILoginRepository, LoginRepository>();
			services.AddScoped<ILoginService, LoginService>();
			services.AddScoped<IRolRepository, RolRepository>();
			services.AddScoped<IRolService, RolService>();
            services.AddScoped<ISedeRepository, SedeRepository>();
            services.AddScoped<ISedeService, SedeService>();
            services.AddScoped<IFacultadRepository, FacultadRepository>();
            services.AddScoped<IFacultadService, FacultadService>();
            services.AddScoped<IProgramaRepository, ProgramaRepository>();
            services.AddScoped<IProgramaService, ProgramaService>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<IEstudianteRepository, EstudianteRepository>();
            services.AddScoped<IEstudianteService, EstudianteService>();
            services.AddScoped<IDocenteRepository, DocenteRepository>();
            services.AddScoped<IDocenteService, DocenteService>();
            services.AddScoped<IModalidadRepository, ModalidadRepository>();
            services.AddScoped<IModalidadService, ModalidadService>();
            services.AddScoped<ISubModalidadRepository, SubModalidadRepository>();
            services.AddScoped<ISubModalidadService, SubModalidadService>();
            services.AddScoped<IProyectoGradoRepository, ProyectoGradoRepository>();
            services.AddScoped<IProyectoGradoService, ProyectoGradoService>();
            #endregion

            // Cors
            services.AddCors(options => options.AddPolicy("AllowWebapp",
												builder => builder.AllowAnyOrigin()
																  .AllowAnyHeader()
																  .AllowAnyMethod()));

			//Add Authentication
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuer = true,
							ValidateAudience = true,
							ValidateLifetime = true,
							ValidateIssuerSigningKey = true,
							ValidIssuer = Configuration["Jwt:Issuer"],
							ValidAudience = Configuration["Jwt:Audience"],
							IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
							ClockSkew = TimeSpan.Zero
						});

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tu API", Version = "v1" });
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors("AllowWebapp");

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tu API v1");
			});
		}
	}
}
