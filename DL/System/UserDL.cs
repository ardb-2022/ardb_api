using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using SBWSFinanceApi.Config;
using SBWSFinanceApi.Models;
using SBWSFinanceApi.Utility;

namespace SBWSFinanceApi.DL
{
    public class UserDL
    {
        string _statement;

internal List<m_user_master> GetUserIDDtls(m_user_master mum)
        {
            List<m_user_master> mumRets=new List<m_user_master>();
            string _query=" SELECT ARDB_CD,BRN_CD, USER_ID, PASSWORD, LOGIN_STATUS, USER_TYPE, USER_FIRST_NAME, USER_MIDDLE_NAME, USER_LAST_NAME "
                        +" FROM M_USER_MASTER WHERE  USER_ID={0} AND ARDB_CD={1} ";
            using (var connection = OrclDbConnection.NewConnection)
            {              
               _statement = string.Format(_query,                
                                            string.Concat("'",  mum.user_id, "'"),
                                            string.Concat("'",  mum.ardb_cd, "'")
                                            );
                using (var command = OrclDbConnection.Command(connection, _statement))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)     
                        {
                            while (reader.Read())
                            {    
                                var mumt = new m_user_master();
                                mumt.ardb_cd = UtilityM.CheckNull<string>(reader["ARDB_CD"]);
                                mumt.brn_cd = UtilityM.CheckNull<string>(reader["BRN_CD"]);
                                mumt.user_id = UtilityM.CheckNull<string>(reader["USER_ID"]);
                                mumt.password=SetUserPass(UtilityM.CheckNull<string>(reader["PASSWORD"]));
                                mumt.login_status = UtilityM.CheckNull<string>(reader["LOGIN_STATUS"]);
                                mumt.user_type = UtilityM.CheckNull<string>(reader["USER_TYPE"]);
                                mumt.user_first_name = UtilityM.CheckNull<string>(reader["USER_FIRST_NAME"]);
                                mumt.user_middle_name = UtilityM.CheckNull<string>(reader["USER_MIDDLE_NAME"]);
                                mumt.user_last_name = UtilityM.CheckNull<string>(reader["USER_LAST_NAME"]);
                                mumRets.Add(mumt);

                            }
                        }
                    }
                }
            }
            return mumRets;
        }
        internal int InsertUserMaster(m_user_master mum)
        {
            List<m_user_master> sigList = new List<m_user_master>();
            var passkey=GetUserPass(mum.password); 
            string _query="INSERT INTO M_USER_MASTER (ARDB_CD,BRN_CD, USER_ID, PASSWORD, LOGIN_STATUS, USER_TYPE, USER_FIRST_NAME, USER_MIDDLE_NAME, USER_LAST_NAME )"
                          +" VALUES( {0},{1},{2},{3},{4},{5},{6},{7},{8} ) ";

            using (var connection = OrclDbConnection.NewConnection)
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        _statement = string.Format(_query,
                                                   string.Concat("'", mum.ardb_cd, "'"),
                                                   string.Concat("'", mum.brn_cd, "'"),
                                                   string.Concat("'", mum.user_id, "'") ,
                                                   string.Concat("'", passkey, "'"),
                                                   string.Concat("'", mum.login_status, "'") ,
                                                   string.Concat("'", mum.user_type, "'") ,
                                                   string.Concat("'", mum.user_first_name, "'") ,
                                                   string.Concat("'", mum.user_middle_name, "'") ,
                                                   string.Concat("'", mum.user_last_name, "'") 
                                                    );

                            using (var command = OrclDbConnection.Command(connection, _statement))
                        {                   
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        } 
                        
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
            }

            return 0;
        }
        internal int UpdateUserMaster(m_user_master mum)
        {
            int _ret=0;
            var passkey="";
            if (!String.IsNullOrWhiteSpace(mum.password))
                passkey = GetUserPass(mum.password);
           
            string _query=" UPDATE M_USER_MASTER " 
         +" SET BRN_CD  = {0} , "
         +" USER_ID = {1} , "
         +" PASSWORD     = NVL({2},PASSWORD) , "
         +" LOGIN_STATUS      = {3} , "
         +" USER_TYPE    = {4} , "
         +" USER_FIRST_NAME   = {5} , "
         +" USER_MIDDLE_NAME   = {6} , "
         +" USER_LAST_NAME    = {7}  "
         +"  WHERE  USER_ID={8} AND ARDB_CD={9} ";

            using (var connection = OrclDbConnection.NewConnection)
            {              
                 using (var transaction = connection.BeginTransaction())
                {               
                    try
                    {
                     _statement = string.Format(_query,
                                                   string.Concat("'", mum.brn_cd, "'"),
                                                   string.Concat("'", mum.user_id, "'") ,
                                                   string.Concat("'", passkey==""?null:passkey, "'"),
                                                   string.Concat("'", mum.login_status, "'") ,
                                                   string.Concat("'", mum.user_type, "'") ,
                                                   string.Concat("'", mum.user_first_name, "'") ,
                                                   string.Concat("'", mum.user_middle_name, "'") ,
                                                   string.Concat("'", mum.user_last_name, "'") ,
                                                   string.Concat("'", mum.user_id, "'") ,
                                                   string.Concat("'", mum.ardb_cd, "'")
                                                    );

                        using (var command = OrclDbConnection.Command(connection, _statement))
                        {                   
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            _ret=0;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _ret=-1;
                    }
                }           
            }
            return _ret;
        }
       internal int DeleteUserMaster(m_user_master mum)
        {
            int _ret=0;

            string _query=" UPDATE M_USER_MASTER SET USER_TYPE = 'D' "
                         +" WHERE USER_ID={0} AND ARDB_CD = {1} ";

            using (var connection = OrclDbConnection.NewConnection)
            {              
                 using (var transaction = connection.BeginTransaction())
                {               
                    try
                    {
                     _statement = string.Format(_query,
                                          !string.IsNullOrWhiteSpace(mum.user_id) ? string.Concat("'", mum.user_id, "'") : "user_id",
                                          !string.IsNullOrWhiteSpace(mum.ardb_cd) ? string.Concat("'", mum.ardb_cd, "'") : "ardb_cd"
                                          );

                        using (var command = OrclDbConnection.Command(connection, _statement))
                        {                   
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            _ret=0;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _ret=-1;
                    }
                }           
            }
            return _ret;
        }

         internal string GetUserPass(string passinp)
        {
            string passout="";
            string _query=" Select f_encript_pass({0}) pass From Dual";
            using (var connection = OrclDbConnection.NewConnection)
            {              
                _statement = string.Format(_query,                
                                            string.IsNullOrWhiteSpace(passinp) ? "" : string.Concat("'",  passinp , "'")
                                            );
                using (var command = OrclDbConnection.Command(connection, _statement))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)     
                        {
                            while (reader.Read())
                            {                                
                                passout = UtilityM.CheckNull<string>(reader["PASS"]);
                            }
                        }
                    }
                }
            }
            return passout;
        }  
         internal string SetUserPass(string passinp)
        {
            string passout="";
            string _query=" Select F_DECRIPT_PASS({0}) pass From Dual";
            using (var connection = OrclDbConnection.NewConnection)
            {              
                _statement = string.Format(_query,                
                                            string.IsNullOrWhiteSpace(passinp) ? "" : string.Concat("'",  passinp , "'")
                                            );
                using (var command = OrclDbConnection.Command(connection, _statement))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)     
                        {
                            while (reader.Read())
                            {                                
                                passout = UtilityM.CheckNull<string>(reader["PASS"]);
                            }
                        }
                    }
                }
            }
            return passout;
        }

    
    }
}
    