using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.CQRS.CQRS.Commands.Response
{
    public class CreateProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public Guid ProductId { get; set; }
    }
}
