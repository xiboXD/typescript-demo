using AElf.Contracts.MultiToken;
using AElf.Sdk.CSharp;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.POAPContract
{
    // Contract class must inherit the base class generated from the proto file
    public class POAPContract : POAPContractContainer.POAPContractBase
    {
        public override Empty Initialize(InitializeInput input)
        {
            if (State.Initialized.Value)
            {
                return new Empty();
            }
            // This is to reference multiToken contract
            State.TokenContract.Value =
                Context.GetContractAddressByName(SmartContractConstants.TokenContractSystemName);
            State.Admin.Value = Context.Sender;
            State.CurrentNftIndex.Value = 1;
            // For this version of the TokenContract system contract, the approve method needs to be called during initialization
            // otherwise the TokenContract cannot be used properly
            State.TokenContract.Approve.Send(new ApproveInput
            {
                Spender = State.TokenContract.Value,
                Symbol = "ELF",
                Amount = 100000_00000000,
            });
            State.Initialized.Value = true;
            CreateCollection(input);
            return new Empty();
        }

        private void CreateCollection(InitializeInput input)
        {
            Assert(Context.Sender == State.Admin.Value, "Only the admin user can create a collection.");
            State.Symbol.Value = input.Symbol;
            State.MintStartTime.Value = input.MintStartTime;
            State.MintEndTime.Value = input.MintEndTime;
            State.CollectionInfo.Value = new CollectionInfo()
            {
                EventTitle = input.EventTitle,
                EventDate = input.EventDate,
                EventVenue = input.EventVenue,
                EventDescription = input.EventDescription,
                NftImageUrl = input.NftImageUrl,
            };
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
            Assert(State.Initialized.Value, "The contract has not been initialized yet");
            Assert(Context.CurrentBlockTime >= State.MintStartTime.Value, "The minting period has not started yet.");
            Assert(Context.CurrentBlockTime < State.MintEndTime.Value, "The minting period has already concluded.");
            
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
                            State.CollectionInfo.Value.NftImageUrl
                        },
                        {
                            "title",
                            State.CollectionInfo.Value.EventTitle
                        },
                        {
                            "date",
                            State.CollectionInfo.Value.EventDate
                        },
                        {
                            "venue",
                            State.CollectionInfo.Value.EventVenue
                        },
                        {
                            "description",
                            State.CollectionInfo.Value.EventDescription
                        }
                    }
                }
            });
            State.TokenContract.Issue.Send(new IssueInput
            {
                Symbol = symbolWithIndex,
                To = Context.Sender,
                Amount = 1
            });
            Context.Fire(new Minted
            {
                Symbol = symbolWithIndex,
                Receiver = Context.Sender
            });
            return new Empty();
        }
    }
}