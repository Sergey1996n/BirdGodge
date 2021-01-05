using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private BombData data;
    [Tooltip("Взрыв")]
    [SerializeField] private GameObject explosions;

    public void Init(BombData _data)
    {
        data = _data;
        GetComponent<SpriteRenderer>().sprite = data.mainSprite;
    }
    public float Speed
    {
        get { return data.speed; }
        protected set { }
    }
    /*public float Rotation
    {
        get { return data.rotation; }
        protected set { }
    }*/

    public static Action<GameObject> onBombOverFly;

    private void FixedUpdate()
    {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -data.speed);
        //transform.Rotate(Vector3.back * data.rotation);
        if (transform.position.y < -6f && onBombOverFly != null)
            onBombOverFly(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //GameController.bombsCount++;
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosions, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
