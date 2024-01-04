using System.Threading;
using System.Threading.Tasks;
using AElf.Contracts.MultiToken;
using AElf.CSharp.Core.Extension;
using AElf.Kernel;
using Google.Protobuf.WellKnownTypes;
using Shouldly;
using Xunit;

namespace AElf.Contracts.POAPContract
{
    // This class is unit test class, and it inherit TestBase. Write your unit test code inside it
    public class POAPContractTests : TestBase
    {
        private readonly Timestamp _currentTime = TimestampHelper.GetUtcNow();

        [Fact]
        public async Task MintTests()
        {
            const string symbolName = "TEST";
            await InitializeAsset();
            
            await CreateSeedNftCollection();
            var seedNftCreateInput = BuildSeedNftCreateInput(symbolName);
            await CreateSeedNft(seedNftCreateInput);
            await TransferSeedToContract();
            
            await InitializeContract(new InitializeInput
            {
                Symbol = symbolName,
                MintStartTime = _currentTime.AddDays(-1),
                MintEndTime = _currentTime.AddDays(1),
                NftImageUrl = "https://i.seadn.io/gcs/files/0f5cdfaaf687de2ebb5834b129a5bef3.png?auto=format&w=3840",
                EventTitle = "WORKSHOP",
                EventDate = "20240101",
                EventVenue = "COM3",
                EventDescription = "A WORKSHOP"
            });
            await POAPContractStub.Mint.SendAsync(new Empty());
            await POAPContractStub1.Mint.SendAsync(new Empty());
            await POAPContractStub2.Mint.SendAsync(new Empty());
            var balance = await TokenContractStub.GetBalance.CallAsync(new GetBalanceInput
            {
                Symbol = symbolName + "-1",
                Owner = DefaultAddress
            });
            balance.Balance.ShouldBe(1);
            var balance1 = await TokenContractStub.GetBalance.CallAsync(new GetBalanceInput
            {
                Symbol = symbolName + "-2",
                Owner = User1Address
            });
            balance1.Balance.ShouldBe(1);
            var balance2 = await TokenContractStub.GetBalance.CallAsync(new GetBalanceInput
            {
                Symbol = symbolName + "-3",
                Owner = User2Address
            });
            balance2.Balance.ShouldBe(1);
        }
        
        private async Task InitializeContract(InitializeInput input)
        {
            await POAPContractStub.Initialize.SendAsync(input);
        }

        private async Task CreateSeedNftCollection()
        {
            await TokenContractStub.Create.SendAsync(new CreateInput
            {
                Symbol = SeedNFTSymbolPrefix + SeedNum,
                Decimals = 0,
                IsBurnable = true,
                TokenName = "Seed collection",
                TotalSupply = 1,
                Issuer = DefaultAddress,
                Owner = DefaultAddress,
                ExternalInfo = new ExternalInfo()
            });
        }

        private CreateInput BuildSeedNftCreateInput(string symbol)
        {
            Interlocked.Increment(ref SeedNum);
            var input = new CreateInput
            {
                Symbol = SeedNFTSymbolPrefix + SeedNum,
                Decimals = 0,
                IsBurnable = true,
                TokenName = "Seed token" + SeedNum,
                TotalSupply = 1,
                Issuer = DefaultAddress,
                Owner = DefaultAddress,
                ExternalInfo = new ExternalInfo()
                {
                    Value =
                    {
                        {
                            "__seed_owned_symbol", symbol + "-0"
                        },
                        {
                            "__seed_exp_time", TimestampHelper.GetUtcNow().AddDays(1).Seconds.ToString()
                        }
                    }
                },
                LockWhiteList = { TokenContractAddress }
            };
            return input;
        }

        private async Task CreateSeedNft(CreateInput input)
        {
            await TokenContractStub.Create.SendAsync(input);
            await TokenContractStub.Issue.SendAsync(new IssueInput
            {
                Symbol = input.Symbol,
                Amount = 1,
                To = DefaultAddress
            });
        }

        private async Task InitializeAsset()
        {
            await TokenContractStub.Transfer.SendAsync(new TransferInput
            {
                To = POAPContractAddress,
                Symbol = "ELF",
                Amount = 100000_00000000
            });
        }

        private async Task TransferSeedToContract()
        {
            await TokenContractStub.Approve.SendAsync(new ApproveInput
            {
                Spender = DefaultAddress,
                Symbol = "SEED-1",
                Amount = 1
            });
            await TokenContractStub.TransferFrom.SendAsync(new TransferFromInput
            {
                From = DefaultAddress,
                To = POAPContractAddress,
                Symbol = "SEED-1",
                Amount = 1
            });
        }
    }
    
}