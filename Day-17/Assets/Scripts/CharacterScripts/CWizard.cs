using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Stat : Chr_Stat
{
    public int m_MagicRange;

    public Wizard_Stat(string a_CrName = "", int a_MgRange = 0)
    {
        m_CharType = CharicType.Wizard;
        m_StrJob   = "마법사";
        m_RscFile  = "Images/WizRenderer";
        m_Name     = a_CrName;
        m_MaxHp    = 100;
        m_MaxMana  = 150;
        m_Attack   = 10;
        m_MagicRange = a_MgRange;
    }

    //캐릭터의 스탯 정보를 기반으로 지형에 돌아다니는 캐릭터 객체를 추가하려고 할 때
    //Hero 게임 오브젝트에 빙의 시키킬 원하는 클래스 추가 함수
    public override CUnit MyAddComponent(GameObject  a_ParentGObj)
    {
        //매개변수로 받은 Hero GameObject 에 CWizard 컴포넌트를 붙여 주고
        CUnit a_RefHero =  a_ParentGObj.AddComponent<CWizard>();
        a_RefHero.m_ChrStat = this;   //지금 이 Wizard_Stat 객체를 CWizard : CUnit쪽 m_ChrStat 변수에 대입해 준다.
        return a_RefHero;
    }
}

public class CWizard : CUnit
{
    //이 캐릭터가 마법사인 건 m_ChrStat.m_CharType == CharacType.Wizard 로 알 수 있다.

    void Awake()  //override 안하면 이것만 호출된다.
    {       
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); //부모쪽 Start() 함수 호출 (공통 등장 준비) 

        if (m_RefGameMgr != null)
            m_RefGameMgr.LogMsg($"{m_ChrStat.m_Name} : 마법사 고유 등장 준비");
    }

    // Update is called once per frame
    protected override void Update()
    {
        //마법사의 고유 AI 행동 패턴 코드
    }

    public override void Attack()
    {
        if (m_RefGameMgr != null)
            m_RefGameMgr.LogMsg($"마법사 공격 : 이름({m_ChrStat.m_Name}), Hp({m_CurHp}) 공격력({m_CurAtt})");
    }

    public override void UseSkill()
    {
        if (m_RefGameMgr != null)
            m_RefGameMgr.LogMsg($"마법사 스킬 : 이름({m_ChrStat.m_Name}), " +
                                $"마법범위({ ((Wizard_Stat)m_ChrStat).m_MagicRange })");
    }
}
