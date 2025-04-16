using UnityEngine;

public class SpeedToVolume : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public float minVolume = 0.1f;
    public float maxVolume = 1f;

    private Rigidbody rb;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float speed = rb.linearVelocity.magnitude;
        float t = Mathf.InverseLerp(minSpeed, maxSpeed, speed);
        audioSource.volume = Mathf.Lerp(minVolume, maxVolume, t);
    }
}