using UnityEngine;

public class Reverb : MonoBehaviour
{
    AudioReverbZone AudioReverbZone;

    private void Awake()
    {
        AudioReverbZone = GetComponent<AudioReverbZone>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioReverbZone.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioReverbZone.enabled = false;
        }
    }
}
