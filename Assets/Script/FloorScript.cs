using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    void FixedUpdate()
    {
        if (GameManager.instance.isStop) return;

        transform.Translate(-0.03f, 0, 0);

        if (transform.position.x <= -3.3275)
            transform.position = new Vector3(3.3275f, -4, 0);
    }
}
