using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject lost; 
    public static bool lose = false;
    public Image[] images = new Image[3];
    public Text[] texts = new Text[3];
    public Image[] greyImage = new Image[3];
    public GameObject rating;

    void Awake() {
        lose = false; 
    }
        void OnTriggerEnter2D(Collider2D other) {
        if (/*other.gameObject.CompareTag("Bomb") && */!PublicClass.shield.Item2)
        {
            lose = true;
            if (PublicClass.rating.Item1 == 10)
                rating.SetActive(true);
            else
                lost.SetActive(true);
            
        }
        else if (other.gameObject.CompareTag("Spec") && !lose)
        {
            switch (other.name)
            {
                case "x2 Green(Clone)":
                    Green(images[0], ref PublicClass.x2.Item1, texts[0], greyImage[0]);
                    break;
                case "x2 Red(Clone)":
                    Red(ref PublicClass.x2.Item1, texts[0]);
                    break;
                case "Shield Green(Clone)":
                    Green(images[1], ref PublicClass.shield.Item1, texts[1], greyImage[1]);
                    break;
                case "Shield Red(Clone)":
                    Red(ref PublicClass.shield.Item1, texts[1]);
                    break;
                case "Time Green(Clone)":
                    Green(images[2], ref PublicClass.timer.Item1, texts[2], greyImage[2]);
                    break;
                case "Time Red(Clone)":
                    Red(ref PublicClass.timer.Item1, texts[2]);
                    break;
                default:
                    break;
            }
            Destroy(other.gameObject);
        }

        void Green(Image image, ref int inttext, Text text, Image grayImage)
        {
            if (grayImage.GetComponent<Image>().fillAmount == 0)
                image.GetComponent<CircleCollider2D>().enabled = true;
            text.text = (++inttext).ToString();
        }

        void Red(ref int inttext, Text text)
        {
            if (inttext > 0)
                text.text = (--inttext).ToString(); ;
        }
    }
}
