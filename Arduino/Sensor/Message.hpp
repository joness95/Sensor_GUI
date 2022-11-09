#include <stdint.h>

enum class MessageType : uint16_t {
  INVALID = 0,
  GET_HEARTBEAT = 0x01,
  GET_HEARTBEAT_RESPONSE,
  SET_PARAMETER,
  SET_PARAMETER_RESPONSE,
  GET_PARAMETER,
  GET_PARAMETER_RESPONSE,
  INITIALIZE,
  INITIALIZE_RESPONSE,

  PARAMETER_FLOAT = 0x100,
  PARAMETER_DOUBLE,
  PARAMETER_INT8 = 0x110,
  PARAMETER_UINT8,
  PARAMETER_INT16,
  PARAMETER_UINT16,
  PARAMETER_INT32,
  PARAMETER_UINT32,
  PARAMETER_INT64,
  PARAMETER_UINT64,
};

enum class ParameterNumber : uint16_t {
  INVALID = 0,
  CYCLETIME
};

struct MessageHead {
  MessageType MsgType;
  uint16_t MsgLength;
};

struct GetParameterRequest {
  MessageHead MessageHead;
  ParameterNumber ParameterNumber;
};
struct GetParameterResponse {
  MessageHead MessageHead;
  ParameterNumber ParameterNumber;
  uint8_t Value[256];
};

struct SetParameterResponse {
  MessageHead MessageHead;
  ParameterNumber ParameterNumber;
  uint8_t Value[256];
};

struct SetParameterRequest {
  MessageHead MessageHead;
  ParameterNumber ParameterNumber;
  uint8_t Value[256];
};

class ISerializable {
public:
  virtual uint8_t ToArray(uint8_t* dest) = 0;
  virtual void FromByteArray(uint8_t *data, int length) = 0;
};

template<typename T>
struct DataMessage : ISerializable {
public:
  MessageHead Head;
  uint16_t MeassurementNumber;
  T Value;
   uint8_t ToArray(uint8_t* dest){
    memcpy(dest,&Head.MsgType,2);
    memcpy(dest+2,&Head.MsgLength,2);
    memcpy(dest+4,&MeassurementNumber,2);
    memcpy(dest+6,&Value,sizeof(T));

    return 4+2+sizeof(T);
  };
   void FromByteArray(uint8_t *data, int length)
  {

  };
};


template<typename T>
void SendData(MessageType type, uint16_t MeassurementNumber, T data) {
  DataMessage<T> msg;
  msg.Head.MsgType =type;
  msg.Head.MsgLength = 6+sizeof(T);
  msg.MeassurementNumber = MeassurementNumber;
  msg.Value = data;

  uint8_t buff[msg.Head.MsgLength];
  uint8_t len = msg.ToArray(buff);

  Serial.write(buff, len);
};

void SendData(uint16_t MeassurementNumber, uint8_t data) {
  SendData<uint8_t>(MessageType::PARAMETER_UINT8 ,MeassurementNumber,data);
};
void SendData(uint16_t MeassurementNumber, uint16_t data) {
  SendData<uint16_t>(MessageType::PARAMETER_UINT16 ,MeassurementNumber,data);
};
void SendData(uint16_t MeassurementNumber, uint32_t data) {
  SendData<uint32_t>(MessageType::PARAMETER_UINT32 ,MeassurementNumber,data);
};
void SendData(uint16_t MeassurementNumber, uint64_t data) {
  SendData<uint64_t>(MessageType::PARAMETER_UINT64 ,MeassurementNumber,data);
};

void SendData(uint16_t MeassurementNumber, int8_t data) {
  SendData<int8_t>(MessageType::PARAMETER_INT8 ,MeassurementNumber,data);
};
void SendData(uint16_t MeassurementNumber, int16_t data) {
  SendData<int16_t>(MessageType::PARAMETER_INT16 ,MeassurementNumber,data);
};
void SendData(uint16_t MeassurementNumber, int32_t data) {
  SendData<int32_t>(MessageType::PARAMETER_INT32 ,MeassurementNumber,data);
};
void SendData(uint16_t MeassurementNumber, int64_t data) {
  SendData<int64_t>(MessageType::PARAMETER_INT64 ,MeassurementNumber,data);
};

void SendData(uint16_t MeassurementNumber, float data) {
  SendData<float>(MessageType::PARAMETER_FLOAT ,MeassurementNumber,data);
};
void SendData(uint16_t MeassurementNumber, double data) {
  SendData<double>(MessageType::PARAMETER_DOUBLE ,MeassurementNumber,data);
};
