using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Stat : Chr_Stat
{
    public int m_MagicRange;

    public Wizard_Stat(string a_CrName = "", int a_MgRange = 0)
    {
        m_CharType = CharicType.Wizard;
        m_StrJob   = "������";
        m_RscFile  = "Images/WizRenderer";
        m_Name     = a_CrName;
        m_MaxHp    = 100;
        m_MaxMana  = 150;
        m_Attack   = 10;
        m_MagicRange = a_MgRange;
    }

    //ĳ������ ���� ������ ������� ������ ���ƴٴϴ� ĳ���� ��ü�� �߰��Ϸ��� �� ��
    //Hero ���� ������Ʈ�� ���� ��Űų ���ϴ� Ŭ���� �߰� �Լ�
    public override CUnit MyAddComponent(GameObject  a_ParentGObj)
    {
        //�Ű������� ���� Hero GameObject �� CWizard ������Ʈ�� �ٿ� �ְ�
        CUnit a_RefHero =  a_ParentGObj.AddComponent<CWizard>();
        a_RefHero.m_ChrStat = this;   //���� �� Wizard_Stat ��ü�� CWizard : CUnit�� m_ChrStat ������ ������ �ش�.
        return a_RefHero;
    }
}

public class CWizard : CUnit
{
    //�� ĳ���Ͱ� �������� �� m_ChrStat.m_CharType == CharacType.Wizard �� �� �� �ִ�.

    void Awake()  //override ���ϸ� �̰͸� ȣ��ȴ�.
    {       
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); //�θ��� Start() �Լ� ȣ�� (���� ���� �غ�) 

        if (m_RefGameMgr != null)
            m_RefGameMgr.LogMsg($"{m_ChrStat.m_Name} : ������ ���� ���� �غ�");
    }

    // Update is called once per frame
    protected override void Update()
    {
        //�������� ���� AI �ൿ ���� �ڵ�
    }

    public override void Attack()
    {
        if (m_RefGameMgr != null)
            m_RefGameMgr.LogMsg($"������ ���� : �̸�({m_ChrStat.m_Name}), Hp({m_CurHp}) ���ݷ�({m_CurAtt})");
    }

    public override void UseSkill()
    {
        if (m_RefGameMgr != null)
            m_RefGameMgr.LogMsg($"������ ��ų : �̸�({m_ChrStat.m_Name}), " +
                                $"��������({ ((Wizard_Stat)m_ChrStat).m_MagicRange })");
    }
}
