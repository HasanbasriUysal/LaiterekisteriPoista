using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTest
{
    public class Computer
    {
        string nimi;
        double hinta;
        int ram;
        int fdd;

        public string Nimi { get { return nimi; } set { nimi = value; } }
        public double Hinta { get { return hinta; } set { hinta = value; } }
        public int Ram {  get { return ram; } set {  ram = value; } }
        public int Fdd { get { return fdd; } set { fdd = value; } }

        public Computer(string nimi, double hinta, int ram, int fdd) 
        {
            this.nimi = nimi;
            this.hinta = hinta; 
            this.ram = ram; 
            this.fdd = fdd; 

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer("Opekone", 540.00d, 16, 500);

          // Create a formatted string to insert object properties as values to a table using SQL  
          string sqlString = $"INSERT INTO dbo.esimtaulu (Nimi, Hinta, Ram, Fdd VALUES ('{computer.Nimi}', {computer.Hinta},{computer.Ram}, {computer.Fdd})";
            Console.WriteLine(sqlString);
            Console.ReadLine();
        }
    }
}
