using Exam70483;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483.MenuCreateAndUseTypes
{
    public class Nulls
    {
        public static void Menu()
        {
            int x = 0;
            do
            {
                /* 
                 * 
                 * Reference Types can represent a non-existent value with a null reference.
                 * Value Types cannot represent null values.
                 * 
                 *  string s = null;    - ok, Nullable type
                 *  int i = null;       - Compile error, value type cannot be null
                 *  
                 *  
                 *  Nullablity for value types introduced in C# 2.0
                 *    Nullable types - int?, double?, bool?, char?, int?
                      https://msdn.microsoft.com/en-us/library/2cf62fcy.aspx
                      Nullable<decimal> result = null     <--- Long form
                      decimal? result = null;             <--- Shorthand form

                      For an example of when you might use a nullable type, consider how an ordinary Boolean variable 
                      can have two values: true and false.There is no value that signifies "undefined".In many programming
                      applications, most notably database interactions, variables can occur in an undefined state.
                      For example, a field in a database may contain the values true or false, but it may also contain
                      no value at all. Similarly, reference types can be set to null to indicate that they are not initialized.
             
                      int? n = null;
            
                      int m1 = n;        // Will not compile.
                      int m2 = (int)n;   // Compiles, but will create an exception if n is null.
                      int m3 = n.Value;  // Compiles, but will create an exception if n is null.

                      Customer customer = null;  <--- An instance of a class can return null, since class is a reference type

                      List<Customer> customerList = null;  <-- List of classes can return null.

                      2 rules of thought on returning NULLS from methods.  
                         1.  Don't do it.  Retuning nulls always requires the calling method to check the return value
                             for Nulls.  If there are any missed it increases the risk there will be a null exception thrown.
                         2.  Always return null anytime the return value is nothing.  So if you are asking for Customers and
                             none are found then you want to return a null.
                    
                     See also Operaters.cs for
                     1. Null Conditional (Ternary) Operator ? :
                     2. Null Coalesce Operator ??
                         // Set y to the value of x if x is not NULL; otherwise
                         // if x==null, set y to -1 else set y to x.
                         // int y = x ?? -1;

                 
                 */
                Console.Clear();
                Console.WriteLine(" Nulls Menu \r ");
                Console.WriteLine(" 0. Creating Null Object using Interface \n ");
                Console.WriteLine(" 1. Create Null Object using Base Class \n ");
                Console.WriteLine(" 2.  \n ");
                Console.WriteLine(" 3.  \n ");
                Console.WriteLine(" 4.  \n ");
                Console.WriteLine(" 5.  \n ");
                Console.WriteLine(" 9.  Quit            \n\n ");
                Console.Write(" Enter Number to execute Routine ");


                int selection;
                selection = Common.readInt("Enter Number to Execute Routine : ", 0, 9);
                switch (selection)
                {
                    case 0:
                        NullsMain();
                        Console.ReadKey();
                        break;
                    case 1:
                        BaseNullsMain();
                        Console.ReadKey();
                        break;
                    case 9:
                        x = 9;
                        break;
                    default:
                        Console.WriteLine(" Invalid Number");
                        break;
                }

            } while (x < 9);
        }
        public static void NullsMain()
        {
            PlayerCharacter sarah = new PlayerCharacter(new DiamondSkinDefence())
            {
                Name = "Sarah"
            };
            PlayerCharacter amrit = new PlayerCharacter(new IronBonesDefence())
            {
                Name = "Amrit"
            };

            //  Creates a Null Reference Exception Error
            // PlayerCharacter gentry = new PlayerCharacter(null)
            // Sending NullDefence solves this issue
            //
            PlayerCharacter gentry = new PlayerCharacter(new NullDefence())
            {
                Name = "gentry"
            };


            sarah.Hit(10);
            amrit.Hit(10);
            gentry.Hit(10);
        }

        public static void BaseNullsMain()
        {
            BPlayerCharacter sarah = new BPlayerCharacter(new BDiamondSkinDefence())
            {
                Name = "Sarah"
            };
            BPlayerCharacter amrit = new BPlayerCharacter(new BIronBonesDefence())
            {
                Name = "Amrit"
            };

            BPlayerCharacter gentry = new BPlayerCharacter(SpecialDefence.Null)
            {
                Name = "gentry"
            };


            sarah.Hit(10);
            amrit.Hit(10);
            gentry.Hit(10);
        }


    } /* End Class Nulls */
    class NullDefence : ISpecialDefence
    {
        public int CalculateDamageReduction(int totaldamage)
        {
            return 0;
        }
    }
    class IronBonesDefence : ISpecialDefence
    {
        public int CalculateDamageReduction(int totaldamage)
        {
            return 5;
        }
    }
    class DiamondSkinDefence : ISpecialDefence
    {
        public int CalculateDamageReduction(int totaldamage)
        {
            return 1;
        }
    }
    class PlayerCharacter
    {
        private readonly ISpecialDefence _specialDefence;
        public PlayerCharacter(ISpecialDefence specialDefence)
        {
            _specialDefence = specialDefence;
        }
        public string Name { get; set; }
        public int Health { get; set; } = 100;
        public void Hit(int damage)
        {
            /* Code no longer needed
             * int damageReduction = 0;
             * if (_specialDefence != null)
             * {
             *    damageReduction = _specialDefence.CalculateDamageReduction(damage);
             * }
             * int totalDamageTaken = damage - damageReduction;
             */

            int totalDamageTaken = damage - _specialDefence.CalculateDamageReduction(damage);
            Health -= totalDamageTaken;
            Console.WriteLine($"{Name}'s has been reduced by {totalDamageTaken} to {Health}");
        }

    }
    class BPlayerCharacter
    {
        private readonly SpecialDefence _specialDefence;
        public BPlayerCharacter(SpecialDefence specialDefence)
        {
            _specialDefence = specialDefence;
        }
        public string Name { get; set; }
        public int Health { get; set; } = 100;
        public void Hit(int damage)
        {
            /* Code no longer needed
             * int damageReduction = 0;
             * if (_specialDefence != null)
             * {
             *    damageReduction = _specialDefence.CalculateDamageReduction(damage);
             * }
             * int totalDamageTaken = damage - damageReduction;
             */

            int totalDamageTaken = damage - _specialDefence.CalculateDamageReduction(damage);
            Health -= totalDamageTaken;
            Console.WriteLine($"{Name}'s has been reduced by {totalDamageTaken} to {Health}");
        }

    }
    public abstract class SpecialDefence
    {
        public abstract int CalculateDamageReduction(int totalDamage);

        public static SpecialDefence Null { get; } = new NullDefence();

        private class NullDefence : SpecialDefence
        {
            public override int CalculateDamageReduction(int totalDamage)
            {
                return 0;
            }
        }
    }
    public class BIronBonesDefence : SpecialDefence
    {
        public override int CalculateDamageReduction(int totaldamage)
        {
            return 5;
        }
    }
    public class BDiamondSkinDefence : SpecialDefence
    {
        public override int CalculateDamageReduction(int totaldamage)
        {
            return 1;
        }
    }

} /* End Namespace */
