using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
  
	public partial class Register : ContentPage
	{
        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public Register ()
		{
			InitializeComponent ();
            
            NavigationPage.SetHasNavigationBar(this, false);
        }
       
        /// <summary>
        /// 
      
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void  registeruser(object sender, EventArgs e)
        {
            if(user.Text != null && password.Text != null && date.Date != null)
            {




             
                var userName = user.Text.Replace(" ", "");
                var passWord = password.Text.Replace(" ", "");
                var datePicker = date.Date;
               checkinputs(userName, passWord, datePicker);
            }
            else
            {
                DisplayAlert(null, "one of the inputs was invalid or empty", "OK");


            }
           
           
            
           

        }

        public void checkinputs(string userName,string passWord,DateTime DatePicker)
        {
           
            if (userName == "" || userName.Length <= 4)
            {
                DisplayAlert(null, "username was either not valid or to short", "OK");
                

            }
            else if (passWord != "")
            {

                if (passWord.Length <= 4)
                {
                    DisplayAlert(null, "password was to short needs to be longer than 5 characters ", "OK");
                   
                }
                else
                {
                    int age = DateTime.Today.Year - DatePicker.Date.Year;
                    if (age < 18)
                    {
                        DisplayAlert(null, "nog niet oud genoeg", "OK");

                       
                    }
                    else
                    {

                     
                        insert(userName, DatePicker.Date.ToString(), passWord );
                        
                    }
                }


            }

            else if (passWord == "")
            {

                DisplayAlert(null, "password was empty ", "OK");
               


            }
         
        }
        private async void insert(string name,string birthdate,string password)
        {
            var db = new SQLiteConnection(_dbpath);
            db.CreateTable<db>();

            var maxPK = db.Table<db>().OrderByDescending(c => c.Id).FirstOrDefault();


            var table = db.Query<db>("SELECT * FROM db WHERE Name = ?", name);
            bool NameAvailable = true;
            foreach (var s in table)
            {
                NameAvailable = false;

            }
            if (NameAvailable == false)
            {
                await DisplayAlert(null, "name is already in use", "OK");
            }
            else
            {


                db dbb = new db()
                {
                    Id = (maxPK == null ? 1 : maxPK.Id + 1),
                    Name = name,
                    birthdate = birthdate,
                    password = password
                };
                db.Insert(dbb);
                Navigation.PushAsync(new dashboard());
                await DisplayAlert(null, "succesfully registered: " + name, "OK");
                
            }

        }
    }
}