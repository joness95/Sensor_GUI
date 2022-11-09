enum class MessageType : uint16_t {
  INVALID = 0,
  GET_HEARTBEAT = 0x01,
  GET_HEARTBEAT_RESPONSE = 0x02,
  SET_PARAMETER = 0x03,
  SET_PARAMETER_RESPONSE = 0x04,
  GET_PARAMETER = 0x05,
  GET_PARAMETER_RESPONSE = 0x06,
  DATA_FLOAT = 0x10,
  DATA_DOUBLE,
  DATA_INT8 = 0x20,
  DATA_UINT8,
  DATA_INT16,
  DATA_UINT16,
  DATA_INT32,
  DATA_UINT32,
  DATA_INT64,
  DATA_UINT64,
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
  virtual uint8_t ToArray() = 0;
  virtual void FromByteArray(uint8_t* data) = 0;
};

template<typename  T>
class DataMessage : public ISerializable {
public:
	MessageHead Head;
	uint16_t MeassurementNumber;
	T Value;
};