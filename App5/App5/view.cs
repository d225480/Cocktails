using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App5
{
	public class view : ContentPage
	{
        private Entry _nameEntry;
        private Entry _addressEntry;
        private Button _saveButton;
        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
		public view ()
		{
            this.Title = "blijkbaar moet dit werken";
            StackLayout stack = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "name  pls";
            stack.Children.Add(_nameEntry);

            _addressEntry = new Entry();
            _addressEntry.Keyboard = Keyboard.Text;
            _addressEntry.Placeholder = "adress  pls";
            stack.Children.Add(_addressEntry);



            Button button = new Button();
            button.Text = "click my please";
       
            stack.Children.Add(button);

            Content = stack;

		}
     
	}
}