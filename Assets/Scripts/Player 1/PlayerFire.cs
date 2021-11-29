using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bulletEffect;
    public GameObject fireEffect;
    public GameObject bulletSound;
    public GameObject reloadSound;
    public GameObject firepos;
    public float damage;

    [HideInInspector] public float fireCooltime; // 발사 사이 딜레이 (= 연사속도)
    [HideInInspector] public int bullet; // 남은 총알 갯수
    bool out_of_bullet; // 장전 필요성 판단


    public float throwPower = 15f; // 수류탄 던지는 힘
    // Start is called before the first frame update
    void Start()
    {
        out_of_bullet = false;
        bullet = 30;
        fireCooltime = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("bullet = "+bullet);
        //Debug.Log("fireCooltime = " + fireCooltime);
        Bomb();
        Shoot();
    }
    // 수류탄 발사
    void Bomb()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }

    }

    // 총알 발사
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bullet = 0;
        }
        // 장전 매커니즘
        if (bullet <= 0)
        {
            if (!out_of_bullet)
            {
                reloadSound.gameObject.GetComponent<AudioSource>().Play();
                fireCooltime = 1.5f;
                out_of_bullet = true;
            }
            if (fireCooltime <= 0)
            {
                bullet = 30;
                out_of_bullet = false;
            }
        }

        fireCooltime -= Time.deltaTime; // 딜레이

        // 총알이 한번 발사될 때 단위로 일어나는 스크립트
        OneShot();
    }

    void OneShot()
    {
        if (Input.GetMouseButton(0) && fireCooltime <= 0f && bullet > 0)
        {
            bullet--;
            fireCooltime = 0.1f;
            GameObject sound = Instantiate(bulletSound);
            GameObject fire = Instantiate(fireEffect);
            fire.transform.position = firepos.transform.position;

            //총알 발사 스크립트 : 실제 착탄 이미지
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.transform.position,
                Camera.main.transform.forward, out hitInfo, 300f))
            {
                // 총알 맞은 적 체력 감소
                // 총알 맞은 오브젝트가 Health 컴포넌트 보유 시에만 작동
                if(hitInfo.transform.gameObject.GetComponent<Health>() != null)
                    hitInfo.transform.gameObject.GetComponent<Health>().health-=damage;

                GameObject bullet = Instantiate(bulletEffect);
                Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);
                bullet.transform.position = hitInfo.point;
                bullet.transform.forward = hitInfo.normal;
            }
        }

    }
   
}
