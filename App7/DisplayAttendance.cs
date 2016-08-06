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
using System.IO;
using SQLite;

namespace hr.AEON
{
    [Activity(Label = "DisplayAttendance")]
    public class DisplayAttendance : Activity
    {
        //public ArrayAdapter<clockin> attListAdapter { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.DisplayAttendance);
            ListView lstview = FindViewById<ListView>(Resource.Id.listView1);

            string dbPath = Path.Combine(
                     System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                     "attendance.db3");

            //create the db cursor
            var db = new SQLiteConnection(dbPath);
            //var items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            List<string> items = new List<string>();
            var  clockinTable = db.Table<clockin>();
            //var index = 1;
            foreach (var s in clockinTable)
            {
                items.Add(s.staffid + "/" + s.clockInTime.ToString("h:mm:ss tt"));
                
            }

            var itemListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            //var attListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, clockinTable);


            lstview.Adapter = itemListAdapter;
        }
    }
}