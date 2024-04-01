//*
// AElf Standards ACS1(Transaction Fee Standard)
//
// Used to manage the transaction fee.

// @generated by protoc-gen-aelf-es v1.0.0 with parameter "target=ts"
// @generated from file base/acs1.proto (package acs1, syntax proto3)
/* eslint-disable */
// @ts-nocheck

import { MethodFees } from "./acs1_pb.js";
import { Empty, StringValue } from "@bufbuild/protobuf";
import { AuthorityInfo } from "../message/authority_info_pb.js";

/**
 * @generated from service acs1.MethodFeeProviderContract
 */
export abstract class MethodFeeProviderContractClient {


    /**
     * Set the method fees for the specified method. Note that this will override all fees of the method.
     *
     * @generated from rpc acs1.MethodFeeProviderContract.SetMethodFee
     */
    abstract async SetMethodFee(request: MethodFees): Promise<Empty> {
    // this is a send method
    }

    /**
     * Change the method fee controller, the default is parliament and default organization.
     *
     * @generated from rpc acs1.MethodFeeProviderContract.ChangeMethodFeeController
     */
    abstract async ChangeMethodFeeController(request: AuthorityInfo): Promise<Empty> {
    // this is a send method
    }

    /**
     * Query method fee information by method name.
     *
     * @generated from rpc acs1.MethodFeeProviderContract.GetMethodFee
     */
    abstract async GetMethodFee(request: StringValue): Promise<MethodFees> {
    // this is a view method
    }

    /**
     * Query the method fee controller.
     *
     * @generated from rpc acs1.MethodFeeProviderContract.GetMethodFeeController
     */
    abstract async GetMethodFeeController(request: Empty): Promise<AuthorityInfo> {
    // this is a view method
    }
}
