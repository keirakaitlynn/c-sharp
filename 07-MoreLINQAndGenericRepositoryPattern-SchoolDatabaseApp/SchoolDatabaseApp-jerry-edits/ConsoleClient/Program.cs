using DomainModel;
using Mm.BusinessLayer;
using System;
using System.Collections.Generic;

namespace ConsoleClient
{
    class Program
    {
        private static IBusinessLayer businessLayer = new BuinessLayer();

        static void Main(string[] args)
        {
            run();
        }

        /// <summary>
        /// Display the menu and get user selection until exit.
        /// </summary>
        public static void run()
        {
            bool repeat = true;
            int input;

            do
            {
                Menu.displayMenu();
                input = Validator.getMenuInput();

                switch (input)
                {
                    case 0:
                        repeat = false;
                        break;
                    case 1:
                        Menu.clearMenu();
                        addTeacher();
                        break;
                    case 2:
                        Menu.clearMenu();
                        updateTeacher();
                        break;
                    case 3:
                        Menu.clearMenu();
                        removeTeacher();
                        break;
                    case 4:
                        Menu.clearMenu();
                        listTeachers();
                        break;
                    case 5:
                        Menu.clearMenu();
                        listTeacherCourses();
                        break;
                    case 6:
                        Menu.clearMenu();
                        addCourse();
                        break;
                    case 7:
                        Menu.clearMenu();
                        updateCourse();
                        break;
                    case 8:
                        Menu.clearMenu();
                        removeCourse();
                        break;
                    case 9:
                        Menu.clearMenu();
                        listCourses();
                        break;
                    case 10:
                        Menu.clearMenu();
                        listAllTeachersAndCourses();
                        break;
                }
            } while (repeat);
        }

        //CRUD for teachers

        /// <summary>
        /// Add a teacher to the database.
        /// </summary>
        public static void addTeacher()
        {
            Console.WriteLine("Enter a teacher name: ");
            string teacherName = Console.ReadLine();
            Teacher newTeacher = new Teacher() { TeacherName = teacherName };
            newTeacher.EntityState = EntityState.Added;
            businessLayer.AddTeacher(newTeacher);
            Console.WriteLine("{0} has been added to the database.", teacherName);
        }

        /// <summary>
        /// Update the name of a teacher.
        /// </summary>
        public static void updateTeacher()
        {
            Menu.displaySearchOptions();
            int input = Validator.getOptionInput();
            listTeachers();

            //Find by a teacher's name
            if (input == 1)
            {
                Console.WriteLine("Enter a teacher's name: ");
                Teacher teacher = businessLayer.GetTeacherByName(Console.ReadLine());
                if (teacher != null)
                {
                    Console.WriteLine("Change this teacher's name to: ");
                    teacher.TeacherName = Console.ReadLine();
                    teacher.EntityState = EntityState.Modified;
                    businessLayer.UpdateTeacher(teacher);
                }
                else
                {
                    Console.WriteLine("Teacher does not exist.");
                }
            }
            //find by a teacher's id
            else if (input == 2)
            {
                int id = Validator.getId();
                Teacher teacher = businessLayer.GetTeacherById(id);
                if (teacher != null)
                {
                    Console.WriteLine("Change this teacher's name to: ");
                    teacher.TeacherName = Console.ReadLine();
                    teacher.EntityState = EntityState.Modified;
                    businessLayer.UpdateTeacher(teacher);
                }
                else
                {
                    Console.WriteLine("Teacher does not exist.");
                }
            }
        }

        /// <summary>
        /// Remove a teacher from the database.
        /// </summary>
        public static void removeTeacher()
        {
            listTeachers();
            int id = Validator.getId();
            Teacher teacher = businessLayer.GetTeacherById(id);
            if (teacher != null)
            {
                Console.WriteLine("{0} has been removed.", teacher.TeacherName);
                teacher.EntityState = EntityState.Deleted;
                businessLayer.RemoveTeacher(teacher);
            }
            else
            {
                Console.WriteLine("Teacher does not exist.");
            }
        }

        /// <summary>
        /// List all teachers in the database.
        /// </summary>
        public static void listTeachers()
        {
            IList<Teacher> teachers = businessLayer.GetAllTeachers();
            foreach (Teacher teacher in teachers)
                Console.WriteLine("Teacher ID: {0}, Name: {1}", teacher.TeacherId, teacher.TeacherName);
        }

        /// <summary>
        /// List the courses of a specified teacher.
        /// </summary>
        public static void listTeacherCourses()
        {
            listTeachers();
            int id = Validator.getId();
            Teacher teacher = businessLayer.GetTeacherById(id);
            if (teacher != null)
            {
                Console.WriteLine("Listing courses for [ID: {0}, Name: {1}]:", teacher.TeacherId, teacher.TeacherName);
                if (teacher.Courses.Count > 0)
                {
                    foreach (Course course in teacher.Courses)
                        Console.WriteLine("Course ID: {0}, Name: {1}", course.CourseId, course.CourseName);
                }
                else
                {
                    Console.WriteLine("No courses for [ID: {0}, Name: {1}]", teacher.TeacherId, teacher.TeacherName);
                }
            }
            else
            {
                Console.WriteLine("Teacher does not exist.");
            }
        }

        //CRUD for courses

        /// <summary>
        /// Add a course to a teacher.
        /// </summary>
        public static void addCourse()
        {
            Console.WriteLine("Enter a course name: ");
            string courseName = Console.ReadLine();

            listTeachers();
            Console.WriteLine("Select a teacher for this course. ");
            int id = Validator.getId();
            Teacher teacher = businessLayer.GetTeacherById(id);

            if (teacher != null)
            {
                //create course
                Course course = new Course()
                {
                    CourseName = courseName,
                    TeacherId = teacher.TeacherId,
                    EntityState = EntityState.Added
                };

                //add course to teacher
                teacher.EntityState = EntityState.Modified;
                foreach (Course c in teacher.Courses)
                    c.EntityState = EntityState.Unchanged;
                teacher.Courses.Add(course);
                businessLayer.UpdateTeacher(teacher);
                Console.WriteLine("{0} has been added to the database.", courseName);
            }
            else
            {
                Console.WriteLine("Teacher does not exist.");
            }
        }

        /// <summary>
        /// Update the name of a course.
        /// </summary>
        public static void updateCourse()
        {
            Menu.displaySearchOptions();
            int input = Validator.getOptionInput();
            listCourses();
            Course course = null;

            //find course by name
            if (input == 1)
            {
                Console.WriteLine("Enter a course's name: ");
                course = businessLayer.GetCourseByName(Console.ReadLine());
            }
            //find course by id
            else if (input == 2)
            {
                course = businessLayer.GetCourseById(Validator.getId());
            }

            // update the course if the course exists
            if (course != null)
            {
                Menu.displayUpdateCourseOptions();
                int ucoInput = Validator.getOptionInput();
                // [1] change name
                if (ucoInput == 1)
                {
                    Console.WriteLine("Change this course's name to: ");
                    course.CourseName = Console.ReadLine();
                    course.EntityState = EntityState.Modified;
                    businessLayer.UpdateCourse(course);
                }
                // [2] change teacher
                else if (ucoInput == 2)
                {
                    // get the current teacher for the course
                    int id = Convert.ToInt32(course.TeacherId);
                    Teacher curTeacher = businessLayer.GetTeacherById(id);
                    Console.WriteLine("Current teacher for the course: ");
                    Console.WriteLine($"Teacher: [ID: {curTeacher.TeacherId}, Name: {curTeacher.TeacherName}]");

                    // get the new teacher selection
                    Console.WriteLine("Change this course's teacher to: ");
                    foreach (Teacher teacher in businessLayer.GetAllTeachers())
                    {
                        // only list the teachers that are different that the current one
                        if (teacher.TeacherId != id)
                        {
                            Console.WriteLine("Teacher ID: {0}, Name: {1}", teacher.TeacherId, teacher.TeacherName);
                        }
                    }
                    course.Teacher = businessLayer.GetTeacherById(Validator.getId());

                    // change the teacher if the selection was valid
                    if (course.Teacher != null && course.Teacher.TeacherId != id)
                    {
                        // update course
                        Console.WriteLine("{0} has been updated.", course.CourseName);
                        course.TeacherId = course.Teacher.TeacherId;
                        course.EntityState = EntityState.Modified;
                        businessLayer.UpdateCourse(course);
                    }
                    else
                    {
                        Console.WriteLine("Not a valid Teacher selection.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Course does not exist.");
            }
        }

        /// <summary>
        /// Remove a course in the database.
        /// </summary>
        public static void removeCourse()
        {
            listCourses();
            int id = Validator.getId();
            Course course = businessLayer.GetCourseById(id);
            if (course != null)
            {
                // TODO: remove course from teacher from database
                Console.WriteLine("{0} has been removed.", course.CourseName);
                course.EntityState = EntityState.Deleted;
                businessLayer.RemoveCourse(course);
            }
            else
            {
                Console.WriteLine("Course does not exist.");
            }
        }

        /// <summary>
        /// List all courses in the database.
        /// </summary>
        public static void listCourses()
        {
            IList<Course> courses = businessLayer.GetAllCourses();
            foreach (Course course in courses)
                Console.WriteLine("Course ID: {0}, Name: {1}", course.CourseId, course.CourseName);
        }

        /// <summary>
        /// List all teachers and courses in the database.
        /// </summary>
        public static void listAllTeachersAndCourses()
        {
            IList<Teacher> teachers = businessLayer.GetAllTeachers();
            foreach (Teacher teacher in teachers)
            {
                Console.WriteLine("Listing courses for [ID: {0}, Name: {1}]:", teacher.TeacherId, teacher.TeacherName);
                int id = Convert.ToInt32(teacher.TeacherId);
                IList<Course> courses = businessLayer.GetCoursesByTeacherId(id);

                if (courses.Count > 0)
                {
                    foreach (Course course in courses)
                        Console.WriteLine("Course: [ID: {0}, Name: {1}]", course.CourseId, course.CourseName);
                }
                else
                {
                    Console.WriteLine("No courses for [ID: {0}, Name: {1}]", teacher.TeacherId, teacher.TeacherName);
                }
            }
        }
    }
}