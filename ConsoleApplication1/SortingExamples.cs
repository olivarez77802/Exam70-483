using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Exam70483
{
    class SortingExamples  // Called by Collections
    {

        public static void Sort_Ascending_Descending()
        {
            Console.WriteLine("Cats listed by name in ASCENDING Order:");
            var temp = new GridSortOptions
            {
                Column = "Name",
                Direction = SortDirection.Ascending
            };
            Print_using_orderby(temp);
            Console.WriteLine("Cats listed by name in DESCENDING Order:");
            var temp2 = new GridSortOptions
            {
                Column = "Name",
                Direction = SortDirection.Descending
            };
            Print_using_orderby(temp2);

            Console.WriteLine("Cats listed by Age in ASCENDING Order:");
            var temp3 = new GridSortOptions
            {
                Column = "Age",
                Direction = SortDirection.Ascending
            };
            Print_using_orderby(temp3);
            Console.WriteLine("Cats listed by Age in DESCENDING Order:");
            var temp4 = new GridSortOptions
            {
                Column = "Age",
                Direction = SortDirection.Descending
            };
            Print_using_orderby(temp4);

        }

        class Employee : IComparable<Employee>
        {
            public int Salary { get; set; }
            public string Name { get; set; }

            public int CompareTo(Employee other)
            {
                // Alphabetic sort if salary is equal. [A to Z]
                if (this.Salary == other.Salary)
                {
                    return this.Name.CompareTo(other.Name);
                }
                // Default to salary sort. [High to low]
                return other.Salary.CompareTo(this.Salary);
            }

            public override string ToString()
            {
                // String representation.
                return this.Salary.ToString() + "," + this.Name;
            }
        }


        public static void Sort_A_Class()
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee() { Name = "Steve", Salary = 10000 });
            list.Add(new Employee() { Name = "Janet", Salary = 10000 });
            list.Add(new Employee() { Name = "Andrew", Salary = 10000 });
            list.Add(new Employee() { Name = "Bill", Salary = 500000 });
            list.Add(new Employee() { Name = "Lucy", Salary = 8000 });

            // Uses IComparable.CompareTo()
            list.Sort();

            // Uses Employee.ToString
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }


        public static void Print_using_orderby(GridSortOptions sort)
        {
            var temp = CommonCollections.IEGetAllCats();
            temp = temp.OrderBy(sort.Column, sort.Direction);
            foreach (CommonCollections.Cat c in temp)
            {
                Console.WriteLine(PrintCats(c));
            }
            Console.ReadKey();
        }




        public static string PrintCats(CommonCollections.Cat c)
        {
            string output = string.Format(
                " - Name: {0}\n - Age {1}\n ",
                c.Name,
                c.Age);

            return output;

        }



    }

    /// <summary>
    /// SortDirection type enum contains Ascending, Descending
    /// </summary>
    public enum SortDirection
    {
        Ascending, Descending
    }


    /// <summary> 
    /// Sorting information for use with the grid. 
    /// </summary> 
    public class GridSortOptions
    {
        public string Column { get; set; }
        public SortDirection Direction { get; set; }
    }

    /// <summary>
    /// Extension methods for sorting.
    /// </summary>
    public static class SortExtensions
    {
        /// <summary>
        /// Jesse Coomment Orders a datasource by a property with the specified name in the specified direction
        /// </summary>
        /// <param name="datasource">The datasource to order</param>
        /// <param name="propertyName">The name of the property to order by</param>
        /// <param name="direction">The direction</param>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> datasource, string propertyName, SortDirection direction)
        {
            return datasource.AsQueryable().OrderBy(propertyName, direction);
        }

        /// <summary>
        /// Orders a datasource by a property with the specified name in the specified direction
        /// </summary>
        /// <param name="datasource">The datasource to order</param>
        /// <param name="propertyName">The name of the property to order by</param>
        /// <param name="direction">The direction</param>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> datasource, string propertyName, SortDirection direction)
        {
            //http://msdn.microsoft.com/en-us/library/bb882637.aspx

            if (string.IsNullOrEmpty(propertyName))
            {
                return datasource;
            }

            var type = typeof(T);
            var property = type.GetProperty(propertyName);

            if (property == null)
            {
                throw new InvalidOperationException(string.Format("Could not find a property called '{0}' on type {1}", propertyName, type));
            }

            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            const string orderBy = "OrderBy";
            const string orderByDesc = "OrderByDescending";

            string methodToInvoke = direction == SortDirection.Ascending ? orderBy : orderByDesc;

            var orderByCall = Expression.Call(typeof(Queryable),
                methodToInvoke,
                new[] { type, property.PropertyType },
                datasource.Expression,
                Expression.Quote(orderByExp));

            return datasource.Provider.CreateQuery<T>(orderByCall);
        }
    }
}
