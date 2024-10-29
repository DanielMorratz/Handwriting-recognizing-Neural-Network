using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neural_Network;

namespace Neural_Network
{
    /*workflow: 
     Recieve input values from one or more weighted input connections
     Collect those values
     Do processing and pass them to the activation function
     send those values to the outputs of the neuron
     */
    
    public interface INeuron
    {
        Guid Id { get; }
        double PreviousPartialDerivative { get; set; }
        List <ISynapse> Inputs { get; set; }
        List<ISynapse> Outputs { get; set; }

        void AddInputNeuron(INeuron inputNeuron);
        void AddOutputNeuron(INeuron outputNeuron);
        double CalculateOutput();

        void AddInputSynapse(double inputValue);
        void PushValueOnInput(double inputValue);
    }
}
