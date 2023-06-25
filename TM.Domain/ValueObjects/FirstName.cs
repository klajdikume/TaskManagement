using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Primitives;

namespace TM.Domain.ValueObjects
{
    public sealed class FirstName : ValueObject
    {
        public const int MaxLength = 50;
        public FirstName(string value)
        {
            Value = value;
        }
    
        public string Value { get; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
