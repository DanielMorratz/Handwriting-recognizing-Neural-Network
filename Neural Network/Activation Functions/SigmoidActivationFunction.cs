using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    internal class SigmoidActivationFunction : IActivationFunction
    {
        private double _coefficient; 

        public SigmoidActivationFunction(double coefficient)
        {
            _coefficient = coefficient;
        }
    }
}
