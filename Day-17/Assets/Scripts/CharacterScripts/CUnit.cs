using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharicType
{
    Wizard = 0,     //������
    Barbarian,      //�ٹٸ���
    Archer,         //�ü�
    Healer,         //����
    Count
}

public class Chr_Stat       //Stat, attribute, �ɷ�ġ (ĳ���� ���� ������)
{
    public CharicType m_CharType;   //ĳ���� Ÿ��
    public string m_StrJob = "";    //�����̸� �ѱ۷� ������ ���´�.
    public string m_Name = "";      //�̸�
    public string m_RscFile = "";   //���ҽ� ������ �̸�
    public int m_MaxHp   = 0;       //ü������
    public int m_MaxMana = 0;       //������
    public int m_Attack  = 0;       //�⺻ ���ݷ�

    //ĳ������ ���� ������ ������� ������ ���ƴٴϴ� ĳ���� ��ü�� �߰��Ϸ��� �� �� 
    //Hero ���� ������Ʈ�� ���� ��Űų ���ϴ� Ŭ���� �߰� �Լ�
    public virtual CUnit MyAddComponent(GameObject a_ParentGObj)
    {
        CUnit a_RefHero = null;
        return a_RefHero;
    }
}

public class CUnit : MonoBehaviour
{
    [HideInInspector] public Chr_Stat m_ChrStat = null;

    [HideInInspector] public int m_CurHp   = 0;  //ü��
    [HideInInspector] public int m_CurMana = 0;  //����
    [HideInInspector] public int m_CurAtt  = 0;  //�������� ���� ���ݷ�

    [HideInInspector] public InGameMgr m_RefGameMgr = null; //InGameMgr�� ������ ���� ��ü

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //--- ĳ���� ���� ���� �غ�
        m_RefGameMgr = FindObjectOfType<InGameMgr>(); //InGameMgr�� ������ ���� ��ü�� ã�� ���´�.
        
        //����� ȣ���Լ�(���� �𵨸� �ε� ���ҽ� ����, ĳ���� ���� ����Ʈ �޸�Ǯ �غ�)
        //��� �޴� �� ���� ���� �ڵ�(���� ��ġ ��...)       
        GameObject a_ChrSprite = Resources.Load(m_ChrStat.m_RscFile) as GameObject; //--- ���ҽ� �ε�
        if (a_ChrSprite != null)
        {
            GameObject a_Clone = Instantiate(a_ChrSprite); //���� �� Hero GameObject �� ���� ��������Ʈ ����
            a_Clone.transform.SetParent(this.transform, false); //Hero �ؿ� ���ϵ�� WizRenderer ���̱�...
        }
        //--- ĳ���� ���� ���� �غ�

        //--- ����ġ ���� ������ ����
        m_CurHp   = m_ChrStat.m_MaxHp;
        m_CurMana = m_ChrStat.m_MaxMana;
        m_CurAtt  = m_ChrStat.m_Attack;
        //--- ����ġ ���� ������ ����
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //--- ĳ���� ���� �ൿ ������ ���� ��ŰŰ
    }

    public virtual void Attack()
    {
        //--- ĳ���� ���� Attack �ߵ� ó��
    }

    public virtual void UseSkill()
    {
        //--- ĳ���� ���� Skill �ߵ� ó��
    }
}
