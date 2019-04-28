using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Ping : IRequest<string> {
        [FromRoute (Name ="id")]
        public int Id { get; set; }
    }

   
    public partial class QueryValidator : AbstractValidator<Ping>
    {
        public QueryValidator()
        {
            RuleFor(m => m.Id).NotNull();
           // RuleFor(m => m.Id).GreaterThan(2);
        }
    }

    public class PingService : IPingService {

        public Task<string> Query(Ping query)
        {
            return Task.FromResult($"Pong {query.Id}");
        }

    }

    public interface IPingService
    {
        Task<string> Query(Ping query);
    }
}
