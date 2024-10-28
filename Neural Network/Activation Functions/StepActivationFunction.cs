using Neural_Network;
using System;

public class StepActivationFunction : IActivationFunction
{
    private double _treshold;

    public StepActivationFunction(double treshold)
    {
        _treshold = treshold;
    }

    // Returns 1 if the input value exceeds the threshold value, otherwise, it returns 0.
    public double CalculateOutput(double input)
    {
        return Convert.ToDouble(input > _treshold);
    }

}
