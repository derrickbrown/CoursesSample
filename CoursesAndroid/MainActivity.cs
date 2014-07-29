using System;
using System.Net.Mime;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CoursesLibrary;

namespace CoursesAndroid
{
    //[Activity(Label = "Courses", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
    
        private CourseManager courseManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

        

            courseManager = new CourseManager();
            courseManager.MoveFirst();
            UpdateUI();
        }


        private void ButtonPrevOnClick(object sender, EventArgs eventArgs)
        {
            courseManager.MovePrev();
            UpdateUI();
        }

        private void ButtonNextOnClick(object sender, EventArgs eventArgs)
        {
            courseManager.MoveNext();
            UpdateUI();
          
        }

        private void UpdateUI()
        {

        }

    }
}

