using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    /*
     *  See also DynamicExamples.cs
     * 
     *  Static Fields versus Instance Fields
     *  
     *  Everything defined in a class either Fields, Methods, Properties, ... can be either Instance Members or Static Fields.
     *  If a member of a class does not have static in front of it, it is defined as an Instance Member.
     *  
     *  Important! - Once you make a field static you can no longer refer to the field using the 'this' key.
     *               this is because the 'this' keyword refers to the instance of the class.   You will have to change the 'this'
     *               to prefix it with the name of the class 'Circle._PI'.  Now compare this with what is written about Extension
     *               Methods in Methods.cs (let's see if this throws you for a loop).
     *               
     *   Static members are invoked using the name of the class
     *   Instance Members are invoked using an Object or Instance of the class.
     *   
     *   Static methods can only call other methods that are defined as static.
     *   
     *   Access modifiers are not allowed on Static Constructors 
     *   e.g.  public static Circle()  - not allowed.   By default if you don't specifiy an access modififier by default it is marked private.
     *   Making a static Constructor makes sense when you want to initialize a Static field
     *   
     *  static Circle()
     *  {
     *    Circle._PI = 3.141F;
     *  }
     *  
     *  Static constructors are called only once, no matter how many instances you create.  By default a static constructor cannot have an access
     *  modifier, it is by default private.  You don't have to call a static constructor.  A static constructor are called before instance fields 
     *  are called. We use a static constructor to initialize static fields.
     *  
     *  Static constructors are called before instance constructors.
     *               
     *   https://www.youtube.com/watch?v=cFQLmHCguGs
     *   
     *   Note! - If you remove the Accessor (see ClassHeirarchy.cs) on a class member by default it will be 'private', so you cannot access member outside class.
     */
    class Circle
    {
        /*
         * _PI does not change.  When you have a variable that does not change it is wise to make the variable static
         * 
         * If you don't have static in front of fields then that means the fields are instance fields.
        */
       
       
        // float _PI = 3.141F;
        static float _PI = 3.141F;
                    
        int _Radius;


        /* Constructor
        */
        public Circle(int Radius)
        {
           this._Radius = Radius;
        }

        public static void Print()
        {

        }

        
        public float CalculateArea()
        {
         /*
         * Can't use this._PI if _PI is made static, we have to make it Circle._PI.
        */
            //  return this._PI * this._Radius * this._Radius;
            return Circle._PI * this._Radius * this._Radius;
        }
    }
    class StaticExamples
    {
        public static void Menu()
        {
            /*
             * With Instance fields you will have the below:
             *  C1 -->  _PI = 3.141
             *          _Radius = 5
             *  
             *  C2 -->  _PI = 3.141
             *          _Radius = 6
             *          
             *  It makes more sense to prefix _PI (a constant) with static so there is only one copy of the static field
             * 
             */

            Circle C1 = new Circle(5);
            float Area1 = C1.CalculateArea();
            Console.WriteLine("Area = {0}", Area1);

            Circle C2 = new Circle(6);
            float Area2 = C2.CalculateArea();
            Console.WriteLine("Area = {0}", Area2);

            /*
             * How you call a static method
             */
            Circle.Print();
        }
    }
}
