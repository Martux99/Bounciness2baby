using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAndRelease : MonoBehaviour
{
    Vector2 startPos;
    bool released = true;
    bool dragPermited=false;
    public GameObject moises;
    public GameObject estela;

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
            /*
            Instantiate(estela, transform);
            Vector2 dire = startPos - (Vector2)transform.position;
            estela.GetComponent<Rigidbody2D>().AddForce(dir * force);*/
        }
        
    }

    public float force = 1300;

    void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().freezeRotation = false;
        if (dragPermited)
        {
            /// <summary>uyuyuy</summary>
            /// mas de nuestras tarugadas por aca
            /// Quien sabe para que sirva

            dragPermited = false;
            released = true;
            
            GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            Vector2 dir = startPos - (Vector2)transform.position;
            GetComponent<Rigidbody2D>().AddForce(dir * force);
        }
        
    }

    void Start()
    {
        startPos = transform.position;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moises")
        {
            GetComponent<Rigidbody2D>().freezeRotation = true;
            GetComponent<Rigidbody2D>().isKinematic = true;
            dragPermited =true;
            moises = collision.gameObject;
        }
    }
   
}
