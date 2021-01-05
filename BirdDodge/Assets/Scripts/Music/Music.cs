using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public GameObject m_on, m_off;
    public GameObject exit;
    private void Start()
    {
        if (gameObject.name == "Music")
        {
            if (PlayerPrefs.GetString("Music") == "no")
            {
                m_on.SetActive(false);
                m_off.SetActive(true);
            }
            else
            {
                m_on.SetActive(true);
                m_off.SetActive(false);
                GetComponent<AudioSource>().Play();
            }
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exit.SetActive(true);
        }
    }
    public void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetString("Music") != "no")
            GameObject.Find("Click Audio").GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Music":
                if (PlayerPrefs.GetString("Music") != "no")
                {
                    PlayerPrefs.SetString("Music", "no");
                    m_on.SetActive(false);
                    m_off.SetActive(true);
                    GetComponent<AudioSource>().Stop();
                }
                else
                {
                    PlayerPrefs.SetString("Music", "yes");
                    m_on.SetActive(true);
                    m_off.SetActive(false);
                    GetComponent<AudioSource>().Play();
                }
                break;
            case "Play":
                PublicClass.coint = 0;
                PublicClass.x2.Item1 = PlayerPrefs.GetInt("X2");
                PublicClass.shield.Item1 = PlayerPrefs.GetInt("Shield");
                PublicClass.timer.Item1 = PlayerPrefs.GetInt("Timer");
                SceneManager.LoadScene("Play");
                break;
            case "Main Camera":
                if (PlayerPrefs.GetString("Music") != "no")
                    GetComponent<AudioSource>().Play();
                break;
            case "Yes":
                Application.Quit();
                break;
            case "No":
                exit.SetActive(false);
                break;
        }
    }
}
