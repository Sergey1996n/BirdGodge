using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesAndNo : MonoBehaviour
{
    public GameObject rating;
    public GameObject lost;

    private void Start()
    {
        if (PlayerPrefs.GetString("Rating") == "yes")
            PublicClass.rating.Item2 = true;
        else
            PublicClass.rating.Item2 = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            rating.SetActive(false);
            lost.SetActive(true);
        }
    }
    private void OnMouseUpAsButton()
    {
        if (gameObject.name == "Okey")
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.TsatsenkoSergey.BirdDodge");
        if (PublicClass.rating.Item2)
            PlayerPrefs.SetString("Rating", "yes");
        else
            PlayerPrefs.SetString("Rating", "no");
        rating.SetActive(false);
        Player.lose = true;
        lost.SetActive(true);
    }
}
