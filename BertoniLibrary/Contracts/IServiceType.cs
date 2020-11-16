using BertoniLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BertoniLibrary.Contracts
{
    public interface IServiceType {
        Task<IList<Album>> Albums();
        Task<IList<Photo>> Photos(int id);
        Task<IList<Comment>> Comments(int id);
    }
}