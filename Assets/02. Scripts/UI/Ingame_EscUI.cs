using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ingame_EscUI : MonoBehaviour
{
    GameObject tFlag;
    EventManager score;

    // Start is called before the first frame update
    void Start()
    {
        tFlag = GameObject.Find("Panel");
        tFlag.gameObject.SetActive(false);
        score = GameObject.Find("PlayerEvent").GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            tFlag.gameObject.SetActive(true);
        }
    }

    public void OnClickBack()
    {
        Debug.Log("x");
        tFlag.gameObject.SetActive(false);
    }

    public void OnClickMain()
    {
        Debug.Log("메인화면으로");
        SceneManager.LoadScene("Main_Title");
    }
}
