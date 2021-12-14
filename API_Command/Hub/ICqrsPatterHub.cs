using System.Threading.Tasks;

namespace API_Command.Hub
{
    public interface ICqrsPatterHub
    {
        /// <summary>
        /// Signals to hub that a user was created
        /// </summary>
        Task UserCreated();
        /// <summary>
        /// Signals to hub that a movie was created
        /// </summary>
        Task MovieCreated();
        /// <summary>
        /// Signals to hub that a movie click was created
        /// </summary>
        Task MovieClickCreated();
    }
}
