using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EfectoSonido : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
   
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            audioSource.Play();
        }
    }
}
