using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomKeyBoard.Models;

namespace CustomKeyBoard.Services
{
    public class DataBaseService
    {
        //Constants Declaration Start++
        private const string DBPath
         = "CredentialsStorage.db";
        private const string AutofillDBPath
            = "AutofillStorage.db";
        //Constant Declaration end++

        //Public Method Start++
        public DataBaseService()
        {
            CreateDatabase();

        }
        private List<Credentials> Allcredentials = new List<Credentials>();

        public Credentials FetchCredentialsFromID(int id)
        {
            return selectTable(id);
        }
        public List<Credentials> FetchAllCredentials()
        {
            Allcredentials = GetAllCredentialFromDB();
            return Allcredentials;
        }
        public void SaveCredentials(Credentials credentials)
        {

            InsertIntoTable(credentials);
        }
        public int DeleteCredentials(int id)
        {
            return DeleteFromTableByPrimaryKey<Credentials>(id);
        }
        public void UpdateCredentials(Credentials credentials)
        {
            UpdateIntoTable(credentials);
        }



        //Public Methods End++



        /// <summary>
        /// Select All operation
        /// </summary>
        /// <returns></returns>
        private List<Credentials> GetAllCredentialFromDB()
        {
            //TODO
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DBPath)))
                {
                    return connection.Table<Credentials>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error while geting all credentials from Database");
                return null;
            }
        }



        /// <summary>
        /// Create DataBase
        /// </summary>
        /// <returns></returns>
        readonly string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CreateDatabaseForAutoFill()
        {
            using (SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(folder, AutofillDBPath)))
            {
                try
                {
                    connection.CreateTable<AutofillData>();
                    return true;
                }
                catch(SQLiteException ex)
                {
                    return false;
                }
            }
        }
        
        private bool CreateDatabase()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(folder, DBPath)))
                {
                    connection.CreateTable<Credentials>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("sql is fucked, exception in create DataBase");
                return false;
            }
        }


        /// <summary>
        /// Delete from DB by PrimaryKey
        /// </summary>
        /// <param name="id"></param>
        private int DeleteFromTableByPrimaryKey<T>(object primaryKey)
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DBPath)))
            {
                try
                {
                    return connection.Delete<T>(primaryKey);
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Insertion Operation
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        private bool InsertIntoTable(Credentials credentials)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(folder, DBPath)))
                {
                    connection.Insert(credentials);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("sql is fucked, exception in inserting into table in DataBase");
                return false;
            }
        }
        /// <summary>
        /// DB Updation Mehod
        /// </summary>
        /// <param name="credentials"></param>
        private int UpdateIntoTable<T>(T credentials)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DBPath)))
                {
                    //DeleteFromTableByPrimaryKey(credentials.Id);
                    //connection.Query<Credentials>("UPDATE Credentials set Domain=?, UserName=?, Password=? Where Id=?", credentials.Domain, credentials.UserName, credentials.Password, credentials.Id);
                    return connection.Update(credentials, typeof(T));
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("sql is fucked, exception in updating into table in DataBase");
            }
            return -1;
        }


        /// <summary>
        /// Select From DB method
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Credentials selectTable(int Id)
        {
            Credentials temp_credentials;
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DBPath)))
                {
                    temp_credentials = connection.Query<Credentials>("SELECT * FROM Credentials Where Id=?", Id)[0];
                    return temp_credentials;
                }
            }
            catch (SQLiteException ex)
            {

                Console.WriteLine("sql is fucked, exception in updating into table in DataBase");
                return null;
            }
        }
    }
}

