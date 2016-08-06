using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite;
using System.IO;

namespace hr.AEON
{
    [Activity(Label = "人事部手提終端", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);
            // Get our button from the layout resource,
            // and attach an event to it
            Button buttonScan = FindViewById<Button>(Resource.Id.MyButton);
            EditText resultText = FindViewById<EditText>(Resource.Id.editText1);
            Button btnCreateDB = FindViewById<Button>(Resource.Id.btnCreateDB);
            Button btnDisplay = FindViewById<Button>(Resource.Id.btnDisplayAttendance);
            string dbPath = Path.Combine(
                     System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                     "attendance.db3");

            //button.Click += delegate {
            //
            //    button.Text = string.Format("{0} clicks!", count++);
            //            };

            buttonScan.Click += async (sender, e) =>
            {

                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
               

                var result = await scanner.Scan();

                if (result != null)
                    Console.WriteLine("Scanned Barcode: " + result.Text);
                    resultText.Text = result.Text;
                    var db = new SQLiteConnection(dbPath);

                    var newClockIn = new clockin();
                    newClockIn.staffid = result.Text;
                    newClockIn.clockInTime = DateTime.Now;
                    db.Insert(newClockIn);
                    db.Close();
                };

            btnCreateDB.Click += delegate {
                StartActivity(typeof(databaseCreate));
            };
            btnDisplay.Click += delegate {
                StartActivity(typeof(DisplayAttendance));
            };

        }
    }
}

