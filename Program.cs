using SchoolWithStaticClass;

int courseNum = School.CreateCourse("Debugging", 12);
int studentNum = School.CreateStudent("Wavy", "Davy");

try
{
    School.EnrolStudent(studentNum, courseNum);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Add functionality to un-enroll students from courses that removes the enrolment from the Course and the Student BUT keeps the enrolment in the School system

// Use student and course IDs to perform this action

