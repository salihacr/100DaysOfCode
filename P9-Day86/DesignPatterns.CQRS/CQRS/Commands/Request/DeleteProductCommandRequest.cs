using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.CQRS.CQRS.Commands.Request
{
    public class DeleteProductCommandRequest
    {
        public Guid Id { get; set; }
    }
}
