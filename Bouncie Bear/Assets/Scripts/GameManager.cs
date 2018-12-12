using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    GameObject player;
    public float lastCrate;
    public GameObject Crate;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y < lastCrate - 3)
        {
            //morite
        }
	}
    public void generateCrate(float posx,float posy)
    {
        float randy = Random.Range(-1.5f, 1.6f);
        while (randy < posx - 0.5f || randy > posx + 0.5f)
        {
            randy = Random.Range(-3, 3.1f);
        }
        Instantiate(Crate, new Vector2(randy, posy), transform.rotation);
    }
}
