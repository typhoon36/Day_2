using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCtrl : MonoBehaviour
{
    public GameObject Bullet_Prefab;


    // Start is called before the first frame update
    void Start()
    {
        Bullet_Prefab = Resources.Load("Bullet_Prefab") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)==true)
        {
            Instantiate(Bullet_Prefab , transform.position , Quaternion.identity);
            //게임중 오브젝트 스폰,어디 위치, Quaternion.identity;
        }
    }
}
