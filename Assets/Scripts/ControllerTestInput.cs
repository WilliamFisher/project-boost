using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTestInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
		
	}

    void HandleInput() {
        if(Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            print("Joystick 0");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            print("Joystick 1");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            print("Joystick 2");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            print("Joystick 3");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            print("Joystick 4");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            print("Joystick 5");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            print("Joystick 6");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            print("Joystick 7");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton8))
        {
            print("Joystick 8");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            print("Joystick 9");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton10))
        {
            print("Joystick 10");
        }

    }
}
