using System.Diagnostics.CodeAnalysis;
using AElf.Sdk.CSharp.State;
using AElf.Standards.ACS6;
using AElf.Types;

namespace AElf.Contracts.HelloWorld
{
    // The state class is used to communicate with the blockchain.
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class HelloWorldState : ContractState
    {
        // StringState is used to put the single data.
        public StringState Message { get; set; }

        //create a storage space for Character
        public BoolState Initialized { get; set; }
        public MappedState<Address, Character> Characters { get; set; }

        //encapsulate AEDPoS consensus contract reference state
        internal RandomNumberProvideacsrContractContainer.RandomNumberProvideacsrContractReferenceState
            RandomNumberContract { get; set; }
    }
}