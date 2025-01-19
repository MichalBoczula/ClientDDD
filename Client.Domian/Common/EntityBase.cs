using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domian.Common
{
    public record EntityBase
    {
        public Guid Id { get; init; }
    }
}
