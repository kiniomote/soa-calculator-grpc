using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcCalculateService.Models;

namespace GrpcCalculateService.Services
{
    public interface ICalculator
    {
        double Calculate(CalculateData calculateData);

        Task<double> CalculateAsync(CalculateData calculateData);
    }
}
