using System.Collections.Generic;

namespace LocationLibrary
{
    internal class DataLayer : IDataLayer
    {
        public List<Client> Clients { get; private set; }

        public DataLayer()
        {
            this.Clients = new List<Client>();
            //Connect à la database...
        }
    }
}