using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CWizard;

//Class ������

public enum CharicType
{
    wizard = 0,
    Barbarian,
    Archer, 
    Count
};

public class CUnit
{
    public CharicType m_CharicType = CharicType.Count; //ĳ���� Ÿ���� ���� �����������
    public string m_StrJob = ""; //�����̸�
    public string m_Name = ""; //�̸�



    public int m_CurHp = 0; //ü��
    public int m_CurMana = 0; //����
    public int m_CurAtt = 0; //���ݷ�

    public CUnit(string a_CrName = "") //������ �Լ�
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
    public int m_MagicRange; //���� �������

    public CWizard(string a_CrName = "", int a_MgRange = 0)    /* : base(a_CrName)*/ //�θ��� �����ڸ� �ٷ� ȣ��
    {
        m_CharicType = CharicType.wizard;
        m_StrJob = "������";
        m_Name = a_CrName;
        m_CurHp = 10; //ü��
        m_CurMana =100; //����
        m_CurAtt = 100; //���ݷ�


        m_MagicRange = a_MgRange;
    }
    public override void OnUpdate()
    {
       // base.OnUpdate();   //�θ����� �Լ� ȣ��
    }

    public override string Attack()
    {
        string a_str = $"������ ����  : �̸�({m_Name}), HP({m_CurHp}),�������� ({m_MagicRange})";
        return a_str;
    }

    // �ٹٸ��� 

    public class CBarbarian : CUnit
    {
        public int m_Speed;
        public int m_Def; //����


        public CBarbarian(string a_CrName = "", int a_seed = 1, int a_Def = 5)
        {
            m_CharicType = CharicType.Barbarian;
            m_StrJob  = "�ٹٸ���";
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
            string str = $"�ٹٸ��� ���� : �̸� ({m_Name}) , ���ݷ�({m_CurAtt}), �̼�({m_Speed})";
            return str;
        }






    } 



}

public class CArcher : CUnit
{
    public int m_AttackLength; //��Ÿ�


    public CArcher(string a_CrName = "", int a_AttLen = 50)  //�����ε� ������ �Լ�
    {
        m_CharicType = CharicType.Archer;
        m_StrJob = "�ü�";
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
        string str = $"�ü� ���� : �̸�({m_Name}) , ���ݷ�({m_CurAtt}) , ��Ÿ�({m_AttackLength})";
        return str;
    }

}


public class Test_01 : MonoBehaviour
{
    CharicType m_CurSelCT = CharicType.Count;  //���� �����ϰ��ִ� �ε��� null�� ���õ� Ķ���Ͱ� ���ٴ� ��
    List<CUnit> g_MyChrLitst = new List<CUnit>(); //���� �����ϰ� �ִ� ĳ���� ����Ʈ

    // Start is called before the first frame update
    void Start()
    {
        //-----�� �κ��丮�� ���� �����ϰ� �ִ� ĳ���� ��� �ε� �� �߰�---------
        CUnit a_TNode = null;


        a_TNode = new CWizard("������" , 70);
        g_MyChrLitst.Add(a_TNode);

        a_TNode = new CBarbarian("����ŷ", 1, 3);
        g_MyChrLitst.Add (a_TNode);

        a_TNode = new CArcher("�����", 55);
        g_MyChrLitst.Add(a_TNode);
        
        //~-----�� �κ��丮�� ���� �����ϰ� �ִ� ĳ���� ��� �ε� �� �߰�---------
    }


    string m_AttStr = "";

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N) == true) //ĳ���� ��ü
        {
            m_CurSelCT++; //ó�� �ѹ��� 3�̵ȴ�.
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
      
        string a_Crstr = "ĳ���� ���� ����";
        if (m_CurSelCT < CharicType.Count)
        {
            a_Crstr = $"{g_MyChrLitst[(int)m_CurSelCT].m_StrJob} �̸�({g_MyChrLitst[(int)m_CurSelCT].m_Name}) ����";
        }

        GUI.Label(new Rect(255, 35, 1000 , 100), "<color=#00ff00><size=32>" + a_Crstr + "</size></color>");


        GUI.Label(new Rect(255, 110 , 1000, 100), "<color=#ffff00><size=32>" + m_AttStr + "</size></color>");

    }


}
