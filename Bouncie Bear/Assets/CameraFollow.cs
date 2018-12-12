using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject kodak;
    public Transform pos;

	void Start () {
        pos = transform;

	}
	
	// Update is called once per frame
	void Update () {
        if (pos.position.y > kodak.transform.position.y)
        {
            kodak.transform.position = new Vector3(0, pos.position.y,-10);
        }

	}
}
