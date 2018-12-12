using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAndRelease : MonoBehaviour
{
    Vector2 startPos;
    bool released = true;
    bool dragPermited=false;
    public GameObject moises;

    void OnMouseDrag()
    {
        if (dragPermited)
        {
            if (released)
            {
                startPos = transform.position;
                released = false;
            }
            Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float radius = 0.5f;
            Vector2 dir = p - startPos;
            if (dir.sqrMagnitude > radius)
            {
                dir = dir.normalized * radius;
            }

            transform.position = startPos + dir;
            Debug.Log(startPos + dir);
        }
        
    }

    public float force = 1300;

    void OnMouseUp()
    {
        if (dragPermited)
        {
            dragPermited = false;
            released = true;
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            Vector2 dir = startPos - (Vector2)transform.position;
            GetComponent<Rigidbody2D>().AddForce(dir * force);
            this.enabled = false;
        }
        
    }

    void Start()
    {
        startPos = transform.position;
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moises")
        {
            dragPermited=true;
            moises = collision.gameObject;
        }
    }
   
}
