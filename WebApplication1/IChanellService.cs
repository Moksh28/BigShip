using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1
{
    public interface IChanellService
    {
        Task<IEnumerable<ChannelModel>> GetChannelsAsync();

        Task<IEnumerable<ChannelModel>> GetChannelById(int user_id);
    }
}
