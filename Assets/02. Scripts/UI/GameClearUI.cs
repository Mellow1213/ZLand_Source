using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{

    GameObject flag;
    Text k;
    bool t;
    EventManager kill;

    // Start is called before the first frame update
    void Start()
    {
        kill = GameObject.Find("PlayerEvent").GetComponent<EventManager>();
        flag = GameObject.Find("Clear Canvas");
        flag.gameObject.SetActive(false);
        t = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (t == true) {
            flag.gameObject.SetActive(true);
            k = GameObject.Find("kill").GetComponent<Text>();
            Time.timeScale = 0;
        }

        k.text = "Kill: "+ kill.kill.ToString();
    }

    public void OnClickRestart()
    {
        Debug.Log("재시작");
        SceneManager.LoadScene("Map"); //씬 전환
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
