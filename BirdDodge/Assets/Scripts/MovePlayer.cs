using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public Transform unnamed;
    public Canvas canvas;
    private Vector2 vector2 = new Vector2(-0.5f, -3f);
    [SerializeField]
    private float speed = 10f;

    void OnMouseDrag() 
    {
        if (!Player.lose)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float w = Screen.width * canvas.transform.localScale.x / 2 - unnamed.GetComponent<CircleCollider2D>().radius * unnamed.transform.localScale.x;
            mousePos.x = mousePos.x > w ? w : mousePos.x;
            mousePos.x = mousePos.x < -w ? -w : mousePos.x;
            unnamed.position = Vector2.MoveTowards(unnamed.position,
                new Vector2(mousePos.x, unnamed.position.y),
                speed * Time.deltaTime);
            if (unnamed.position.x > vector2.x)
                unnamed.GetComponentInChildren<SpriteRenderer>().flipX = false;
            else if (unnamed.position.x < vector2.x)
                unnamed.GetComponentInChildren<SpriteRenderer>().flipX = true;
            vector2 = unnamed.position;
            if (PlayerPrefs.GetInt("Score") < PublicClass.coint)
                PlayerPrefs.SetInt("Score", PublicClass.coint);
        }
    }

}
