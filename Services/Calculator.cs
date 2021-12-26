using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcCalculateService.Models;
using GrpcCalculatorService;

namespace GrpcCalculateService.Services
{
    public delegate double CalculateAction(CalculateData calculateData);

    public class Calculator : ICalculator
    {
        private readonly Dictionary<Sign, CalculateAction> _calculateActions;

        public Calculator()
        {
            _calculateActions = new Dictionary<Sign, CalculateAction>()
            {
                [Sign.Plus] = Plus,
                [Sign.Minus] = Minus,
                [Sign.Multiply] = Multiply,
                [Sign.Divide] = Divide,
                [Sign.Degree] = Degree,
                [Sign.Root] = Root,
            };
        }

        public double Calculate(CalculateData calculateData)
        {
            return _calculateActions[calculateData.GetSign()](calculateData);
        }

        public async Task<double> CalculateAsync(CalculateData calculateData)
        {
            return await Task.Run(() => Calculate(calculateData));
        }

        private double Plus(CalculateData calculateData)
        {
            return calculateData.FirstParam + calculateData.SecondParam;
        }

        private double Minus(CalculateData calculateData)
        {
            return calculateData.FirstParam - calculateData.SecondParam;
        }

        private double Multiply(CalculateData calculateData)
        {
            return calculateData.FirstParam * calculateData.SecondParam;
        }

        private double Divide(CalculateData calculateData)
        {
            return calculateData.FirstParam / calculateData.SecondParam;
        }

        private double Degree(CalculateData calculateData)
        {
            return Math.Pow(calculateData.FirstParam, calculateData.SecondParam);
        }

        private double Root(CalculateData calculateData)
        {
            return Math.Pow(calculateData.FirstParam, 1 / calculateData.SecondParam);
        }
    }
}
