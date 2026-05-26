using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlMpfFileService
    {
        Task<string> SaveAsync(int doorId, string mpfContent);
    }
}
