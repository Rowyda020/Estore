// package: 
// file: src/app/protos/DeductionProcess.proto

import * as src_app_protos_DeductionProcess_pb from "../../../src/app/protos/DeductionProcess_pb";
import {grpc} from "@improbable-eng/grpc-web";

type DeductionProcessDeduction = {
  readonly methodName: string;
  readonly service: typeof DeductionProcess;
  readonly requestStream: false;
  readonly responseStream: false;
  readonly requestType: typeof src_app_protos_DeductionProcess_pb.DeductionRequest;
  readonly responseType: typeof src_app_protos_DeductionProcess_pb.DeductionResponse;
};

export class DeductionProcess {
  static readonly serviceName: string;
  static readonly Deduction: DeductionProcessDeduction;
}

export type ServiceError = { message: string, code: number; metadata: grpc.Metadata }
export type Status = { details: string, code: number; metadata: grpc.Metadata }

interface UnaryResponse {
  cancel(): void;
}
interface ResponseStream<T> {
  cancel(): void;
  on(type: 'data', handler: (message: T) => void): ResponseStream<T>;
  on(type: 'end', handler: (status?: Status) => void): ResponseStream<T>;
  on(type: 'status', handler: (status: Status) => void): ResponseStream<T>;
}
interface RequestStream<T> {
  write(message: T): RequestStream<T>;
  end(): void;
  cancel(): void;
  on(type: 'end', handler: (status?: Status) => void): RequestStream<T>;
  on(type: 'status', handler: (status: Status) => void): RequestStream<T>;
}
interface BidirectionalStream<ReqT, ResT> {
  write(message: ReqT): BidirectionalStream<ReqT, ResT>;
  end(): void;
  cancel(): void;
  on(type: 'data', handler: (message: ResT) => void): BidirectionalStream<ReqT, ResT>;
  on(type: 'end', handler: (status?: Status) => void): BidirectionalStream<ReqT, ResT>;
  on(type: 'status', handler: (status: Status) => void): BidirectionalStream<ReqT, ResT>;
}

export class DeductionProcessClient {
  readonly serviceHost: string;

  constructor(serviceHost: string, options?: grpc.RpcOptions);
  deduction(
    requestMessage: src_app_protos_DeductionProcess_pb.DeductionRequest,
    metadata: grpc.Metadata,
    callback: (error: ServiceError|null, responseMessage: src_app_protos_DeductionProcess_pb.DeductionResponse|null) => void
  ): UnaryResponse;
  deduction(
    requestMessage: src_app_protos_DeductionProcess_pb.DeductionRequest,
    callback: (error: ServiceError|null, responseMessage: src_app_protos_DeductionProcess_pb.DeductionResponse|null) => void
  ): UnaryResponse;
}

