using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rdk.randomuser.Models
{
    public class User
    {
        private string title;
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string gender;
        [JsonProperty("gender")]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string firstname;
        [JsonProperty("first")]
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private string lastname;
        [JsonProperty("last")]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string email;
        [JsonProperty("email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /*********ADDRESS*********/
        private string street;
        [JsonProperty("street")]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        private string city;
        [JsonProperty("city")]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string state;
        [JsonProperty("state")]
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private string postcode;
        [JsonProperty("postcode")]
        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        private string cellphone;
        [JsonProperty("cell")]
        public string Cellphone
        {
            get { return cellphone; }
            set { cellphone = value; }
        }

        private string birthday;
        [JsonProperty("dob")]
        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        
        private string userIcon_URL;
        [JsonProperty("medium")]
        public string UserIcon_URL
        {
            get { return userIcon_URL; }
            set { userIcon_URL = value; }
        }

        public override string ToString()
        {
            return Title + ". " + FirstName + " " + LastName;
        }

        public string GetFullAddress()
        {
            return Street + " " + Postcode + " " + City + ", " + State;
        }
    }
}
