
using UnityEngine;
public class spawner : MonoBehaviour
{

    public GameObject objectToSpawn;
    public float timeTospawn;
    private float currentTimeTospawn;
    Vector3 spawPosition;
    // private float fireRate=1.0f;
    private SpriteRenderer sr;
    private Animator mAnimator;
    private AudioSource audioSource;
    public GameObject eventsystem;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator= GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(eventsystem.GetComponent<scoreManager>().score>=10){
            timeTospawn=4;
        }

        if(eventsystem.GetComponent<scoreManager>().score>=20){
            timeTospawn=3;
        }

        if(eventsystem.GetComponent<scoreManager>().score>=40){
            timeTospawn=2;
        }

         if(eventsystem.GetComponent<scoreManager>().score>=80){
            timeTospawn=1;
        }



        // spawnObject();
     if(currentTimeTospawn> 0){
        currentTimeTospawn-= Time.deltaTime;
        sr.enabled=true;
     }   
     else{
        
        playAnimation();
        currentTimeTospawn=timeTospawn;
     }
    }

 
    private void playAnimation(){
        // set animation 
        if (mAnimator !=null)
        {
                mAnimator.SetBool("isSpawn",true);
            }

    }

     // Called from the Animation Event
    public void TransitionToIdle()
    {
        // Set the "TransitionToIdle" trigger to transition back to "Idle"
        
        // Debug.Log(transform.position); //x -10 -10
        spawPosition = transform.position;
        spawPosition.x = Random.Range(-6,6);
        transform.position = spawPosition;
        playAudio();
        Instantiate(objectToSpawn,spawPosition,objectToSpawn.transform.rotation); 
        mAnimator.SetBool("isSpawn",false);
    }

    private float startTime;
    private float endTime;
    private void playAudio(){
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();

        // Ensure the start and end times are within the audio clip's duration
        startTime = Mathf.Clamp(3.0f, 0, audioSource.clip.length);
        endTime = Mathf.Clamp(0.1f, 0.0f, audioSource.clip.length);

        // Set the time to start playing the audio clip
        audioSource.time = startTime;

        // Play the audio
        audioSource.Play();
    }

}
