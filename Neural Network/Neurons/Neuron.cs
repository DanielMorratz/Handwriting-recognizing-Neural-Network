using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network.Neurons
{
    public class Neuron : INeuron
    {

        private IActivationFunction _activationFunction;
        private IInputFunction _inputFunction; 

        // Input and Output connections of the neuron
        public List<Isynapse> Inputs { get; set; }
        public List<Isynapse> Outputs { get; set; } 

        public Guid Id { get; private set; }

        // Calculated partial derivative in previous iteration of training process
        public double PreviousPartialDerivative { get; set; }

        // Constructor
        public Neuron(IActivationFunction activationFunction, IInputFunction inputFunction)
        {
            Id = Guid.NewGuid();
            Inputs = new List<ISynapse>();
            Outputs = new List<ISynapse>();

            _activationFunction = activationFunction;
            _inputFunction = inputFunction;

        }

        // Connect two neurons.
        // This neuron is the output neuron of the connection

        public void AddInputNeuron(INeuron inputNeuron)
        {
            var synapse = new Synapse(inputNeuron, this);
            Inputs.Add(synapse);
            inputNeuron.Outputs.Add(synapse);
        }

        // Connect two neurons. 
        // This neuron is the input neuron of the connection.
        
        public void AddOutputNeuron(INeuron outputNeuron)
        {
            var synapse = new Synapse(outputNeuron, this);
            Outputs.Add(synapse);
            outputNeuron.Inputs.Add(synapse);
        }

        public double CalculateOutput()
        {
            return _activationFunction.CalculateOutput(_inputFunction.CalculateInput(this.Inputs));
        }

        public void AddInputSynapse(double inputValue)
        {
            var inputsynapse = new InputSynapse(this, inputValue);
            Inputs.Add(inputsynapse);
        }

        public void PushValueOnInput(double inputValue)
        {
            ((InputSynapse)Inputs.First()).Output = inputValue;
        }


    }
}
