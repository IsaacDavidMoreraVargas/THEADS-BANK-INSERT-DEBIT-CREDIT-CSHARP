using System;
using System.IO;
using System.Threading;
using System.Linq;


//universidad estatal a distancia
//Isaac Morera Vargas
//Grupo 1
//cedula 116200798
//San Jose
namespace MORERVAVARGASISAAC_TareaII
{
	class Program
	{
		
		public static void Main(string[] args)
		{

			Thread tread= new Thread(CargarDatosVentana);
			Thread tread2= new Thread(CargarDatosCaja);
            Console.WriteLine("Se iniciara\nDigite enter>>");
            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("----------Canal Ventana iniciado----------"); 
            tread.Start();
            Thread.Sleep(5000);
            Console.WriteLine("----------Canal Ventana Finalizado iniciado----------");
            
            Console.WriteLine("----------Canal Caja iniciado----------"); 
            tread2.Start();
            Thread.Sleep(5000);
            Console.WriteLine("----------Canal Caja Finalizado iniciado----------");

            Console.WriteLine("Para salir\nDigite enter>>");
            Console.ReadKey();
            
		}
		
       static void CargarDatosVentana()
		   {
        	
       	    
        	string archivo ="Prueba.txt";
		    string contenido = String.Empty;
		    double saldo1=0.00;
		    
          
         
                if (File.Exists(archivo))
                      {	
                        contenido = File.ReadAllText(archivo);
                        
                        string [] temporal=contenido.Split('\n', ' ');
                        string [] Ventana= new string[temporal.Length];
                        
                        int b=0, a=0; 
                        	
                        for(a=0; a<temporal.Length;a++)
                        {
                        	string temporalN=" ";
                        	temporalN= temporal[a];
                        	
                        	if(temporalN=="Ventanilla;")
                        	{
                        	   for(b=a; b<temporal.Length; b++)
                                {
                        	   	   Ventana[b]=temporal[a];
                        	   	   a++;
                        	   	   b++;
                        	   	   Ventana[b]=temporal[a];
                        	   	   a++;
                        	   	   b++;
                        	   	   Ventana[b]=temporal[a];
                        	   	   break;
                        	    }
                        	}
                        	

                       }
                        
                        
                        for(a=0; a<temporal.Length;a++)
                        {

                        	try{
                        		string prueba=Ventana[a];
                        		
                        		if(prueba.Contains("."))
                        		{
                        		  prueba= prueba.Replace(".", ",");
                        		}
                        	    
                        		saldo1=Double.Parse(prueba);
                        		Console.WriteLine("+Credito al saldo "+saldo1);
                        		
                        		operacion llamado = new operacion();
                        		llamado.Resultados(saldo1); 
                        		Console.WriteLine("saldo:"+saldo1);
                        		Thread.Sleep(2000);
                        		
                        		
                        	   }catch (Exception f) 
                                   {
                                       Console.WriteLine();
                                   }               
                                               
                        }          

               }else
                   {
                  	   Console.WriteLine("No esta el archivo");
                   } 
                         
        }

       static void CargarDatosCaja()
		   {
       	
			string archivo ="Prueba.txt";
		    string contenido = String.Empty;
            double saldo1=0.00;
 
          
                if (File.Exists(archivo))
                      {
                	
                        contenido = File.ReadAllText(archivo);
                        
                        string [] temporal=contenido.Split('\n', ' ');
                        string [] Caja = new string[temporal.Length];
                        int a=0, c=0;
                        
                         for(a=0; a<temporal.Length;a++)
                         {
                         	
                        	string temporalN=" ";
                        	temporalN= temporal[a];
                        	
                        	
                          if(temporalN=="Cajero;")
                        	{
                        	   for(c=a; c<temporal.Length; c++)
                                {
                        	   	   Caja[c]=temporal[a];
                        	   	   a++;
                        	   	   c++;
                        	   	   Caja[c]=temporal[a];
                        	   	   a++;
                        	   	   c++;
                        	   	   Caja[c]=temporal[a];
                        	   	   break;
                        	    }
                        	
                        	}
                         }
                         
                         
                      for(a=0; a<temporal.Length;a++)
                        {  	
                        	try{
                        		string prueba=Caja[a];
                        		
                        		if(prueba.Contains("."))
                        		{
                        		  prueba= prueba.Replace(".", ",");
                        		}
                        	    
                        	    saldo1=Double.Parse(prueba);
                        	    Console.WriteLine("-Debito al saldo "+saldo1); 
                        	    
                        	    operacion llamado = new operacion();
                                llamado.Resultados(saldo1); 
                                Console.WriteLine("saldo:"+saldo1);

                               Thread.Sleep(2000);                                
                        	    
                        	    
                        	    
                        	    }catch (Exception f) 
                                   {
                                       Console.WriteLine();
                                   }                                 
                         } 
                      
                      
                      
                   }else
                   {
                  	   Console.WriteLine("No esta el archivo");
                   }
 
           }
       
       
   }
	
	
	class operacion
       {
       public double Resultados(double saldo1)
		{	
       	
         	double comodin=saldo1;
         	return comodin;
		}
       }
}