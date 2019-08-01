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
        //Constant Declaration end++

        //Public Method Start++
        public DataBaseService()
        {
            CreateDatabase();

        }
        private List<Credentials> Allcredentials = new List<Credentials>();
        public List<Credentials> FetchAllCredentials()
        {

            Allcredentials = GetAllCredentialFromDB();

            ////Mock Start
            //Credentials MockCred = new Credentials();
            //MockCred.UserName = "kishore123";
            //MockCred.Password = "password123";
            //MockCred.Domain = "facebook.com";
            //List<Credentials> MockCredentialList = new List<Credentials>();
            //MockCredentialList.Add(MockCred);
            //return MockCredentialList;
            ////Mock end

            //Actual Start
            return Allcredentials;
        }
        public void SaveCredentials(Credentials credentials)
        {

            InsertIntoTable(credentials);
        }
        public void DeleteCredentials(int id)
        {

            DeleteFromTableByPrimaryKey(id);
        }
        public void UpdateCredentials(Credentials credentials)
        {
            UpdateInDB(credentials);
        }

        //public void FetchCredentialsByDomain(string domain)
        //{
        //    //TODO
        //}
        //public void FetchCredentialsByUser(string user)
        //{
        //    //TODO
        //}
        //public void FetchCredentialsByDomainAndUser(string domain,string user)
        //{
        //    //TODO
        //}

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
        private void DeleteFromTableByPrimaryKey(int id)
        {
            //Todo
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder,DBPath)))
                {
                    connection.Query<Credentials>("DELETE FROM  Credentials Where Id=?", id);
                    
                }
            }
            catch (SQLiteException ex)
            {
                throw new NotImplementedException();
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
        private void UpdateInDB(Credentials credentials)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Select From DB method
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool selectTable(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DBPath)))
                {
                    connection.Query<Credentials>("SELECT * FROM Credentials Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {

                return false;
            }
        }
    }
}

