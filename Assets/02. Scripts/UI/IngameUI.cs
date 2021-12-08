using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item {
    public string name;
}

public class IngameUI : MonoBehaviour
{

    GameObject tFlag;
    GameObject bFlag;
    Item[] bitem = new Item[6];
    Item[] citem = new Item[6];

    public Text t1, t2, t3, t4, t5, t6, c;

    Text gunNum, by, hp, ammo;

    public Slider hpBar;

    int gunN, ammoN;

    GameObject gunIcon, count;
    public GameObject wave;

    public Sprite gun;

    PlayerFire playerfire;
    Health health;
    EventManager score;
    EventManager fTime;


    // Start is called before the first frame update
    void Start()
    {
        playerfire = GameObject.Find("Player").GetComponent<PlayerFire>();
        health= GameObject.Find("Player").GetComponent<Health>();
        score = GameObject.Find("PlayerEvent").GetComponent<EventManager>();
        fTime = GameObject.Find("PlayerEvent").GetComponent<EventManager>();
        count = GameObject.Find("Count");
        
        count.gameObject.SetActive(false);

        gunN = 1;
        gunIcon = GameObject.Find("Gun Icon");
        gunIcon.GetComponent<Image>().sprite = gun;


        gunNum = GameObject.Find("Gun Num").GetComponent<Text>();
        by = GameObject.Find("By-Products").GetComponent<Text>();
        hp = GameObject.Find("HP_Text").GetComponent<Text>();
        ammo = GameObject.Find("Ammunition").GetComponent<Text>();

        tFlag = GameObject.Find("Grenade info");
        tFlag.gameObject.SetActive(false);
        bFlag = GameObject.Find("Barricade info");
        bFlag.gameObject.SetActive(false);

        GameObject.Find("Boat Lock").SetActive(false);
        GameObject.Find("Call Lock").SetActive(false);

        for (int i = 0; i < bitem.Length; i++) {
            bitem[i] = new Item();
            citem[i] = new Item();
        }

        t1.text = bitem[0].name = "통나무";
        t2.text = bitem[1].name = "줄";
        t3.text = bitem[2].name = "나무 판자";
        t4.text = bitem[3].name = "천";
        t5.text = bitem[4].name = "나무 막대";
        t6.text = bitem[5].name = "노";

        citem[0].name = "못";
        citem[1].name = "철판";
        citem[2].name = "라디오";
        citem[3].name = "건전지";
        citem[4].name = "마이크";
        citem[5].name = "망치";

    }

    // Update is called once per frame
    void Update()
    {

        ammoN = playerfire.bullet;
        ammo.text = ammoN.ToString() + "/30";
        hp.text = "HP "+ health.health.ToString("N0") + "/100";

        by.text = score.score.ToString();

        hpBar.value = (float)health.health / 100;

        if (wave.activeSelf == true)
        {
            count.gameObject.SetActive(true);
            c.text = fTime.finalTimer.ToString("N2");
        }

    }

    public void OnMouseOver_t() {
        tFlag.gameObject.SetActive(true);
    }

    public void OnMouseOver_b()
    {
        bFlag.gameObject.SetActive(true);
    }

    public void OnMouseExit_t()
    {
        tFlag.gameObject.SetActive(false);
    }

    public void OnMouseExit_b()
    {
        bFlag.gameObject.SetActive(false);
    }

    public void OnclickBoat() {

        t1.text = bitem[0].name;
        t2.text = bitem[1].name;
        t3.text = bitem[2].name;
        t4.text = bitem[3].name;
        t5.text = bitem[4].name;
        t6.text = bitem[5].name;

    }

    public void OnclickCall() {

        t1.text = citem[0].name;
        t2.text = citem[1].name;
        t3.text = citem[2].name;
        t4.text = citem[3].name;
        t5.text = citem[4].name;
        t6.text = citem[5].name;

    }
}
