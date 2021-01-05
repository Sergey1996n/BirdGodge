using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SpecButton : MonoBehaviour
{
    public Text textButton;
    public Image circleGray;
    void Start()
    {
        switch (gameObject.name)
        {
            case "X2":
                Text(PublicClass.x2.Item1);
                break;
            case "Shield":
                Text(PublicClass.shield.Item1);
                break;
            case "Time":
                Text(PublicClass.timer.Item1);
                break;
            default:
                break;
        }
        gameObject.GetComponent<CircleCollider2D>().radius = Screen.width / 8.571428571428f;
        circleGray.GetComponent<Image>().fillAmount = 0;
    }

    void Text(int inttext)
    {
        if (inttext > 0)
            textButton.text = inttext.ToString();
        else
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void OnMouseUpAsButton()
    {
        if (!Player.lose && Time.timeScale != 0)
        switch (gameObject.name)
        {
            case "X2":
                StartCoroutine(EnumeratorX2());
                break;
            case "Shield":
                StartCoroutine(EnumeratorShield());
                break;
            case "Time":
                StartCoroutine(EnumeratorTimer());
                break;
            default:
                break;
        }
    }

    IEnumerator EnumeratorX2()
    {
        if (PublicClass.x2.Item1 > 0)
        {
            circleGray.GetComponent<Image>().fillAmount = 1;
            textButton.text = (--PublicClass.x2.Item1).ToString();
            PublicClass.x2.Item2 = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(EnumeratorFillAmount());
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            PublicClass.x2.Item2 = false;
        }
        else
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        StopCoroutine(EnumeratorX2());
    }

    IEnumerator EnumeratorShield()
    {
        if (PublicClass.shield.Item1 > 0)
        {
            circleGray.GetComponent<Image>().fillAmount = 1;
            textButton.text = (--PublicClass.shield.Item1).ToString();
            PublicClass.shield.Item2 = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(EnumeratorFillAmount());
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            PublicClass.shield.Item2 = false;
        }
        else
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        StopCoroutine(EnumeratorShield());
    }

    IEnumerator EnumeratorTimer()
    {
        if (PublicClass.timer.Item1 > 0)
        {
            circleGray.GetComponent<Image>().fillAmount = 1;
            textButton.text = (--PublicClass.timer.Item1).ToString();
            PublicClass.timer.Item2 = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(EnumeratorFillAmount());
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        else
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        StopCoroutine(EnumeratorTimer());
    }

    IEnumerator EnumeratorFillAmount()
    {
        while(circleGray.GetComponent<Image>().fillAmount != 0) 
        { 
            circleGray.GetComponent<Image>().fillAmount -= 0.004f;
            yield return new WaitForSeconds(0.01f);
        }
            StopCoroutine(EnumeratorFillAmount());
    }
}
