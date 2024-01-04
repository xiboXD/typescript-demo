using AElf.Contracts.MultiToken;
using AElf.Sdk.CSharp.State;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.POAPContract
{
    // The state class is access the blockchain state
    public partial class POAPContractState : ContractState
    {
        /// <summary>
        /// Whether the contract is already intialized.
        /// </summary>
        public BoolState Initialized { get; set; }

        /// <summary>
        /// The symbol of the NFT collection.
        /// </summary>
        public StringState Symbol { get; set; }

        /// <summary>
        /// The index of the next NFT to be minted.
        /// </summary>
        public UInt64State CurrentNftIndex { get; set; }

        /// <summary>
        /// The information of the event.
        /// </summary>
        public SingletonState<EventInfo> EventInfo { get; set; }

        /// <summary>
        /// The start time of the minting period.
        /// </summary>
        public SingletonState<Timestamp> MintStartTime { get; set; }

        /// <summary>
        /// The end time of the minting period.
        /// </summary>
        public SingletonState<Timestamp> MintEndTime { get; set; }

        /// <summary>
        /// The contract reference we can use to call the token contract.
        /// </summary>
        internal TokenContractContainer.TokenContractReferenceState TokenContract { get; set; }
    }
}