﻿// <auto-generated />
using System;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BE_MeGraduo.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20231017014153_October160841pm")]
    partial class October160841pm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaComentario")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdPersona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProyecto")
                        .HasColumnType("int");

                    b.Property<int?>("ProyectoGradoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoGradoId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.ConsultaEstudianteValidado", b =>
                {
                    b.Property<long>("Identificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreditosAprobados")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPrograma")
                        .HasColumnType("int");

                    b.Property<int>("Modalidad")
                        .HasColumnType("int");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RolDefault")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubModalidad")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TieneProyecto")
                        .HasColumnType("bit");

                    b.HasKey("Identificacion");

                    b.ToTable("ConsultaEstudianteValidados");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.Docente", b =>
                {
                    b.Property<long>("Identificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Enfasis")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdPrograma")
                        .HasColumnType("int");

                    b.HasKey("Identificacion");

                    b.ToTable("Docentes");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.Estudiante", b =>
                {
                    b.Property<long>("Identificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreditosAprobados")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdPrograma")
                        .HasColumnType("int");

                    b.Property<int>("Modalidad")
                        .HasColumnType("int");

                    b.Property<int>("SubModalidad")
                        .HasColumnType("int");

                    b.Property<bool>("TieneProyecto")
                        .HasColumnType("bit");

                    b.HasKey("Identificacion");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.Facultad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreFacultad")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("SedeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Facultades");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.FileProyectosGrado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProyecto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FilesProyectosGrados");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.InformacionProyectoGradoFase1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProyectoGrado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("InformacionProyectosGradoFase1");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.InformacionProyectoGradoFase2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProyectoGrado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("InformacionProyectosGradoFase2");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.Modalidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreModalidad")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Modalidades");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.Persona", b =>
                {
                    b.Property<long>("Identificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Identificacion");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.Programa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacultadId")
                        .HasColumnType("int");

                    b.Property<string>("NombrePrograma")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("NumeroCreditos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Programas");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.ProyectoGrado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaTematica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bibliografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Calificacion")
                        .HasColumnType("float");

                    b.Property<bool?>("EsAceptadaPropuesta")
                        .HasColumnType("bit");

                    b.Property<string>("EstadoProyecto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("GrupoInvestigacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("IdAsesor")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdDirector")
                        .HasColumnType("bigint");

                    b.Property<long>("IdIntegrante1")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdIntegrante2")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdIntegrante3")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdJurado")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdJurado2")
                        .HasColumnType("bigint");

                    b.Property<int>("IdModalidad")
                        .HasColumnType("int");

                    b.Property<string>("Justificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineaInvestigacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjetivoGeneral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjetivosEspecificos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanteamientoProblema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubLineaInvestigacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoFase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProyectosDeGrado");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.Sede", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreSede")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Sedes");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.SubModalidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModalidadID")
                        .HasColumnType("int");

                    b.Property<string>("NombreSubModalidad")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("SubModalidades");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.Usuario", b =>
                {
                    b.Property<long>("Identificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EstadoUsuario")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RolDefault")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identificacion");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.UsuarioRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<long>("UsuarioIdentificacion")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UsuarioRoles");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.Comentario", b =>
                {
                    b.HasOne("BE_MeGraduo.Domain.Models.ProyectoGrado", null)
                        .WithMany("Comentarios")
                        .HasForeignKey("ProyectoGradoId");
                });

            modelBuilder.Entity("BE_MeGraduo.Domain.Models.ProyectoGrado", b =>
                {
                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}