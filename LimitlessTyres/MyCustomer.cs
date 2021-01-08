using LimitlessTyres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitlessTyres
{
    class MyCustomer
    {

        private int customerNo;
        private string companyName, customerType, surname, forename, street, town, county, postcode, contactNo;

        public MyCustomer()
        {

            this.customerNo = 0;
            this.companyName = ""; this.customerType = ""; this.surname = ""; this.forename = ""; this.street = ""; this.town = ""; this.county = "";
            this.postcode = ""; this.contactNo = "";

        }

        public MyCustomer(int customerNo, string companyName, string customerType, string surname, string forename, string street,
            string town, string county, string postcode, string contactNo)
        {

            this.customerNo = customerNo;
            this.companyName = companyName; this.customerType = customerType; this.surname = surname; this.forename = forename; this.street = street; this.town = town; this.county = county;
            this.postcode = postcode; this.contactNo = contactNo;

        }

        public int CustomerNo
        {

            get { return customerNo; }
            set { customerNo = value; }

        }

        public string CompanyName
        {
            get { return companyName; }
            set
            {
                if (MyValidation.validLength(value, 2, 15) && MyValidation.validLetter(value))

                {
                    companyName = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Company Name must be 2-20 letters");
            }
        }

        public string CustomerType
        {

            get { return customerType; }
            set
            {
                if (MyValidation.validLength(value, 2, 15) && MyValidation.validLetter(value))

                {
                    customerType = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Customer Type must be 2-20 letters");
            }

        }


        public string Surname
        {

            get { return surname; }
            set
            {
                if (MyValidation.validLength(value, 2, 15) && MyValidation.validSurname(value))

                {
                    surname = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Surname must be 2-15 letters");
            }
        }

        public string Forename
        {

            get { return forename; }
            set
            {
                if (MyValidation.validLength(value, 2, 15) && MyValidation.validForename(value))
                {
                    forename = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Forename must be 2-15 letters");

            }
        }

        public string Street
        {

            get { return street; }
            set
            {
                if (MyValidation.validLength(value, 5, 40) && MyValidation.validLetterNumberWhitespace(value))
                {
                    street = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Street must be 5-40 letters");

            }
        }

        public string Town
        {

            get { return town; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validLetterWhitespace(value))
                {
                    town = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Town must be 2-20 letters");

            }
        }

        public string County
        {

            get { return county; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validLetter(value))
                {
                    county = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("County must be 2-20 letters");

            }
        }

        public string Postcode
        {

            get { return postcode; }
            set
            {
                if (MyValidation.validLength(value, 7, 8) && MyValidation.validLetterNumberWhitespace(value))
                {
                    postcode = MyValidation.EachLetterToUpper(value);
                }
                else
                    throw new MyException("Postcode must be 7-8 letters and alphanumeric only");

            }
        }

        public string ContactNo
        {

            get { return contactNo; }
            set
            {
                if (MyValidation.validLength(value, 11, 15) && MyValidation.validNumber(value))
                {
                    contactNo = value;
                }
                else
                    throw new MyException("Contact number must be 1-15 digits");

            }
        }


    }
}
