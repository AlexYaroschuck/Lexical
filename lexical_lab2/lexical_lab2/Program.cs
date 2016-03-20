using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexical_lab2
{
    class Program
    {     

        static string ToPostfix(string infix)
        {
            string postfix = " ";
            Stack<Char> stack = new Stack<char>();

            try
            {
                for(int i=0 ; i<infix.Length;i++)
                {
                    var sym = infix[i];
                    if (sym.Equals('+') || sym.Equals('-') || sym.Equals('*') || sym.Equals('/'))
                    {
                        if (stack.Count <= 0)
                            stack.Push(sym);
                        else
                        {
                            if (stack.Peek().Equals('*') || stack.Peek().Equals('/'))
                            {
                                postfix += stack.Pop();
                                i--;
                            }
                            else
                            {
                                if (sym.Equals('+') || sym.Equals('-'))
                                {
                                    postfix += stack.Pop();
                                    stack.Push(sym);
                                }
                                else
                                    stack.Push(sym);
                            }
                        }
                    }
                    else
                        postfix += sym;
                }

                var len = stack.Count;
                for (int i = 0; i < len; i++)
                    postfix += stack.Pop();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error is: " + ex.Message);
                Console.WriteLine("stackTrace is: " + ex.StackTrace);
            }

            return postfix;
        }

        static void IntoFile(string infix,string postix)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Result.txt",true))
                {
                    var inf = "infix form :  " + infix;
                    var post = "postfix from :  " + postix;
                    var line = "--------------------------------";
                    sw.WriteLine(inf);
                    sw.WriteLine(post);
                    sw.WriteLine(line);
                }
            
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error is: " + ex.Message);
                Console.WriteLine("stackTrace is: " + ex.StackTrace);
            }
        }

        static void Main(string[] args)
        {
            var infix = Console.ReadLine();
            var postfix = ToPostfix(infix);
            Console.WriteLine(postfix);
            IntoFile(infix,postfix);
            Console.ReadLine();
        }
    }
}
