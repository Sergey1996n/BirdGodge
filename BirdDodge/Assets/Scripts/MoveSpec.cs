using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpec : MonoBehaviour
{
    private float fallSpeed = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6f)
            Destroy(gameObject);
        fallSpeed += PublicClass.updateSpeed;
        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);

    }
}
