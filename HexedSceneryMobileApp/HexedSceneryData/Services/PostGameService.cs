
using HexedSceneryCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryData.Services
{
    public interface IPostGameService
    {
        List<PostGameTableType> GetPostGameTableTypes();
    }
    public class PostGameService : IPostGameService
    {
        public List<PostGameTableType> GetPostGameTableTypes()
        {
            throw new NotImplementedException();
        }
    }
}
