using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBird : MonoBehaviour
{

    private float speed = 1f;
    private Vector3 bird = new Vector3(0.8f, -0.5f, 0);



    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, bird, Time.deltaTime * speed);
        if (transform.position == bird && bird.x != -0.8f)
            bird.x = -0.8f;
        else if (transform.position == bird && bird.x == -0.8f)
            bird.x = 0.8f;
    }
}
