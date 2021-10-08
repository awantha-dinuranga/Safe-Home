using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    int Restart = 0;
    public AudioSource restartAudio;
    public void RestartGame()
    {
        SceneManager.LoadScene(Restart);
        restartAudio.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
