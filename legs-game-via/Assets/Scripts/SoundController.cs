using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip[] walkingSounds;
    public AudioClip jumpingSound;
    public AudioSource walkingSource;
    public AudioSource jumpingSource;
    public LayerMask groundLayer;

    private bool isGrounded = true;

    private void Start()
    {
        walkingSource = gameObject.AddComponent<AudioSource>();
        jumpingSource = gameObject.AddComponent<AudioSource>();

        walkingSource.loop = false;

        walkingSource.playOnAwake = false;
        jumpingSource.playOnAwake = false;

        walkingSource.volume = 1f;
        jumpingSource.volume = 1f;

        walkingSource.spatialBlend = 1f;
        jumpingSource.spatialBlend = 1f;

        walkingSource.rolloffMode = AudioRolloffMode.Linear;
        jumpingSource.rolloffMode = AudioRolloffMode.Linear;
    }

    private void Update()
{
    // Grounded check
    isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayer);

    // Walking
    if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && isGrounded)
    {
        if (!walkingSource.isPlaying)
        {
            AudioClip walkingSound = walkingSounds[Random.Range(0, walkingSounds.Length)];
            walkingSource.clip = walkingSound;
            walkingSource.Play();
        }

        // Increase the pitch of walking sounds when the player is sprinting
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            walkingSource.pitch = 1.5f; // Adjust the pitch value as desired
        }
        else
        {
            walkingSource.pitch = 1f; // Reset the pitch to normal
        }
    }
    else
    {
        walkingSource.Stop();
    }

    // Jumping
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        jumpingSource.clip = jumpingSound;
        jumpingSource.Play();
    }
}

}
