using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Api;
    using Dal.Api;
    using System.Text;
namespace Bl.Services
{
    

    public class MpfFileService : IBlMpfFileService
    {
        IDal Dal;
        public MpfFileService(IDal Dal)
        {
            this.Dal = Dal;
        }
        public async Task<string> SaveAsync(int doorId, string mpfContent)
        {
                      var fullPath = Dal.doors.createFilePath(doorId);

            await File.WriteAllTextAsync(
                fullPath,
                mpfContent,
                Encoding.UTF8
            );

            await Dal.doors.UpdateDoorFilePathAsync(
                doorId,
                fullPath
            );

            return fullPath;
        }
    }
}
