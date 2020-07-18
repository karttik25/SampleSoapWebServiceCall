using System;

namespace SampleSoapWebServiceCall
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebServiceTest webService = new WebServiceTest();

            //Console.WriteLine("Output of WebService: " + WebServiceTest.ToString());
            SOAPWebCall obj = new SOAPWebCall();

            #region Call sample Hello world 
            //creating object of program class to access methods    
            Console.WriteLine("Call value from HelloWorld");
            //Calling InvokeService method    
            obj.InvokeServiceHelloWorld();
            #endregion

            #region Call sample Add method 
            //creating object of program class to access methods    

            Console.WriteLine("Please Enter Input values..");
            //Reading input values from console    
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            //Calling InvokeService method    
             obj.InvokeServiceAdd(a,b);
            #endregion
            Console.Read();
        }


    }
}
