

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70483
{
    /*
     *  See also DynamicExamples.cs; BaseExamples.cs
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
     *  are called. We use a static constructor to initialize static fields.  If you were to put the access modifier
     *  of public someone could call the static constructor and we should not be allowing this to be done.
     *  
     *  If something is not going to change on a per object basis, it is wise to make it static.  Note! once you make
     *  it static you can refer to it using the 'this' keyword since it is no longer an instance field.  Instead of
     *  using 'this' you can prefix the field with the name of the class.  Note! static members are invoked using
     *  the name of the class( This differs from instance members, it wouldn't make sense to invoke static member the
     *  same as instance members).
     *  
     *  Static constructors are called before instance constructors.
     *               
     *   https://www.youtube.com/watch?v=cFQLmHCguGs
     *   
     *   Note! - If you remove the Accessor (see ClassHeirarchy.cs) on a class member by default it will be 'private', 
     *   so you cannot access member outside class.   The class itself will be internal if an access modifier
     *   is not declared.
     *   
     *   Interfaces can't have static methods.  A class that implements an interface needs to implement them all
     *   as instance methods.  Static classes can't have instance methods.
     *   
     *   Static verus Constant verus Read-Only
     *   const - Must be assigned a value at declaration and cannot change at a later time.  Const is defined at compile time and
     *           is immutable.  Only primitive or built in types are allowed to be declared as const.  Example string, double.  A 
     *           class you created would not be a primitive or built in type.  Any variable declared as const will implicitily be
     *           declared as static.
     *   static - belongs to the type of the object, rather than an instance of that type.  
     *   readonly - A readonly field is one where assignment to that field can only occur as part of the declaration of the class or in a constructor.
     *              This means that a readonly variable can have different values for different constructors in the same class.   You cannot declare
     *              the field outside of the class.
     *   https://exceptionnotfound.net/const-vs-static-vs-readonly-in-c-sharp-applications/
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
