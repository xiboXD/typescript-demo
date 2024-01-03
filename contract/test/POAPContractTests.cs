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
        [Fact]
        public async Task CreateCollectionAndNftTests()
        {
            const string symbolName = "TEST";
            const string nftCollectionSymbol = symbolName + "-0";
            const string nftSymbol = symbolName + "-1";
            await InitializeAsync();
            
            await CreateSeedNftCollection();
            var seedNftCreateInput = BuildSeedNftCreateInput(symbolName);
            await CreateSeedNft(seedNftCreateInput);

            await CreateNftCollection(nftCollectionSymbol);
            await CreateNft(nftSymbol);

            var balance = await TokenContractStub.GetBalance.CallAsync(new GetBalanceInput
            {
                Symbol = nftSymbol,
                Owner = POAPContractAddress
            });
            balance.Balance.ShouldBe(1);
        }
        
        private async Task InitializeAsync()
        {
            await POAPContractStub.Initialize.SendAsync(new Empty());
            await TokenContractStub.Transfer.SendAsync(new TransferInput
            {
                To = POAPContractAddress,
                Symbol = "ELF",
                Amount = 100000_00000000
            });
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

        private async Task CreateNftCollection(string symbol)
        {
            await POAPContractStub.CreateCollection.SendAsync(new CreateCollectionInput
            {
                Symbol = symbol,
                Issuer = POAPContractAddress,
                NftImageUrl = "https://i.seadn.io/gcs/files/0f5cdfaaf687de2ebb5834b129a5bef3.png?auto=format&w=3840"
            });
        }
        
        private async Task CreateNft(string symbol)
        {
            await POAPContractStub.Mint.SendAsync(new MintInput
            {
                Symbol = symbol,
                Issuer = POAPContractAddress,
                NftImageUrl = "https://i.seadn.io/gcs/files/0f5cdfaaf687de2ebb5834b129a5bef3.png?auto=format&w=3840",
                Title = "WORKSHOP",
                Date = "20240105",
                Venue = "COM3",
                Description = "This is POAP contract"
            });
        }
    }
    
}