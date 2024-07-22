using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
     public class Program
    {
        static void Main(string[] args)
        {
            var onlineCourse = new OnlineCourse { CourseId = 1, Title = "Curso en Línea", tipo = "En Linea" };
            var onsiteCourse = new OnsiteCourse { CourseId = 2, Title = "Curso Presencial", tipo = "Presencial" };
            var hybridCourse = new HybridCourse(3, "Curso Híbrido", onlineCourse, onsiteCourse, "Hibrido");

            var student = new Student { Id = 1, Nombre = "Ramon" };

            List<Course> courses = new List<Course> { onlineCourse, onsiteCourse, hybridCourse };

            foreach (var course in courses)
            {
                course.Subscribe(student);
                Console.WriteLine(course.type());
                Console.WriteLine();
                
            }
            Console.ReadKey();
        }
    }
     public abstract class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string tipo { get; set; }

        public abstract void Subscribe(Student student);
        public abstract string type();
    }
     public class Student
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
     public class OnlineCourse : Course
    {
        public override void Subscribe(Student student)
        {
            Console.WriteLine($"El estudiante {student.Nombre} se ha suscrito al curso en línea {Title}.");
        }

        public override string type()
        {
            return $"Curso: {tipo}";
        }
    }
     public class OnsiteCourse : Course
    {
        public override void Subscribe(Student student)
        {
            Console.WriteLine($"El estudiante {student.Nombre} se ha suscrito al curso presencial {Title}.");
        }

        public override string type()
        {
            return $"Curso: {tipo}";

        }
    }
     public class HybridCourse : Course
    {
        private readonly OnlineCourse _onlineCourse;
        private readonly OnsiteCourse _onsiteCourse;

        public HybridCourse(int courseId, string title, OnlineCourse onlineCourse, OnsiteCourse onsiteCourse, string tipos)
        {
            CourseId = courseId;
            Title = title;
            _onlineCourse = onlineCourse;
            _onsiteCourse = onsiteCourse;
            tipo = tipos;
        }

        public override void Subscribe(Student student)
        {
            Console.WriteLine($"El estudiante {student.Nombre} se ha suscrito al curso híbrido {Title}.");
            _onlineCourse.Subscribe(student);
            _onsiteCourse.Subscribe(student);
        }

        public override string type()
        {
            return $"Curso: {tipo} \n{_onlineCourse.type()} \n{_onsiteCourse.type()}";
        }
    }
}
