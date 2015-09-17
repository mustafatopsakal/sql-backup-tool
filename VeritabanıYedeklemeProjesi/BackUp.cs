using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace VeritabanıYedeklemeProjesi
{
    class BackUp
    {

        //public void WriteFile(string fileName,string writingText)
        //{
        //    StreamWriter SW = File.AppendText(Application.StartupPath + fileName);
        //    SW.WriteLine(writingText);
        //    SW.Close();
        //}


        public bool Connect(string serverName, string userName, string password)
        {
            /*Bir SQL Servera server adı kullanıcı adı ve şifresiyle bağlanan fonksiyon. */

            SqlConnection con = new SqlConnection("server= " + serverName + ";User Id= " + userName + ";" + "pwd= " + password + ";");
            bool check = false;
            try
            {
                con.Open();
                check = true;

            }

            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                //WriteFile("//eKutuphaneBackUpLog.txt", e.Message);
            }
            finally
            {
                con.Close();
            }

            return check;
        }


        public List<string> GetDatabaseList(string serverName, string userName, string password)
        {
            /*Bir SQL Servera bağlantı ve veritabanı isimlerinin çekilmesi.*/
            List<string> list = new List<string>();

            // Open connection to the database
            string conString = "server= " + serverName + ";User Id= " + userName + ";" + "pwd= " + password + ";";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }
            }
            return list;

        }


        public void FullBackUp(string serverName, string userName, string password, string veriTabaniAd, string @yedeklemeKonum, string copyOnly, int yedekNo /*, string sikistirmaTur*/)
        {
            /*Full yedekleme yapan fonksiyon. */
            SqlConnection con = new SqlConnection("server= " + serverName + ";User Id= " + userName + ";" + "pwd= " + password + ";");

            try
            {
                con.Open();
                //SqlCommand BackUpFull = new SqlCommand("BACKUP DATABASE" + "[" + veriTabaniAd + "]" + "TO  DISK = N'" + @yedeklemeKonum + veriTabaniAd + "_FULL_"+ yedekNo  +".bak'" + " WITH " + copyOnly + "NOFORMAT, NOINIT,  NAME = N'" + veriTabaniAd + "_FULL_" + yedekNo + "', SKIP, NOREWIND, NOUNLOAD," + sikistirmaTur + ",  STATS = 10", con);
                SqlCommand BackUpFull = new SqlCommand("BACKUP DATABASE" + "[" + veriTabaniAd + "]" + "TO  DISK = N'" + @yedeklemeKonum + veriTabaniAd + "_FULL_" + yedekNo + ".bak'" + " WITH " + copyOnly + "NOFORMAT, NOINIT,  NAME = N'" + veriTabaniAd + "_FULL_" + yedekNo + "', SKIP, NOREWIND, NOUNLOAD, NO_COMPRESSION,  STATS = 10", con);
                BackUpFull.ExecuteNonQuery();
                //con.Close();
                //BackUpFull.Dispose();
                UpdateFullNumber(veriTabaniAd, yedekNo);
                InsertBackUpMovementLogs("FULLBACKUP", veriTabaniAd, "İŞLEM BAŞARILI");
            }
            catch (SqlException e)
            {
                InsertBackUpMovementLogs("FULLBACKUP", veriTabaniAd, e.Message);
            }
            finally
            {
                //con.Dispose();
                con.Close();
            }
        }



        public void DifferantialBackUp(string serverName, string userName, string password, string veriTabaniAd, string @yedeklemeKonum, int yedekNo /*, string sikistirmaTur*/)
        {
            /*Differantial yedekleme yapan fonksiyon. */
            SqlConnection con = new SqlConnection("server= " + serverName + ";User Id= " + userName + ";" + "pwd= " + password + ";");

            try
            {
                con.Open();
                //SqlCommand BackUpDifferantial = new SqlCommand("BACKUP DATABASE" + "[" + veriTabaniAd + "]" + "TO  DISK = N'" + @yedeklemeKonum + veriTabaniAd + "_DIFFERANTIAL_" + yedekNo + ".bak'" + "WITH DIFFERENTIAL, NOFORMAT, NOINIT,  NAME = N'" + veriTabaniAd + "_DIFFERANTIAL_" + yedekNo + "', SKIP, NOREWIND, NOUNLOAD," + sikistirmaTur + ",  STATS = 10", con);
                SqlCommand BackUpDifferantial = new SqlCommand("BACKUP DATABASE" + "[" + veriTabaniAd + "]" + "TO  DISK = N'" + @yedeklemeKonum + veriTabaniAd + "_DIFFERANTIAL_" + yedekNo + ".bak'" + "WITH DIFFERENTIAL, NOFORMAT, NOINIT,  NAME = N'" + veriTabaniAd + "_DIFFERANTIAL_" + yedekNo + "', SKIP, NOREWIND, NOUNLOAD, NO_COMPRESSION,  STATS = 10", con);
                BackUpDifferantial.ExecuteNonQuery();
                //con.Close();
                //BackUpDifferantial.Dispose();

                UpdateDifferantialNumber(veriTabaniAd, yedekNo);
                InsertBackUpMovementLogs("DIFFERANTIALBACKUP", veriTabaniAd, "İŞLEM BAŞARILI");

            }
            catch (SqlException e)
            {
                InsertBackUpMovementLogs("DIFFERANTIALBACKUP", veriTabaniAd, e.Message);
            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
        }



        public void TransactLogBackUp(string serverName, string userName, string password, string veriTabaniAd, string @yedeklemeKonum, string truncateOpsiyon, string copyOnly, int yedekNo/*, string sikistirmaTur*/)
        {
            /*TransactLog yedekleme yapan fonksiyon. */

            SqlConnection con = new SqlConnection("server= " + serverName + ";User Id= " + userName + ";" + "pwd= " + password + ";");

            try
            {
                con.Open();
                //SqlCommand BackUpTransactLog = new SqlCommand("BACKUP LOG" + "[" + veriTabaniAd + "]" + "TO  DISK = N" + "'" + @yedeklemeKonum + veriTabaniAd + "_TRANSACTLOG_"+ yedekNo + ".bak'" + " WITH " + truncateOpsiyon + copyOnly + "NOFORMAT, NOINIT,  NAME = N'" + veriTabaniAd + "_TRANSACTLOG_" + yedekNo + "', SKIP, NOREWIND, NOUNLOAD," + sikistirmaTur + ",  STATS = 10", con);
                SqlCommand BackUpTransactLog = new SqlCommand("BACKUP LOG" + "[" + veriTabaniAd + "]" + "TO  DISK = N" + "'" + @yedeklemeKonum + veriTabaniAd + "_TRANSACTLOG_" + yedekNo + ".bak'" + " WITH " + truncateOpsiyon + copyOnly + "NOFORMAT, NOINIT,  NAME = N'" + veriTabaniAd + "_TRANSACTLOG_" + yedekNo + "', SKIP, NOREWIND, NOUNLOAD, NO_COMPRESSION,  STATS = 10", con);
                BackUpTransactLog.ExecuteNonQuery();
                //con.Close();
                //BackUpTransactLog.Dispose();
                UpdateTransactLogNumber(veriTabaniAd, yedekNo);
                InsertBackUpMovementLogs("TRANSACTLOGBACKUP", veriTabaniAd, "İŞLEM BAŞARILI");

            }
            catch (SqlException e)
            {
                InsertBackUpMovementLogs("TRANSACTLOGBACKUP", veriTabaniAd, e.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public void RestoreVerifyOnly(string serverName, string userName, string password, string @yedeklemeKonum)
        {
            /*Veritabanı yedeklendikten sonra doğru mu yedeklenildiğinin kontrolü.*/
            /*Geri dönüş tipi bulunamadı ?! */
            SqlConnection con = new SqlConnection("server= " + serverName + ";User Id= " + userName + ";" + "pwd= " + password + ";");

            try
            {
                con.Open();
                SqlCommand RestoreVerify = new SqlCommand("RESTORE VERIFYONLY FROM disk= " + "'" + @yedeklemeKonum + "'", con);
                RestoreVerify.ExecuteNonQuery();
                //WriteFile("//eKutuphaneBackUpLog.txt", @yedeklemeKonum + " GEÇERLİ BİR YEDEKTİR.");
            }

            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                //WriteFile("//eKutuphaneBackUpLog.txt", @yedeklemeKonum + " GEÇERSİZ BİR YEDEKTİR." + e.Message);
            }
            finally
            {

                con.Close();
            }

        }


        public List<string> BackUpLogs(string serverName, string userName, string password, string @yedeklemeKonum)
        {
            /*Yedeklenen bir veritabanının logları*/
            List<string> list = new List<string>();

            // Open connection to the database
            string conString = "server= " + serverName + ";User Id= " + userName + ";" + "pwd= " + password + ";";


            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("RESTORE HEADERONLY FROM disk='" + @yedeklemeKonum + "'", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add("BackUpName: " + dr[0].ToString() + " ");
                            list.Add("BackUpType: " + dr[2].ToString() + " ");
                            list.Add("Compressed: " + dr[4].ToString() + " ");
                            list.Add("Position: " + dr[5].ToString() + " ");
                            list.Add("DeviceType: " + dr[6].ToString() + " ");
                            list.Add("ServerName: " + dr[8].ToString() + " ");
                            list.Add("DatabaseName: " + dr[9].ToString() + " ");
                            list.Add("DatabaseCreationDate: " + dr[11].ToString() + " ");
                            list.Add("BackUpSize: " + dr[12].ToString() + " ");
                            list.Add("BackUpStartDate: " + dr[17].ToString() + " ");
                            list.Add("BackUpFinishDate: " + dr[18].ToString() + " ");
                            list.Add("IsCopyOnly: " + dr[43].ToString() + " ");
                            list.Add("BackUpTypeDescription: " + dr[49].ToString() + " ");
                        }
                    }
                }
            }
            return list;

        }

        public void DeleteBackUp(string @BackUpLocation)
        {
            //Diskteki konumu verilen bir dosyayı silen fonksiyon.
            if (System.IO.File.Exists(@BackUpLocation))
            {
                System.IO.File.Delete(@BackUpLocation);
            }
        }

        public int CalculateTime(string BackUpTiming, string BackUpFrequency)
        {
            int timeMilisecond = 0;

            if (BackUpTiming == "GÜN")
            {
                timeMilisecond = 86400000;
            }
            else if (BackUpTiming == "SAAT")
            {
                timeMilisecond = 3600000;
            }
            else if (BackUpTiming == "DAKİKA")
            {
                timeMilisecond = 60000;
            }

            timeMilisecond = timeMilisecond * Convert.ToInt32(BackUpFrequency);

            return timeMilisecond;
        }


        public void Insert
       (
        string DatabaseName,
        string FullTiming, int FullFrequency, string FullCompressOption, string FullCopyOnlyOption, int FullLimit,
        string DifferantialTiming, int DifferantialFrequency, string DifferantialCompressOption, int DifferantialLimit,
        string TransactLogTiming, int TransactLogFrequency, string TransactLogCompressOption, string TransactLogCopyOnlyOption, string TransactLogTruncateOption, int TransactLogLimit
       )
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            try
            {
                con.Open();
                SQLiteCommand Insert = new SQLiteCommand("insert into Settings(DatabaseName, FullTiming, FullFrequency, FullCompressOption, FullCopyOnlyOption, FullLimit, DifferantialTiming, DifferantialFrequency, DifferantialCompressOption, DifferantialLimit, TransactLogTiming, TransactLogFrequency, TransactLogCompressOption, TransactLogCopyOnlyOption, TransactLogTruncateOption, TransactLogLimit) values('" + DatabaseName + "','" + FullTiming + "','" + FullFrequency + "','" + FullCompressOption + "','" + FullCopyOnlyOption + "','" + FullLimit + "','" + DifferantialTiming + "','" + DifferantialFrequency + "','" + DifferantialCompressOption + "','" + DifferantialLimit + "','" + TransactLogTiming + "','" + TransactLogFrequency + "','" + TransactLogCompressOption + "','" + TransactLogCopyOnlyOption + "','" + TransactLogTruncateOption + "','" + TransactLogLimit + "')", con);
                Insert.ExecuteNonQuery();
                //con.Close();
                //Insert.Dispose();
                InsertBackUpNumber(DatabaseName);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
        }

        public void UpdateFull(string DatabaseName, string FullTiming, int FullFrequency, string FullCompressOption, string FullCopyOnlyOption, int FullLimit)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            try
            {
                con.Open();
                SQLiteCommand Update = new SQLiteCommand("Update Settings set FullTiming ='" + FullTiming + "',FullFrequency = '" + FullFrequency + "',FullCompressOption = '" + FullCompressOption + "',FullCopyOnlyOption = '" + FullCopyOnlyOption + "',FullLimit = '" + FullLimit + "' Where DatabaseName = '" + DatabaseName + "'", con);
                Update.ExecuteNonQuery();
                //con.Close();
                //Update.Dispose();
            }
            catch (SqlException)
            {

            }
            finally
            {
                //con.Dispose();
                con.Close();
            }
        }

        public void UpdateDifferantial(string DatabaseName, string DifferantialTiming, int DifferantialFrequency, string DifferantialCompressOption, int DifferantialLimit)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            try
            {
                con.Open();
                SQLiteCommand Update = new SQLiteCommand("Update Settings set DifferantialTiming ='" + DifferantialTiming + "',DifferantialFrequency = '" + DifferantialFrequency + "',DifferantialCompressOption = '" + DifferantialCompressOption + "',DifferantialLimit = '" + DifferantialLimit + "' Where DatabaseName = '" + DatabaseName + "'", con);
                Update.ExecuteNonQuery();
                //con.Close();
                //Update.Dispose();
            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
        }

        public void UpdateTransactLog(string DatabaseName, string TransactLogTiming, int TransactLogFrequency, string TransactLogCompressOption, string TransactLogCopyOnlyOption, string TransactLogTruncateOption, int TransactLogLimit)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            try
            {
                con.Open();
                SQLiteCommand Update = new SQLiteCommand("Update Settings set TransactLogTiming ='" + TransactLogTiming + "', TransactLogFrequency = '" + TransactLogFrequency + "',TransactLogCompressOption = '" + TransactLogCompressOption + "',TransactLogCopyOnlyOption = '" + TransactLogCopyOnlyOption + "',TransactLogTruncateOption = '" + TransactLogTruncateOption + "',TransactLogLimit = '" + TransactLogLimit + "' Where DatabaseName = '" + DatabaseName + "'", con);
                Update.ExecuteNonQuery();
                //con.Close();
                //Update.Dispose();
            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
        }


        public void Delete(string DatabaseName)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            try
            {
                con.Open();
                SQLiteCommand Delete = new SQLiteCommand("delete from Settings where DatabaseName = " + "'" + DatabaseName + "'", con);
                Delete.ExecuteNonQuery();
                //con.Close();
                //Delete.Dispose();
            }

            catch
            {

            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
        }

        public void InsertBackUpNumber(string DatabaseName)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            try
            {
                con.Open();
                SQLiteCommand Insert = new SQLiteCommand("insert into BackUpNumbers(DatabaseName, FullNumber, DifferantialNumber, TransactLogNumber) values('" + DatabaseName + "','" + 0 + "','" + 0 + "','" + 0 + "')", con);
                Insert.ExecuteNonQuery();
                //con.Close();
                //Insert.Dispose();
            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
        }

        public void UpdateFullNumber(string DatabaseName, int ActualNumber)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            try
            {
                con.Open();
                SQLiteCommand UpdateFull = new SQLiteCommand("Update BackUpNumbers set FullNumber = '" + ActualNumber + "' Where DatabaseName = '" + DatabaseName + "'", con);
                UpdateFull.ExecuteNonQuery();
                //con.Close();
                //UpdateFull.Dispose();
            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
        }

        public void UpdateDifferantialNumber(string DatabaseName, int ActualNumber)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            try
            {
                con.Open();
                SQLiteCommand UpdateDifferantial = new SQLiteCommand("Update BackUpNumbers set DifferantialNumber = '" + ActualNumber + "' Where DatabaseName = '" + DatabaseName + "'", con);
                UpdateDifferantial.ExecuteNonQuery();
                //con.Close();
                //UpdateDifferantial.Dispose();
            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
        }

        public void UpdateTransactLogNumber(string DatabaseName, int ActualNumber)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            try
            {
                con.Open();
                SQLiteCommand UpdateTransactLog = new SQLiteCommand("Update BackUpNumbers set TransactLogNumber = '" + ActualNumber + "' Where DatabaseName = '" + DatabaseName + "'", con);
                UpdateTransactLog.ExecuteNonQuery();
                //con.Close();
                //UpdateTransactLog.Dispose();
            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
                //con.Dispose();
            }
        }

        public int GetFullNumber(string DatabaseName)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            con.Open();
            int fullNumber = 0;
            // Set up a command with the given query and associate
            // this with the current connection.
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT FullNumber from BackUpNumbers Where DatabaseName = '" + DatabaseName + "'", con))
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        fullNumber = Convert.ToInt32(dr[0]);
                    }
                }

                //con.Close();
                //cmd.Dispose();
            }
            con.Close();
            //con.Dispose();

            return fullNumber;
        }

        public int GetDifferantialNumber(string DatabaseName)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            con.Open();
            int differantialNumber = 0;
            // Set up a command with the given query and associate
            // this with the current connection.
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT DifferantialNumber from BackUpNumbers Where DatabaseName = '" + DatabaseName + "'", con))
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        differantialNumber = Convert.ToInt32(dr[0]);
                    }
                }

                //con.Close();
                //cmd.Dispose();
            }
            con.Close();
            //con.Dispose();

            return differantialNumber;
        }


        public int GetTransactLogNumber(string DatabaseName)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            con.Open();
            int transactLogNumber = 0;
            // Set up a command with the given query and associate
            // this with the current connection.
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT TransactLogNumber from BackUpNumbers Where DatabaseName = '" + DatabaseName + "'", con))
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        transactLogNumber = Convert.ToInt32(dr[0]);
                    }
                }

                //con.Close();
                //cmd.Dispose();
            }
            con.Close();
            //con.Dispose();

            return transactLogNumber;
        }

        public List<string> GetDatabaseNames()
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            /*Bir SQL Servera bağlantı ve veritabanı isimlerinin çekilmesi.*/
            List<string> list = new List<string>();

            // Open connection to the database
            using (con)
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT DatabaseName from Settings", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }

                    //con.Close();
                    //cmd.Dispose();
                }
                con.Close();
                //con.Dispose();
            }


            return list;
        }

        public List<string> GetSettingsDatabase(string DatabaseName)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            List<string> list = new List<string>();


            // Open connection to the database
            using (con)
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * from Settings Where DatabaseName = '" + DatabaseName + "'", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                list.Add(dr[i].ToString());
                            }
                        }
                    }

                    //con.Close();
                    //cmd.Dispose();
                }
                con.Close();
                //con.Dispose();
            }

            return list;
        }


        public void InsertBackUpMovementLogs(string Movement, string DatabaseName, string Description)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            string OperationDate = DateTime.Now.ToShortDateString();
            string OperationHour = DateTime.Now.ToLongTimeString();

            try
            {
                con.Open();
                SQLiteCommand Insert = new SQLiteCommand("insert into BackUpMovementLogs(Movement, OperationDate, OperationHour, DatabaseName, Description) values('" + Movement + "','" + OperationDate + "','" + OperationHour + "','" + DatabaseName + "','" + Description + "')", con);
                Insert.ExecuteNonQuery();
                con.Close();
                Insert.Dispose();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                //con.Close();
                con.Dispose();
            }
        }

        public void GetLogTable(DataGridView dataGrid, string tabloAd)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
            try
            {
                con.Open();
                /*Bu komutu parametre alan bir sql data adapter sınıfı oluşturulur. 
                 * Verilerin databaseden alınması işlemini yapar. */
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("Select * from " + tabloAd, con);

                //Data Table Oluşturur.
                DataTable dt = new DataTable();
                //Data tablenin içini veritabanından alınan verilerle doldur.
                adapter.Fill(dt);
                //Doldurulan data tableyi parametre olarak gelen data gride ata.
                dataGrid.DataSource = dt;
            }

            catch (SqlException e)
            {
                //Hata mesajı.
                MessageBox.Show(e.Message);
            }

            finally
            {
                con.Close();
            }

        }

        //public void Update
        //(
        //string DatabaseName, string DatabaseLocation,
        //string FullTiming, int FullFrequency, string FullCompressOption, string FullCopyOnlyOption, int FullLimit,
        //string DifferantialTiming, int DifferantialFrequency, string DifferantialCompressOption, int DifferantialLimit,
        //string TransactLogTiming, int TransactLogFrequency, string TransactLogCompressOption, string TransactLogCopyOnlyOption, string TransactLogTruncateOption, int TransactLogLimit
        //)
        //{
        //SQLiteConnection con = new SQLiteConnection(@"Data Source=" + Application.StartupPath + "\\BackUpDatabase.db;Version=3;Legacy Format=True;Pooling=true;");
        //    try
        //    {
        //        con.Open();
        //        SQLiteCommand Update = new SQLiteCommand("Update Settings set DatabaseLocation ='" + DatabaseLocation + "', FullTiming ='" + FullTiming + "',FullFrequency = '" + FullFrequency + "',FullCompressOption = '" + FullCompressOption + "',FullCopyOnlyOption = '" + FullCopyOnlyOption + "',FullLimit = '" + FullLimit + "',DifferantialTiming = '" + DifferantialTiming + "', DifferantialFrequency = '" + DifferantialFrequency + "',DifferantialCompressOption = '" + DifferantialCompressOption + "',DifferantialLimit = '" + DifferantialLimit + "', TransactLogTiming ='" + TransactLogTiming + "',TransactLogFrequency = '" + TransactLogFrequency + "',TransactLogCompressOption = '" + TransactLogCompressOption + "',TransactLogCopyOnlyOption = '" + TransactLogCopyOnlyOption + "',TransactLogTruncateOption = '" + TransactLogTruncateOption + "',TransactLogLimit = '" + TransactLogLimit + "' Where DatabaseName = '" + DatabaseName + "'", con);
        //        Update.ExecuteNonQuery();
        //        con.Close();
        //        Update.Dispose();
        //    }

        //    catch
        //    {
        //        MessageBox.Show("GÜNCELLEME HATASI OLUŞTU");
        //    }

        //    finally
        //    {

        //        con.Dispose();
        //    }
        //}





    }
}
