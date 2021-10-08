using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public AudioSource completed;
    public Vaccine vaccineStatus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FinishHome") && vaccineStatus.vaccineStatus)
        {
            Destroy(collision.gameObject);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            completed.Play();
        }
    }
}