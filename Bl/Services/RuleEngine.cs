using Bl.Api;
using Bl.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{
    public class RuleEngine
    {
        private readonly List<IBlDoorRule> _rules;

        public RuleEngine(List<IBlDoorRule> rules)
        {
            _rules = rules;
        }

        public List<Operation> Generate(BlDoor door)
        {
            var result = new List<Operation>();

            foreach (var rule in _rules)
            {
                result.AddRange(rule.Apply(door));
            }

            return result;
        }
    }
}
