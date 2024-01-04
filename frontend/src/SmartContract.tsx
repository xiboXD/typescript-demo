import { IPortkeyProvider, MethodsBase } from "@portkey/provider-types";
import useSmartContract from "./useSmartContract";
import { useState } from "react";

function SmartContract({ provider }: { provider: IPortkeyProvider | null }) {
  const contract = useSmartContract(provider);
  const [mintAccount, setMintAccount] = useState("");

  const onInitialize = async () => {
    const accounts = await provider?.request({
      method: MethodsBase.ACCOUNTS,
    });
    if (!accounts) throw new Error("No accounts");

    const account = accounts?.tDVW?.[0]!;
    if (!account) throw new Error("No account");

    return await contract?.callSendMethod("Initialize", account, {
      Symbol: "symbol",
      MintStartTime: "",
      MintEndTime: "",
      NftImageUrl:
        "https://i.seadn.io/gcs/files/0f5cdfaaf687de2ebb5834b129a5bef3.png?auto=format&w=3840",
      EventTitle: "WORKSHOP",
      EventDate: "20240101",
      EventVenue: "COM3",
      EventDescription: "A WORKSHOP",
    });
  };

  const onMint = async () => {
    return await contract?.callSendMethod("Mint", mintAccount, {});
  };

  if (!provider) return null;

  return (
    <div>
      <button onClick={onInitialize}>Initialize</button>
      <input
        value={mintAccount}
        onChange={(e) => setMintAccount(e.target.value)}
      />
      <button onClick={onMint}>Mint</button>
    </div>
  );
}

export default SmartContract;
