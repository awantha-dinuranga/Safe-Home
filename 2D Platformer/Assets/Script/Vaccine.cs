using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vaccine : MonoBehaviour
{
    public AudioSource vaccinatedAudio;
    public Text statusText;
    public bool vaccineStatus = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vaccine"))
        {
            Destroy(collision.gameObject);
            statusText.text = "Vaccinated | Safe Now";
            vaccineStatus = true;

            vaccinatedAudio.Play();
        }
    }
}
