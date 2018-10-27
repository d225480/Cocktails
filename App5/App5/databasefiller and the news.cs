using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using FastExcel;
using System.Data;
using Syncfusion.XlsIO;
using System.Reflection;

namespace App5
{
    public class databasefiller_and_the_news
    {
        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public databasefiller_and_the_news()
        {

        }
        public static void filler()
        {
            string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
            var db = new SQLiteConnection(_dbpath);
            db.CreateTable<cocktails>();

            var maxPK = db.Table<cocktails>().OrderByDescending(c => c.Id).FirstOrDefault();


            readExcel();



              // DisplayAlert(null, "succesfully registered: " + name, "OK");


        }
        public static void readExcel()
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            string resourcePath = "/Assets/Cocktails.xlsx";
            //"App" is the class of Portable project.
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;

            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Opens the workbook
            IWorkbook workbook = application.Workbooks.Open(fileStream);

        }
//        Tell me, doctor, where are we going this time
//        Is this the 50's, or 1999
//        All I wanted to do, was play my guitar and sing
//        So take me away, I don't mind
//        But you better promise me, I'll be back in time
//        Gotta get back in time
//        Don't bet your future, on one roll of the dice
//        Better remember, lightning never strikes twice
//        Please don't drive at eighty eight, don't want to be late again
//        So take me away, I don't mind
//        But you better promise me, I'll be back in time
//        Gotta get back in time
//        Gotta get back in time
//        Get me back in time
//        Gotta get back in time
//        Gotta get back in time
//        Get back, get back
//        Get back Marty
//        Gotta get back in time
//        Gotta get back in time
//        Get back, get back
            }
}
