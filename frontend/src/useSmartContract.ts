import { IPortkeyProvider, IChain } from "@portkey/provider-types";
import { useEffect, useState } from "react";

export type IContract = ReturnType<IChain["getContract"]>;

function useSmartContract(provider: IPortkeyProvider | null) {
  const [smartContract, setSmartContract] = useState<IContract>();

  useEffect(() => {
    (async () => {
      if (!provider) return null;

      try {
        // 1. get the sidechain tDVW using provider.getChain
        const chain = await provider?.getChain("tDVW");
        if (!chain) throw new Error("No chain");

        const address = "4CknAAWUdByDxrHVPM3F1PGPGSgwaFt7mSapxBifqsipMfqpm"; // replace with your deployed contract address

        // 2. get the contract
        const contract = chain?.getContract(address);
        setSmartContract(contract);
      } catch (error) {
        console.log(error, "====error");
      }
    })();
  }, [provider]);

  return smartContract;
}

export default useSmartContract;
