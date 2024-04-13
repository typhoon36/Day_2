using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CWizard;

//Class 다형성

public enum CharicType
{
    wizard = 0,
    Barbarian,
    Archer, 
    Count
};

public class CUnit
{
    public CharicType m_CharicType = CharicType.Count; //캐릭터 타입이 아직 적용되지않음
    public string m_StrJob = ""; //직업이름
    public string m_Name = ""; //이름



    public int m_CurHp = 0; //체력
    public int m_CurMana = 0; //마나
    public int m_CurAtt = 0; //공격력

    public CUnit(string a_CrName = "") //생성자 함수
    {

    }

    public virtual void OnUpdate()
    {

    }

    public virtual string Attack()
    {
        return "";
    }



}

public class CWizard : CUnit
{
    public int m_MagicRange; //마법 적용범위

    public CWizard(string a_CrName = "", int a_MgRange = 0)    /* : base(a_CrName)*/ //부모쪽 생성자를 바로 호출
    {
        m_CharicType = CharicType.wizard;
        m_StrJob = "마법사";
        m_Name = a_CrName;
        m_CurHp = 10; //체력
        m_CurMana =100; //마나
        m_CurAtt = 100; //공격력


        m_MagicRange = a_MgRange;
    }
    public override void OnUpdate()
    {
       // base.OnUpdate();   //부모쪽의 함수 호출
    }

    public override string Attack()
    {
        string a_str = $"마법사 공격  : 이름({m_Name}), HP({m_CurHp}),마법범위 ({m_MagicRange})";
        return a_str;
    }

    // 바바리안 

    public class CBarbarian : CUnit
    {
        public int m_Speed;
        public int m_Def; //방어력


        public CBarbarian(string a_CrName = "", int a_seed = 1, int a_Def = 5)
        {
            m_CharicType = CharicType.Barbarian;
            m_StrJob  = "바바리안";
            m_Name  = a_CrName;
            m_CurHp =  100;
            m_CurMana = 100;
            m_CurAtt = 10;
            m_Speed = a_seed;
            m_Def = a_Def;
        }
        public override void OnUpdate()
        {
           
        }
        public override string Attack()
        {
            string str = $"바바리안 공격 : 이름 ({m_Name}) , 공격력({m_CurAtt}), 이속({m_Speed})";
            return str;
        }






    } 



}

public class CArcher : CUnit
{
    public int m_AttackLength; //사거리


    public CArcher(string a_CrName = "", int a_AttLen = 50)  //오버로딩 생성자 함수
    {
        m_CharicType = CharicType.Archer;
        m_StrJob = "궁수";
        m_Name   =a_CrName;
        m_CurHp = 100;
        m_CurMana = 100;
        m_CurAtt = 10;
        m_AttackLength = a_AttLen;
    }

    public override void OnUpdate()
    {
        
    }

    public override string Attack()
    {
        string str = $"궁수 공격 : 이름({m_Name}) , 공격력({m_CurAtt}) , 사거리({m_AttackLength})";
        return str;
    }

}


public class Test_01 : MonoBehaviour
{
    CharicType m_CurSelCT = CharicType.Count;  //현재 선택하고있느 인덱스 null은 선택된 캘릭터가 없다는 뜻
    List<CUnit> g_MyChrLitst = new List<CUnit>(); //내가 보유하고 있느 캐릭터 리스트

    // Start is called before the first frame update
    void Start()
    {
        //-----내 인벤토리에 내가 보유하고 있는 캐릭터 목록 로딩 및 추가---------
        CUnit a_TNode = null;


        a_TNode = new CWizard("간달프" , 70);
        g_MyChrLitst.Add(a_TNode);

        a_TNode = new CBarbarian("바이킹", 1, 3);
        g_MyChrLitst.Add (a_TNode);

        a_TNode = new CArcher("레골라스", 55);
        g_MyChrLitst.Add(a_TNode);
        
        //~-----내 인벤토리에 내가 보유하고 있는 캐릭터 목록 로딩 및 추가---------
    }


    string m_AttStr = "";

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N) == true) //캐릭터 교체
        {
            m_CurSelCT++; //처음 한번은 3이된다.
            Debug.Log(m_CurSelCT);
            if(CharicType.Count <= m_CurSelCT )
            {
                m_CurSelCT = CharicType.wizard;
            }
            m_AttStr = "";


        }//~ if(Input.GetKeyDown(KeyCode.N) == true)

      if(Input.GetKeyDown(KeyCode.A) == true)
        {
            if(m_CurSelCT < CharicType.Count)
            m_AttStr = g_MyChrLitst[(int)m_CurSelCT].Attack();

        }

    }

    private void OnGUI()
    {
      
        string a_Crstr = "캐릭터 선택 없음";
        if (m_CurSelCT < CharicType.Count)
        {
            a_Crstr = $"{g_MyChrLitst[(int)m_CurSelCT].m_StrJob} 이름({g_MyChrLitst[(int)m_CurSelCT].m_Name}) 선택";
        }

        GUI.Label(new Rect(255, 35, 1000 , 100), "<color=#00ff00><size=32>" + a_Crstr + "</size></color>");


        GUI.Label(new Rect(255, 110 , 1000, 100), "<color=#ffff00><size=32>" + m_AttStr + "</size></color>");

    }


}
