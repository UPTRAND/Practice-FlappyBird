using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public AudioSource BirdSound_1, BirdSound_2, BirdSound_3, BirdSound_4;

    Rigidbody2D rig;
    Animator ani;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        rig.AddForce(Vector3.up * 270);
    }

    void Update()
    {
        ani.SetFloat("Velocity", rig.velocity.y);
        if (transform.position.y > 4.75f) 
            transform.position = new Vector3(-1.5f, 4.75f, 0);

        if (rig.velocity.y > 0) 
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, 30f, rig.velocity.y / 8f));
        else 
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, -90f, -rig.velocity.y / 8f));

        if (GameManager.instance.isStop) return;

        if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            rig.velocity = Vector3.zero;
            rig.AddForce(Vector3.up * 270);
            BirdSound_1.Play();
        }

    }
void Die()
    {
        Debug.Log("aaa");
        if (!GameManager.instance.isStop)
            BirdSound_3.Play();
        GameManager.instance.isStop = true;
        GameManager.instance.uiManager.GameOver();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            GameManager.instance.uiManager.SetQuit();
            Die();
        }
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("ScorePoint"))
        {
            GameManager.instance.Score++;
            BirdSound_2.Play();
        }

    }
}
