using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcCalculatorService;
using GrpcCalculateService.Models;
using Microsoft.AspNetCore.Authorization;

namespace GrpcCalculateService.Services
{
    public class CalculatorService : GrpcCalculator.GrpcCalculatorBase
    {
        public override Task<GrpcTokenResult> Login(GrpcLoginData request, ServerCallContext context)
        {
            return Task.FromResult(new GrpcTokenResult
            {
                Token = new JwtTokenGenerator().GenerateToken(request.Username, request.Password)
            });
        }

        [Authorize]
        public override Task<GrpcCalculateResult> Calculate(GrpcCalculateData request, ServerCallContext context)
        {
            return Task.FromResult(new GrpcCalculateResult
            {
                Result = new Calculator().Calculate(new CalculateData(request))
            });
        }
    }
}
