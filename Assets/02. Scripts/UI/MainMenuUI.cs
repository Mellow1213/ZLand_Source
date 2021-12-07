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
        Debug.Log("����");
        SceneManager.LoadScene("Map"); //�� ��ȯ
    }

    public void OnClickHowTo() {
        Debug.Log("���� ���");
        flag.gameObject.SetActive(true); //â ����
    }

    public void OnClickBack() {
        Debug.Log("x");
        flag.gameObject.SetActive(false); //â �ݱ�
    }

    public void OnClickQuit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
