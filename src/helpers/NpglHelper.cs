/*
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.If not, see<http://www.gnu.org/licenses/>.
*/

using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Npgsql;
using OdinSoft.SDK.Data;

namespace OpenETaxBill.Certifier
{
    /// <summary>
    /// database helper class
    /// </summary>
    public class NpglHelper
    {
        //-----------------------------------------------------------------------------------------------------------------------------
        // 
        //-----------------------------------------------------------------------------------------------------------------------------
        private readonly Lazy<NpglHelper> m_lzyHelper = new Lazy<NpglHelper>(() =>
        {
            return new NpglHelper();
        });

        /// <summary></summary>
        public NpglHelper SNG
        {
            get
            {
                return m_lzyHelper.Value;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        /// Private Properties
        //-----------------------------------------------------------------------------------------------------------------------------

        ////-----------------------------------------------------------------------------------------------------------------------------
        ///// Private Functions
        ////-----------------------------------------------------------------------------------------------------------------------------
        //private DeltaHelper m_delta_helper = null;
        //private OdinSoft.SDK.Data.DeltaHelper DeltaHelper
        //{
        //    get
        //    {
        //        if (m_delta_helper == null)
        //            m_delta_helper = new DeltaHelper();
        //        return m_delta_helper;
        //    }
        //}

        //-----------------------------------------------------------------------------------------------------------------------------
        ///
        //-----------------------------------------------------------------------------------------------------------------------------
        private string _getFieldValue(Object p_object)
        {
            var _result = p_object.ToString();

            if (p_object.GetType() == typeof(DateTime))
            {
                _result
                    = Convert.ToDateTime(p_object).ToString("yyyy-MM-dd") + " "
                    + Convert.ToDateTime(p_object).Hour.ToString("00") + ":"
                    + Convert.ToDateTime(p_object).Minute.ToString("00") + ":"
                    + Convert.ToDateTime(p_object).Second.ToString("00");

                _result = String.Format("'{0}'", _result);
            }
            else if (p_object.GetType() == typeof(string))
            {
                _result = String.Format("'{0}'", _result.Replace("'", "''"));
            }

            return _result;
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        /// _bldDataInsSQL : datarow와 테이블 컬럼, 키값을 보내 Insert 문장을 만드는 함수
        //-----------------------------------------------------------------------------------------------------------------------------
        private string _bldDataInsSQL(DataRow p_rows)
        {
            var _result = "";

            var _addcol = new StringBuilder();
            var _addval = new StringBuilder();

            foreach (DataColumn _col in p_rows.Table.Columns)
            {
                if (_col.AutoIncrement == false)
                {
                    string _column = _col.ColumnName;
                    Object _object = p_rows[_column];

                    if (Convert.IsDBNull(_object) == false)
                    {
                        string _value = _getFieldValue(_object);

                        _addcol.Append(_column + ", ");
                        _addval.Append(_value + ", ");
                    }
                    else if (_column == "sfid" || _column == "slmd")
                    {
                        _addcol.Append(_column + ", ");
                        _addval.Append("now(), ");
                    }
                }
            }

            if (_addcol.ToString() != "" && _addval.ToString() != "")
            {
                _result = ""
                    + " INSERT INTO [" + p_rows.Table.TableName + "] "
                    + " ("
                    + _addcol.ToString().Substring(0, _addcol.Length - 2)
                    + " ) "
                    + " VALUES "
                    + " ( "
                    + _addval.ToString().Substring(0, _addval.Length - 2)
                    + " ) ";
            }

            return _result;
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        /// _bldDataDelSQL : datarow와 테이블 컬럼, 키값을 보내 Delete 문장을 만드는 함수
        //-----------------------------------------------------------------------------------------------------------------------------
        private string _bldDataDelSQL(DataRow p_rows)
        {
            var _result = "";

            var _where = new StringBuilder();
            DataColumn[] _keys = p_rows.Table.PrimaryKey;

            for (int _key = 0; _keys.Length > _key; _key++)
            {
                string _column = _keys[_key].ColumnName;
                Object _object = p_rows[_column, DataRowVersion.Original];

                string _value = _getFieldValue(_object);
                _where.Append(String.Format("[{0}] = {1} AND ", _column, _value));
            }

            if (_where.Length > 0)
            {
                _result
                    = " DELETE FROM [" + p_rows.Table.TableName + "] "
                    + " WHERE " + _where.ToString().Substring(0, _where.Length - 5);
            }

            return _result;
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        /// _bldDataUpdSQL : datarow와 테이블 컬럼, 키값을 보내 Update 문장을 만드는 함수
        //-----------------------------------------------------------------------------------------------------------------------------
        private string _bldDataUpdSQL(DataRow p_rows)
        {
            var _result = "";

            var _updcol = new StringBuilder();
            var _where = new StringBuilder();

            foreach (DataColumn _col in p_rows.Table.Columns)
            {
                if (_col.AutoIncrement == false)
                {
                    string _column = _col.ColumnName;

                    if (_column == "slmd")
                    {
                        _updcol.Append(_column + " = now(), ");
                    }
                    else
                    {
                        Object _object = p_rows[_column];

                        if (Convert.IsDBNull(_object) == false)
                        {
                            string _value = _getFieldValue(_object);
                            _updcol.Append(String.Format("[{0}] = {1}, ", _column, _value));
                        }
                        else
                        {
                            _updcol.Append(_column + " = null, ");
                        }
                    }
                }
            }

            DataColumn[] _keys = p_rows.Table.PrimaryKey;

            for (int _index = 0; _keys.Length > _index; _index++)
            {
                string _column = _keys[_index].ColumnName;
                Object _object = p_rows[_column, DataRowVersion.Original];

                string _value = _getFieldValue(_object);
                _where.Append(String.Format("[{0}] = {1} AND ", _column, _value));
            }

            if (_updcol.ToString() != "" && _where.ToString() != "")
            {
                _result
                    = "UPDATE [" + p_rows.Table.TableName + "] "
                    + "   SET " + _updcol.ToString().Substring(0, _updcol.Length - 2)
                    + " WHERE " + _where.ToString().Substring(0, _where.Length - 5);
            }

            return _result;
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        /// Build Database Commands
        //-----------------------------------------------------------------------------------------------------------------------------
        //private DatCommands buildCommands(DataSet p_dataSet)
        //{
        //    DatCommands _dbcs = new DatCommands();

        //    foreach (DataTable _table in p_dataSet.Tables)
        //    {
        //        foreach (DataRow _row in _table.Rows)
        //        {
        //            switch (_row.RowState)
        //            {
        //                case DataRowState.Added:
        //                    _dbcs.Add(_bldDataInsSQL(_row), (NpgsqlParameterCollection)null);
        //                    break;

        //                case DataRowState.Deleted:
        //                    _dbcs.Add(_bldDataDelSQL(_row), (NpgsqlParameterCollection)null);
        //                    break;

        //                case DataRowState.Modified:
        //                    _dbcs.Add(_bldDataUpdSQL(_row), (NpgsqlParameterCollection)null);
        //                    break;
        //            }
        //        }
        //    }

        //    return _dbcs;
        //}

        /// <summary>
        /// This method assigns an array of values to an array of NpgsqlParameters
        /// </summary>
        /// <param name="commandParameters">Array of NpgsqlParameters to be assigned values</param>
        /// <param name="parameterValues">Array of objects holding the values to be assigned</param>
        private void _returnParameterValue(NpgsqlParameter[] commandParameters, NpgsqlParameterCollection parameterValues)
        {
            if (commandParameters != null && parameterValues != null)
            {


                for (int i = 0; i < commandParameters.Length; i++)
                {
                    NpgsqlParameter _cp = commandParameters[i];
                    if (_cp.Direction == ParameterDirection.Input)
                        continue;

                    //Update the Return Value
                    if (_cp.Direction == ParameterDirection.ReturnValue)
                    {
                        foreach (NpgsqlParameter _pv in parameterValues)
                        {
                            if (_pv.Direction == ParameterDirection.ReturnValue)
                            {
                                _pv.Value = _cp.Value;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (NpgsqlParameter _pv in parameterValues)
                        {
                            if (_pv.ParameterName.ToLower() == _cp.ParameterName.ToLower())
                            {
                                _pv.Value = _cp.Value;
                                break;
                            }
                        }
                    }
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        // Public functions
        //-----------------------------------------------------------------------------------------------------------------------------

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="p_kind_db"></param>
        ///// <returns></returns>
        //public MKindOfDatabase GetKindOfDB(string p_kind_db)
        //{
        //    return (MKindOfDatabase)Enum.Parse(typeof(MKindOfDatabase), p_kind_db);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_connection_string"></param>
        /// <param name="p_tablename"></param>
        /// <returns></returns>
        public DataSet FillSchema(string p_connection_string, string p_tablename)
        {
            var _result = new DataSet();

            using (NpgsqlConnection _sqlcon = new NpgsqlConnection(p_connection_string))
            {
                NpgsqlDataAdapter _adapter = new NpgsqlDataAdapter("SELECT * FROM " + p_tablename, _sqlcon);
                _adapter.FillSchema(_result, SchemaType.Source, p_tablename);
            }

            return _result;
        }

        /// <summary>
        /// 데이터셋에 한개 이상의 테이블이 있는지와 각각의 테이블에 한개이상의 row가 있는지 확인 합니다.
        /// 모든 테이블에 record가 한개도 없으면 true 입니다.
        /// </summary>
        /// <param name="p_orgset"></param>
        /// <returns></returns>
        public bool IsNullOrEmpty(DataSet p_orgset)
        {
            var _result = true;

            if (p_orgset != null && p_orgset.Tables != null && p_orgset.Tables.Count > 0)
            {
                foreach (DataTable _dt in p_orgset.Tables)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        _result = false;
                        break;
                    }
                }
            }

            return _result;
        }

        /// <summary>
        /// 데이터셋의 특정 테이블에 한개 이상의 row가 있는지 확인 합니다.
        /// </summary>
        /// <param name="p_orgset"></param>
        /// <param name="p_tableNdx"></param>
        /// <returns></returns>
        public bool IsNullOrEmpty(DataSet p_orgset, int p_tableNdx)
        {
            var _result = true;

            if (p_orgset != null && p_orgset.Tables != null && p_orgset.Tables.Count > p_tableNdx)
            {
                DataTable _dt = p_orgset.Tables[p_tableNdx];
                if (_dt.Rows.Count > 0)
                    _result = false;
            }

            return _result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_orgtbl"></param>
        /// <returns></returns>
        public bool IsNullOrEmpty(DataTable p_orgtbl)
        {
            var _result = true;

            if (p_orgtbl != null && p_orgtbl.Rows.Count > 0)
                _result = false;

            return _result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public bool IsNullValue(NpgsqlParameter p_value)
        {
            var _result = true;

            if (p_value != null && p_value.Value != null)
            {
                if (String.IsNullOrEmpty(p_value.Value.ToString()) == false)
                    _result = false;
            }

            return _result;
        }

        /// <summary>
        /// 데이터셋 내의 특정 테이블이 몇개의 record를 가지고 있는지 확인 합니다.
        /// </summary>
        /// <param name="p_orgset"></param>
        /// <param name="p_tableNdx"></param>
        /// <returns></returns>
        public int RowCount(DataSet p_orgset, int p_tableNdx)
        {
            var _result = -1;

            if (p_orgset != null && p_orgset.Tables != null && p_orgset.Tables.Count > p_tableNdx)
            {
                DataTable _dt = p_orgset.Tables[p_tableNdx];
                _result = _dt.Rows.Count;
            }

            return _result;
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        /// SelectDataSet
        //-----------------------------------------------------------------------------------------------------------------------------
        //public DataSet SelectDataSet(string p_connection_string, string p_cmdtxt)
        //{
        //    DatCommand _dbc = new DatCommand(p_cmdtxt);
        //    return SelectDataSet(p_connection_string, CommandType.Text, p_cmdtxt, _dbc.Name);
        //}

        //public DataSet SelectDataSet(string p_connection_string, string p_cmdtxt, NpgsqlParameterCollection p_dbps)
        //{
        //    DatCommand _dbc = new DatCommand(p_cmdtxt);
        //    return SelectDataSet(p_connection_string, CommandType.Text, p_cmdtxt, _dbc.Name, p_dbps.ToArray());
        //}

        //public DataSet SelectDataSet(string p_connection_string, DatCommands p_dbcs)
        //{
        //    var _result = new DataSet();

        //    using (NpgsqlConnection _sqlconn = new NpgsqlConnection(p_connection_string))
        //    {
        //        _sqlconn.Open();

        //        foreach (DatCommand _dbc in p_dbcs)
        //            _result.Merge(SelectDataSet(_sqlconn, CommandType.Text, _dbc.Text, _dbc.Name));
        //    }

        //    return _result;
        //}

        //-----------------------------------------------------------------------------------------------------------------------------
        /// SelectScalar
        //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Execute a NpgsqlCommand (that returns a 1x1 resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new NpgsqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a NpgsqlConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params NpgsqlParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            // Create & open a NpgsqlConnection, and dispose of it after we are done
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Call the overload that takes a connection in place of the connection string
                return ExecuteScalar(connection, commandType, commandText, commandParameters);
            }
        }

        /// <summary>
        /// Execute a NpgsqlCommand (that returns a 1x1 resultset) against the specified NpgsqlConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new NpgsqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid NpgsqlConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public object ExecuteScalar(NpgsqlConnection connection, CommandType commandType, string commandText, params NpgsqlParameter[] commandParameters)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            NpgsqlCommand cmd = new NpgsqlCommand();

            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (NpgsqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Execute the command & return the results
            object retval = cmd.ExecuteScalar();

            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();

            if (mustCloseConnection)
                connection.Close();

            return retval;
        }

        public object SelectScalar(string p_connection_string, string p_cmdtxt, NpgsqlParameterCollection p_dbps)
        {
            return ExecuteScalar(p_connection_string, CommandType.Text, p_cmdtxt, p_dbps.ToArray());
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        /// ExecuteReader
        //-----------------------------------------------------------------------------------------------------------------------------
        
        /// <summary>
        /// This enum is used to indicate whether the connection was provided by the caller, or created by SqlHelper, so that
        /// we can set the appropriate CommandBehavior when calling ExecuteReader()
        /// </summary>
        private enum NpgsqlConnectionOwnership
        {
            /// <summary>Connection is owned and managed by SqlHelper</summary>
            Internal,
            /// <summary>Connection is owned and managed by the caller</summary>
            External
        }

        /// <summary>
        /// Create and prepare a NpgsqlCommand, and call ExecuteReader with the appropriate CommandBehavior.
        /// </summary>
        /// <remarks>
        /// If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
        /// 
        /// If the caller provided the connection, we want to leave it to them to manage.
        /// </remarks>
        /// <param name="connection">A valid NpgsqlConnection, on which to execute this command</param>
        /// <param name="transaction">A valid NpgsqlTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="connectionOwnership">Indicates whether the connection parameter was provided by the caller, or created by SqlHelper</param>
        /// <returns>NpgsqlDataReader containing the results of the command</returns>
        private NpgsqlDataReader ExecuteReader(NpgsqlConnection connection, NpgsqlTransaction transaction, CommandType commandType, string commandText, NpgsqlParameter[] commandParameters, NpgsqlConnectionOwnership connectionOwnership)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");

            bool mustCloseConnection = false;
            // Create a command and prepare it for execution
            NpgsqlCommand cmd = new NpgsqlCommand();
            try
            {
                PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

                // Create a reader
                NpgsqlDataReader dataReader;

                // Call ExecuteReader with the appropriate CommandBehavior
                if (connectionOwnership == NpgsqlConnectionOwnership.External)
                {
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }

                // Detach the SqlParameters from the command object, so they can be used again.
                // HACK: There is a problem here, the output parameter values are fletched 
                // when the reader is closed, so if the parameters are detached from the command
                // then the SqlReader can't set its values. 
                // When this happen, the parameters can't be used again in other command.
                bool canClear = true;
                foreach (NpgsqlParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                        canClear = false;
                }

                if (canClear)
                {
                    cmd.Parameters.Clear();
                }

                if (mustCloseConnection)
                    connection.Close();

                return dataReader;
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteReader", ex);
            }
        }

        /// <summary>
        /// Execute a NpgsqlCommand (that returns a resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  NpgsqlDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new NpgsqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a NpgsqlConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A NpgsqlDataReader containing the resultset generated by the command</returns>
        public NpgsqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params NpgsqlParameter[] commandParameters)
        {
            // [주의] 사용한 IDataReader.Close()하지 않으면 Client에서 아래와 같이 정의할 경우 Connection이 계속 오픈되어 있어 sql connection이 Full이 일어남.
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            NpgsqlConnection connection = null;
            try
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();

                // Call the private overload that takes an internally owned connection in place of the connection string
                return ExecuteReader(connection, (NpgsqlTransaction)null, commandType, commandText, commandParameters, NpgsqlConnectionOwnership.Internal);
            }
            catch (Exception ex)
            {
                // If we fail to return the SqlDatReader, we need to close the connection ourselves
                if (connection != null)
                    connection.Close();

                throw new Exception("ExecuteReader", ex);
            }
        }

        public NpgsqlDataReader ExecuteReader(string p_connection_string, string p_cmdtxt)
        {
            return ExecuteReader(p_connection_string, CommandType.Text, p_cmdtxt);
        }

        public NpgsqlDataReader ExecuteReader(string p_connection_string, string p_cmdtxt, NpgsqlParameterCollection p_dbps)
        {
            return ExecuteReader(p_connection_string, CommandType.Text, p_cmdtxt, p_dbps.ToArray());
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        /// ExecuteText
        //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// This method is used to attach array of SqlParameters to a NpgsqlCommand.
        /// 
        /// This method will assign a value of DbNull to any parameter with a direction of
        /// InputOutput and a value of null.  
        /// 
        /// This behavior will prevent default values from being used, but
        /// this will be the less common case than an intended pure output parameter (derived as InputOutput)
        /// where the user provided no input value.
        /// </summary>
        /// <param name="command">The command to which the parameters will be added</param>
        /// <param name="commandParameters">An array of SqlParameters to be added to command</param>
        private void AttachParameters(NpgsqlCommand command, NpgsqlParameter[] commandParameters)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (NpgsqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input)
                            if (p.Value == null)
                            {
                                p.Value = DBNull.Value;
                            }

                        command.Parameters.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
        /// to the provided command
        /// </summary>
        /// <param name="command">The NpgsqlCommand to be prepared</param>
        /// <param name="connection">A valid NpgsqlConnection, on which to execute this command</param>
        /// <param name="transaction">A valid NpgsqlTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="mustCloseConnection"><c>true</c> if the connection was opened by the method, otherwose is false.</param>
        private void PrepareCommand(NpgsqlCommand command, NpgsqlConnection connection, NpgsqlTransaction transaction, CommandType commandType, string commandText, NpgsqlParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // Associate the connection with the command
            command.Connection = connection;

            // Set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            // If we were provided a transaction, assign it
            if (transaction != null)
            {
                if (transaction.Connection == null)
                    throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            // Set the command type
            command.CommandType = commandType;
            command.CommandTimeout = 600;

            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }

            return;
        }

        /// <summary>
        /// Execute a NpgsqlCommand (that returns no resultset) against the specified NpgsqlConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new NpgsqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid NpgsqlConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public int ExecuteNonQuery(NpgsqlConnection connection, CommandType commandType, string commandText, params NpgsqlParameter[] commandParameters)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            NpgsqlCommand cmd = new NpgsqlCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (NpgsqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();

            // return value 
            if (cmd.Parameters.Count > 0 && cmd.Parameters[0].Direction == ParameterDirection.ReturnValue)
                retval = (int)cmd.Parameters[0].Value;

            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            if (mustCloseConnection)
                connection.Close();

            return retval;
        }

        /// <summary>
        /// Execute a NpgsqlCommand (that returns no resultset) against the specified NpgsqlTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new NpgsqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid NpgsqlTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public int ExecuteNonQuery(NpgsqlTransaction transaction, CommandType commandType, string commandText, params NpgsqlParameter[] commandParameters)
        {
            if (transaction == null)
                throw new ArgumentNullException("transaction");

            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Create a command and prepare it for execution
            NpgsqlCommand cmd = new NpgsqlCommand();

            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();

            // return value 
            if (cmd.Parameters.Count > 0 && cmd.Parameters[0].Direction == ParameterDirection.ReturnValue)
                retval = (int)cmd.Parameters[0].Value;

            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();

            return retval;
        }

        /// <summary>
        /// Execute a NpgsqlCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new NpgsqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a NpgsqlConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params NpgsqlParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");

            // Create & open a NpgsqlConnection, and dispose of it after we are done
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Call the overload that takes a connection in place of the connection string
                return ExecuteNonQuery(connection, commandType, commandText, commandParameters);
            }
        }

        public int ExecuteText(string p_connection_string, string p_cmdtxt)
        {
            return ExecuteNonQuery(p_connection_string, CommandType.Text, p_cmdtxt);
        }

        public int ExecuteText(string p_connection_string, string p_cmdtxt, NpgsqlParameterCollection p_dbps)
        {
            return ExecuteNonQuery(p_connection_string, CommandType.Text, p_cmdtxt, p_dbps.ToArray());
        }

        //public int ExecuteText(string p_connection_string, DatCommands p_dbcs)
        //{
        //    var _result = 0;

        //    foreach (DatCommand _dbc in p_dbcs)
        //    {
        //        ExecuteNonQuery(p_connection_string, CommandType.Text, _dbc.Text, _dbc.Value.ToArray());

        //        _result++;
        //    }

        //    return _result;
        //}

        public int ExecuteText(string p_connection_string, params string[] p_cmdtxts)
        {
            var _result = 0;

            using (NpgsqlConnection _sqlconn = new NpgsqlConnection(p_connection_string))
            {
                _sqlconn.Open();
                NpgsqlTransaction transaction = _sqlconn.BeginTransaction();

                try
                {
                    for (int i = 0; i < p_cmdtxts.Length; i++)
                    {
                        if (p_cmdtxts[i] != null && p_cmdtxts[i] != "")
                        {
                            ExecuteNonQuery(transaction, CommandType.Text, p_cmdtxts[i]);

                            _result++;
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _result = -1;

                    throw new Exception("ExecuteText", ex);
                }
                finally
                {
                    _sqlconn.Close();
                }
            }

            return _result;
        }

        public int ExecuteText(string p_connection_string, NpgsqlParameterCollection p_dbps, params string[] p_cmdtxts)
        {
            var _result = 0;

            using (NpgsqlConnection _sqlconn = new NpgsqlConnection(p_connection_string))
            {
                _sqlconn.Open();
                NpgsqlTransaction transaction = _sqlconn.BeginTransaction();

                try
                {
                    for (int i = 0; i < p_cmdtxts.Length; i++)
                    {
                        if (p_cmdtxts[i] != null && p_cmdtxts[i] != "")
                        {
                            ExecuteNonQuery(transaction, CommandType.Text, p_cmdtxts[i], p_dbps.ToArray());
                            _result++;
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _result = -1;

                    throw new Exception("ExecuteText", ex);
                }
                finally
                {
                    _sqlconn.Close();
                }
            }

            return _result;
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        // ExecuteProc
        //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_connection_string"></param>
        /// <param name="p_spName"></param>
        /// <returns></returns>
        public NpgsqlParameterCollection GetNpgsqlParameters(string p_connection_string, string p_spName)
        {
            var _dbps = new NpgsqlParameterCollection();

            NpgsqlParameter[] _sbps = SqlHelperParameterCache.GetSpParameterSet(p_connection_string, p_spName);
            foreach (NpgsqlParameter _s in _sbps)
            {
                _dbps.Add(_s.ParameterName, _s.SqlDbType, _s.Direction, DBNull.Value);
            }

            return _dbps;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_connection_string"></param>
        /// <param name="p_spName"></param>
        /// <param name="p_args"></param>
        /// <returns></returns>
        public int ExecuteProc(string p_connection_string, string p_spName, params object[] p_args)
        {
            return ExecuteNonQuery(p_connection_string, p_spName, p_args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_connection_string"></param>
        /// <param name="p_spName"></param>
        /// <param name="p_dbps"></param>
        /// <returns></returns>
        public int ExecuteProc(string p_connection_string, string p_spName, NpgsqlParameterCollection p_dbps)
        {
            var _result = -1;

            NpgsqlParameter[] _params = p_dbps.ToArray();
            _result = ExecuteProcQuery(p_connection_string, p_spName, _params);
            {
                _returnParameterValue(_params, p_dbps);
            }

            return _result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_connection_string"></param>
        /// <param name="p_spName"></param>
        /// <param name="p_dbps"></param>
        /// <returns></returns>
        public DataSet ExecuteProcSet(string p_connection_string, string p_spName, NpgsqlParameterCollection p_dbps)
        {
            var _result = new DataSet();

            NpgsqlParameter[] _params = p_dbps.ToArray();
            _result = ExecuteProcSet(p_connection_string, p_spName, _params);
            {
                _returnParameterValue(_params, p_dbps);
            }

            return _result;
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        /// ExecuteDataSet
        //-----------------------------------------------------------------------------------------------------------------------------
        public DataSet ExecuteDataSet(string p_connection_string, string p_cmdtxt)
        {
            return ExecuteDataSet(p_connection_string, CommandType.Text, p_cmdtxt);
        }

        public DataSet ExecuteDataSet(string p_connection_string, string p_cmdtxt, NpgsqlParameterCollection p_dbps)
        {
            return ExecuteDataSet(p_connection_string, CommandType.Text, p_cmdtxt, p_dbps.ToArray());
        }

        public DataSet ExecuteDataSet(string p_connection_string, string p_spName, params object[] p_args)
        {
            return ExecuteDataSet(p_connection_string, p_spName, p_args);
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        /// Update DataSet
        //-----------------------------------------------------------------------------------------------------------------------------
        //public int UpdateDataSet(string p_connection_string, DataSet p_dataSet)
        //{
        //    return UpdateDeltaSet(p_connection_string, p_dataSet);
        //}

        //-----------------------------------------------------------------------------------------------------------------------------
        /// 
        //-----------------------------------------------------------------------------------------------------------------------------
        public DataRow NewDataRow(DataTable p_datatable)
        {
            DataRow _result = p_datatable.NewRow();
            foreach (DataColumn _dc in p_datatable.Columns)
            {
                if (_dc.AllowDBNull == false)
                {
                    if (_dc.DataType == typeof(System.DateTime))
                    {
                        _result[_dc.ColumnName] = DateTime.Now;
                    }
                    else if (_dc.DataType == typeof(System.String))
                    {
                        _result[_dc.ColumnName] = "";
                    }
                    else if (_dc.DataType == typeof(System.Int32))
                    {
                        _result[_dc.ColumnName] = 0;
                    }
                    else if (_dc.DataType == typeof(System.Boolean))
                    {
                        _result[_dc.ColumnName] = false;
                    }
                }
            }

            return _result;
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_datset"></param>
        /// <returns></returns>
        public string ZipSet(DataSet p_datset)
        {
            if (IsNullOrEmpty(p_datset) == true)
                return "";

            return ZipDataSet.SNG.CompressDataSet(p_datset);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_zipset"></param>
        /// <returns></returns>
        public DataSet UnZipSet(string p_zipset)
        {
            if (String.IsNullOrEmpty(p_zipset) == true)
                return null;

            return ZipDataSet.SNG.DecompressDataSet(p_zipset);
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------------------------------------------------------
    }
}