using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWithStaticClass
{
    public class Enrolment
    {
        private int _id;
        public int Id { get { return _id; } }


        private Student _student;
        public Student Student { get { return _student; } }


        private Course _course;
        public Course Course { get { return _course; } }

        private int _grade;
        // validate between 0 and 100
        public int Grade
        {
            get { return _grade; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Grade must be set between 0 and 100 inclusive.");
                }
                else
                {
                    _grade = value;
                }
            }
        }

        private DateTime _enrolmentDate;
        public DateTime EnrolmentDate { get { return _enrolmentDate; } }

        public Enrolment(int id, Student student, Course course)
        {
            _id = id;
            _student = student;
            _course = course;

            _enrolmentDate = DateTime.Now;
        }
    }
}
