using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeAndRestart : MonoBehaviour
{
    private void Start()
    {
        PublicClass.lose = false;

    }
    void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetString("Music") != "no")
            GameObject.Find("Click Audio").GetComponent<AudioSource>().Play();

        switch (gameObject.name)
        {
            case "Restart":
                SceneManager.LoadScene("Play");
                break;
            case "Home":
                PlayerPrefs.SetInt("X2", PublicClass.x2.Item1);
                PlayerPrefs.SetInt("Shield", PublicClass.shield.Item1);
                PlayerPrefs.SetInt("Timer", PublicClass.timer.Item1);
                SceneManager.LoadScene("Main");
                break;
            default:
                break;
        }

        PublicClass.coint = 0;
        PublicClass.updateSpeed = 0;
        PublicClass.time = 0.8f;
    }
}
