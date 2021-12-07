using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {

    [SerializeField] float WaitForSeconds;
	public bool isBomb;


	// Update is called once per frame
	void Update () {
		Debug.Log(WaitForSeconds);
		WaitForSeconds -= Time.deltaTime;
		if(WaitForSeconds <= 0)
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
