using AElf.Sdk.CSharp.State;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.POAPContract
{
    // The state class is access the blockchain state
    public partial class POAPContractState : ContractState
    {
        public SingletonState<Address> Admin { get; set; }
        public BoolState Initialized { get; set; }
        public StringState Symbol { get; set; }
        public UInt64State CurrentNftIndex { get; set; }
        public SingletonState<CollectionInfo> CollectionInfo { get; set; }
        public SingletonState<Timestamp> StartTime { get; set; }
        public SingletonState<Timestamp> EndTime { get; set; }
    }
}