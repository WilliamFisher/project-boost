using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    AudioSource audioSource;
    private bool audioActive = false;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        if (!audioActive)
        {
            DontDestroyOnLoad(this.gameObject);
            audioActive = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Minus))
        {
            audioSource.volume -= 0.1f;
        }
        if(Input.GetKeyDown(KeyCode.Equals))
        {
            audioSource.volume += 0.1f;
        }
	}
}
