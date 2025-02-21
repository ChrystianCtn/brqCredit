using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brqCredit.Application.Interface
{
    public interface ITrade
    {
        public double Value { get;  }
        public string ClientSector { get;  }
        public DateTime NextPaymentDate { get;  }
    }
}
