using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    void FixedUpdate()
    {
        if (GameManager.instance.isStop) return;

        transform.Translate(-0.03f, 0, 0);
        if(transform.position.x < -4)
            Destroy(gameObject);
    }
}
