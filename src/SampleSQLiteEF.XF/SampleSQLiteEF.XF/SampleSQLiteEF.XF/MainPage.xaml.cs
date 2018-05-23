using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleSQLiteEF.XF
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            // redmine.sqlite3 をロードする
            _ent = new RedmineModel.RedmineEntities();
            this.lv.ItemsSource = _ent.issues.ToList();
		}

        RedmineModel.RedmineEntities _ent;
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
