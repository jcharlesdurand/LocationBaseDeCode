using System;
using System.Collections.Generic;
using System.Text;

namespace LocationLibrary
{
    public interface IDataLayer
    {
        List<Client> Clients { get; }

        //.... vehiclues , reservation..
    }
}
