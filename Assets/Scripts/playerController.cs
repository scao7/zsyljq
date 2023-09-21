
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator mAnimator;
    private SpriteRenderer sr;
    public float moveSpeed = 10.0f;
    private Rigidbody2D rb;
    public GameObject bulletPrefeb;
    public Transform firePoint;
    public float fireRate = 1.0f; // The time delay between shots (1 shot per second)
    private float nextFireTime; // Time at which the next shot can be fired
    private AudioSource audioSource;

    void Start()
    {
        mAnimator= GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){
      
    }
    void FixedUpdate()
    {
        blow();
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // Debug.Log(horizontalInput);
        Vector3 movement = new Vector3(horizontalInput,0.0f,0.0f);
        rb.velocity = movement*moveSpeed;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Exit the game (or application)
            SceneManager.LoadScene("menu");
        }

    }

    private void blow(){
        // set animation 
        if (mAnimator !=null)
        {
            if (Input.GetKey(KeyCode.Space)){
                mAnimator.SetBool("isBlow",true);
                // Debug.Log(sr.sprite.name);
                if (sr.sprite.name=="ljq_21"){
                    if (Time.time >= nextFireTime){
                        Instantiate(bulletPrefeb,firePoint);
                        playAudio();
                        nextFireTime = Time.time + 1 / fireRate;
                    }

                    
                }
                
            }
            else{
                 mAnimator.SetBool("isBlow",false);
            }
        }
    }

    private float startTime;
    private float endTime;
    private void playAudio(){
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();

        // Ensure the start and end times are within the audio clip's duration
        startTime = Mathf.Clamp(0.3f, 0, audioSource.clip.length);
        endTime = Mathf.Clamp(0.1f, 0.0f, audioSource.clip.length);

        // Set the time to start playing the audio clip
        audioSource.time = startTime;

        // Play the audio
        audioSource.Play();
    }


}
