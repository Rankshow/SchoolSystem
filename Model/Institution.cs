using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Explicit.Model
{
    public class Institution
    {
        public int Id { set; get; }
        public string? Name { set; get; }
        public string? Email { set; get; }
        public string? State { set; get; }
        public string? Country { set; get; }
    }
}