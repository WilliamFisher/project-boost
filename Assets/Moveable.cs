﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Moveable : MonoBehaviour {

    [SerializeField]
    Vector3 movementVector = new Vector3(10f, 10f, 10f);

    [SerializeField]
    float period = 2f;

    float movementFactor;
    Vector3 startingPos;

	void Start () {
        startingPos = transform.position;
	}
	
	void Update () {
        if (period <= Mathf.Epsilon) { return; }

        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
	}
}
