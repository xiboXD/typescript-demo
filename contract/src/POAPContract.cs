using AElf.Contracts.MultiToken;
using AElf.Sdk.CSharp;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.POAPContract
{
    // Contract class must inherit the base class generated from the proto file
    public class POAPContract : POAPContractContainer.POAPContractBase
    {
        public override Empty Initialize(Empty input)
        {
            if (State.Initialized.Value)
            {
                return new Empty();
            }

            State.TokenContract.Value =
                Context.GetContractAddressByName(SmartContractConstants.TokenContractSystemName);
            State.TokenContract.Approve.Send(new ApproveInput
            {
                Spender = State.TokenContract.Value,
                Symbol = "ELF",
                Amount = 100000_00000000,
            });
            State.Initialized.Value = true;
            return new Empty();
        }

        public override Empty CreateCollection(CreateCollectionInput input)
        {
            State.TokenContract.Create.Send(new CreateInput
            {
                Symbol = input.Symbol,
                TokenName = input.Symbol + " collection",
                TotalSupply = 1,
                Decimals = 0,
                Issuer = input.Issuer,
                Owner = input.Issuer,
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
            return new Empty();
        }

        public override Empty Mint(MintInput input)
        {
            State.TokenContract.Create.Send(new CreateInput
            {
                Symbol = input.Symbol,
                TokenName = input.Symbol + " token",
                TotalSupply = 1,
                Decimals = 0,
                Issuer = input.Issuer,
                Owner = input.Issuer,
                IsBurnable = false,
                ExternalInfo = new ExternalInfo()
                {
                    Value =
                    {
                        {
                            "__nft_image_url",
                            input.NftImageUrl
                        },
                        {
                            "title",
                            input.Title
                        },
                        {
                            "date",
                            input.Date
                        },
                        {
                            "venue",
                            input.Venue
                        },
                        {
                            "description",
                            input.Description
                        }
                    }
                }
            });
            State.TokenContract.Issue.Send(new IssueInput
            {
                Symbol = input.Symbol,
                To = input.Issuer,
                Amount = 1
            });
            return new Empty();
        }
    }
}