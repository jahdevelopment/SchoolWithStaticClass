using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWithStaticClass
{
    public static class School
    {
        public static HashSet<Student> Students = new HashSet<Student>();
        public static HashSet<Course> Courses = new HashSet<Course>();
        public static HashSet<Enrolment> Enrolments = new HashSet<Enrolment>();

        private static int _courseIdCounter = 100;
        private static int _studentIdCounter = 90;
        private static int _enrolmentIdCounter = 1;

        public static Student? GetStudent(int id)
        {
            Student? student = null;

            foreach (Student s in Students)
            {
                if (s.StudentId == id)
                {
                    student = s;
                    break;
                }
            }

            return student;
        }
        public static Course? GetCourse(int id)
        {
            Course? course = null;

            foreach (Course c in Courses)
            {
                if (c.CourseId == id)
                {
                    course = c;
                    break;
                }
            }

            return course;
        }
        public static int CreateStudent(string firstName, string lastName)
        {
            try
            {
                Student newStudent = new Student(_studentIdCounter, firstName, lastName);
                _studentIdCounter++;

                Students.Add(newStudent);

                return newStudent.StudentId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        public static int CreateCourse(string title, int capacity)
        {
            try
            {
                Course newCourse = new Course(_courseIdCounter, title, capacity);
                _courseIdCounter++;

                Courses.Add(newCourse);
                // validate that all properties are unique

                return newCourse.CourseId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        public static void EnrolStudent(int studentId, int courseId)
        {
            Student student = GetStudent(studentId);
            Course course = GetCourse(courseId);

            if (student == null)
            {
                throw new ArgumentException("Error searching student");
            }
            else if (course == null)
            {
                throw new ArgumentException("Error searching course");
            }

            Enrolment newEnrolment = new Enrolment(_enrolmentIdCounter, student, course);

            _enrolmentIdCounter++;

            course.AddEnrolment(newEnrolment);
            student.CurrentEnrolment = newEnrolment;

            HashSet<Enrolment> secondCopy = course.GetEnrolments();

            if (!secondCopy.Contains(newEnrolment))
            {
                throw new Exception("Failed to add enrolment to course list.");
            }
            else if (student.CurrentEnrolment != newEnrolment)
            {
                throw new Exception("Failed to set student's current enrolment");
            }
            else
            {
                Console.WriteLine($"Student {newEnrolment.Student.StudentId} enrolled in course {newEnrolment.Course.Title}.");
            }

            Enrolments.Add(newEnrolment);
        }
    }
}
