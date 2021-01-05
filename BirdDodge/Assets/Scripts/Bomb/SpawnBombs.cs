using System.Collections;
using UnityEngine;

public class SpawnBombs : MonoBehaviour {
    
    public GameObject Bombs;
    public Canvas canvas;
    public GameObject[] spec = new GameObject[6];


    void Start () {
        StartCoroutine (Spawn ());
        StartCoroutine(Spec());
    }

    IEnumerator Spawn () {
        while (!Player.lose) {
            float w = Screen.width * canvas.transform.localScale.x / 2 - Bombs.GetComponent<CircleCollider2D>().radius * Bombs.transform.localScale.x;
            Instantiate (Bombs, new Vector2 (Random.Range ( -w, w), 5.5f), Quaternion.identity);
            if (PublicClass.timer.Item2)
            {
                PublicClass.time += 0.04f;
                if (PublicClass.updateSpeed > 0.02f)
                    PublicClass.updateSpeed -= 0.02f;
                PublicClass.timer.Item2 = false;
            }
            yield return new WaitForSeconds (PublicClass.time);
        }
    }

    IEnumerator Spec()
    {
        while (!Player.lose)
        {
            yield return new WaitForSeconds(Random.Range(25f * PublicClass.time, 50f * PublicClass.time));
            if (!Player.lose)
            {
                int i = Random.Range(0, 6);
                float w = Screen.width * canvas.transform.localScale.x / 2 - spec[i].GetComponent<CircleCollider2D>().radius * spec[i].transform.localScale.x;
                Instantiate(spec[i], new Vector2(Random.Range(-w, w), 5.5f), Quaternion.identity);
            }
        }
    }
}

