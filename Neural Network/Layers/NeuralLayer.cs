using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    public class NeuralLayer
    {
        public List<INeuron> Neurons;
        public NeuralLayer() 
        {
            Neurons = new List<INeuron>();
        }

        public void ConnectLayers(NeuralLayer inputLayer)
        {
            // hvad fuck sker der her
            var combos = Neurons.SelectMany(neuron => inputLayer.Neurons,
            (neuron, input) => new { neuron, input });
            combos.ToList().ForEach(x => x.neuron.AddInputNeuron(x.input));
        }
    }
}
