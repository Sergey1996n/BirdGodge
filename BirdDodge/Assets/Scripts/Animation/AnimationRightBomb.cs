using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRightBomb : MonoBehaviour
{
    private float speed = 1f;
    private Vector3 bomb = new Vector3(0.8f, 1.1f, 0);

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, bomb, Time.deltaTime * speed);
        if (transform.position == bomb && bomb.y != 1.1f)
            bomb.y = 1.1f;
        else if (transform.position == bomb && bomb.y == 1.1f)
            bomb.y = -0.5f;
    }
}
