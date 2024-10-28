using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    // This Interface represents connections among neurons
    public interface IInputFunction
    {
        // Takes a list of connections describes in the ISynapse interface
        double CalculateInput(List<ISynapse> inputs);
    }
}
