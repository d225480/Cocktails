using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class dashboard : ContentPage
	{
        public int buttonwidth = 80;

        public dashboard ()
		{
			InitializeComponent ();
           
        NavigationPage.SetHasNavigationBar(this, false);
        }
        public class variabelcell
        {
             public  int buttonwidth = 80;
        }
	}
}