using System;

namespace chain
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);
            int[] requests = {2,5,14,22,18,3,27,20};
            foreach(int request in requests)
            {
                h1.HandlerRequest(request);
            }
            Console.Read();
        }
    }
    abstract class Handler{
        protected Handler successor;
        public void SetSuccessor(Handler successor){
            this.successor = successor;
        }
        public abstract void HandlerRequest(int request);
    }
    class ConcreteHandler1:Handler{
        public override void HandlerRequest(int request){
            if(request >= 0 && request <10)
            {
                Console.WriteLine("{0}处理请求{1}", this.GetType().Name,request);
            }
            else if (successor != null)
            {
                successor.HandlerRequest(request);
            }
        }
    }
    class ConcreteHandler2:Handler{
        public override void HandlerRequest(int request){
            if(request >= 10 && request <20)
            {
                Console.WriteLine("{0}处理请求{1}", this.GetType().Name,request);
            }
            else if (successor != null)
            {
                successor.HandlerRequest(request);
            }
        }
    }
    class ConcreteHandler3:Handler{
        public override void HandlerRequest(int request){
            if(request >= 20 && request <30)
            {
                Console.WriteLine("{0}处理请求{1}", this.GetType().Name,request);
            }
            else if (successor != null)
            {
                successor.HandlerRequest(request);
            }
        }
    }
    abstract class Manager{
        protected string name;
        protected Manager superior;
        public Manager(string name){
            this.name = name;
        }
        public void SetSuperior(Manager superior){
            this.superior = superior;
        }
        abstract public void RequestApplicaitons(Request request);
    }
}

