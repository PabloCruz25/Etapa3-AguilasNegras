using UnityEngine;

public class DesaparecerConSonido : MonoBehaviour
{
    public AudioClip sonidoDesaparicion;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (sonidoDesaparicion != null)
        {
            audioSource.PlayOneShot(sonidoDesaparicion);
        }

        // Destruye el objeto después de que suene
        Destroy(gameObject, sonidoDesaparicion.length);
    }
}