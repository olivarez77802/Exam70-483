using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JesseTesting.App
{
    class CommonCollections
    {
        public class Cat
        {
            public int Age { get; set; }
            public string Name { get; set; }

        }
        public static List<Cat> GetSomeCats(int number)
        {
            return GetAllCats().Take(number).ToList();
        }
        public static List<Cat> GetAllCats()
        {
            List<Cat> dbcats = new List<Cat>
            {
                new Cat() { Name = "Fluffy", Age = 10 },
                new Cat() { Name = "Sylvester", Age=8},
                new Cat() { Name = "Whiskers", Age=2},
                new Cat() { Name = "Sasha", Age=14 },
                new Cat() { Name = "Furrytail", Age=5},
                new Cat() { Name = "Peaches", Age=4},
                new Cat() { Name = "Sam", Age=10} 

            };
            // returning a List of Cats in Descending Order
            return dbcats.OrderByDescending(ob => ob.Name).ToList();
        }

        public static IEnumerable<Cat> IEGetAllCats()
        {
            List<Cat> dbcats = new List<Cat>
            {
                new Cat() { Name = "Fluffy", Age = 10 },
                new Cat() { Name = "Sylvester", Age=8},
                new Cat() { Name = "Whiskers", Age=2},
                new Cat() { Name = "Sasha", Age=14 },
                new Cat() { Name = "Furrytail", Age=5},
                new Cat() { Name = "Peaches", Age=4},
                new Cat() { Name = "Sam", Age=10} 

            };
            // returning a List of Cats in Descending Order
            return dbcats.ToList();

        }

        public class LogonDTO
        {
            public int EID { get; set; }
            public string IPAddress { get; set; }
            public DateTime LogonTime { get; set; }
        }
        public static List<LogonDTO> GetAllEmployeeLogonHistory(int employeeID)
        {
            return GetAllLogonHistory()
                .Where(lh => lh.EID == employeeID)
                .OrderByDescending(ob => ob.LogonTime).ToList()
                .ToList();
        }
        public static List<LogonDTO> GetAllLogonHistory()
        {
            List<LogonDTO> logons = new List<LogonDTO>()
            {
                new LogonDTO { EID = 1, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 23, 12, 12, 12) },
                new LogonDTO { EID = 1, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 9, 23, 12, 12, 12) },
                new LogonDTO { EID = 1, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 10, 23, 12, 12, 12) },
                new LogonDTO { EID = 1, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 11, 23, 12, 12, 12) },
                new LogonDTO { EID = 1, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 12, 23, 12, 12, 12) },
                new LogonDTO { EID = 2, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 22, 8, 8, 8)    },
                new LogonDTO { EID = 2, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 9, 22, 8, 8, 8)    },
                new LogonDTO { EID = 2, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 10, 22, 8, 8, 8)    },
                new LogonDTO { EID = 2, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 11, 22, 8, 8, 8)    },
                new LogonDTO { EID = 2, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 12, 22, 8, 8, 8)    },
                new LogonDTO { EID = 3, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 22, 8, 8, 8)    },
                new LogonDTO { EID = 3, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 9, 22, 8, 8, 8)    },
                new LogonDTO { EID = 3, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 10, 22, 8, 8, 8)    },
                new LogonDTO { EID = 3, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 11, 22, 8, 8, 8)    },
                new LogonDTO { EID = 3, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 12, 22, 8, 8, 8)    },
                new LogonDTO { EID = 4, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 23, 12, 12, 12) },
                new LogonDTO { EID = 4, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 9, 23, 12, 12, 12) },
                new LogonDTO { EID = 4, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 10, 23, 12, 12, 12) },
                new LogonDTO { EID = 4, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 11, 23, 12, 12, 12) },
                new LogonDTO { EID = 4, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 12, 23, 12, 12, 12) },
                new LogonDTO { EID = 5, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 22, 8, 8, 8)    },
                new LogonDTO { EID = 5, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 9, 22, 8, 8, 8)    },
                new LogonDTO { EID = 5, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 10, 22, 8, 8, 8)    },
                new LogonDTO { EID = 5, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 22, 8, 8, 8)    },
                new LogonDTO { EID = 5, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 9, 22, 8, 8, 8)    },
                new LogonDTO { EID = 5, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 11, 22, 8, 8, 8)    },
                new LogonDTO { EID = 6, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 12, 22, 8, 8, 8)    },
                new LogonDTO { EID = 7, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 23, 12, 12, 12) },
                new LogonDTO { EID = 8, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 22, 8, 8, 8)    },
                new LogonDTO { EID = 9, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 22, 8, 8, 8)    },
                new LogonDTO { EID = 10, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 23, 12, 12, 12) },
            //    new LogonDTO { EID = 11, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 22, 8, 8, 8)   },
                new LogonDTO { EID = 12, IPAddress = "1.1.1.1", LogonTime = new DateTime(2012, 8, 22, 8, 8, 8)    }
            };
            return logons.OrderByDescending(ob => ob.LogonTime).ToList();
        }
    }
}
