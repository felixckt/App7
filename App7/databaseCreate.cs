using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;


namespace hr.AEON
{
    [Activity(Label = "databaseCreate")]
    public class databaseCreate : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.database);
            Button btnCreateDB = FindViewById<Button>(Resource.Id.btnCreateDB);
            Button btnDumpDB = FindViewById<Button>(Resource.Id.btnDumpDb);

            string dbPath = Path.Combine(
                     System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                     "attendance.db3");
            



            btnCreateDB.Click += delegate
            {
                //Create db coding here
                Console.WriteLine("Creating database, if it doesn't already exist");
                var db = new SQLiteConnection(dbPath);
                
                db.CreateTable<clockin>();
                if (db.Table<clockin>().Count() != 0)
                {
                    db.DeleteAll<clockin>();
                };
            };

            btnDumpDB.Click += delegate
            {
                var db = new SQLiteConnection(dbPath);
                Console.WriteLine("Reading data");
                var table = db.Table<clockin>();
                foreach (var s in table)
                {
                    Console.WriteLine(s.Id + " " + s.staffid + s.clockInTime.ToString("h:mm:ss tt"));
                }
                db.Close();
            };

        }
    }
}

    