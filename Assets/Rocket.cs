using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    [SerializeField]
    float rcsThrust = 80f;

    [SerializeField]
    float mainThrust = 100f;

    Rigidbody rigidBody;
    AudioSource rocketAudio;
    Scene scene;

	// Use this for initialization
	void Start ()
    {
        scene = SceneManager.GetActiveScene();
        rigidBody = gameObject.GetComponent<Rigidbody>();
        rocketAudio = gameObject.GetComponent<AudioSource>();
	}


    // Update is called once per frame
    void Update ()
    {
        Thrust();
        Rotate();
	}

    void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!rocketAudio.isPlaying)
            {
                rocketAudio.Play();
            }
        }
        else
        {
            rocketAudio.Stop();
        }
    }

    void Rotate()
    {
        rigidBody.freezeRotation = true;

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                if(scene.buildIndex < 1)
                {
                    SceneManager.LoadScene(scene.buildIndex + 1);
                }
                break;
            default:
                SceneManager.LoadScene(scene.buildIndex);
                break;
        }
    }
}
