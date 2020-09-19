/*Cameron Deao
 * CST-247
 * James Sinevar
 * 9/18/2020 */

using Benchmark___Bible_Verse.Models;
using Benchmark___Bible_Verse.Services.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Benchmark___Bible_Verse.Services.Data
{
    public class VerseDAO
    {
        //Global readonly string from connection to DB.
        readonly string connection = "Data Source=(localdb)\\MSSQLLocalDB;initial catalog=Test ;Integrated Security=True;";
        //Connection is made null and initialized in a separate method.
        SqlConnection conn = null;

        //Initial method called when inserting data.
        public bool InsertVerse(BibleVerse verse)
        {
            //Connection is established.
            EstablishConnection();

            //Checking if the verse exists.
            if(!CheckVerse(verse))
            {
                //Inserting the verse.
                VerseInsertion(verse);
                //Returning true.
                return true;
            }
            else
            {
                return false;
            }
        }

        //Verse object is received for insertion.
        public void VerseInsertion(BibleVerse verse)
        {
            //Query to enter data.
            string query = "INSERT INTO dbo.verse (TESTAMENT, BOOK, CHAPTER, VERSE, TEXT)" +
                " values (@Testament, @Book, @Chapter, @Verse, @Text)";
            SqlCommand command = new SqlCommand(query, conn);

            try
            {
                //All variables of the query have a value added based on the passed object.
                command.Parameters.AddWithValue("@Testament", verse.Testament.ToString());
                command.Parameters.AddWithValue("@Book", verse.Book);
                command.Parameters.AddWithValue("@Chapter", verse.Chapter);
                command.Parameters.AddWithValue("@Verse", verse.VerseNum);
                command.Parameters.AddWithValue("@Text", verse.VerseText);

                conn.Open();
                command.ExecuteNonQuery();

                //Logging entry
                VerseLogger.GetInstance().Debug("Inserted a verse into the DB.");
            }
            catch(SqlException e)
            {
                //Exception fires in the event of an error.
                VerseLogger.GetInstance().Error(e, " An error occurred in VerseInsertion()");
                Debug.WriteLine("An exception occurred: " + e);
            }
            finally
            {
                conn.Close();
            }
        }

        //Checking if the verse object exists within the database.
        public bool CheckVerse(BibleVerse verse)
        {
            //Query to find data.
            string query = "SELECT 1 FROM dbo.verse WHERE BOOK = @Book AND CHAPTER = @Chapter AND VERSE = @Verse";
            SqlCommand command = new SqlCommand(query, conn);

            try
            {
                //All variables of the query have a value added based on the passed object.
                command.Parameters.Add("@Book", System.Data.SqlDbType.VarChar, 50).Value = verse.Book;
                command.Parameters.Add("@Chapter", System.Data.SqlDbType.Int).Value = verse.Chapter;
                command.Parameters.Add("@Verse", System.Data.SqlDbType.Int).Value = verse.VerseNum;

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                //reader.HasRows fires in the event the data is found within the database.
                if (reader.HasRows)
                {
                    VerseLogger.GetInstance().Debug("A verse was found in CheckVerse()");
                    conn.Close();
                    //Returns true.
                    return true;
                }

            }
            catch (SqlException e)
            {
                //Exception fires in the event of an error.
                VerseLogger.GetInstance().Error(e, " An error occurred in CheckVerse()");
                Debug.WriteLine("An exception occurred: " + e);
            }
            finally
            {
                conn.Close();
            }

            return false;
        }

        //Finding a verse within the database.
        public BibleVerse FindVerse(BibleVerse verse)
        {
            EstablishConnection();

            //Query to find data.
            string query = "SELECT * FROM dbo.verse WHERE TESTAMENT = @Testament AND BOOK = @Book AND CHAPTER = @Chapter" +
                " AND VERSE = @Verse";
            SqlCommand command = new SqlCommand(query, conn);

            try
            {
                //All variables of the query have a value added based on the passed object.
                command.Parameters.Add("@Testament", System.Data.SqlDbType.VarChar, 15).Value = verse.Testament;
                command.Parameters.Add("@Book", System.Data.SqlDbType.VarChar, 50).Value = verse.Book;
                command.Parameters.Add("@Chapter", System.Data.SqlDbType.Int).Value = verse.Chapter;
                command.Parameters.Add("@Verse", System.Data.SqlDbType.Int).Value = verse.VerseNum;

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    VerseLogger.GetInstance().Debug("A verse was found in FindVerse()");
                    while (reader.Read())
                    {
                        //New verse object is created an properties are set based on found data.
                        BibleVerse foundVerse = new BibleVerse();
                        if (reader.GetString(1) == "Old")
                        {
                            foundVerse.Testament = Testament.Old;
                        }
                        else
                        {
                            foundVerse.Testament = Testament.New;
                        }
                        foundVerse.Book = reader.GetString(2);
                        foundVerse.Chapter = reader.GetInt32(3);
                        foundVerse.VerseNum = reader.GetInt32(4);
                        foundVerse.VerseText = reader.GetString(5);

                        conn.Close();
                        //Returning the created verse object.
                        return foundVerse;
                    }
                }

            }
            catch (SqlException e)
            {
                //Exception fires in the event of an error.
                VerseLogger.GetInstance().Error(e, " An error occurred in FindVerse()");
                Debug.WriteLine("An exception occurred: " + e);
            }
            finally
            {
                conn.Close();
            }
            //Null is returned when no data is found within the database for a verse.
            VerseLogger.GetInstance().Debug("No verse was found in FindVerse()");
            return null;
        }

        //Establishing a connection to the database.
        public void EstablishConnection()
        {
            conn = new SqlConnection(connection);
        }
    }
}