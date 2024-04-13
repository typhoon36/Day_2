using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItem 
{
    public static int g_CurUniqId = 0; //게임 시작시 로컬에서 로딩해 올 값  UniqueId

    string[] m_ItName = {"드래곤의검", "엘프의반지", "사자의이빨", "팔라독의활", 
                        "고양이의갑옷", "상어의단검", "너구리의지팡이", "독수리의창"};

    public int m_ItemUId = -1;   //-1은 아직 아이템Id가 부여 되지 않았다는 뜻
    public string m_Name = "";  //드래곤의 검, 천사의 반지, 고양이의 방패
    public int m_Level = 1;     //1 ~ 30 레벨
    public int m_Grade = 7;     //등급 7 ~ 1 등급
    public int m_Price = 1000;  //아이템 가격

    public CItem() //디폴트 생성자 함수
    {
    }          

    public CItem(string a_Name) //생성자 오버로딩 함수
    {
        m_Name = a_Name;
        m_ItemUId = g_CurUniqId;
        g_CurUniqId++;
        PlayerPrefs.SetInt("CurUniqId", g_CurUniqId);
        m_Level = Random.Range(1, 9);       // 1 ~ 8
        m_Grade = 7 - Random.Range(0, 2);   // 7 ~ 6
        m_Price = Random.Range(100, 1001);  // 100 ~ 1000
    }

    public void InitItem()
    {
        int a_Idx = Random.Range(0, m_ItName.Length);
        m_Name = m_ItName[a_Idx];
        m_ItemUId = g_CurUniqId;
        g_CurUniqId++;
        PlayerPrefs.SetInt("CurUniqId", g_CurUniqId);
        m_Level = Random.Range(1, 9);       // 1 ~ 8
        m_Grade = 7 - Random.Range(0, 2);   // 7 ~ 6
        m_Price = Random.Range(100, 1001);  // 100 ~ 1000
    }
}


