using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class Persona
    {
        public int[] TIDs = new int[4];
        private string firstName, lastName, nickName, eMail, passWord;
        private int rosterNumber, uID;
        private double phoneNumber;
        private bool admin, privacy;

        public Persona()
        {
            this.firstName = "";
            this.lastName = "";
            this.nickName = "";
            this.eMail = "";
            this.passWord = "";
            this.rosterNumber = 0;
            this.uID = 0;
            this.phoneNumber = 0000000000;
            this.admin = false;
            for( int i = 0; i<=3 ; i++ )
            {
                TIDs[i] = 0;
            }
        }

        public string FName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string NName
        {
            get { return nickName; }
            set { nickName = value; }
        }

        public string EMail
        {
            get { return eMail; }
            set { eMail = value; }
        }

        public string PWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public int RNumber
        {
            get { return rosterNumber; }
            set { rosterNumber = value; }
        }

        public int UID
        {
            get { return uID; }
            set { uID = value; }
        }

        public double PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public bool Privacy
        {
            get { return privacy; }
            set { privacy = value; }
        }

    }
}
