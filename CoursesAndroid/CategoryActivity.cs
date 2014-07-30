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
using CoursesLibrary;

namespace CoursesAndroid
{
    [Activity(Label = "Courses", MainLauncher = true, Icon = "@drawable/icon")]
    public class CategoryActivity : ListActivity
    {

        private CourseCategoryManager _courseCategoryManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _courseCategoryManager = new CourseCategoryManager();
            ListAdapter = 
                new CourseCategoryManagerAdapter(this, 
                    Android.Resource.Layout.SimpleListItem1, 
                    _courseCategoryManager);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {           
            var intent = new Intent(this, typeof(CourseActivity));

            _courseCategoryManager.MoveTo(position);
            string categoryTitle = _courseCategoryManager.Current.Title;

            intent.PutExtra(CourseActivity.DISPLAY_CATEGORY_TITLE_EXTRA, categoryTitle);
            StartActivity(intent);

        }
    }
}