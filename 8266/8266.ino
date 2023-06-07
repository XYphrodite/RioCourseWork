#include <SPI.h>
#include <MFRC522.h>
#include "ESP8266WiFi.h"
#include <ESP8266HTTPClient.h>
#include <WiFiClient.h>

#define SS_PIN D8
#define RST_PIN D0
#define light D4

MFRC522 rfid(SS_PIN, RST_PIN);  // Instance of the class
WiFiClient wifiClient;

MFRC522::MIFARE_Key key;

// Init array that will store new NUID
byte nuidPICC[4];

//WIFI
const char* ssid = "Royal";
const char* password = "royalpswd";

const String address = "192.168.1.22";
const String port = "5000";

const String URL = "http://" + address + ":" + port + "/api/Rfid";

void setup() {
  pinMode(light, OUTPUT);
  Serial.begin(115200);

  // Connect to WiFi
  WiFi.begin(ssid, password);
  // while wifi not connected yet, print '.'
  // then after it connected, get out of the loop
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  //print a new line, then print WiFi connected and the IP address
  Serial.println("");
  Serial.println("WiFi connected");
  // Print the IP address
  Serial.println(WiFi.localIP());

  SPI.begin();      // Init SPI bus
  rfid.PCD_Init();  // Init MFRC522
  Serial.println();
  Serial.print(F("Reader :"));
  rfid.PCD_DumpVersionToSerial();

  for (byte i = 0; i < 6; i++) {
    key.keyByte[i] = 0xFF;
  }
  Serial.println();
  Serial.println(F("This code scan the MIFARE Classic NUID."));
  //Serial.print(F("Using the following key:"));
  //printHex(key.keyByte, MFRC522::MF_KEY_SIZE);
}

void loop() {
  // Reset the loop if no new card present on the sensor/reader. This saves the entire process when idle.
  if (!rfid.PICC_IsNewCardPresent()) {
    return;
  }

  // // Verify if the NUID has been readed
  if (!rfid.PICC_ReadCardSerial()) {
    return;
  }

  Serial.print(F("PICC type: "));
  MFRC522::PICC_Type piccType = rfid.PICC_GetType(rfid.uid.sak);
  Serial.println(rfid.PICC_GetTypeName(piccType));

  // Check is the PICC of Classic MIFARE type
  if (piccType != MFRC522::PICC_TYPE_MIFARE_MINI && piccType != MFRC522::PICC_TYPE_MIFARE_1K && piccType != MFRC522::PICC_TYPE_MIFARE_4K) {
    Serial.println(F("Your tag is not of type MIFARE Classic."));
    return;
  }

  if (rfid.uid.uidByte[0] != nuidPICC[0] || rfid.uid.uidByte[1] != nuidPICC[1] || rfid.uid.uidByte[2] != nuidPICC[2] || rfid.uid.uidByte[3] != nuidPICC[3]) {
    Serial.println(F("A new card has been detected."));

    // Store NUID into nuidPICC array
    for (byte i = 0; i < 4; i++) {
      nuidPICC[i] = rfid.uid.uidByte[i];
    }

    Serial.println(F("The NUID tag is:"));
    Serial.print(F("In hex: "));
    String rfId = printHex(rfid.uid.uidByte, rfid.uid.size);
    Serial.println();
    //Serial.println(rfId);
    SendRfId(rfId) ? Open() : No();
    Serial.println();
  } else Serial.println(F("Card read previously."));

  // Halt PICC
  rfid.PICC_HaltA();

  // Stop encryption on PCD
  rfid.PCD_StopCrypto1();
}


/**
   Helper routine to dump a byte array as hex values to Serial.
*/
String printHex(byte* buffer, byte bufferSize) {
  String str = "";
  for (byte i = 0; i < bufferSize; i++) {
    str += String(buffer[i], HEX);
    Serial.print(buffer[i] < 0x10 ? " 0" : " ");
    Serial.print(buffer[i], HEX);
  }
  return str;
}


bool SendRfId(String msg) {
  HTTPClient http;  //Объявить объект класса HttpClient
  http.begin(wifiClient, URL);                                          //Укажите адрес запроса
  http.addHeader("Content-Type", "application/x-www-form-urlencoded");  //Укажите заголовок типа содержимого
  String toSend = "str=" + msg;
  int httpCode = http.POST(toSend);   //Отправьте запрос
  String payload = http.getString();  //Получите полезную нагрузку ответа

  Serial.println(httpCode);  //Распечатать код возврата HTTP
  Serial.println(payload);   //Полезная нагрузка для ответа на запрос печати

  http.end();  //Закрыть соединение
  return payload == "1" ? true : false;
}

void Open() {
  for (int i = 0; i < 10; i++) {
    digitalWrite(light, HIGH);  //turn buzzer on
    delay(100);
    digitalWrite(light, LOW);  //turn buzzer off
    delay(50);
  }
}

void No() {
  digitalWrite(light, HIGH);  //turn buzzer on
  delay(1000);
  digitalWrite(light, LOW);  //turn buzzer off
}