using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesLibrary
{
    public class CourseManager
    {
        private readonly Course[] _courses;
        private int currentIndex;
        private readonly int lastIndex;

        public CourseManager()
        {
            this._courses = InitCourses();
            lastIndex = _courses.Length - 1;
        }

        private Course[] InitCourses()
        {
            var initCourses = new Course[] {
                new Course()
                { 
                    Title = "Android for .NET Developers",
                    Description = "Provides an overview of the tools used in the Android " + 
                    "development process including the newly released Android Studio.",
                    Image = "ps_top_card_01"
                },

                new Course()
                { 
                    Title = "Android Dreams, Widgets, Notifications",
                    Description = "Provide users with a rich and interactive experience " +
                    "without ever requiring them to open your app.",
                    Image = "ps_top_card_02"
                },
                new Course()
                { 
                    Title = "Android Photo/Video Programming",
                    Description = "Learn how to capitalize on the Android camera " + 
                    "within your apps to capture still photos and video.",
                    Image = "ps_top_card_03"
                },
                new Course()
                { 
                    Title = "Android Location-Based Apps",
                    Description = "Cover the wide range of Android location capabilities " +
                    "including determining user location, power management, and " + 
                    "translating location data to human-readable addresses.",
                    Image = "ps_top_card_04"
                }

                
            };

           
            return initCourses;
        }

        public int Length
        {
            get { return _courses.Length; }
        }


        public void MoveFirst()
        {
            currentIndex = 0;
        }

        public void MovePrev()
        {
            if (currentIndex > 0)
                --currentIndex;
        }

        public void MoveNext()
        {
            if (currentIndex < _courses.Length - 1)
                ++currentIndex;
        }

        public void MoveTo(int position)
        {
            if(position >= 0 && position <= lastIndex)
                currentIndex = position;
            else
            {
                throw new IndexOutOfRangeException(string.Format("{0} is an invalid position", position));
            }

        }

        public Course Current
        {
            get { return _courses[currentIndex]; }
        }

        public bool CanMovePrev 
        {
            get { return currentIndex > 0; }
        }

        public bool CanMoveNext
        {
            get { return currentIndex < _courses.Length -1; }
        }

    }

}
