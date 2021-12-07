using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    Health health;
    GameObject flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = GameObject.Find("GameOver Canvas");
        flag.gameObject.SetActive(false);
        health = GameObject.Find("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health == 0){
            flag.gameObject.SetActive(true);
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
