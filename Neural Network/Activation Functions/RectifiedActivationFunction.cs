using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    internal class RectifiedActivationFunction : IActivationFunction
    {
        public double CalculateOutput(double input)
        {
            return Math.Max(0,input);
        }
    }
}
