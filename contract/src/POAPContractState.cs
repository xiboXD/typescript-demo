using AElf.Sdk.CSharp.State;

namespace AElf.Contracts.POAPContract
{
    // The state class is access the blockchain state
    public partial class POAPContractState : ContractState
    {
        public BoolState Initialized { get; set; }
    }
}