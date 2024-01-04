using AElf.Contracts.MultiToken;
using AElf.Sdk.CSharp;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.POAPContract
{
    // Contract class must inherit the base class generated from the proto file.
    public class POAPContract : POAPContractContainer.POAPContractBase
    {
        public override Empty Initialize(InitializeInput input)
        {
            // The Initialize method can only be called once.
            if (State.Initialized.Value)
            {
                return new Empty();
            }
            // This is to reference multiToken contract.
            State.TokenContract.Value =
                Context.GetContractAddressByName(SmartContractConstants.TokenContractSystemName);
            State.CurrentNftIndex.Value = 1;
            // For this version of the TokenContract system contract, the approve method needs to be called during initialization
            // otherwise the TokenContract cannot be used properly.
            State.TokenContract.Approve.Send(new ApproveInput
            {
                Spender = State.TokenContract.Value,
                Symbol = "ELF",
                Amount = 100000_00000000,
            });
            // Call the CreateCollection method to create the NFT collection within the Initialize method, to be invoked by the contract deployer.
            CreateCollection(input);
            State.Initialized.Value = true;
            return new Empty();
        }

        private void CreateCollection(InitializeInput input)
        {
            State.Symbol.Value = input.Symbol;
            State.MintStartTime.Value = input.MintStartTime;
            State.MintEndTime.Value = input.MintEndTime;
            State.EventInfo.Value = new EventInfo
            {
                Title = input.EventTitle,
                Date = input.EventDate,
                Venue = input.EventVenue,
                Description = input.EventDescription,
            };
            // The symbol of the NFT collection needs to end with '-0'.
            var symbolWithIndex = State.Symbol.Value + "-0";
            State.TokenContract.Create.Send(new CreateInput
            {
                Symbol = symbolWithIndex,
                TokenName = input.Symbol + " collection",
                TotalSupply = 1,
                Decimals = 0,
                Issuer = Context.Self,
                Owner = Context.Self,
                IsBurnable = false,
                ExternalInfo = new ExternalInfo()
                {
                    Value =
                    {
                        {
                            "__nft_image_url",
                            input.NftImageUrl
                        }
                    }
                }
            });
        }

        public override Empty Mint(Empty input)
        {
            // Minting is only allowed after initialization.
            Assert(State.Initialized.Value, "The contract has not been initialized yet");
            // Minting must occur within the specified time frame.
            Assert(Context.CurrentBlockTime >= State.MintStartTime.Value, "The minting period has not started yet.");
            Assert(Context.CurrentBlockTime < State.MintEndTime.Value, "The minting period has already concluded.");
            
            // The NFTs minted will contain the index as suffixes.
            var symbolWithIndex = State.Symbol.Value + "-" + State.CurrentNftIndex.Value++;
            State.TokenContract.Create.Send(new CreateInput
            {
                Symbol = symbolWithIndex,
                TokenName = symbolWithIndex + " token",
                TotalSupply = 1,
                Decimals = 0,
                Issuer = Context.Self,
                Owner = Context.Self,
                IsBurnable = false,
                ExternalInfo = new ExternalInfo()
                {
                    Value =
                    {
                        {
                            "__nft_image_url",
                            State.EventInfo.Value.NftImageUrl
                        },
                        {
                            "title",
                            State.EventInfo.Value.Title
                        },
                        {
                            "date",
                            State.EventInfo.Value.Date
                        },
                        {
                            "venue",
                            State.EventInfo.Value.Venue
                        },
                        {
                            "description",
                            State.EventInfo.Value.Description
                        }
                    }
                }
            });
            // After minting an NFT, it needs to be issued to the user's address.
            State.TokenContract.Issue.Send(new IssueInput
            {
                Symbol = symbolWithIndex,
                To = Context.Sender,
                Amount = 1
            });
            // Use Context.Fire to emit an event, which can be captured and processed.
            Context.Fire(new Minted
            {
                Symbol = symbolWithIndex,
                Receiver = Context.Sender
            });
            return new Empty();
        }
    }
}