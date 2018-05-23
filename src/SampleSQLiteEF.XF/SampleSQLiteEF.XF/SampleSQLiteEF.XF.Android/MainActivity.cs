using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SampleSQLiteEF.XF.Droid
{
    [Activity(Label = "SampleSQLiteEF.XF", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);


            // 初回だけ redmine.sqlite3 をコピーする
            copyLocal("redmine.sqlite3");


            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }


        /// <summary>
        /// 指定した assets/ファイルをローカルにコピーする
        /// </summary>
        /// <param name="fname"></param>
        private string copyLocal(string fname)
        {
            var st = new System.IO.BinaryReader(this.Resources.Assets.Open(fname));
            var docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var ofname = System.IO.Path.Combine(docs, fname);
            var ofs = System.IO.File.OpenWrite(ofname);
            int DEFAULT_BUFFER_SIZE = 1024 * 4;
            byte[] buf = new byte[DEFAULT_BUFFER_SIZE];
            int n = 0;
            int nn = 0;
            while ((n = st.Read(buf, 0, buf.Length)) > 0)
            {
                ofs.Write(buf, 0, n);
                System.Diagnostics.Debug.WriteLine(string.Format("cnt: {0}", nn));
                nn++;
            }
            ofs.Close();
            st.Close();
            return ofname;
        }
    }
}

