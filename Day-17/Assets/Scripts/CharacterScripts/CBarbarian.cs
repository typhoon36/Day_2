using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BarBarian_Stat;
public class BarBarian_Stat : Chr_Stat
{
    public int m_Speed;
    public int m_Def;

    public BarBarian_Stat(string a_CrName = "", int a_Speed = 1, int a_Def = 5) //������ �����ε� �Լ�
    {
        m_CharType = CharicType.Barbarian;
        m_StrJob = "�ٹٸ���";
        m_RscFile = "Images/BbrRanderer";
        m_Name = a_CrName;
        m_MaxHp = 150;
        m_MaxMana = 80;
        m_Attack = 50;
        m_Speed = a_Speed;
        m_Def = a_Def;
    }

    //ĳ������ ���� ������ ������� ������ ���ƴٴϴ� ĳ���� ��ü�� �߰��Ϸ��� �� ��
    //Hero ���� ������Ʈ�� ���� ��Űų ���ϴ� Ŭ���� �߰� �Լ�
    public override CUnit MyAddComponent(GameObject a_ParentGObj)
    {
        //�Ű������� ���� Hero GameObject �� CWizard ������Ʈ�� �ٿ� �ְ�
        CUnit a_RefHero = a_ParentGObj.AddComponent<CBarbarian>();
        a_RefHero.m_ChrStat = this;   //���� �� Wizard_Stat ��ü�� CWizard : CUnit�� m_ChrStat ������ ������ �ش�.
        return a_RefHero;
    }
    public class CBarbarian : CUnit
    {
        //1.awake - 2 myaddcomponent : arefhero.mchrstat = this; =--- 3 start()


        //void Awake()  //override ���ϸ� �̰͸� ȣ��ȴ�.
        //{
        //}

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start(); //�θ��� Start() �Լ� ȣ�� (���� ���� �غ�) 

            if (m_RefGameMgr != null)
                m_RefGameMgr.LogMsg($"{m_ChrStat.m_Name} : �ٹٸ��� ���� ���� �غ�");
        }

        // Update is called once per frame
        protected override void Update()
        {
            //�ٹٸ����� ���� AI �ൿ ���� �ڵ�
        }

        public override void Attack()
        {
            if (m_RefGameMgr != null)
                m_RefGameMgr.LogMsg($"�ٹٸ��� ���� : �̸�({m_ChrStat.m_Name}), Hp({m_CurHp}) ���ݷ�({m_CurAtt})");
        }

        public override void UseSkill()
        {
            if (m_RefGameMgr != null)
                m_RefGameMgr.LogMsg($"�ٹٸ��� ��ų : �̸�({m_ChrStat.m_Name}), " +
                                    $"�̼�({((BarBarian_Stat)m_ChrStat).m_Speed})" +
                                    $"����({((BarBarian_Stat)m_ChrStat).m_Def})");
        }
        
        
    }
}
