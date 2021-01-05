using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private ActionData data;
    public void Init(ActionData _data)
    {
        data = _data;
        GetComponent<SpriteRenderer>().sprite = data.mainSprite;
    }
    public float Speed
    {
        get { return data.speed; }
        protected set { }
    }
    public float Count
    {
        get { return data.count; }
        protected set { }
    }

    public static Action<GameObject> onActionOverFly;
    private void FixedUpdate()
    {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -data.speed);
        if (transform.position.y < -6f && onActionOverFly != null)
            onActionOverFly(gameObject);
    }
}
