using System;
using GrpcCalculatorService;

namespace GrpcCalculateService.Models
{
    public enum Sign
    {
        Plus='+',
        Minus='-',
        Multiply='*',
        Divide='/',
        Degree='^',
        Root='~',
    }

    public class CalculateData
    {
        public double FirstParam { get; set; }

        public double SecondParam { get; set; }

        public string Sign { get; set; }

        public CalculateData(GrpcCalculateData grpcData)
        {
            FirstParam = grpcData.FirstParam;
            SecondParam = grpcData.SecondParam;
            Sign = grpcData.Sign;
        }

        public Sign GetSign()
        {
            return (Sign)Sign[0];
        }
    }
}
