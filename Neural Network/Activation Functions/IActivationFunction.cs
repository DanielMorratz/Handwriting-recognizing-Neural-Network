using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    public interface IActivationFunction
    {
        public double CalculateOutput(double input);
    }
}
