// just for ease of submission, I wrote them in one file.

using System.Diagnostics;

namespace ConsoleApp1
{
    public interface IPersonService
    {
        int CalculateAge();
        decimal CalculateSalary();
        List<string> GetAddresses();
        void AddAddress(string address);
    }

    public interface IStudentService : IPersonService
    {
        double CalculateGPA();
        void EnrollInCourse(Course course);
    }

    public interface IInstructorService : IPersonService
    {
        decimal CalculateBonusSalary();
    }

    public interface ICourseService
    {
        void EnrollStudent(Student student);
        List<Student> GetEnrolledStudents();
    }

    public interface IDepartmentService
    {
        void AddCourse(Course course);
        List<Course> GetOfferedCourses();
    }

    public abstract class Person : IPersonService
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        private decimal _salary;
        private List<string> Addresses = new();

        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0) throw new ArgumentException("Salary cannot be negative");
                _salary = value;
            }
        }

        public Person(string name, DateTime dob, decimal salary)
        {
            Name = name;
            DateOfBirth = dob;
            Salary = salary; 
        }

        public int CalculateAge()
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }

        public virtual decimal CalculateSalary()
        {
            return Salary;
        }

        public void AddAddress(string address)
        {
            Addresses.Add(address);
        }

        public List<string> GetAddresses()
        {
            return Addresses;
        }
    }

    public class Course : ICourseService
    {
        public string Name { get; set; }
        private List<Student> EnrolledStudents = new();

        public Course(string name)
        {
            Name = name;
        }

        public void EnrollStudent(Student student)
        {
            EnrolledStudents.Add(student);
        }

        public List<Student> GetEnrolledStudents()
        {
            return EnrolledStudents;
        }
    }

    public class Student : Person, IStudentService
    {
        private List<(Course course, string grade)> Courses = new();

        public Student(string name, DateTime dob, decimal salary) : base(name, dob, salary) { }

        public void EnrollInCourse(Course course)
        {
            Courses.Add((course, " "));
            course.EnrollStudent(this);
        }

        public double CalculateGPA()
        {
            double totalPoints = 0;
            int totalCourses = Courses.Count;

            foreach (var (course, grade) in Courses)
            {
                totalPoints += grade switch
                {
                    "A" => 4.0,
                    "A-" => 3.7,
                    "B+" => 3.3,
                    "B" => 3.0,
                    "B-" => 2.7,
                    "C+" => 2.3,
                    "C" => 2.0,
                    "C-" => 1.7,
                    "D+" => 1.3,
                    "D" => 1.0,
                    "D-" => 0.7,
                    "F" => 0.0,
                    _ => 0.0
                };
            }

            return totalCourses > 0 ? totalPoints / totalCourses : 0.0;
        }

        public void AssignGrade(Course course, string grade)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].course == course)
                {
                    Courses[i] = (course, grade);
                    break;
                }
            }
        }

        public class Department : IDepartmentService
        {
            public string Name { get; set; }
            public Instructor Head { get; set; }
            public decimal Budget { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            private List<Course> OfferedCourses = new();

            public Department(string name, decimal budget, DateTime start, DateTime end, Instructor head)
            {
                Name = name;
                Budget = budget;
                StartDate = start;
                EndDate = end;
                Head = head;
            }

            public void AddCourse(Course course)
            {
                OfferedCourses.Add(course);
            }

            public List<Course> GetOfferedCourses()
            {
                return OfferedCourses;
            }
        }

        public class Instructor : Person, IInstructorService
        {
            public Department Department { get; set; }
            public DateTime JoinDate { get; set; }

            public Instructor(string name, DateTime dob, decimal salary, DateTime joinDate)
                : base(name, dob, salary)
            {
                JoinDate = joinDate;
            }

            public decimal CalculateBonusSalary()
            {
                int yearsOfExperience = DateTime.Now.Year - JoinDate.Year;
                return yearsOfExperience * 800;
            }
            public override decimal CalculateSalary()
            {
                return base.CalculateSalary() + CalculateBonusSalary();
            }
        }
        public class OOP
        {
            static void Main(string[] args)
            {
                Instructor instructor = new Instructor("Dr. Jiang", new DateTime(1980, 5, 15), 80000, new DateTime(2010, 6, 1));

                Department csDepartment = new Department("Computer Science", 500000, DateTime.Now.AddMonths(-6), DateTime.Now.AddMonths(6), instructor);

                Course course1 = new Course("Data Structures and Algorithms");
                Course course2 = new Course("Introduction to Computer Science");

                csDepartment.AddCourse(course1);
                csDepartment.AddCourse(course2);

                Student student = new Student("Runkai", new DateTime(1998, 4, 24), 0);
                student.EnrollInCourse(course1);
                student.EnrollInCourse(course2);

                student.AssignGrade(course1, "A");
                student.AssignGrade(course2, "B+");

                Console.WriteLine($"Student: {student.Name}, GPA: {student.CalculateGPA():F2}");
                Console.WriteLine($"Professor: {instructor.Name}, Salary: {instructor.CalculateSalary()}");
            }

        }

    }

}
