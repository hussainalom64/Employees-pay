using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace OOPTask1
{
    public class Program
    {
        public class Employee
        {
            private string surname;
            private string nationalInsurance;
            protected double hours;
            protected double rateOfPay;

            public Employee(string sname, string ni, double hours, double rate)
            {
               this.surname = sname;
               this.nationalInsurance = ni;
                if (hours <= 48)
                { this.hours = hours; }
                else
                { this.hours = 48;}
                if (rate >= 10.50)
                { this.rateOfPay = rate; }
                else
                {
                    this.rateOfPay = 10.50;
                }

            }

            public double calcPay()
            {
                return (hours * rateOfPay);
            }

        }

        public class Sales:Employee //Sales class inherits all the attributes and methods of the Employee class
        {
            private double Comission;

            public Sales(string sname, string ni, double hours, double rate, double comission) : base(sname, ni, hours, rate) 
            {   //using base employee constructur to help create sales object
                if(rate >= 9.00)
                { this.rateOfPay = rate; }
                else
                { this.rateOfPay = 9.00; }
                Comission= comission; //added a new attribute to the sales class
            }

            public double calcPay()
            {
                return (hours * rateOfPay + Comission);
            }
        }

        static void Main(string[] args)
        {
            string inputSurname;
            string inputNationalInsurance;
            double inputHours;
            double inputRateOfPay;
            double pay;
            double inputComission;

            Console.WriteLine("Please enter your surname.");
            inputSurname = Console.ReadLine();

            Console.WriteLine("Please enter your national insurance number.");
            inputNationalInsurance = Console.ReadLine();

            Console.WriteLine("How many hours have you worked this week?");
            inputHours = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("What is your rate of pay?");
            inputRateOfPay = Convert.ToDouble(Console.ReadLine());

            Employee emp = new Employee(inputSurname, inputNationalInsurance, inputHours, inputRateOfPay);
            
            pay = emp.calcPay();
            Console.WriteLine("Your full payment is " + pay);

            Console.WriteLine("What is your comission?");
            inputComission = Convert.ToDouble(Console.ReadLine());
            Sales sales1 = new Sales(inputSurname, inputNationalInsurance, inputHours, inputRateOfPay, inputComission);
            Console.WriteLine("Your payment for a saleman is: " + sales1.calcPay());
        }
    }
}