using ExitGames.Client.Photon;
using Photon.Realtime;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace NetworkSanity.Core
{
    [Obfuscation(Exclude = false)]
    /// <summary>
    /// Return value of function determines whether it should block the original function
    /// </summary>
    internal interface ISanitizer
    {
        [Obfuscation(Exclude = false)]
        // check event and reject if necessary
        bool OnPhotonEvent(LoadBalancingClient loadBalancingClient, EventData eventData);
        // check if currently ratelimited to make sure vrchat doesn't log those events in case debug logging is enabled
        bool VRCNetworkingClientOnPhotonEvent(EventData eventData);
    }
}
