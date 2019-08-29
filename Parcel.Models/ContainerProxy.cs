
using ParcelDelivery.Models.Interfaces;


namespace ParcelDelivery.Models
{
    public partial class Parcel : IParcel
    {
        public bool NeedSignOff { get; set; }
        public Departments Department { get; set; }

        public T_Sender Sender { get; set; }

        public Receipient Receipient { get; set; }

        public decimal Weight { get; set; }

        public decimal Value { get; set; }
    }

    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Company))]
    public partial class T_Sender
    {

        private string nameField;

        private Address addressField;

        private int ccNumberField;

        private bool ccNumberFieldSpecified;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public Address Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public int CcNumber
        {
            get
            {
                return this.ccNumberField;
            }
            set
            {
                this.ccNumberField = value;
            }
        }

        /// <remarks/>
        public bool CcNumberSpecified
        {
            get
            {
                return this.ccNumberFieldSpecified;
            }
            set
            {
                this.ccNumberFieldSpecified = value;
            }
        }
    }

    public partial class Address
    {

        private string streetField;

        private sbyte houseNumberField;

        private string postalCodeField;

        private string cityField;

        /// <remarks/>
        public string Street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        public sbyte HouseNumber
        {
            get
            {
                return this.houseNumberField;
            }
            set
            {
                this.houseNumberField = value;
            }
        }

        /// <remarks/>
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }
    }

    public partial class Company : T_Sender
    {
    }

    public partial class Receipient
    {

        private string nameField;

        private Address addressField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public Address Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }
    }

    public partial class parcels
    {

        private Parcel[] parcelField;

        public Parcel[] Parcel
        {
            get
            {
                return this.parcelField;
            }
            set
            {
                this.parcelField = value;
            }
        }
    }

    public partial class Container : IContainer
    {
        
        private int idField;

        public System.DateTime shippingDateField { get; set; }

        public Parcel[] parcels { get; set; }

        /// <remarks/>
        public int Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public System.DateTime ShippingDate
        {
            get
            {
                return this.shippingDateField;
            }
            set
            {
                this.shippingDateField = value;
            }
        }
    }
}