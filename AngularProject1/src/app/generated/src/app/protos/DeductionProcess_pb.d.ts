// package: 
// file: src/app/protos/DeductionProcess.proto

import * as jspb from "google-protobuf";

export class DeductionRequest extends jspb.Message {
  getProductid(): number;
  setProductid(value: number): void;

  getPrice(): number;
  setPrice(value: number): void;

  getQuantity(): number;
  setQuantity(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): DeductionRequest.AsObject;
  static toObject(includeInstance: boolean, msg: DeductionRequest): DeductionRequest.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: DeductionRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): DeductionRequest;
  static deserializeBinaryFromReader(message: DeductionRequest, reader: jspb.BinaryReader): DeductionRequest;
}

export namespace DeductionRequest {
  export type AsObject = {
    productid: number,
    price: number,
    quantity: number,
  }
}

export class DeductionResponse extends jspb.Message {
  getSuccess(): boolean;
  setSuccess(value: boolean): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): DeductionResponse.AsObject;
  static toObject(includeInstance: boolean, msg: DeductionResponse): DeductionResponse.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: DeductionResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): DeductionResponse;
  static deserializeBinaryFromReader(message: DeductionResponse, reader: jspb.BinaryReader): DeductionResponse;
}

export namespace DeductionResponse {
  export type AsObject = {
    success: boolean,
  }
}

