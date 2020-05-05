using System;
using System.Collections.Generic;
using System.Text;

namespace PALP.Data
{
    public interface INetworkConnection
    {
        bool isConnected { get; set; }
        void checkNetworkConnection();
    }
}
