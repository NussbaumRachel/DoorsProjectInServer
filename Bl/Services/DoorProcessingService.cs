using Bl.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Models;
namespace Bl.Services
{
    public class DoorProcessingService
    {
        private readonly RuleEngine _engine;

        public DoorProcessingService()
        {
            _engine = new RuleEngine(new List<IBlDoorRule>
        {
            new FrameRule(),
            new HingesRule(),
            new PerforationRule(),
            new SkylightRule()
        });
        }

        public List<Operation> BuildOperations(BlDoor door)
        {
            return _engine.Generate(door);
        }
    }
}
