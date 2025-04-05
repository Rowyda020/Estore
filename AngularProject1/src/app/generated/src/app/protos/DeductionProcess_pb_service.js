// package: 
// file: src/app/protos/DeductionProcess.proto

var src_app_protos_DeductionProcess_pb = require("../../../src/app/protos/DeductionProcess_pb");
var grpc = require("@improbable-eng/grpc-web").grpc;

var DeductionProcess = (function () {
  function DeductionProcess() {}
  DeductionProcess.serviceName = "DeductionProcess";
  return DeductionProcess;
}());

DeductionProcess.Deduction = {
  methodName: "Deduction",
  service: DeductionProcess,
  requestStream: false,
  responseStream: false,
  requestType: src_app_protos_DeductionProcess_pb.DeductionRequest,
  responseType: src_app_protos_DeductionProcess_pb.DeductionResponse
};

exports.DeductionProcess = DeductionProcess;

function DeductionProcessClient(serviceHost, options) {
  this.serviceHost = serviceHost;
  this.options = options || {};
}

DeductionProcessClient.prototype.deduction = function deduction(requestMessage, metadata, callback) {
  if (arguments.length === 2) {
    callback = arguments[1];
  }
  var client = grpc.unary(DeductionProcess.Deduction, {
    request: requestMessage,
    host: this.serviceHost,
    metadata: metadata,
    transport: this.options.transport,
    debug: this.options.debug,
    onEnd: function (response) {
      if (callback) {
        if (response.status !== grpc.Code.OK) {
          var err = new Error(response.statusMessage);
          err.code = response.status;
          err.metadata = response.trailers;
          callback(err, null);
        } else {
          callback(null, response.message);
        }
      }
    }
  });
  return {
    cancel: function () {
      callback = null;
      client.close();
    }
  };
};

exports.DeductionProcessClient = DeductionProcessClient;

