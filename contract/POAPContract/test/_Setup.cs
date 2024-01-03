using System.IO;
using AElf.Contracts.MultiToken;
using AElf.Cryptography.ECDSA;
using AElf.Kernel;
using AElf.Kernel.SmartContract;
using AElf.Standards.ACS0;
using AElf.Testing.TestBase;
using AElf.Types;
using Google.Protobuf;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace AElf.Contracts.POAPContract
{
    // The Module class load the context required for unit testing
    public class Module : ContractTestModule<POAPContract>
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<ContractOptions>(o => o.ContractDeploymentAuthorityRequired = false);
        }
    }

    // The TestBase class inherit ContractTestBase class, it defines Stub classes and gets instances required for unit testing
    public class TestBase : ContractTestBase<Module>
    {
        // The Stub class for unit testing
        internal POAPContractContainer.POAPContractStub POAPContractStub;
        internal POAPContractContainer.POAPContractStub POAPContractStub1;
        internal POAPContractContainer.POAPContractStub POAPContractStub2;

        internal TokenContractContainer.TokenContractStub TokenContractStub;
        internal ACS0Container.ACS0Stub ZeroContractStub;

        protected ECKeyPair DefaultKeyPair => Accounts[0].KeyPair;
        protected ECKeyPair User1 => Accounts[1].KeyPair;
        protected ECKeyPair User2 => Accounts[2].KeyPair;
        protected Address DefaultAddress => Accounts[0].Address;
        protected Address User1Address => Accounts[1].Address;
        protected Address User2Address => Accounts[2].Address;
        protected Address POAPContractAddress;
        
        protected string SeedNFTSymbolPrefix = "SEED-";
        protected int SeedNum = 0;

        public TestBase()
        {
            ZeroContractStub = GetContractZeroTester(DefaultKeyPair);
            var result = AsyncHelper.RunSync(async () =>await ZeroContractStub.DeploySmartContract.SendAsync(new ContractDeploymentInput
            {   
                Category = KernelConstants.CodeCoverageRunnerCategory,
                Code = ByteString.CopyFrom(
                    File.ReadAllBytes(typeof(POAPContract).Assembly.Location))
            }));
            
            POAPContractAddress = Address.Parser.ParseFrom(result.TransactionResult.ReturnValue);
            POAPContractStub = GetPOAPContractContractStub(DefaultKeyPair);
            POAPContractStub1 = GetPOAPContractContractStub(User1);
            POAPContractStub2 = GetPOAPContractContractStub(User2);
            TokenContractStub = GetTokenContractStub(DefaultKeyPair);
        }

        private POAPContractContainer.POAPContractStub GetPOAPContractContractStub(ECKeyPair senderKeyPair)
        {
            return GetTester<POAPContractContainer.POAPContractStub>(POAPContractAddress, senderKeyPair);
        }
        private TokenContractContainer.TokenContractStub GetTokenContractStub(ECKeyPair senderKeyPair)
        {
            return GetTester<TokenContractContainer.TokenContractStub>(TokenContractAddress, senderKeyPair);
        }
        private ACS0Container.ACS0Stub GetContractZeroTester(ECKeyPair keyPair)
        {
            return GetTester<ACS0Container.ACS0Stub>(BasicContractZeroAddress, keyPair);
        }
    }
}