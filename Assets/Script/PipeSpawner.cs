using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject PipePrefab;
    float NextTime = 0;

    void Update()
    {
        if (GameManager.instance.isStop) return;

        if (Time.time > NextTime)
        {
            NextTime = Time.time + 1.7f;
            GameObject Pipe 
                = Instantiate(PipePrefab, new Vector3(4, Random.Range(-1f, 3.2f), 0), Quaternion.identity);
            Pipe.transform.SetParent(transform, false);
        }
    }
}
