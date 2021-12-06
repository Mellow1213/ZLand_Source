using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Transform target;
    public Vector3 relativeVec;
    private Animator anim;
    private Transform spine;
    public GameObject Avatar;

    bool aimMode = false; 
    void Start()
    {
        target = GameObject.Find("Aim").GetComponent<Transform>();
        anim = Avatar.GetComponent<Animator>();
        spine = anim.GetBoneTransform(HumanBodyBones.Spine);
    } 
    
    void Update() {
        if(Input.GetMouseButtonDown(1))
        { 
            Debug.Log("바라보기"); 
            StartCoroutine(aimModeOn()); 
        }
        else if(Input.GetMouseButtonUp(1))  
        { 
            Debug.Log("해제"); 
            StartCoroutine(aimModeOff()); 
        } 
        if(aimMode == true) { 
            spine.LookAt(target.position); 
            spine.rotation = spine.rotation * Quaternion.Euler(relativeVec);   
        } 
    } 
    IEnumerator aimModeOn()  { 
         Debug.Log("조준"); 
        yield return new WaitForSeconds(0.07f); 
        aimMode = true; 
    } 
    
    IEnumerator aimModeOff() 
    { 
        yield return new WaitForSeconds(1.0f); 
        aimMode = false; 
    }

}
