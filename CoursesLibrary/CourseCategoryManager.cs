using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesLibrary
{
    public class CourseCategoryManager
    {
        private readonly CourseCategory[] categories;
        private int currentIndex = 0;
        private readonly int lastIndex;

        public CourseCategoryManager()
        {
            categories = InitCategories();
            lastIndex = categories.Length - 1;
        }

        private CourseCategory[] InitCategories()
        {
            var initCategories = new CourseCategory[] {
                new CourseCategory()
                {
                    Title = "Android",
                    Description = "Android programming courses"
                },
                new CourseCategory()
                {
                    Title = "iOS",
                    Description = "iOS programming courses"
                },
                new CourseCategory()
                {
                    Title = "Windows Phone",
                    Description = "Windows Phone programming courses"
                }
            };

            return initCategories;
        }

        public int Length
        {
            get { return categories.Length; }
        }

        public void MoveFirst()
        {
            currentIndex = 0;
        }

        public void MoveNext()
        {
            if (currentIndex < lastIndex)
                ++currentIndex;
        }

        public void MoveTo(int position)
        {
            if (position >= 0 && position <= lastIndex)
                currentIndex = position;
            else
                throw new IndexOutOfRangeException(
                    String.Format("{0} is an invalid position. Position must be between 0 and {1}",
                    position, lastIndex));

        }

        public CourseCategory Current
        {
            get { return categories[currentIndex]; }
        }

        public Boolean CanMoveNext
        {
            get { return currentIndex < lastIndex; }
        }


    }
}
