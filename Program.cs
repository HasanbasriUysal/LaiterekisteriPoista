using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laitekirjasto

{
    // Yleinen laiteluokka, yliluokka tietokoneille, tableteille ja puhelimille 

    class Device
    {
        // Luodaan kenttä (field) name, esitellään (define) ja annetaan arvo (set initial value)
        string name = "Uusi laite";
        // Luodaan kenttä vastaava ominaisuus (property) Name ja sille asetusmetodi set ja lukumetodi get. Ne voi kirjoittaa joko yhdelle tai useammalle riville
        public string Name { get { return name; } set { name = value;} }

        string purchaseDate = "1.1.1900";
        public string PurchaseDate { get {  return purchaseDate; } set {  purchaseDate = value; } }

        // Huomaa jälkiliite d (suffix)
        double price = 0.0d; 
        public double Price { get { return price; } set { price = value; } }

        int warranty = 12;
        public int Warranty { get {  return warranty; } set {warranty=value; } }

        // Konstruktori eli olionmuodostin (constructor) ilman argumentteja
        public Device() 
        {
        
        }

        // Konstruktori nimi-argumentilla
        public Device(string name)
        { 
            this.name = name;
        }

        // Konstruktori kaikilla argumenteilla 
        public Device(string name, string purchaseDate, double price, int warranty)
        {
            this.name = name;
            this.purchaseDate = purchaseDate;
            this.price = price;
            this.warranty = warranty;
        }


    }

    // Pääohjelman luokka, josta tulee Program.exe
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ohjelman varsinaiset toiminnot tapahtuvat täällä
            // Ohjelma kysyy käyttäjältä tietoja laitteista ja 
            // vastaamalla kysymyksiin tiedot tallennetaan muuttujiin.

            //Luodaan uusi laite Device-luokasta

            Device laite = new Device("Opekone");
            Console.WriteLine("Laitteen nimi on: " + laite.Name);
            Console.WriteLine("Ostopäivä oli: "+ laite.PurchaseDate);

            // Pidetään ikkuna auki, kunnes käyttäjä painaa <enter>
            Console.ReadLine();

        }
    }
}
