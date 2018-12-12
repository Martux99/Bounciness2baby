using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estelita : MonoBehaviour {

    public GameObject punto;

	// Use this for initialization
	void Start () {
        StartCoroutine(generador());
        Destroy(gameObject, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator generador()
    {
        while (true)
        {
            Instantiate(punto, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);

        }
    }
}
