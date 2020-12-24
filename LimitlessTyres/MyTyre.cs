using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitlessTyres
{
    class MyTyre
    {
        private int supplierID, qtyInStock;
        private string tyreID, tyreTypeCode, tyreDesc;
        private double tyrePrice;

        public MyTyre()
        {
            this.tyreID = "";
            this.tyreTypeCode = "";
            this.supplierID = 0;
            this.tyreDesc = "";
            this.tyrePrice = 0;
            this.qtyInStock = 0;
        }

        public MyTyre(String tyreID, String tyreTypeCode, int supplierID, string tyreDesc, double tyrePrice, int qtyInStock)
        {
            this.tyreID = tyreID;
            this.tyreTypeCode = tyreTypeCode;
            this.supplierID = supplierID;
            this.tyreDesc = tyreDesc;
            this.tyrePrice = tyrePrice;
            this.qtyInStock = qtyInStock;
        }

        public string TyreID
        {
            get { return tyreID; }
            set
            {
                if (MyValidation.validLength(value, 11, 11) && MyValidation.validTyreID(value))
                    tyreID = MyValidation.EachLetterToUpper(value);

                else
                    throw new MyException("Please provide a width, profile, diameter and speed rating.");
            }
        }

        public string TyreTypeCode
        {
            get { return tyreTypeCode; }
            set 
            {
                if (MyValidation.validLetterNumber(value))
                    tyreTypeCode = MyValidation.EachLetterToUpper(value);
                else
                    throw new MyException("Please provide a tyre type.");
            }
        }

        public int SupplierID
        {
            get { return supplierID; }
            set 
            {
                if (MyValidation.validNumber(Convert.ToString(value)) && value>0)
                    supplierID = value;
                else
                    throw new MyException("Please provide a supplier.");
            }
        }

        public string TyreDesc
        {
            get { return tyreDesc; }
            set {
                if (MyValidation.validLength(value, 2, 40) && MyValidation.validLetterNumberWhitespace(value))
                    tyreDesc = value;
                else
                    throw new MyException("Tyre Description must be 2-40 characters.");
            }
        }

        public double TyrePrice
        {
            get { return tyrePrice; }
            set
            {
                if (MyValidation.validMoney(Convert.ToString(value)) && value>=0)
                    tyrePrice = value;
                else
                    throw new MyException("Tyre Price must be a number, and not be negative.");
            }
        }

        public int QtyInStock
        {
            get { return qtyInStock; }
            set {
                if (MyValidation.validNumber(Convert.ToString(value)) && value>=0)
                    qtyInStock = value;
                else
                    throw new MyException("Quantity in stock must be a number.");
            }
        }
    }
}
