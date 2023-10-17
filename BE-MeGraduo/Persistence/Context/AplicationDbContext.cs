using BE_MeGraduo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BE_MeGraduo.Persistence.Context
{
	public class AplicationDbContext : DbContext
	{
        public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Persona> Personas { get; set; }
		public DbSet<Rol> Roles { get; set; }
		public DbSet<UsuarioRol> UsuarioRoles { get; set; }
		public DbSet<Sede> Sedes { get; set; }
		public DbSet<Facultad> Facultades { get; set; }
		public DbSet<Programa> Programas { get; set; }
		public DbSet<Estudiante> Estudiantes { get; set; }
		public DbSet<Docente> Docentes { get; set; }
		public DbSet<Modalidad> Modalidades {  get; set; }
        public DbSet<SubModalidad> SubModalidades { get; set; }
		public DbSet<ProyectoGrado> ProyectosDeGrado { get; set; }
		public DbSet<FileProyectosGrado> FilesProyectosGrados { get; set; }
		public DbSet<InformacionProyectoGradoFase1> InformacionProyectosGradoFase1 { get; set; }
        public DbSet<InformacionProyectoGradoFase2> InformacionProyectosGradoFase2 { get; set; }
		public DbSet<ConsultaEstudianteValidado> ConsultaEstudianteValidados { get; set; }
		public DbSet<ConsultaDocenteValidado> ConsultaDocenteValidados { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) 
		{ 
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Usuario>()
				.HasKey(u => new { u.Identificacion });

			modelBuilder.Entity<Persona>()
				.HasKey(p => new { p.Identificacion });

			modelBuilder.Entity<Usuario>()
			.HasIndex(u => u.Email)
			.IsUnique();

			modelBuilder.Entity<Persona>()
			.HasIndex(u => u.Email)
			.IsUnique();

			base.OnModelCreating(modelBuilder);
		}
	}
}
