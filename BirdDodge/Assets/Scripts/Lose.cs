using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public GameObject restart;
    public GameObject home;
    public GameObject slider;
    public GameObject contin;
    void Start()
    {
        if (PlayerPrefs.GetString("Music") != "no")
            GetComponent<AudioSource>().Play();
        if (!PublicClass.lose)
        {
            home.SetActive(false);
            restart.SetActive(false);
            contin.SetActive(true);
            slider.SetActive(true);
            PublicClass.lose = true;
        }
        else
        {
            home.SetActive(true);
            restart.SetActive(true);
            contin.SetActive(false);
            slider.SetActive(false);
            PublicClass.lose = false;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("X2", PublicClass.x2.Item1);
            PlayerPrefs.SetInt("Shield", PublicClass.shield.Item1);
            PlayerPrefs.SetInt("Timer", PublicClass.timer.Item1);
            PublicClass.lose = false;
            SceneManager.LoadScene("Main");
            PublicClass.coint = 0;
            PublicClass.updateSpeed = 0;
            PublicClass.time = 0.8f;
        }
    }

}