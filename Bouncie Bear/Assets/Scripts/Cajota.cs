using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajota : MonoBehaviour {

    Rigidbody2D player;
    GameManager gm;
    bool generatedNext=false;
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            gm.lastCrate = this.transform.position.y;
            player = collision.gameObject.GetComponent<Rigidbody2D>();
            //player.gravityScale = 0;
            player.velocity = new Vector2(0, 0);
            player.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.5f);
            if (generatedNext == false)
            {
                gm.generateCrate(transform.position.x,transform.position.y);
                generatedNext = true;

            }
        }
    }

}
