using Agency.Helpers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agency
{
    public interface IFirebaseService
    {
        public Task<List<string>> AddRange(string path, IList<IFormFile> files);
        public Task<ResponseMessage> RemoveRange(string path, IList<string> fileNames);
    }
}