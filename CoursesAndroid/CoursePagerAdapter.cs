using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using CoursesLibrary;

namespace CoursesAndroid
{
    public class CoursePagerAdapter : FragmentStatePagerAdapter
    {
        private CourseManager _courseManager;

        public CoursePagerAdapter(FragmentManager fm, CourseManager courseManager)
            : base(fm)
        {
            this._courseManager = courseManager;
        }

        public override Fragment GetItem(int position)
        {
            _courseManager.MoveTo(position);

            var courseFragment = new CourseFragment();
            courseFragment.Course = _courseManager.Current;

            return courseFragment;
        }

        public override int Count
        {
            get { return _courseManager.Length; }
        }
    }
}