using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoypadSelector : MonoBehaviour {
    public enum Joypad {
        Mouse,
        Joypad0,
        Joypad1,
        Joypad2,
        Joypad3,
    };

    public Joypad joypad;
    WavePhysicsController waveController;
    SwordyBody swordyBody;

    void Awake() {
        waveController = gameObject.GetComponent<WavePhysicsController>();
        swordyBody = gameObject.GetComponentInChildren<SwordyBody>();
    }

    void Start() {
        WaveInput input = null;
        JoyWaveInput joyInput = null;
        switch (joypad) {
        case Joypad.Mouse:
            input = gameObject.AddComponent<MouseWaveInput>() as WaveInput;
            break;
        case Joypad.Joypad0:
            joyInput = gameObject.AddComponent<JoyWaveInput>();
            joyInput.axis = "Joypad0";
            input = joyInput as WaveInput;
            break;
        case Joypad.Joypad1:
            joyInput = gameObject.AddComponent<JoyWaveInput>();
            joyInput.axis = "Joypad1";
            input = joyInput as WaveInput;
            break;
        case Joypad.Joypad2:
            joyInput = gameObject.AddComponent<JoyWaveInput>();
            joyInput.axis = "Joypad2";
            input = joyInput as WaveInput;
            break;
        case Joypad.Joypad3:
            joyInput = gameObject.AddComponent<JoyWaveInput>();
            joyInput.axis = "Joypad3";
            input = joyInput as WaveInput;
            break;
        }

        waveController.input = input;
        swordyBody.waveInput = input;
    }
}
