using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;
using InscripcionesCursos.BE;

namespace InscripcionesCursos.DAO
{
	public class UsuarioDAO
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public UsuarioDAO(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Usuario table.
		/// </summary>
		public void Insert(Usuario usuario)
		{
			ValidationUtility.ValidateArgument("usuario", usuario);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DNI", usuario.DNI),
				new SqlParameter("@ApellidoNombre", usuario.ApellidoNombre),
				new SqlParameter("@Email", usuario.Email),
				new SqlParameter("@IdCargo", usuario.IdCargo),
				new SqlParameter("@Password", usuario.Password),
				new SqlParameter("@CambioPrimerLogin", usuario.CambioPrimerLogin),
				new SqlParameter("@CuentaActivada", usuario.CuentaActivada),
				new SqlParameter("@CodigoActivacion", usuario.CodigoActivacion),
				new SqlParameter("@IdSede", usuario.IdSede),
                new SqlParameter("@IdEstado", usuario.Estado),
                new SqlParameter("@IdCarrera", Convert.ToInt32(usuario.Carrera)),
                new SqlParameter("@CuatrimestreAnioIngreso", usuario.CuatrimestreAnioIngreso),
                new SqlParameter("@CuatrimestreAnioReincorporacion", usuario.CuatrimestreAnioReincorporacion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioInsert", parameters);
            SqlConnection.ClearAllPools();
		}

		/// <summary>
		/// Updates a record in the Usuario table.
		/// </summary>
		public void Update(Usuario usuario)
		{
			ValidationUtility.ValidateArgument("usuario", usuario);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DNI", usuario.DNI),
				new SqlParameter("@ApellidoNombre", usuario.ApellidoNombre),
				new SqlParameter("@Email", usuario.Email),
				new SqlParameter("@IdCargo", usuario.IdCargo),
				new SqlParameter("@Password", usuario.Password),
				new SqlParameter("@CambioPrimerLogin", usuario.CambioPrimerLogin),
				new SqlParameter("@CuentaActivada", usuario.CuentaActivada),
				new SqlParameter("@CodigoActivacion", usuario.CodigoActivacion),
				new SqlParameter("@IdSede", usuario.IdSede),
                new SqlParameter("@IdEstado", usuario.Estado),
                new SqlParameter("@IdCarrera", Convert.ToInt32(usuario.Carrera)),
                new SqlParameter("@CuatrimestreAnioIngreso", usuario.CuatrimestreAnioIngreso),
                new SqlParameter("@CuatrimestreAnioReincorporacion", usuario.CuatrimestreAnioReincorporacion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioUpdate", parameters);
            SqlConnection.ClearAllPools();
		}

		/// <summary>
		/// Deletes a record from the Usuario table by its primary key.
		/// </summary>
		public void Delete(int dNI)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DNI", dNI)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioDelete", parameters);
            SqlConnection.ClearAllPools();
		}

		/// <summary>
		/// Deletes a record from the Usuario table by a foreign key.
		/// </summary>
		public void DeleteAllByIdCargo(int idCargo)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCargo", idCargo)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioDeleteAllByIdCargo", parameters);
            SqlConnection.ClearAllPools();
		}

		/// <summary>
		/// Deletes a record from the Usuario table by a foreign key.
		/// </summary>
		public void DeleteAllByIdSede(int idSede)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSede", idSede)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioDeleteAllByIdSede", parameters);
            SqlConnection.ClearAllPools();
		}

		/// <summary>
		/// Selects a single record from the Usuario table.
		/// </summary>
		public Usuario Select(int dNI)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DNI", dNI)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioSelect", parameters))
			{
				if (dataReader.Read())
				{
					var mapper = MapDataReader(dataReader);
                    SqlConnection.ClearAllPools();
                    return mapper;
				}
				else
				{
                    SqlConnection.ClearAllPools();
					return null;
				}
			}
		}

		/// <summary>
		/// Selects a single record from the Usuario table.
		/// </summary>
		public string SelectJson(int dNI)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DNI", dNI)
			};

			var json = SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioSelect", parameters);
            SqlConnection.ClearAllPools();
            return json;
		}

		/// <summary>
		/// Selects all records from the Usuario table.
		/// </summary>
		public List<Usuario> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAll"))
			{
				List<Usuario> UsuarioList = new List<Usuario>();
				while (dataReader.Read())
				{
					Usuario Usuario = MapDataReader(dataReader);
					UsuarioList.Add(Usuario);
				}
                SqlConnection.ClearAllPools();
				return UsuarioList;
			}
		}

		/// <summary>
		/// Selects all records from the Usuario table.
		/// </summary>
		public string SelectAllJson()
		{
			var json = SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAll");
            SqlConnection.ClearAllPools();
            return json;
		}

		/// <summary>
		/// Selects all records from the Usuario table by a foreign key.
		/// </summary>
		public List<Usuario> SelectAllByIdCargo(int idCargo)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCargo", idCargo)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAllByIdCargo", parameters))
			{
				List<Usuario> UsuarioList = new List<Usuario>();
				while (dataReader.Read())
				{
					Usuario Usuario = MapDataReader(dataReader);
					UsuarioList.Add(Usuario);
				}
                SqlConnection.ClearAllPools();
				return UsuarioList;
			}
		}

		/// <summary>
		/// Selects all records from the Usuario table by a foreign key.
		/// </summary>
		public List<Usuario> SelectAllByIdSede(int idSede)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSede", idSede)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAllByIdSede", parameters))
			{
				List<Usuario> UsuarioList = new List<Usuario>();
				while (dataReader.Read())
				{
					Usuario Usuario = MapDataReader(dataReader);
					UsuarioList.Add(Usuario);
				}
                SqlConnection.ClearAllPools();
				return UsuarioList;
			}
		}

		/// <summary>
		/// Selects all records from the Usuario table by a foreign key.
		/// </summary>
		public string SelectAllByIdCargoJson(int idCargo)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCargo", idCargo)
			};

			var json = SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAllByIdCargo", parameters);
            SqlConnection.ClearAllPools();
            return json;
		}

		/// <summary>
		/// Selects all records from the Usuario table by a foreign key.
		/// </summary>
		public string SelectAllByIdSedeJson(int idSede)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSede", idSede)
			};

			var json = SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAllByIdSede", parameters);
            SqlConnection.ClearAllPools();
            return json;
		}
		
		 /// <summary>
        /// Select user for Login.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Usuario ValidateLogin(int dni, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DNI", dni),
                new SqlParameter("@Password", password)
			};

            Usuario user = new Usuario();

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioValidateLogin", parameters))
            {
                while (dataReader.Read())
                {
                    user = MapDataReader(dataReader);
                }
                SqlConnection.ClearAllPools();
                return user;
            }
        }

        /// <summary>
        /// Update field Password with random alphanumeric characters.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Usuario UpdateGeneratedPassword(int dni, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DNI", dni),
                new SqlParameter("@Password", password)
			};

            Usuario user = new Usuario();

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioUpdateGeneratedPassword", parameters))
            {
                while (dataReader.Read())
                {
                    user = MapDataReader(dataReader);
                }
                SqlConnection.ClearAllPools();
                return user;
            }
        }

        /// <summary>
        /// Update password and change first access bit.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="codigoActivacion"></param>
        /// <returns></returns>
        public bool UpdateMandatoryPasswordEmail(int dni, string password, string email, int codigoActivacion)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DNI", dni),
                new SqlParameter("@Password", password),
                new SqlParameter("@Email", email),
                new SqlParameter("@CodigoActivacion", codigoActivacion)
			};

            Object objScalar = SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "UsuarioUpdateMandatoryPassword", parameters);
            SqlConnection.ClearAllPools();

            if (Convert.ToInt32(objScalar) == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Updates user email.
        /// </summary>
        public void UpdateEmail(Usuario usuario)
        {
            ValidationUtility.ValidateArgument("usuario", usuario);

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DNI", usuario.DNI),
				new SqlParameter("@Email", usuario.Email)
			};

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioUpdateEmail", parameters);
            SqlConnection.ClearAllPools();
        }

        /// <summary>
        /// Activate user account
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="codigoActivacion"></param>
        /// <returns>Usuario</returns>
        public Usuario ActivateAccount(int dni, int codigoActivacion)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
			    {
				    new SqlParameter("@DNI", dni),
                    new SqlParameter("@CodigoActivacion", codigoActivacion)
			    };

                Usuario user = new Usuario();

                using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioActivateAccount", parameters))
                {
                    while (dataReader.Read())
                    {
                        user = MapDataReader(dataReader);
                    }
                    SqlConnection.ClearAllPools();
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Import users
        /// </summary>
        public void ImportPadron(int dni, string apellidoNombre, int idSede, string estado, int idCarrera, string cuatrimestreIngreso, string cuatrimestreReincorporacion, int idCargo)
        {

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DNI", dni),
				new SqlParameter("@ApellidoNombre", apellidoNombre),
				new SqlParameter("@IdSede", idSede),
				new SqlParameter("@IdEstado", estado),
				new SqlParameter("@IdCarrera", idCarrera),
				new SqlParameter("@CuatrimestreAnioIngreso", cuatrimestreIngreso),
				new SqlParameter("@CuatrimestreAnioReincorporacion", cuatrimestreReincorporacion),
                new SqlParameter("@IdCargo", idCargo)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioImportPadron", parameters);
            SqlConnection.ClearAllPools();
        }

		/// <summary>
		/// Creates a new instance of the Usuario class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private Usuario MapDataReader(SqlDataReader dataReader)
		{
			Usuario Usuario = new Usuario();
			Usuario.DNI = dataReader.GetInt32("DNI", 0);
			Usuario.ApellidoNombre = dataReader.GetString("ApellidoNombre", null);
			Usuario.Email = dataReader.GetString("Email", null);
			Usuario.IdCargo = dataReader.GetInt32("IdCargo", 0);
			Usuario.Password = dataReader.GetString("Password", null);
			Usuario.CambioPrimerLogin = dataReader.GetBoolean("CambioPrimerLogin", false);
			Usuario.CuentaActivada = dataReader.GetBoolean("CuentaActivada", false);
			Usuario.CodigoActivacion = dataReader.GetInt32("CodigoActivacion", 0);
			Usuario.IdSede = dataReader.GetInt32("IdSede", 0);
            Usuario.Estado = dataReader.GetString("Descripcion", null);
            Usuario.Carrera = dataReader.GetString("Nombre", null);
            Usuario.CuatrimestreAnioIngreso = dataReader.GetString("CuatrimestreAnioIngreso", null);
            Usuario.CuatrimestreAnioReincorporacion = dataReader.GetString("CuatrimestreAnioReincorporacion", null);

			return Usuario;
		}

		#endregion
    }
}
