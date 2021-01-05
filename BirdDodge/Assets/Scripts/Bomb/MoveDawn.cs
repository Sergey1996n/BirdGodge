using UnityEngine;

public class MoveDawn : MonoBehaviour
{

    //[SerializeField]
    private float fallSpeed = 4.5f;
    private bool score = false;
    void Update ()
    {
        if (!Player.lose)
            if (transform.position.y < -3.825f && !score)
            {
                if (PublicClass.x2.Item2)
                    PublicClass.coint += 2;
                else
                    PublicClass.coint++;
                score = !score;
            }
        if (transform.position.y < -6f)
            Destroy(gameObject);
        if (Time.timeScale != 0) 
            fallSpeed += PublicClass.updateSpeed;
        if (PublicClass.coint / 10 != PublicClass.proverkaCoint)
        {
            PublicClass.updateSpeed += 0.01f;
            PublicClass.proverkaCoint = PublicClass.coint / 10;
            PublicClass.time -= 0.02f;
        }
        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
    }
}
