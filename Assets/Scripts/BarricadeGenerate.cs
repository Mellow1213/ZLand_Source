using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeGenerate : MonoBehaviour
{

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.Translate(-0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(0.1f, 0.0f, 0.0f);
        }
    }

    public void OnclickBarricade() {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject barri = Instantiate(prefab) as GameObject;
        barri.transform.position = player.transform.position;

    }
}
