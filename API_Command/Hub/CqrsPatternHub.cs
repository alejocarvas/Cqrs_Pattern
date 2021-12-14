using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace API_Command.Hub
{
    public class CqrsPatternHub : Hub<ICqrsPatterHub>
    {
        /// <summary>
        /// Emits a signal when a user is created
        /// </summary>
        public async Task UserCreated()
        {
            await Clients.All.UserCreated();
        }

        /// <summary>
        /// Emits a signal when a movie is created
        /// </summary>
        public async Task MovieCreated()
        {
            await Clients.All.MovieCreated();
        }

        /// <summary>
        /// Emits a signal when a movie click is created
        /// </summary>
        public async Task MovieClickCreated()
        {
            await Clients.All.MovieClickCreated();
        }
    }
}
