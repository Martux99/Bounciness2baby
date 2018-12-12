using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    GameObject player;
    public float lastCrate;
    public GameObject Crate;
    bool arreglado = false;

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
        float randy = Random.Range(-2f, 2f);
        Debug.Log(randy);
        Debug.Log(posx);
        if ((randy > posx - 0.5f && randy<0) || (randy < posx + 0.5f && randy>0))
        {
            if (randy < 0)
            {
                randy = 2f;
            }
            else
                randy = -2f;
            Debug.Log("Correcion");
        }
        
        Instantiate(Crate, new Vector2(randy, posy+3.0f), transform.rotation);
    }
}
