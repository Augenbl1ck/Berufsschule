#include <Arduino.h>

const int gruenLed = D1;
const int gelbLed = D2;
const int rotLed = D3;
const int taster = D4;

const int leds[] = {rotLed, gelbLed, gruenLed};
const int ledCount = 3;
const int pwmMax = 255;
const int fadeSchritt = 2;
const int orangeHaltMs = 200;

int fadeSchrittMs[ledCount];
int fadeHelligkeit[ledCount];
int fadeRichtung[ledCount];
bool fadeHalten[ledCount];
unsigned long fadeLetzterSchritt[ledCount];

int ledIndex(int led) {
    for (int i = 0; i < ledCount; i++) {
        if (leds[i] == led) {
            return i;
        }
    }
    return -1;
}

void fadeAktualisieren() {
    unsigned long jetzt = millis();

    for (int i = 0; i < ledCount; i++) {
        if (fadeRichtung[i] == 0) {
            continue;
        }
        if (jetzt - fadeLetzterSchritt[i] < (unsigned long)fadeSchrittMs[i]) {
            continue;
        }

        fadeLetzterSchritt[i] = jetzt;
        fadeHelligkeit[i] += fadeRichtung[i];

        if (fadeHelligkeit[i] >= pwmMax) {
            fadeHelligkeit[i] = pwmMax;
            fadeRichtung[i] = fadeHalten[i] ? 0 : -1;
        } else if (fadeHelligkeit[i] <= 0) {
            fadeHelligkeit[i] = 0;
            fadeRichtung[i] = 0;
        }

        analogWrite(leds[i], fadeHelligkeit[i]);
    }
}

bool fadeLaeuft() {
    for (int i = 0; i < ledCount; i++) {
        if (fadeRichtung[i] != 0) {
            return true;
        }
    }
    return false;
}

void warte(unsigned long ms) {
    unsigned long start = millis();
    while (millis() - start < ms) {
        fadeAktualisieren();
        yield();
    }
}

void warteBisFertig() {
    while (fadeLaeuft()) {
        fadeAktualisieren();
        yield();
    }
}

void fadeEin(int led, int schrittMs) {
    int i = ledIndex(led);
    if (i < 0) {
        return;
    }

    fadeSchrittMs[i] = schrittMs;
    fadeHelligkeit[i] = 0;
    fadeRichtung[i] = 1;
    fadeHalten[i] = true;
    fadeLetzterSchritt[i] = millis();
    analogWrite(led, 0);
}

void fadeAus(int led, int schrittMs) {
    int i = ledIndex(led);
    if (i < 0) {
        return;
    }

    fadeSchrittMs[i] = schrittMs;
    fadeRichtung[i] = -1;
    fadeHalten[i] = false;
    fadeLetzterSchritt[i] = millis();
}

void wechsel(int vonLed, int nachLed) {
    fadeAus(vonLed, fadeSchritt);
    fadeEin(nachLed, fadeSchritt);
    warteBisFertig();
}

void warteAufTaster() {
    while (digitalRead(taster) == HIGH) {
        fadeAktualisieren();
        yield();
    }
    warte(50);

    while (true) {
        fadeAktualisieren();
        if (digitalRead(taster) == HIGH) {
            warte(50);
            if (digitalRead(taster) == HIGH) {
                return;
            }
        }
        yield();
    }
}

void setup() {
    analogWriteRange(pwmMax);
    analogWriteFreq(1000);

    pinMode(taster, INPUT);

    for (int i = 0; i < ledCount; i++) {
        pinMode(leds[i], OUTPUT);
        analogWrite(leds[i], 0);
        fadeRichtung[i] = 0;
        fadeHelligkeit[i] = 0;
        fadeHalten[i] = false;
    }

    fadeEin(rotLed, fadeSchritt);
    warteBisFertig();
}

void loop() {
    warteAufTaster();

    wechsel(rotLed, gelbLed);
    warte(orangeHaltMs);
    wechsel(gelbLed, gruenLed);

    warte(5000);

    wechsel(gruenLed, gelbLed);
    warte(orangeHaltMs);
    wechsel(gelbLed, rotLed);
}
