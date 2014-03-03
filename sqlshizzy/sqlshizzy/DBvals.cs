using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamsocl
{
    public class DBvals
    {
        private string firstName, lastName, nickName, eMail, passWord;
        private int rosterNumber, uID, tID1, tID2, tID3, tID4;
        private double phoneNumber;
        private bool admin, privacy;

        public DBvals()
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

        public int TID1
        {
            get { return tID1; }
            set { tID1 = value; }
        }

        public int TID2
        {
            get { return tID2; }
            set { tID2 = value; }
        }

        public int TID3
        {
            get { return tID3; }
            set { tID3 = value; }
        }

        public int TID4
        {
            get { return tID4; }
            set { tID4 = value; }
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
