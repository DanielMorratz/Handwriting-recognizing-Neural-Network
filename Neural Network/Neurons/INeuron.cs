using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network.Neurons
{
    /*workflow: 
     Recieve input values from one or more weighted input connections
     Collect those values
     Do processing and pass them to the activation function
     send those values to the outputs of the neuron
     */
    
    public interface INeuron
    {
        Guid ID { get; }
        double PreviousPartialDerivate { get; set; }
        List <Isynapse> Inputs { get; set; }
        List<Isynapse> Outputs { get; set; }

        void AddInputNeuron(INeuron inputNeuron);
        void AddOutputNeuron(INeuron outputNeuron);
        double CalculateOutput();

        void AddInputSynapse(double inputValue);
        void PushValueOnInput(double inputValue);
    }
}
