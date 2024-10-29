using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    public class Synapse : ISynapse 
    {
        internal INeuron _fromNeuron;
        internal INeuron _toNeuron;

        // Weight of the connection
        public double Weight { get; set; } 
        // Weight that connection had in previous itteration
        // Used in training process
        public double PreviousWeight { get; set; }

        public Synapse(INeuron fromNeuron, INeuron toNeuron, double weight)
        {
            _fromNeuron = fromNeuron;
            _toNeuron = toNeuron;
            Weight = weight;
            PreviousWeight = 0;
        }

        public Synapse(INeuron fromNeuron, INeuron toNeuron)
        {
            _fromNeuron = fromNeuron;
            _toNeuron = toNeuron;

            var tmpRandom = new Random();
            Weight = tmpRandom.NextDouble();
            PreviousWeight = 0;
        }

        // Returns output value of the connection
        public double GetOutput()
        {
            return _fromNeuron.CalculateOutput();
        }

        // Checks if Neuron is the input of the connection
        public bool IsFromNeuron(Guid fromNeuronId)
        {
            return _fromNeuron.Id.Equals(fromNeuronId);
        }

        // Update weight
        public void UpdateWeight(double learningRate, double delta)
        {
            PreviousWeight = Weight;
            Weight += learningRate * delta;
        }
    }
}
