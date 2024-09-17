namespace Day7_iti
{
   public delegate int del(int x, int y);
  public delegate T del2<T,t1,t2>(t1 x, t1 y);
    delegate void mydel(button btn);
    class opertaors
    {
        public static bool boolean()
        {
            return false;
        }

        public static int sum(int x,int y)
        {
            return x + y;
        }
        public static int sub(int x,int y)
        {
            return x - y;
        }
        public static int mult(int x,int y)
        { return x * y; }
    }
    class button
    {
        public string value { set; get; }
        public button(string value)
        {
            this.value = value;
        }

        public event mydel click;
        public void onClick()
        {
            if (click != null)
                click(this);
        }
    }
    class page
    {
        public string name { set; get; }
        public page(string name)
        {
            this.name = name;
        }
        public void display(button btn)
        {
            Console.WriteLine($"this page fired{this.name} when click on this button: {btn.value}");
        }
        //public void subscriber(button btn)
        //{
        //    btn.click += display;
        //}
    }
    internal class Program
    {
        public static void calc(int x,int y,del d)
        {
           Console.WriteLine(   d.Invoke(x,y));
        }
        static void Main(string[] args)
        {
            #region user define
            //del d = new del(opertaors.sum);
            //del d = opertaors.sum;
            //Console.WriteLine(d.Invoke(4, 5));
            //Console.WriteLine(d(4, 5));
            #endregion

            #region calc
            //calc(4, 5, opertaors.sum);
            //calc(4, 5, opertaors.sub);
            #endregion

            #region multi cast
            //del d1 = opertaors.sum;//1
            //d1 += opertaors.sum;//2
            // d1+=opertaors.sub;//3
            //del d2 = opertaors.mult;//4
            //del d3 = d1 + d2;
            //Console.WriteLine(d3.GetInvocationList().Length);
            //Console.WriteLine(d3(4, 5));//20
            //                            //   Console.WriteLine(d1.GetInvocationList().Length);
            //                            //Console.WriteLine(d1(4,5));//-1

            #endregion

            #region generic delegate
            //del2<int,int,int> d = opertaors.sum;
            //Console.WriteLine(d.Invoke(4, 5));
            #endregion

            #region anonyms
            del d = delegate (int x, int y)
            {
                return x + y;
            };
            Console.WriteLine(d(4, 5));
            #endregion

            #region built-in fun
            Func<int, int, int> fun = opertaors.sub;
            // Action<int, int, int> a = opertaors.mult; error:because taking string
            //  Predicate<bool> pre = opertaors.boolean;
            #endregion

            #region Events
            button btn = new button("Button");
            page p = new page("home");
            // p.subscriber(btn);
            btn.click += p.display;
            btn.onClick();
            #endregion
        }
    }
}
