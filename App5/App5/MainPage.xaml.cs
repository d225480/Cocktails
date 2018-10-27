using SQLite;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{

	public partial class MainPage : ContentPage
	{


        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public MainPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);




        }
        private  void  login(object sender,EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            db.CreateTable<db>();

            var maxPK = db.Table<db>().OrderByDescending(c => c.Id).FirstOrDefault();


            var table = db.Query<db>("SELECT * FROM db WHERE Name = ?", username.Text);
            bool NameAvailable = true;
            foreach (var s in table)
            {
               if(s.Name == username.Text && s.password == password.Text)
                {
                    NameAvailable = false;
                    Navigation.PushAsync(new dashboard());
                }
               else
                {
                    NameAvailable = false;
                    DisplayAlert(null, "username or password was wrong " , "OK");
                }

            }
            if (NameAvailable == true)
            {
                DisplayAlert(null, "username or password was wrong ", "OK");
            }

            //   Navigation.PushAsync(new view());
        }

   
        private  void registerbutton(object sender, EventArgs e)
        {
           
            
            Navigation.PushAsync(new Register());
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
    }
}
