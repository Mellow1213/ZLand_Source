using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    Health health;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        health = GameObject.Find("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickRestart()
    {
        Debug.Log("�����");
        SceneManager.LoadScene("In_game_UI"); //�� ��ȯ
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
