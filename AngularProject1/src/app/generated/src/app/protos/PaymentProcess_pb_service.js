// package: 
// file: src/app/protos/PaymentProcess.proto

var src_app_protos_PaymentProcess_pb = require("../../../src/app/protos/PaymentProcess_pb");
var grpc = require("@improbable-eng/grpc-web").grpc;

var PaymentPorcess = (function () {
  function PaymentPorcess() {}
  PaymentPorcess.serviceName = "PaymentPorcess";
  return PaymentPorcess;
}());

PaymentPorcess.Transaction = {
  methodName: "Transaction",
  service: PaymentPorcess,
  requestStream: false,
  responseStream: false,
  requestType: src_app_protos_PaymentProcess_pb.TransactionRequest,
  responseType: src_app_protos_PaymentProcess_pb.TransactionResponse
};

exports.PaymentPorcess = PaymentPorcess;

function PaymentPorcessClient(serviceHost, options) {
  this.serviceHost = serviceHost;
  this.options = options || {};
}

PaymentPorcessClient.prototype.transaction = function transaction(requestMessage, metadata, callback) {
  if (arguments.length === 2) {
    callback = arguments[1];
  }
  var client = grpc.unary(PaymentPorcess.Transaction, {
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

exports.PaymentPorcessClient = PaymentPorcessClient;

