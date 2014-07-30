using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using CoursesLibrary;

namespace CoursesAndroid
{
    [Activity(Label = "Courses")] //, MainLauncher = true, Icon="@drawable/icon")]
    public class CourseActivity : FragmentActivity
    {
        private const String DEFAULT_CATEGORY_TITLE = "Android";
        public const string DISPLAY_CATEGORY_TITLE_EXTRA = "DisplayCategoryTitleExtra";
        private CourseManager _courseManager;
        private CoursePagerAdapter _coursePagerAdapter;
        private ViewPager _viewPager;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            string displayCategoryTitle = DEFAULT_CATEGORY_TITLE;
            Intent startupIntent = this.Intent;
            if (startupIntent != null)
            {
                String displayCategoryTitleExtra =
                    startupIntent.GetStringExtra(DISPLAY_CATEGORY_TITLE_EXTRA);

                if (!string.IsNullOrEmpty(displayCategoryTitleExtra))
                    displayCategoryTitle = displayCategoryTitleExtra;
            }

            SetContentView(Resource.Layout.CourseActivity);
            _courseManager = new CourseManager(displayCategoryTitle);
            _courseManager.MoveFirst();

            _coursePagerAdapter = 
                new CoursePagerAdapter(SupportFragmentManager, _courseManager);

            _viewPager = FindViewById<ViewPager>(Resource.Id.coursePager);
            _viewPager.Adapter = _coursePagerAdapter;
        }
    }
}