using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer_Stat : Chr_Stat
{
    public int m_HealPower; //ġ�� ��


    public Healer_Stat(string a_CrName = "", int a_HealPower = 5)
    {
        m_CharType = CharicType.Healer;
        m_StrJob = "����";
        m_RscFile = "Images/HealRanderer";
        m_Name = a_CrName;
        m_MaxHp = 40;
        m_MaxMana = 80;
        m_Attack = 5;
        m_HealPower = a_HealPower;

    }

    //ĳ������ ���� ������ ������� ������ ���ƴٴϴ� ĳ���� ��ü�� �߰��Ϸ��� �� ��
    //Hero ���� ������Ʈ�� ���� ��Űų ���ϴ� Ŭ���� �߰� �Լ�
    public override CUnit MyAddComponent(GameObject a_ParentGObj)
    {
        //�Ű������� ���� Hero GameObject �� CWizard ������Ʈ�� �ٿ� �ְ�
        CUnit a_RefHero = a_ParentGObj.AddComponent<CHealer>();
        a_RefHero.m_ChrStat = this;   //���� �� Wizard_Stat ��ü�� CWizard : CUnit�� m_ChrStat ������ ������ �ش�.
        return a_RefHero;
    }
    public class CHealer : CUnit
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
                m_RefGameMgr.LogMsg($"{m_ChrStat.m_Name} : ���� ���� ���� �غ�");
        }

        // Update is called once per frame
        protected override void Update()
        {
            //������ ���� AI �ൿ ���� �ڵ�
        }

        public override void Attack()
        {
            if (m_RefGameMgr != null)
                m_RefGameMgr.LogMsg($"���� ���� : �̸�({m_ChrStat.m_Name}), Hp({m_CurHp})" +
                    $" ���ݷ�({m_CurAtt})");
        }

        public override void UseSkill()
        {
            if (m_RefGameMgr != null)
                m_RefGameMgr.LogMsg($"���� ��ų : �̸�({m_ChrStat.m_Name}), " +
                                    $"��Ÿ�({((Healer_Stat)m_ChrStat).m_HealPower})");

        }


    }
}
