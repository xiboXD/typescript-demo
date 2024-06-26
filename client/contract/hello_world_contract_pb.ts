// @generated by protoc-gen-es v1.7.1 with parameter "target=ts"
// @generated from file contract/hello_world_contract.proto (syntax proto3)
/* eslint-disable */
// @ts-nocheck

import type { BinaryReadOptions, FieldList, JsonReadOptions, JsonValue, PartialMessage, PlainMessage } from "@bufbuild/protobuf";
import { Message, proto3 } from "@bufbuild/protobuf";

/**
 * @generated from message Character
 */
export class Character extends Message<Character> {
  /**
   * @generated from field: int32 health = 1;
   */
  health = 0;

  /**
   * @generated from field: int32 strength = 2;
   */
  strength = 0;

  /**
   * @generated from field: int32 speed = 3;
   */
  speed = 0;

  constructor(data?: PartialMessage<Character>) {
    super();
    proto3.util.initPartial(data, this);
  }

  static readonly runtime: typeof proto3 = proto3;
  static readonly typeName = "Character";
  static readonly fields: FieldList = proto3.util.newFieldList(() => [
    { no: 1, name: "health", kind: "scalar", T: 5 /* ScalarType.INT32 */ },
    { no: 2, name: "strength", kind: "scalar", T: 5 /* ScalarType.INT32 */ },
    { no: 3, name: "speed", kind: "scalar", T: 5 /* ScalarType.INT32 */ },
  ]);

  static fromBinary(bytes: Uint8Array, options?: Partial<BinaryReadOptions>): Character {
    return new Character().fromBinary(bytes, options);
  }

  static fromJson(jsonValue: JsonValue, options?: Partial<JsonReadOptions>): Character {
    return new Character().fromJson(jsonValue, options);
  }

  static fromJsonString(jsonString: string, options?: Partial<JsonReadOptions>): Character {
    return new Character().fromJsonString(jsonString, options);
  }

  static equals(a: Character | PlainMessage<Character> | undefined, b: Character | PlainMessage<Character> | undefined): boolean {
    return proto3.util.equals(Character, a, b);
  }
}

