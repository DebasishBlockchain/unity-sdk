using System.Threading.Tasks;

namespace Thirdweb
{
    /// <summary>
    /// The entry point for the thirdweb SDK.
    /// </summary>
    public class ThirdwebSDK
    {
        [System.Serializable]
        public struct Options
        {
            public GaslessOptions? gasless;
        }

        [System.Serializable]
        public struct GaslessOptions
        {
            public OZDefenderOptions? openzeppelin;
            public BiconomyOptions? biconomy;
            public bool experimentalChainlessSupport;
        }

        [System.Serializable]
        public struct OZDefenderOptions
        {
            public string relayerUrl;
            public string relayerForwarderAddress;
        }

        [System.Serializable]
        public struct BiconomyOptions
        {
            public string apiId;
            public string apiKey;
        }

        private string chainOrRPC;

        public ThirdwebSDK(string chainOrRPC, Options options = new Options()) 
        {
            this.chainOrRPC = chainOrRPC;
            Bridge.Initialize(chainOrRPC, options);
        }

        public Task<string> Connect() 
        {
            return Bridge.Connect();
        }

        public Contract GetContract(string address)
        {
            return new Contract(this.chainOrRPC, address);
        }
    }
}