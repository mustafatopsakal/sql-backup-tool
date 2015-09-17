using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace VeritabanıYedeklemeProjesi
{
    class ClassFTP
    {
        public string FtpAdress, UserName, Password;

        public ClassFTP(string FTPAdress, string UserName, string Password)
        {
            this.FtpAdress = FTPAdress;
            this.UserName = UserName;
            this.Password = Password;
        }

        public string testFTPConnect()
        {
            try
            {
                //string Url = string.Format("{0}:21/public.html/", FtpAdress);
                string Url = string.Format("{0}:21", FtpAdress);
                FtpWebRequest FTPRequest = (FtpWebRequest)WebRequest.Create(new Uri(Url)); //FTP isteği
                FTPRequest.Timeout = 10000; //FTP zaman aşımı
                FTPRequest.UseBinary = true; //FTP veri aktarım izini
                FTPRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FTPRequest.Proxy = WebRequest.GetSystemWebProxy();
                FTPRequest.Credentials = new NetworkCredential(UserName, Password);
                //FTPRequest.EnableSsl = true; 
                FtpWebResponse FTPResponse = (FtpWebResponse)FTPRequest.GetResponse();
                string Answer = string.Format("Yanıt : {0} Açıklama : {1}", ((int)FTPResponse.StatusCode).ToString(), FTPResponse.StatusDescription.ToString());

                return Answer;
            }
            catch (WebException e)
            {
                return e.Message.ToString();
            }
        }

        public void getDirectories(ListBox LBox)
        {
            string Url = string.Format("{0}:21", FtpAdress);
            FtpWebRequest FTPRequest = (FtpWebRequest)WebRequest.Create(new Uri(Url));
            FTPRequest.UseBinary = true;
            FTPRequest.Proxy = WebRequest.GetSystemWebProxy();
            FTPRequest.Timeout = 10000;
            FTPRequest.Credentials = new NetworkCredential(UserName, Password);
            FTPRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FTPRequest.KeepAlive = false;
            //FTPRequest.EnableSsl = true; 
            FtpWebResponse FTPAnswer = (FtpWebResponse)FTPRequest.GetResponse();
            Stream FTPAnswerStr = FTPAnswer.GetResponseStream();
            StreamReader FTPAnswerReader = new StreamReader(FTPAnswerStr);
            //StreamReader FTPAnswerReader = new StreamReader(FTPAnswer.GetResponseStream());
            String list = FTPAnswerReader.ReadToEnd();
            list = list.Replace("\n", "$");
            /*Bir stringte yeni satır görülen yerleri esas alarak list stringe çevirmek için
            * /n bir karakter olmadığı için /n görülen yere bir karakter yazılır. Ve bu karaktere rastlanılan
            * her yerde stringin öncesi bir eleman olarak listeye eklenir.Böylelikle string sonuna kadar gidilir.*/

            foreach (var item in list.Split('$'))
            {
                LBox.Items.Add(item.ToString());
            }
            FTPAnswerStr.Close();
            FTPAnswerReader.Close();
            FTPAnswer.Close();
        }

        public void ListFiles(string SelectedIndex, ListBox LBox)
        {
            string Url = string.Format("{0}:21/{1}", FtpAdress, SelectedIndex.ToString());
            FtpWebRequest FTPRequest = (FtpWebRequest)WebRequest.Create(new Uri(Url));
            FTPRequest.UseBinary = true;
            FTPRequest.Proxy = WebRequest.GetSystemWebProxy();
            FTPRequest.Timeout = 10000;
            FTPRequest.Credentials = new NetworkCredential(UserName, Password);
            FTPRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FTPRequest.KeepAlive = false;
            //FTPRequest.EnableSsl = true; 
            FtpWebResponse FTPAnswer = (FtpWebResponse)FTPRequest.GetResponse();
            Stream FTPAnswerStr = FTPAnswer.GetResponseStream();
            StreamReader FTPAnswerReader = new StreamReader(FTPAnswerStr);
            //StreamReader FTPAnswerReader = new StreamReader(FTPAnswer.GetResponseStream());
            String list = FTPAnswerReader.ReadToEnd();
            list = list.Replace("\n", "$");
            /*Bir stringte yeni satır görülen yerleri esas alarak list stringe çevirmek için
            * /n bir karakter olmadığı için /n görülen yere bir karakter yazılır. Ve bu karaktere rastlanılan
            * her yerde stringin öncesi bir eleman olarak listeye eklenir.Böylelikle string sonuna kadar gidilir.*/



            foreach (var item in list.Split('$'))
            {
                LBox.Items.Add(item.ToString());
            }
            FTPAnswerStr.Close();
            FTPAnswerReader.Close();
            FTPAnswer.Close();

        }

        public void CreateNewDirectory(string DirectoryName)
        {
            try
            {
                string Url = string.Format("{0}:21/{1}", FtpAdress, DirectoryName);
                FtpWebRequest FTPRequest = (FtpWebRequest)WebRequest.Create(new Uri(Url));
                FTPRequest.UseBinary = true;
                FTPRequest.Proxy = WebRequest.GetSystemWebProxy();
                FTPRequest.Timeout = 10000;
                FTPRequest.Credentials = new NetworkCredential(UserName, Password);
                FTPRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                FTPRequest.KeepAlive = false;
                FtpWebResponse FTPAnswer = (FtpWebResponse)FTPRequest.GetResponse();
                Stream FTPAnswerStr = FTPAnswer.GetResponseStream();
                StreamReader FTPAnswerReader = new StreamReader(FTPAnswerStr);
                FTPAnswerStr.Close();
                FTPAnswerReader.Close();
                FTPAnswer.Close();
            }
            catch (WebException e)
            {
                MessageBox.Show(e.Message);
            }
        }








        public void UploadFile(string DiskLocation, string FileName, string FTPDirectoryName)
        {
            try
            {
                //FileInfo toUpload = new FileInfo(FileToUpload);
                string Url = string.Format("{0}:21/{1}/{2}", FtpAdress, FTPDirectoryName, FileName);
                FtpWebRequest FTPRequest = (FtpWebRequest)WebRequest.Create(new Uri(Url));
                FTPRequest.Method = WebRequestMethods.Ftp.UploadFile;
                FTPRequest.Credentials = new NetworkCredential(UserName, Password);
                Stream ftpStream = FTPRequest.GetRequestStream();
                FileStream file = File.OpenRead(DiskLocation + FileName);
                StreamReader FTPAnswerReader = new StreamReader(DiskLocation + FileName);
                int length = 1024;
                byte[] buffer = new byte[length];
                int bytesRead = 0;
                do
                {
                    bytesRead = file.Read(buffer, 0, length);
                    ftpStream.Write(buffer, 0, bytesRead);
                }
                while (bytesRead != 0);
                FTPAnswerReader.Close();
                file.Close();
                ftpStream.Close();
            }

            catch (WebException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
