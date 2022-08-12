using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HW_15_15._6._6 //реализован метод, который соберет всех учеников всех классов в один список, используя LINQ.
{
    class Program
    {
        static void Main(string[] args)
        {
            var classes = new[]
            {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
           };
            
            // для интереса, чтобы проверить работу, сделала обычный метод:
            var allStudents = GetAllStudents(classes);
            Console.WriteLine("Обычный метод:");
            Console.WriteLine(string.Join(" ", allStudents));
            Console.WriteLine();

            // используя LINQ
            var allStudents1 = GetAllStudents1(classes);
            Console.WriteLine("метод линк:");
            Console.WriteLine(string.Join(" ", allStudents1));
            Console.WriteLine();

            // используя метод расширения
            var allStudents2 = GetAllStudents2(classes);
            Console.WriteLine("метод расширения:");
            Console.WriteLine(string.Join(" ", allStudents2));
            Console.WriteLine();
        }

        /// <summary>
        /// метод, который добавляет в новый список типа ЛИСТ, всех студентов
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        static string[] GetAllStudents(Classroom[] classes)
        {
            var names = new List<string>();          
            foreach (Classroom name in classes)
            {
                foreach (var nam in name.Students)
                {
                    names.Add(nam);                 
                }
            }
            return names.ToArray();
        }

        /// <summary>
        /// метод , с использованием запроса LINQ
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        static string[] GetAllStudents1(Classroom[] classes)
        {
            var namess = from clas in classes
                         from name in clas.Students
                         select name;
            return namess.ToArray();
        }

        /// <summary>
        /// метод расширения,тоже сделала просто так (для сравнения)
        /// </summary>
        /// <param name="classes"></param>
        static string[] GetAllStudents2(Classroom[] classes)
        {
            var names = classes.SelectMany(u => u.Students);
            return names.ToArray();
        }      
    }  
}
