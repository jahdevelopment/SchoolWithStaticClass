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
