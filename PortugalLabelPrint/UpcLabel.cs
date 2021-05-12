using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

namespace PortugalLabelPrint
{
    class UpcLabel
    {
        
        private readonly string upc;
        public int PosX=0;
        public void SetPos(string a)
        {
            PosX = Convert.ToInt32( a);
        }

        //Функція яка повертає список принтерів
        public List<string> GetAllPrinterList()
        {
            List<string> MyPrinters = new List<string>();
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {

                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                MyPrinters.Add(pkInstalledPrinters);
            }
            return MyPrinters;

        }

        int AddNumber(int a, int b)
        {
            return a+b;
        }

        //Конструктор
        public UpcLabel(string upc)
        {
            this.upc = upc ?? throw new ArgumentNullException("upc");
        }

        //Функція що друкує етикетку з Логотипом (EPL)
        public void PrintLogo(string printerName)
        {
            DateTime thisDay = DateTime.Today;
            StringBuilder sb;

            if (printerName == null)
            {
                throw new ArgumentNullException("printerName");
            }


            //Формування етикетки
            sb = new StringBuilder();
            sb.AppendLine();
            /*
            sb.AppendLine("N");
            sb.AppendLine("Q460,024");
            sb.AppendLine("s2");
            sb.AppendLine("D5");
            sb.AppendLine("ZT");
            sb.AppendLine("JF");
            */
            sb.AppendLine("N");
            sb.AppendLine("S1");
            sb.AppendLine("ZB");
            sb.AppendLine(@"A" + AddNumber(100, PosX) + @",20,0,4,1,1,N,""Date:""");
            sb.AppendLine("A" + AddNumber(100, PosX) + @",20,0,3,1,1,N," + "\"" + thisDay.ToString("d") + "\"");
            sb.AppendLine(@"A" + AddNumber(200, PosX) + @",20,0,4,1,1,N,""Time:""");
            sb.AppendLine("A" + AddNumber(250, PosX) + @",20,0,4,1,1,N," + "\"" + DateTime.Now.ToString() + "\"");
            sb.AppendLine(@"A" + AddNumber(100, PosX) + @",40,0,4,1,1,N,""ORDER:""");
            sb.AppendLine("LO"+AddNumber(100,PosX/2)+ @",70,600,5"); 
           
            
            /*
            sb.AppendLine("^XA");
            sb.AppendLine("^LRY");
            sb.AppendLine("^FO240,20^AS^FD LOGO^FS");
            sb.AppendLine("^FO0,60^GB640,2,0^FS");
            sb.AppendLine("^FO10,110^AS^FD EMBOSING DATE- DATA/GODZ ^FS");
            sb.AppendLine("^FO10,1100^AS^FD");
            sb.AppendLine(thisDay.ToString("d") + DateTime.Now.ToString("h:mm:ss tt") + "^FS");
            sb.AppendLine("^FO10,190^AS^FD INSPECTION DATE ^FS");
            sb.AppendLine("^FO10,230^AS^FD DATA/ GODZINA/ PODPIS ^FS");
            sb.AppendLine("^FO10,300^AC^FD" + thisDay.ToString("d") + "^FS");
            sb.AppendLine("^XZ");*/
            sb.AppendLine("P1");
            sb.AppendLine("ZB");
            Console.WriteLine(sb.ToString());
            RawPrinterHelper.SendStringToPrinter(printerName, sb.ToString());
        }

        //Друк етикетки контролю
        public void PrintBlank(string printerName)
        {
            StringBuilder sb;
            sb = new StringBuilder();
            sb.AppendLine("N");

            sb.AppendLine("S10");
            sb.AppendLine("ZB");
            //sb.AppendLine(@"A" + AddNumber(150, PosX) + @",10,0,4,1,2,N," + "\"" + "test" + "\"" + "");
            //sb.AppendLine(@"A" + AddNumber(300, PosX) + @",10,0,4,1,2,N," + "\"" + Article + "\"" + "");
            //sb.AppendLine(@"A" + AddNumber(300, PosX) + @",80,0,4,1,2,N," + "\"" + Quantity + "st" + "\"" + "");
            //sb.AppendLine("LO10,10,6,100");
            //sb.AppendLine("LO" + @"10,0,500,5");
            /*sb.AppendLine(@"A" + AddNumber(150, PosX) + @",150,0,4,1,1,N,""Allowed to do logotype:""");
            DateTime date1 = DateTime.Now;
            date1=date1.AddMinutes(5);
            sb.AppendLine("A" + AddNumber(150, PosX) + @",175,0,4,1,1,N," + "\"" +"min:"+ date1.ToString("HH:mm") + "\"");
            date1 = date1.AddMinutes(20);
            sb.AppendLine("A" + AddNumber(400, PosX) + @",175,0,4,1,1,N,"  + "\"" + "max:" + date1.ToString("HH:mm") + "\"");
            */

            //sb.AppendLine("LO" + AddNumber(100, PosX / 2) + @",70,600,5");


            /*
            sb.AppendLine("^XA");
            sb.AppendLine("^LRY");
            sb.AppendLine("^FO240,20^AS^FD LOGO^FS");
            sb.AppendLine("^FO0,60^GB640,2,0^FS");
            sb.AppendLine("^FO10,110^AS^FD EMBOSING DATE- DATA/GODZ ^FS");
            sb.AppendLine("^FO10,1100^AS^FD");
            sb.AppendLine(thisDay.ToString("d") + DateTime.Now.ToString("h:mm:ss tt") + "^FS");
            sb.AppendLine("^FO10,190^AS^FD INSPECTION DATE ^FS");
            sb.AppendLine("^FO10,230^AS^FD DATA/ GODZINA/ PODPIS ^FS");
            sb.AppendLine("^FO10,300^AC^FD" + thisDay.ToString("d") + "^FS");
            sb.AppendLine("^XZ");*/
            sb.AppendLine("P1");
            sb.AppendLine("ZB");
            RawPrinterHelper.SendStringToPrinter(printerName, sb.ToString());

        }
        public void Print(string printerName, string Article, string Quantity, int size, string Batch)
        { 
            StringBuilder sb;

            if (printerName == null)
            {
                throw new ArgumentNullException("printerName");
            }


            sb = new StringBuilder();

            sb.AppendLine(@"A" + AddNumber(300, size) + @",5,0,4,1,2,N,"+ "\"" + Article + "\"" + "");
            sb.AppendLine(@"A" + AddNumber(300, size) + @",45,0,4,1,2,N," + "\"" + Quantity + "st"+"\"" + "");
            sb.AppendLine(@"B" + AddNumber(150, size) + @",80,0,1,3,2,70,B," + "\"" + Batch + "st" + "\"" + "");
            sb.AppendLine();
            sb.AppendLine("P1");
            sb.AppendLine("ZB");
            Console.WriteLine(sb.ToString());
            RawPrinterHelper.SendStringToPrinter(printerName, sb.ToString());
        }
    }
}
