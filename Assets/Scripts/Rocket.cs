using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 80f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float levelLoadDelay = 2f;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;

    Rigidbody rigidBody;
    AudioSource rocketAudio;
    Scene scene;

    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

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
        if(state == State.Alive)
        {
            Thrust();
            Rotate();
        }
	}

    void Thrust()
    {
        if (Input.GetButton("Fire1"))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!rocketAudio.isPlaying)
            {
                rocketAudio.PlayOneShot(mainEngine);
            }
            mainEngineParticles.Play();
        }
        else
        {
            rocketAudio.Stop();
            mainEngineParticles.Stop();
        }
    }

/*    void Thrust()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            print(Input.GetAxis("Fire1"));
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!rocketAudio.isPlaying)
            {
                rocketAudio.PlayOneShot(mainEngine);
            }
            mainEngineParticles.Play();
        }
        else
        {
            rocketAudio.Stop();
            mainEngineParticles.Stop();
        }
    }*/

    void Rotate()
    {
        rigidBody.angularVelocity = Vector3.zero;

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        var x = Input.GetAxis("Horizontal");

        transform.Rotate(0, 0, -x * rotationThisFrame);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        state = State.Transcending;
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(success);
        successParticles.Play();
        Invoke("LoadNextScene", levelLoadDelay);
    }

    void StartDeathSequence()
    {
        state = State.Dying;
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(death);
        deathParticles.Play();
        Invoke("ReloadScene", levelLoadDelay);
    }

    void LoadNextScene()
    {
        int nextSceneIndex = scene.buildIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene("End");
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(scene.buildIndex);
    }
}
