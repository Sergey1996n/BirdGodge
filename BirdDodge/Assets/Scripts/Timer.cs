using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject restart;
    public GameObject home;
    public GameObject contin;
    void Start()
    {
        gameObject.GetComponent<Slider>().value = 5f;
    }

    void Update()
    {
        gameObject.GetComponent<Slider>().value -= Time.deltaTime;
        if (gameObject.GetComponent<Slider>().value == 0)
        {
            restart.SetActive(true);
            home.SetActive(true);
            contin.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
