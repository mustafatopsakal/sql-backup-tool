using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.IO;
using System.Threading;


namespace VeritabanıYedeklemeProjesi
{
    class ThreadingClass
    {
        BackUp BackUpObj = new BackUp();


        int FullLimit, DifferantialLimit, TransactLogLimit;

        string ServerName, UserName, Password;
        public string DatabaseName;
        string BackUpLocation;
        string FullBackUpTiming, FullBackUpFrequency, FullCompressOption, FullCopyOnlyOption, FullBackUpLimit;
        string DifferantialBackUpTiming, DifferantialBackUpFrequency, DifferantialCompressOption, DifferantialBackUpLimit;
        string TransactLogBackUpTiming, TransactLogBackUpFrequency, TransactLogCompressOption, TransactLogCopyOnlyOption, TransactLogTruncateOption, TransactLogBackUpLimit;

        //bool FullBackUpState = true;
        //bool DifferantialBackUpState = true;
        //bool TransactLogBackUpState = true;

        Thread thread1;
        Thread thread2;
        Thread thread3;

        //List<Thread> threads = new List<Thread>();
        //string stateFull = true;
        //string stateDifferantial = true;
        //string stateTransactLog = true;


        public ThreadingClass(string ServerName, string UserName, string Password, string DatabaseName, string BackUpLocation)
        {

            this.ServerName = ServerName;
            this.UserName = UserName;
            this.Password = Password;
            this.DatabaseName = DatabaseName;
            this.BackUpLocation = BackUpLocation;


            List<string> list = BackUpObj.GetSettingsDatabase(DatabaseName);

            DatabaseName = list[0];

            FullBackUpTiming = list[1];
            FullBackUpFrequency = list[2];
            FullCompressOption = list[3];
            FullCopyOnlyOption = list[4];
            FullBackUpLimit = list[5];

            DifferantialBackUpTiming = list[6];
            DifferantialBackUpFrequency = list[7];
            DifferantialCompressOption = list[8];
            DifferantialBackUpLimit = list[9];

            TransactLogBackUpTiming = list[10];
            TransactLogBackUpFrequency = list[11];
            TransactLogCompressOption = list[12];
            TransactLogCopyOnlyOption = list[13];
            TransactLogTruncateOption = list[14];
            TransactLogBackUpLimit = list[15];

            FullLimit = Convert.ToInt32(FullBackUpLimit);
            DifferantialLimit = Convert.ToInt32(DifferantialBackUpLimit);
            TransactLogLimit = Convert.ToInt32(TransactLogBackUpLimit);
        }


        public void RunFullBackUp()
        {

            int BackUpNumberFull = BackUpObj.GetFullNumber(DatabaseName);
            if (FullLimit == BackUpNumberFull - 1)
            {
                BackUpNumberFull = 1;
            }
            else
            {
                BackUpNumberFull++;
            }

            while (true)
            {

                if (FullLimit == BackUpNumberFull - 1)
                {
                    BackUpNumberFull = 1;
                }
                BackUpObj.DeleteBackUp(@BackUpLocation + DatabaseName + "_FULL_" + BackUpNumberFull + ".bak");
                BackUpObj.FullBackUp(ServerName, UserName, Password, DatabaseName, BackUpLocation, FullCopyOnlyOption, BackUpNumberFull);
                //BackUpObj.RestoreVerifyOnly(ServerName, UserName, Password, @BackUpLocation + DatabaseName + "_FULL_" + BackUpNumberFull + ".bak");
                BackUpNumberFull++;
                Thread.Sleep(BackUpObj.CalculateTime(FullBackUpTiming, FullBackUpFrequency));
            }
        }

        public void RunDifferantialBackUp()
        {

            int BackUpNumberDifferantial = BackUpObj.GetDifferantialNumber(DatabaseName);
            if (DifferantialLimit == BackUpNumberDifferantial - 1)
            {
                BackUpNumberDifferantial = 1;
            }
            else
            {
                BackUpNumberDifferantial++;
            }

            while (true)
            {
                Thread.Sleep(BackUpObj.CalculateTime(DifferantialBackUpTiming, DifferantialBackUpFrequency));
                if (DifferantialLimit == BackUpNumberDifferantial - 1)
                {
                    BackUpNumberDifferantial = 1;
                }
                BackUpObj.DeleteBackUp(@BackUpLocation + DatabaseName + "_DIFFERANTIAL_" + BackUpNumberDifferantial + ".bak");
                BackUpObj.DifferantialBackUp(ServerName, UserName, Password, DatabaseName, BackUpLocation, BackUpNumberDifferantial);
                //BackUpObj.RestoreVerifyOnly(ServerName, UserName, Password, @BackUpLocation + DatabaseName + "_DIFFERANTIAL_" + BackUpNumberDifferantial + ".bak");
                BackUpNumberDifferantial++;
            }
        }

        public void RunTransactLogBackUp()
        {

            int BackUpNumberTransactLog = BackUpObj.GetTransactLogNumber(DatabaseName);
            if (TransactLogLimit == BackUpNumberTransactLog - 1)
            {
                BackUpNumberTransactLog = 1;
            }
            else
            {
                BackUpNumberTransactLog++;
            }

            while (true)
            {
                Thread.Sleep(BackUpObj.CalculateTime(TransactLogBackUpTiming, TransactLogBackUpFrequency));
                if (TransactLogLimit == BackUpNumberTransactLog - 1)
                {
                    BackUpNumberTransactLog = 1;
                }
                BackUpObj.DeleteBackUp(@BackUpLocation + DatabaseName + "_TRANSACTLOG_" + BackUpNumberTransactLog + ".bak");
                BackUpObj.TransactLogBackUp(ServerName, UserName, Password, DatabaseName, BackUpLocation, TransactLogTruncateOption, TransactLogCopyOnlyOption, BackUpNumberTransactLog);
                //BackUpObj.RestoreVerifyOnly(ServerName, UserName, Password, @BackUpLocation + DatabaseName + "_TRANSACTLOG_" + BackUpNumberTransactLog + ".bak");
                BackUpNumberTransactLog++;
            }
        }


        public void StartThread()
        {

            thread1 = new Thread(RunFullBackUp);
            thread1.IsBackground = true;
            thread1.Start();

            thread2 = new Thread(RunDifferantialBackUp);
            thread2.IsBackground = true;
            thread2.Start();

            thread3 = new Thread(RunTransactLogBackUp);
            thread3.IsBackground = true;
            thread3.Start();

        }

        //public void StopThread()
        //{
        //    thread1.Suspend();
        //    thread2.Suspend();
        //    thread3.Suspend();
        //}

        //public void ResumeThread()
        //{
        //    thread1.Resume();
        //    thread2.Resume();
        //    thread3.Resume();
        //}

        public void CancelThread()
        {
            thread1.Abort();
            thread2.Abort();
            thread3.Abort();
        }



    }
}
