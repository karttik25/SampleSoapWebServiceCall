using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace SampleSoapWebServiceCall
{
    public class SOAPWebCall
    {
        public HttpWebRequest CreateSOAPWebRequest(string SoapReq, string SoapURL)
        {
            //Making Web Request    
            //  HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"https://localhost:44303/WebServiceTest.asmx");
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"http://localhost:61263//"+ SoapURL );

            //SOAPAction    
            Req.Headers.Add(@"SOAPAction:http://tempuri.org/"+SoapReq);
            //Content_type    
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method    
            Req.Method = "POST";
            //return HttpWebRequest    
            return Req;
        }
        public void InvokeServiceHelloWorld()
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest("HelloWorld", "WebService1.asmx");

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            //SOAP Body Request  
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
               <HelloWorld xmlns=""http://tempuri.org/"" /> 
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    //writting stream result on console    
                    Console.WriteLine(ServiceResult);
                   // Console.ReadLine();
                }
            }
        }
        public void InvokeServiceAdd(int a, int b)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest("Addition", "WebService1.asmx");

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            //SOAP Body Request  
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
             <soap:Body>
                <Addition xmlns=""http://tempuri.org/"">
                  <a>" + a + @"</a>
                  <b>" + b + @"</b>
                </Addition>
         </soap:Body> 
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    //writting stream result on console    
                    Console.WriteLine(ServiceResult);
                 //   Console.ReadLine();
                }
            }
        }

    }
}
