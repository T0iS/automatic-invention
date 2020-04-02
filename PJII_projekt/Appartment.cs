using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJII_projekt
{
    class Appartment
    {

        private bool occupied;
        private int? appNumber;
        private int? price;
        private string address;

        public Appartment(int? number, int? price, string address, bool occupied)
        {
            this.occupied = occupied;
            this.appNumber = number;
            this.price = price;
            this.address = address;
        }

        public string DataToString()
        {
            string tmp = isOccupiedText();
            

            string fin = "Byt na adrese: " + this.address.ToString() +
                " s cislem: " + this.appNumber.ToString() + ", cena: "
                + this.price.ToString() + tmp;
            return fin;
        }
        //getters
        public int? getAppNumber()
        {
            return this.appNumber;
        }    
        public int? getPrice()
        {
            return this.price;
        }
        public bool getOccupied()
        {
            return this.occupied;
        }
        public string getAddress()
        {
            return this.address;
        }
        //setters
        public void setAppNumber(int? n)
        {
            this.appNumber = n;
        }
        public void setPrice(int? p)
        {
            this.price = p;
        }
        public void setAddress(string s)
        {
            this.address = s;
        }
        public void setOccupied(bool b)
        {
            this.occupied = b;
        }

        public string isOccupiedText()
        {
            if (this.occupied)
            {
                return " je obsazen";
            }
            else return " neni obsazen";
        }
        public string occupiedTF() {

            if (this.occupied)
            {
                return "true";
            }
            else return "false";
        }
        
    }
}
