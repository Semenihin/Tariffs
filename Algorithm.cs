using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pcar21.Models
{
    public class Algorithm
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double day { get; set; }
        public double night { get; set; }
        public double mid { get; set; }
        public double mounth { get; set; }

        public Algorithm()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            String Response = wc.DownloadString("https://www.pes.spb.ru/for_customers/electricity_tariffs/electricity_tariffs_for_st_petersburg/");
            a=Convert.ToDouble(System.Text.RegularExpressions.Regex.Match(Response, @"([0-9]+\,[0-9]+)\n\t\t</td>").Groups[1].Value);
            b=Convert.ToDouble(System.Text.RegularExpressions.Regex.Match(Response, @"([0-9]+\,[0-9]+)\n\t\t</td>").NextMatch().Groups[1].Value);
            c=Convert.ToDouble(System.Text.RegularExpressions.Regex.Match(Response, @"([0-9]+\,[0-9]+)\n\t\t</td>").NextMatch().NextMatch().Groups[1].Value);
            day = 0.63;
            night = 1 - day;
        }

        public void Mid(string str)
        {
            List<double> list = new List<double>();
            string temp="";
            str += " ";
            for(int i=0; i < str.Length; ++i)
            {
                if(str[i]==' ' || str[i] == '\0')
                {
                    if (temp != "")
                    {
                        list.Add(Convert.ToDouble(temp));
                        temp = "";
                    }
                }
                else
                {
                    if (str[i] == '.') { temp+= ','; }
                    else temp += str[i];
                }
            }
            mid=list.Sum() / list.Count();
            mid = list.Average();
        }


        public void Work(double cash)
        {
            mounth=cash/(a*mid-(b*day*mid+c*night*mid));
        }

        public int Year()
        {
            return (int)mounth/12;
        }
        public int Mounth()
        {
            return (int)mounth %12;
        }
    }
}
