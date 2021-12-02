using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {

    [SerializeField] float WaitForSeconds = 1f;
	public bool isBomb;


	// Update is called once per frame
	void Update () {
        Destroy(gameObject, WaitForSeconds);		
	}

	void OnTriggerEnter(Collider other)
    {
		if (other.transform.gameObject.GetComponent<Health>() != null 
			&& other.gameObject.tag != "Player"
			&& isBomb)
			other.transform.gameObject.GetComponent<Health>().health -= 30f;

	}


}
