using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laitekirjasto
{
    // LUOKKAMÄÄRITYKSET
    // =================
    
    // Yleinen laiteluokka, yliluokka tietokoneille, tableteille ja puhelimille
    class Device
    {
        // Kentät ja ominaisuudet
        // ----------------------
        
        // Luodaan kenttä (field) name, esitellään (define) ja annetaan arvo (set initial value)
        string name = "Uusi laite";

        // Luodaan kenttää vastaava ominaisuus (property) Name ja sille asetusmetodi set ja lukumetodi get. Ne voi kirjoittaa joko yhdelle tai useammalle riville
        public string Name { get { return name; } set { name = value; } }

        string purchaseDate = "1.1.1900";
        public string PurchaseDate { get { return purchaseDate; } set { purchaseDate = value; } }

        // Huomaa jälkiliite d (suffix)
        double price = 0.0d;
        public double Price { get { return price; } set { price = value; } }

        int warranty = 12;
        public int Warranty { get { return warranty; } set { warranty = value; } }


        string processorType = "N/A";
        public string ProcessorType { get { return processorType; } set { processorType = value; } }

        int amountRAM = 0;
        public int AmountRam { get { return amountRAM; } set { amountRAM = value; } }

        int storageCapacity = 0;
        public int StorageCapacity { get { return storageCapacity; } set { storageCapacity = value; } }

        // Konstruktorit
        // -------------

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

        // Muut metodit
        // ------------

        // Yliluokan metodit
        public void ShowPurchaseInfo()
        {
            // Luetaan laitteen ostotiedot sen kentistä, huom! this
            Console.WriteLine();
            Console.WriteLine("Laitteen hankintatiedot");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Laitteen nimi: " + this.name);
            Console.WriteLine("Ostopäivä: " + this.purchaseDate);
            Console.WriteLine("Hankinta: " + this.price);
            Console.WriteLine("Takuu: " + this.warranty + " kk");
        }

        // Luetaan laitteen yleiset tekniset tiedot ominaisuuksista, huom iso alkukirjain
        public void ShowBasicTechnicalInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Laitteen tekniset tiedot");
            Console.WriteLine("------------------------");
            Console.WriteLine("Koneen nimi: " + Name);
            Console.WriteLine("Prosessori: " + ProcessorType);
            Console.WriteLine("Keskusmuisti: " + AmountRam);
            Console.WriteLine("Levytila: " + StorageCapacity);

        }

        // Lasketaan takuun päättymispäivä, huomaa ISO-standardin mukaiset päivämäärät: vuosi-kuukausi-päivä
        public void CalculateWarrantyEndingDate()
        {
            // Muutetaan päivämäärä merkkijono päivämäärä-kellonaika-muotoon
            DateTime startDate = DateTime.ParseExact(this.PurchaseDate,
                                        "yyyy-MM-dd",
                                         CultureInfo.InvariantCulture);

            // Lisätään takuun kesto
            DateTime endDate = startDate.AddMonths(this.Warranty);

            // Muunnetaan päivämäärä ISO-standardin mukaiseen muotoon
            endDate = endDate.Date;
            
            string isoDate = endDate.ToString("yyyy-MM-dd"); 
            
            Console.WriteLine("Takuu päättyy: " + isoDate);
        }

    }

    // Tietokoneiden luokka, perii ominaisuuksia ja metodeja laiteluokasta Device

    class Computer : Device
    {
        
        // Konstruktorit
        public Computer() : base()
            { }

        public Computer(string name) : base(name)
            { }

        // Muut metodit
        
    }

    // Tablettien luokka, perii laiteluokan
    class Tablet : Device
    {
        // Kentät ja ominaisuudet
        // ----------------------

        string operatingSystem; // Kenttä -> pieni alkukirjain
        public string OperatingSystem { get {  return operatingSystem; } set {  operatingSystem = value; } } // Ominaisuus -> iso alkukirjain
        bool stylusEnabled = false; // Kynätuen kenttä
        public bool StylusEnabled { get {  return stylusEnabled; } set {  stylusEnabled = value; } } // Kynätuki-ominaisuus

        // Konstruktortit
        // --------------

        public Tablet() : base() { }
        
        public Tablet(string name) : base(name) { }


        // Tablet-luokan erikoismetodit
        // ----------------------------
        public void TabletInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Tabletin erityitiedot");
            Console.WriteLine("---------------------");
            Console.WriteLine("Käyttöjärjestelmä: " + OperatingSystem);
            Console.WriteLine("Kynätuki: " + StylusEnabled);
        }

    }
    // Pääohjelman luokka, josta tulee Program.exe
    // ===========================================
    internal class Program
    {
        // Ohjelman käynnistävä metodi
        // ---------------------------
        static void Main(string[] args)
        {
            // Luodaan vektorit ja laskurit niiden alkioille
            Computer[] computers = new Computer[10];
            Tablet[] tablets = new Tablet[10];
            int numberOfComputers = 0;
            int numberOfTablets = 0;

            // Vaihtoehtoisesti luodaan pinot laitteille
            Stack<Computer> computerStack = new Stack<Computer>();


            // Ikuinen silmukka pääohjelman käynnissä pitämiseen
            while (true)
            {
                
                
                Console.WriteLine("Minkä laitteen tietot tallenetaan?");
                Console.Write("1 tietokone, 2 tabletti ");
                string type = Console.ReadLine();

                // Luodaan Switch-Case-rakenne vaihtoehdoille

                switch (type)
                {
                    case "1":

                        // Kysytään käyttäjältä tietokoneen tiedot
                        // ja luodaan uusi tietokoneolio
                        Console.Write("Nimi: ");
                        string computerName = Console.ReadLine();
                        Computer computer = new Computer(computerName);
                        Console.Write("Ostopäivä muodossa vvvv-kk-pp: ");
                        computer.PurchaseDate = Console.ReadLine();
                        Console.Write("Hankintahinta: ");
                        string price = Console.ReadLine();

                        try
                        {
                            computer.Price = double.Parse(price);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen hintatieto, käytä desimaalipilkkua (,)" + ex.Message);

                            break;
                        }

                        Console.Write("Takuun kesto kuukausina: ");
                        string warranty = Console.ReadLine();

                        try
                        {
                           computer.Warranty = int.Parse(warranty);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen takuutieto, vain kuukausien määrä kokonaislukuna " + ex.Message);
                            break;
                        }

                        Console.Write("Prosessorin tyyppi: ");
                        computer.ProcessorType = Console.ReadLine();
                        Console.Write("Keskumuistin määrä (GB): ");
                        string amountRam = Console.ReadLine();

                        try
                        {
                            computer.AmountRam = int.Parse(amountRam);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen muistin määrä, vain kokonaisluvut sallittu " + ex.Message);
                            break;
                        }

                        Console.Write("Tallennuskapasiteetti (GB): ");
                        string storageCapacity = Console.ReadLine();

                        try
                        {
                            computer.StorageCapacity = int.Parse            (storageCapacity);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Virheellinen tallennustilan koko, vain kokonaisluvut sallittu " + ex.Message);
                            break;
                        }

                        

                        // Näytetään olion tiedot metodien avulla
                        computer.ShowPurchaseInfo();
                        computer.ShowBasicTechnicalInfo();

                        try
                        {
                            computer.CalculateWarrantyEndingDate();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ostopäivä virheellinen " + ex.Message);
                            break;
                        }

                        // Lisätään tietokone vektoriin
                        computers[numberOfComputers] = computer;
                        Console.WriteLine("Vektorin indeksi on nyt " + numberOfComputers);
                        numberOfComputers++;  
                        Console.WriteLine("Nyt syötettiin " + numberOfComputers + ". kone");

                        // Vaihtoehtoisesti lisätään tietokone pinoon
                        computerStack.Push(computer);   

                        break;

                    case "2":
                        Console.Write("Nimi: ");
                        string tabletName = Console.ReadLine();
                        Tablet tablet = new Tablet(tabletName);
                        break;


                    default:
                        Console.WriteLine("Virheellinen valinta, anna pelkkä numero");
                        break;
                }

                // Ohelman sulkeminen: poistutaan ikuisesta silmukasta
                Console.WriteLine("Haluatko jatkaa K/e");
                string continueAnswer = Console.ReadLine();
                continueAnswer = continueAnswer.Trim();
                continueAnswer = continueAnswer.ToLower();
                if (continueAnswer == "e")
                {
                    // Vektorissa on se määrä alkioita, jotka sille on alustuvaiheessa annettu
                    Console.WriteLine("Tietokonevektorissa on " + computers.Length + " alkiota");

                    Console.WriteLine("Pinossa on nyt " + computerStack.Count + " tietokonetta");
                    break;
                }
            }


            // Pidetään ikkuna auki, kunnes käyttäjä painaa <enter>
            Console.ReadLine();
        }
    }
}
