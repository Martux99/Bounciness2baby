using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAndRelease : MonoBehaviour
{

    Vector2 startPos;

    void OnMouseDrag()
    {
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float radius = 1f;
        Vector2 dir = p - startPos;
        if (dir.sqrMagnitude > radius)
        {
            dir = dir.normalized * radius;
        }

        transform.position = startPos + dir;
        Debug.Log(startPos + dir);
    }

    public float force = 1300;

    void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;

        Vector2 dir = startPos - (Vector2)transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * force);
        this.enabled = false;
    }

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {

    }
}
