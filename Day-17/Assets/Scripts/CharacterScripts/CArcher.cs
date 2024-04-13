using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_Stat : Chr_Stat
{
    public int m_AttackLength;
  

    public Archer_Stat(string a_CrName = "", int a_AttackLength = 100)
    {
        m_CharType = CharicType.Archer;
        m_StrJob = "�ü�";
        m_RscFile = "Images/ArcRanderer";
        m_Name = a_CrName;
        m_MaxHp = 150;
        m_MaxMana = 80;
        m_Attack = 50;
        m_AttackLength = a_AttackLength;
        
    }

    //ĳ������ ���� ������ ������� ������ ���ƴٴϴ� ĳ���� ��ü�� �߰��Ϸ��� �� ��
    //Hero ���� ������Ʈ�� ���� ��Űų ���ϴ� Ŭ���� �߰� �Լ�
    public override CUnit MyAddComponent(GameObject a_ParentGObj)
    {
        //�Ű������� ���� Hero GameObject �� CWizard ������Ʈ�� �ٿ� �ְ�
        CUnit a_RefHero = a_ParentGObj.AddComponent<CArcher>();
        a_RefHero.m_ChrStat = this;   //���� �� Wizard_Stat ��ü�� CWizard : CUnit�� m_ChrStat ������ ������ �ش�.
        return a_RefHero;
    }
    public class CArcher : CUnit
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
                m_RefGameMgr.LogMsg($"{m_ChrStat.m_Name} : ��ó ���� ���� �غ�");
        }

        // Update is called once per frame
        protected override void Update()
        {
            //��ó�� ���� AI �ൿ ���� �ڵ�
        }

        public override void Attack()
        {
            if (m_RefGameMgr != null)
                m_RefGameMgr.LogMsg($"��ó ���� : �̸�({m_ChrStat.m_Name}), Hp({m_CurHp}) ���ݷ�({m_CurAtt})");
        }

        public override void UseSkill()
        {
            if (m_RefGameMgr != null)
                m_RefGameMgr.LogMsg($"��ó ��ų : �̸�({m_ChrStat.m_Name}), " +
                                    $"��Ÿ�({((Archer_Stat)m_ChrStat).m_AttackLength})");
                                
        }


    }
}
