namespace TerminateAThreadInCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Example - 1 - Abort()
            //Thread threadObj = new Thread(SomeMethod);
            //threadObj.Start();

            //Console.WriteLine("Thread is Abort");
            //threadObj.Abort();
            #endregion

            #region Example - 2 - Abort(object stateInfo) Method
            try
            {
                Thread threadObj = new Thread(SomeMethod)
                {
                    Name = "Thread1"
                };
                threadObj.Start();
                Thread.Sleep(1000);
                Console.WriteLine("Abort Thread Thread 1");
                threadObj.Abort(100);

                //Waiting for the thread to terminate.
                threadObj.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Thread Abort Exception occured, Message :" + ex.Message);
            }
            finally
            {
                Console.WriteLine("Main thread is terminating.");
                Console.ReadKey();
            }
            
            #endregion

            Console.ReadLine();
        }

        #region Example - 1 - Abort()
        //public static void SomeMethod()
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}
        #endregion

        #region Example - 2 - Abort(object stateInfo) Method
        public static void SomeMethod()
        {
            try
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is Starting");
                for (int i = 1; i <= 100; i++)
                {
                    Console.Write(i + " ");
                    if((i%10)==0)
                    {
                        Console.WriteLine();
                        Thread.Sleep(200);
                    }
                }
                Console.WriteLine($"{Thread.CurrentThread.Name} Exiting Normally");
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is aborted and the code is {ex.ExceptionState}");
            }
        }
        #endregion
        
    }
}