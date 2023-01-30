using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWithStaticClass
{
    public class Course
    {
        private int _courseId;
        // readonly -- only define at start
        public int CourseId { get { return _courseId; } }
        private void _setCourseId(int courseId)
        {
            if (courseId > 99)
            {
                _courseId = courseId;
            }
            else
            {
                throw new Exception("Course ID should be number greater than 100");
            }
        }


        private string _title;
        public string Title { get { return _title; } }
        private void _setTitle(string title)
        {
            if (title.Length > 2)
            {
                _title = title;
            }
            else
            {
                throw new Exception("Title should be three or more characters.");
            }
        }


        private int _capacity;
        public int Capacity { get { return _capacity; } }
        private void _setCapacity(int capacity)
        {
            if (capacity > 0)
            {
                _capacity = capacity;
            }
            else
            {
                throw new Exception("Capacity must be greater than zero.");
            }
        }

        // one course contains many students
        private HashSet<Enrolment> _enrolments = new HashSet<Enrolment>();

        public void AddEnrolment(Enrolment enrolment)
        {
            _enrolments.Add(enrolment);
        }
        public HashSet<Enrolment> GetEnrolments()
        {
            // expose a copy of the collection -- and all of the elements on the collection - without exposing the collection itself
            HashSet<Enrolment> setCopy = _enrolments.ToHashSet();
            return setCopy;
        }

        public void RemoveEnrolment(Enrolment enrolment)
        {
            _enrolments.Remove(enrolment);
        }


        public Course(int courseId, string title, int capacity)
        {
            _setCourseId(courseId);
            _setTitle(title);
            _setCapacity(capacity);
        }
    }
}
