#include <Arduino.h>

const int pinA = D1;
const int pinB = D2;
const int pinC = D3;
const int ledAnzahl = 6;

void alleAus() {
    pinMode(pinA, INPUT);
    pinMode(pinB, INPUT);
    pinMode(pinC, INPUT);
}

void leuchte(int plus, int minus) {
    alleAus();
    pinMode(plus, OUTPUT);
    pinMode(minus, OUTPUT);
    digitalWrite(plus, HIGH);
    digitalWrite(minus, LOW);
}

void ledAn(int nr) {
    switch (nr) {
        case 0:
            leuchte(pinA, pinB);
            break;
        case 1:
            leuchte(pinB, pinA);
            break;
        case 2:
            leuchte(pinB, pinC);
            break;
        case 3:
            leuchte(pinC, pinB);
            break;
        case 4:
            leuchte(pinA, pinC);
            break;
        case 5:
            leuchte(pinC, pinA);
            break;
        default:
            alleAus();
            break;
    }
}

void setup() {
    alleAus();
}

void loop() {
    for (int i = 0; i < ledAnzahl; i++) {
        ledAn(i);
        delay(300);
    }
}
