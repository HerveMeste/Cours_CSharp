using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulWebServices.Models
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetCommentByPostIds(List<int> postIds);
    }
}
