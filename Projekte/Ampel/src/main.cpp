#include <Arduino.h>

const int rotLed = D1;
const int gelbLed = D2;
const int gruenLed = D3;

void alleAus() {
    digitalWrite(rotLed, LOW);
    digitalWrite(gelbLed, LOW);
    digitalWrite(gruenLed, LOW);
}

template <size_t N>
void leuchteNur(int (&leds)[N]) {
    alleAus()
    for (size_t i = 0; i < N; i++) {
        digitalWrite(leds[i], HIGH);
    }
}

void setup() {
    pinMode(rotLed, OUTPUT);
    pinMode(gelbLed, OUTPUT);
    pinMode(gruenLed, OUTPUT);
}

void loop() {
    int ampel[] = {rotLed, gelbLed};
    leuchteNur(ampel);
}
