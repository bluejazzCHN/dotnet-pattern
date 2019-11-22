using System;
using System.Linq;

namespace ProxyPatern {
    public abstract class Subject {
        public abstract void DoSomeWork ();
    }
    public class ConcreteSubject : Subject {
        public override void DoSomeWork () {
            Console.WriteLine ("ConcreteSubject.DoSomeWork()");
        }
    }
    public class Proxy : Subject {
        string[] registeredUsers;
        string currentUser;
        Subject cs;
        public Proxy (string currentUser) {
            registeredUsers = new string[] { "Admin", "Rohit", "Sam" };
            this.currentUser = currentUser;
        }

        public override void DoSomeWork () {
            Console.WriteLine ("\nProxy call happening now...");
            Console.WriteLine ("{0} wants to invoke a proxymethod.", currentUser);
            if (registeredUsers.Contains (currentUser)) {

                if (cs == null) {
                    Console.WriteLine ("CS initialed....");
                    cs = new ConcreteSubject ();
                }
                cs.DoSomeWork ();
            } else {
                Console.WriteLine ("Sorry {0}, you do not have access.", currentUser);
            }
        }
    }
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("***Proxy Pattern Demo***\n");
            //Authorized user-Admin
            Proxy px1 = new Proxy ("Admin");
            px1.DoSomeWork ();
            //Unwanted User-Robin
            Proxy px2 = new Proxy ("Robin");
            px2.DoSomeWork ();
            Console.ReadKey ();
        }
    }
}