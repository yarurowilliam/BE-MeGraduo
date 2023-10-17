namespace BE_MeGraduo.Persistence
{
	public static class Constantes
	{
		#region ['USUARIOS']
		public const string USUARIO_REGISTRADO = "¡Usuario registrado con exito!";
		public const string USUARIO_YA_EXISTE = "El usuario con id: {0} o email: {1} ya existe!";
		public const string ESTADO_DEFAULT_USER = "CONFIRMAR EMAIL";
		public const string ESTADO_COMPLETAR_INFORMACION = "COMPLETAR INFORMACION";
		public const string USUARIO_NO_EXISTE = "El usuario con identificacion: {0} no existe en el sistema!";
		public const string USUARIO_YA_FUE_CONFIRMADO = "El usuario con identificacion: {0} ya confirmo su email!";
		public const string ROL_CON_USUARIO_YA_EXISTE = "Ese rol ya fue asignado a ese usuario";
		public const string ROL_ASIGNADO_CORRECTO = "Se asigno el rol a este usuario";
		public const string ASIGNACION_NOEXISTE = "La asignacion que intenta quitar no existe.";
		public const string ROL_RETIRADO_CORRECTAMENTE = "La asignacion fue retirada correctamente";
        public const string NO_HAY_USERS = "No hay usuarios registrados";
        public const string VALIDE_SU_EMAIL = "Usted antes de llenar su informacion debe completar su email";
        public const string VERIFICACION_TOTAL = "VERIFICADO";
        public const string PENDIENTE_LLENAR_INFO = "Esta cuenta aun no completa su informacion personal, ya fue notificada!";
        public const string PENDIENTE_CONFIRMAR_MAIL = "Esta cuenta aun no confirma su correo, ya fue notificada!";
        #endregion
        #region ['LOGIN']
        public const string CORREO_CONFIRMADO = "Tu correo fue confirmado, ahora completa tu informacion personal";
        public const string CUENTA_VERIFICADA = "Gracias por verificar esta cuenta!";
        public const string PASSWORD_INCORRECTA = "Usuario o contraseña o rol incorrecto";
		public const string USUARIO_SIN_ROLES = "Usted no tiene roles asignados...";
		#endregion
		#region ['ROLES']
		public const string ROL_YA_EXISTE = "El rol {0} ya existe!";
		public const string ROL_REGISTRADO = "Rol registrado con exito";
		public const string NO_HAY_ROLES = "No hay roles registrados en el sistema";
		public const string ROL_NO_EXISTE = "El rol {0} no existe!";
		public const string ROL_ELIMINADO = "El ROL fue eliminado con exito";
		public const string ROL_ACTUALIZADO = "El rol fue actualizado con exito";
        #endregion
        #region ['SEDES']
        public const string SEDE_YA_EXISTE = "La sede {0} ya existe!";
        public const string SEDE_REGISTRADA = "Sede registrado con exito";
        public const string NO_HAY_SEDES= "No hay Sedes registrados en el sistema";
        public const string SEDE_NO_EXISTE = "El sede {0} no existe!";
        public const string SEDE_ELIMINADO = "El sede fue eliminado con exito";
        public const string SEDE_ACTUALIZADO = "El sede fue actualizado con exito";
        #endregion
        #region ['FACULTAD']
        public const string FACULTAD_YA_EXISTE = "La facultad {0} ya existe!";
        public const string FACULTAD_REGISTRADA = "Facultad registrado con exito";
        public const string NO_HAY_FACULTAD = "No hay facultad registradas en el sistema";
        public const string FACULTAD_NO_EXISTE = "la facultad {0} no existe!";
        public const string FACULTAD_ELIMINADO = "la facultad fue eliminado con exito";
        public const string SFACULTAD_ACTUALIZADO = "La facultad fue actualizado con exito";
        #endregion
        #region ['PROGRAMA']
        public const string PROGRAMA_YA_EXISTE = "El programa {0} ya existe!";
        public const string PROGRAMA_REGISTRADA = "Programa registrado con exito";
        public const string NO_HAY_PROGRAMA = "No hay programa registradas en el sistema";
        public const string PROGRAMA_NO_EXISTE = "El programa {0} no existe!";
        public const string PROGRAMA_ELIMINADO = "la programa fue eliminado con exito";
        public const string PROGRAMA_ACTUALIZADO = "La programa fue actualizado con exito";
        #endregion
        #region ['PERSONA']
        public const string PERSONA_YA_EXISTE = "La persona con identificacion: {0} ya existe!";
        public const string COMPLETO_INFO_PERSONA = "Gracias por completar tu informacion personal!";
        #endregion
        #region ['ESTUDIANTE']
        public const string ESTUDIANTE_YA_TIENE_INFORMACION = "El estudiante con identificacion: {0} ya existe!";
        public const string COMPLETE_INFO_ESTUDIANTE = "COMPLETA INFORMACION ESTUDIANTE";
        public const string INFORMACION_COMPLETADA_ESTUDIANTE = "Gracias por completar tu informacion como estudiante!";
        public const string ESTUDIANTE_NO_EXISTE = "Esta identificacion no esta registrada.";
        #endregion
        #region ['DOCENTE']
        public const string DOCENTE_YA_TIENE_INFORMACION = "El docente con identificacion: {0} ya existe!";
        public const string COMPLETE_INFO_DOCENTE = "COMPLETA INFORMACION DOCENTE";
        public const string INFORMACION_COMPLETADA_DOCENTE = "Gracias por completar tu informacion como DOCENTE!";
        #endregion
        public const string PENDIENTE_VERIFICACION = "PENDIENTE VERIFICACION";
        #region ['MODALIDAD']
        public const string MODALIDAD_YA_EXISTE = "La modalidad {0} ya existe!";
        public const string MODALIDAD_REGISTRADA = "Modalidad registrada con exito";
        public const string NO_HAY_MODALIDAD = "No hay modalidades registradas en el sistema";
        public const string MODALIDAD_NO_EXISTE = "la modalidad {0} no existe!";
        public const string MODALIDAD_ELIMINADO = "la modalidad fue eliminada con exito";
        public const string MODALIDAD_ACTUALIZADO = "La modalidad fue actualizada con exito";
        #endregion
        #region ['SUB-MODALIDAD']
        public const string SUB_MODALIDAD_YA_EXISTE = "La sub modalidad {0} ya existe!";
        public const string SUB_MODALIDAD_REGISTRADA = "Sub Modalidad registrada con exito";
        public const string NO_HAY_SUB_MODALIDAD = "No hay sub modalidades registradas en el sistema";
        public const string SUB_MODALIDAD_NO_EXISTE = "la sub modalidad {0} no existe!";
        public const string SUB_MODALIDAD_ELIMINADO = "la sub modalidad fue eliminada con exito";
        public const string SUB_MODALIDAD_ACTUALIZADO = "La sub modalidad fue actualizada con exito";
        #endregion
        #region ['PROYECTO']
        public const string PROYECTO_YA_EXISTE = "El proyecto {0} ya existe!";
        public const string PROPUESTA_REGISTRADO = "Proyecto registrado con exito";
        public const string NO_HAY_PROYECTO = "No proyectos registrados en el sistema";
        public const string NO_HAY_PROYECTO_ASIGNADO = "No tiene proyectos asignados.";
        public const string PROYECTO_NO_EXISTE = "El proyecto {0} no existe!";
        public const string PROYECTO_ELIMINADO = "El proyecto fue eliminado con exito";
        public const string PROYECTO_ACTUALIZADO = "El proyecto fue actualizado con exito";
        public const string COMENTARIO_ADD = "Se añadio su comentario";
        #endregion
    }
}
