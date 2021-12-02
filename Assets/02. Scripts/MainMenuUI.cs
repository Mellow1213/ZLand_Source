using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    GameObject flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = GameObject.Find("How UI");
        flag.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStart() {
        Debug.Log("시작");
        SceneManager.LoadScene("Map"); //씬 전환
    }

    public void OnClickHowTo() {
        Debug.Log("게임 방법");
        flag.gameObject.SetActive(true); //창 열기
    }

    public void OnClickBack() {
        Debug.Log("x");
        flag.gameObject.SetActive(false); //창 닫기
    }

    public void OnClickQuit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
