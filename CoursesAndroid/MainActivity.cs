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
    [Activity(Label = "Courses", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button buttonPrev;
        private Button buttonNext;
        private TextView textTitle;
        private ImageView imageCourse;
        private TextView textDescription;
        private CourseManager courseManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
            buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
            textTitle = FindViewById<TextView>(Resource.Id.textTitle);
            imageCourse = FindViewById<ImageView>(Resource.Id.imageCourse);
            textDescription = FindViewById<TextView>(Resource.Id.textDescription);
   
            buttonPrev.Click += ButtonPrevOnClick;
            buttonNext.Click += ButtonNextOnClick;

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
            textTitle.Text = courseManager.Current.Title;
            textDescription.Text = courseManager.Current.Description;
            imageCourse.SetImageResource(Resource.Drawable.ps_top_card_02);
        }

    }
}

