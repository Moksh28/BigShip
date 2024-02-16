using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class ChannelService:IChanellService
    {
        private readonly IDbConnection _connection;

        public ChannelService(IDbConnection connection)
        {
            _connection = connection;
        }


        public async Task<IEnumerable<ChannelModel>> GetChannelsAsync()
        {
            var query = @"
                            SELECT * FROM ChannelList WHERE is_active = TRUE;
                        ";

            var results = await _connection.QueryAsync<ChannelModel>(query);
            return results;
        }

        public async Task<IEnumerable<ChannelModel>> GetChannelById(int user_id)
        {
            var query = @"
                            SELECT cl.channel_name
                            FROM ChannelList cl
                            JOIN UserIntegratedChannels uic ON cl.channel_id = uic.channel_id
                            WHERE uic.user_id = @user_id AND uic.is_permitted = TRUE;

                        ";

            var results = await _connection.QueryAsync<ChannelModel>(query, new {user_id});
            return results;
        }
    }
}
