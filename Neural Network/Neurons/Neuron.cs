using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neural_Network;

namespace Neural_Network
{
    /* 
     Each Neuron has its unique identifier Id - used in backpropagation algorithm
        (and so is PreviousPartialDerivative)
     A neuron has two lists, one for input connections and another one for output connections.

     AddInputNeuron() and AddOutputNeuron() are used to create a connection among neurons
           The first one adds input connection to some neuron and the second one adds output connection to some neuron.

    AddInputsynapse() adds InputSynapse which is a special connection type. Used just for the input layer
         i.e., they are used only for adding input to the entirety of the system.
     
    CalculateOutput() method is used to activate a chain reaction of output calculation. 
         this will call input function, which will request values from all input connections.
         In turn, these connections will request output values from input neurons of these connections, 
         i.e., output values of neurons from the previous layer. 
         This process will be done until input layer is reached and input values are propagated through the system.
     */
    public class Neuron : INeuron
    {

        private IActivationFunction _activationFunction;
        private IInputFunction _inputFunction; 

        // Input and Output connections of the neuron
        public List<ISynapse> Inputs { get; set; }
        public List<ISynapse> Outputs { get; set; } 

        public Guid Id { get; private set; }

        // Calculated partial derivative in previous iteration of training process - used in backpropagation algorithm
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

        // Input layer neurons just recieve input values
        // for this they need to have connections
        // this function adds connection to the neuron
        // [param:] is Initial value that will be pushed as an input to the connection
        public void AddInputSynapse(double inputValue)
        {
            var inputSynapse = new InputSynapse(this, inputValue);
            Inputs.Add(inputSynapse);
        }

        // Sets New value on the input connections
        // [param:] is New value that will be "pushed" as an input to the connection
        public void PushValueOnInput(double inputValue)
        {
            ((InputSynapse)Inputs.First()).Output = inputValue;
        }

    }
}
