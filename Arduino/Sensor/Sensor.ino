#include "MQ131.h"
#include <stdint.h>
#include "Message.hpp"
uint8_t testval = 0;


unsigned long lastTimeCalled;

uint32_t CYCLETIME = 5000;




void Send_GET_Parameter_CYCLETIME_Response() {
  GetParameterResponse response;
  response.MessageHead.MsgType = MessageType::GET_PARAMETER_RESPONSE;
  response.ParameterNumber = ParameterNumber::CYCLETIME;
  memcpy(&response.Value, &CYCLETIME, 2);
  response.MessageHead.MsgLength = 8;
  Serial.write((uint8_t *)&response, ((uint8_t *)&response.MessageHead.MsgLength)[0]);
}

void SET_Parameter(SetParameterRequest request) {

  memcpy(&CYCLETIME, request.Value, 2);
  GetParameterResponse response;
  response.MessageHead.MsgType = MessageType::SET_PARAMETER_RESPONSE;
  response.ParameterNumber = ParameterNumber::CYCLETIME;
  memcpy(&response.Value, &CYCLETIME, 2);
  response.MessageHead.MsgLength = 8;
  Serial.write((uint8_t *)&response, ((uint8_t *)&response.MessageHead.MsgLength)[0]);
}

void GET_Parameter(GetParameterRequest request) {
  switch (request.ParameterNumber) {
    case ParameterNumber::CYCLETIME:
      Send_GET_Parameter_CYCLETIME_Response();
      break;
    default:
      break;
  }
}

void RecieveMessages() {
  if (Serial.available() > 0) {
    MessageHead head;

    Serial.readBytes((uint8_t *)&head, 4);

    uint8_t data[head.MsgLength];
    Serial.readBytes(data, head.MsgLength);

    switch (head.MsgType) {
      case MessageType::GET_PARAMETER:
        GetParameterRequest Get_param_request;
        Get_param_request.MessageHead = head;
        memcpy(&Get_param_request.ParameterNumber, data, head.MsgLength - 4);
        GET_Parameter(Get_param_request);
        break;
      case MessageType::SET_PARAMETER:
        SetParameterRequest Set_param_request;
        Set_param_request.MessageHead = head;
        memcpy(&Set_param_request.ParameterNumber, data, head.MsgLength - 4);
        SET_Parameter(Set_param_request);
        break;
      default:


        break;
    }
  }
}




void setup() {
  Serial.begin(115200);

}

void customDelay(unsigned long milliseconds) {
  unsigned long ms = 0;
  while (milliseconds - ms > 100) {
    RecieveMessages();
    delay(100);
    ms+=100;
  }
    RecieveMessages();

  delay(milliseconds-ms);
  

}

void loop() {
  SendData(0, testval);
  SendData(1, 255-testval);
  SendData(2, float(random()%100)/1.23f);

  testval++;


  customDelay(CYCLETIME);
}


  // Init the sensor
  // - Heater control on pin 2
  // - Sensor analog read on pin A0
  // - Model LOW_CONCENTRATION
  // - Load resistance RL of 1MOhms (1000000 Ohms)
  //MQ131.begin(2,A0, LOW_CONCENTRATION, 1000000);

  //Serial.println("Calibration in progress...");
  //
  ////MQ131.calibrate();
  //
  //Serial.println("Calibration done!");
  //Serial.print("R0 = ");
  //Serial.print(MQ131.getR0());
  //Serial.println(" Ohms");
  //Serial.print("Time to heat = ");
  //Serial.print(MQ131.getTimeToRead());
  //Serial.println(" s");


  //DataMessage m;
  //m.Head.MsgType = MessageType::PARAMETER_UINT16;
  //m.Head.MsgLength = sizeof(m)-sizeof(MessageHead);
  //m.ParameterNumber = 0;
  //m.Data = new uint8_t[2];
  //int value = 1000;
  //memcpy(m.data,&value,2);
  //
  //Serial.write((char*)&m, sizeof(m));
  //float f = 32.2f;

  //Serial.println("Sampling...");
  //MQ131.sample();
  //Serial.print("Concentration O3 : ");
  //Serial.print(MQ131.getO3(PPM));
  //Serial.println(" ppm");
  //Serial.print("Concentration O3 : ");
  //Serial.print(MQ131.getO3(PPB));
  //Serial.println(" ppb");
  //Serial.print("Concentration O3 : ");
  //Serial.print(MQ131.getO3(MG_M3));
  //Serial.println(" mg/m3");
  //Serial.print("Concentration O3 : ");
  //Serial.print(MQ131.getO3(UG_M3));
  //Serial.println(" ug/m3");