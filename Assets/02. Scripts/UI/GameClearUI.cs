using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{

    GameObject flag;
    Text k;
    EventManager end;
    EventManager kill;

    // Start is called before the first frame update
    void Start()
    {
        kill = GameObject.Find("PlayerEvent").GetComponent<EventManager>();
        end = GameObject.Find("PlayerEvent").GetComponent<EventManager>();
        flag = GameObject.Find("Clear Canvas");
        flag.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (end.gameEnd == true) {
            flag.gameObject.SetActive(true);
            k = GameObject.Find("kill").GetComponent<Text>();
            k.text = "Kill: " + kill.kill.ToString();
            Time.timeScale = 0;
        }
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
