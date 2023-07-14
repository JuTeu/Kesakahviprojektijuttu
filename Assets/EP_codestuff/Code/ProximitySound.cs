using UnityEngine;

public class ProximitySound : MonoBehaviour
{
    public float proximityDistance = 20f; // Distance at which the sound starts playing
    private AudioSource audioSource;
    private GameObject player;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= proximityDistance)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
