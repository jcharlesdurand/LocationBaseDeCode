using System;
using System.Linq;

namespace LocationLibrary
{
    public class Location
    {
        private IDataLayer _dataLayer;

        public bool UserConnected { get; private set; }

        public Location()
        {
            /// si on utilisais la librairie au travers d'une application
            this._dataLayer = new DataLayer();
        }

        public Location(IDataLayer dataLayer)
        {
            this._dataLayer = dataLayer;
        }

        public string ConnectUser(string username, string password)
        {
            Client client = this._dataLayer.Clients.SingleOrDefault(_ => _.Username == username);
            if (client == null)
            {
                this.UserConnected = false;
                return "Username not recognized";
            }
            else
            {
                if (client.Password == password)
                {
                    this.UserConnected = true;
                }
                else
                {
                    this.UserConnected = false;
                    return "Incorrect password";
                }
            }

            return "";
        }
    }
}
