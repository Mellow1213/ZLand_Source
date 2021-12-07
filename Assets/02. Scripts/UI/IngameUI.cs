using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item {
    public enum ItemType { Boat, Call }
    public ItemType itemType;
    public string name;
    public bool check;
}

public class IngameUI : MonoBehaviour
{

    GameObject tFlag;
    GameObject bFlag;
    Item[] bitem = new Item[6];
    Item[] citem = new Item[6];

    public Text t1, t2, t3, t4, t5, t6;
    GameObject i1, i2, i3, i4, i5, i6;

    Text gunNum, by, hp, ammo;

    int gunN, ammoN;
    GameObject gunIcon;
    public Sprite gun1, gun2;
    PlayerFire playerfire;
    Health health;
    EventManager score;


    // Start is called before the first frame update
    void Start()
    {
        playerfire = GameObject.Find("Player").GetComponent<PlayerFire>();
        health= GameObject.Find("Player").GetComponent<Health>();
        score = GameObject.Find("PlayerEvent").GetComponent<EventManager>();

        gunN = 1;
        gunIcon = GameObject.Find("Gun Icon");
        gunIcon.GetComponent<Image>().sprite = gun1;


        gunNum = GameObject.Find("Gun Num").GetComponent<Text>();
        by = GameObject.Find("By-Products").GetComponent<Text>();
        hp = GameObject.Find("HP_Text").GetComponent<Text>();
        ammo = GameObject.Find("Ammunition").GetComponent<Text>();

        tFlag = GameObject.Find("Turret info");
        tFlag.gameObject.SetActive(false);
        bFlag = GameObject.Find("Barricade info");
        bFlag.gameObject.SetActive(false);

        GameObject.Find("Boat Lock").SetActive(false);
        GameObject.Find("Call Lock").SetActive(false);

        for (int i = 0; i < bitem.Length; i++) {
            bitem[i] = new Item();
            citem[i] = new Item();
        }

        for (int i = 0; i < bitem.Length; i++)
        {
            //bitem[i].itemType = Boat;
            bitem[i].check = false;
            //citem[i].itemType = Call;
            citem[i].check = false;
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

        i1 = GameObject.Find("Item_Image");
        i2 = GameObject.Find("Item_Image(1)");
        i3 = GameObject.Find("Item_Image(2)");
        i4 = GameObject.Find("Item_Image(3)");
        i5 = GameObject.Find("Item_Image(4)");
        i6 = GameObject.Find("Item_Image(5)");

    }

    // Update is called once per frame
    void Update()
    {

        ammoN = playerfire.bullet;
        ammo.text = ammoN.ToString() + "/30";
        hp.text = "HP "+ health.health.ToString("N0") + "/100";

        by.text = score.score.ToString();

        /* if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gunN = 1;
            gunNum.text = gunN.ToString();
            gunIcon.GetComponent<Image>().sprite = gun1;
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunN = 2;
            gunNum.text = gunN.ToString();
            gunIcon.GetComponent<Image>().sprite = gun2;
            
        } */
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

        CheckItemImage();

        t1.text = bitem[0].name;
        t2.text = bitem[1].name;
        t3.text = bitem[2].name;
        t4.text = bitem[3].name;
        t5.text = bitem[4].name;
        t6.text = bitem[5].name;

    }

    public void OnclickCall() {

        CheckItemImage();

        t1.text = citem[0].name;
        t2.text = citem[1].name;
        t3.text = citem[2].name;
        t4.text = citem[3].name;
        t5.text = citem[4].name;
        t6.text = citem[5].name;

    }

    public void CheckItemImage(){
        i1.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
    }
}
