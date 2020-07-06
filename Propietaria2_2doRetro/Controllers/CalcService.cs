using System;
using System.Linq;

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using System.Xml.Linq;
using System.Collections.Generic;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class CalcService : System.Web.Services.WebService
{
   public CalcService () {
   }
   
   [WebMethod]
   public double Suma(List<double> Sumandos) {
       double total = 0;
       foreach(var d in Sumandos){
           total += d;
        }
        return total;
    }

   [WebMethod]
   public double Resta(double valor, double restando){
       return valor - restando;
   }
    
   [WebMethod]
   public double Multiplicar(double valor, double multiplicador)
   { 
       return valor * multiplicador;
   }
   
   [WebMethod]
   public double Dividir(double dividendo, double divisor)
   { 
       if(divisor == 0) return 0;
       return dividendo / divisor;
   }
}
