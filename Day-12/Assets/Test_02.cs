using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class MyItem
{
    public string m_Name = ""; //������ �̸�
    public int m_Level = 0; //������ ����
    public float m_AttRate = 1.0f; //���ݻ�·�
    public int m_price = 100; //������ ����

    public MyItem(string a_Name = "", int a_Lv = 0, float a_Ar = 0.0f, int a_price = 0)
    {
        // ������ �����ε� �Լ�
        m_Name = a_Name;
        m_Level = a_Lv;
        m_AttRate = a_Ar;
        m_price = a_price;
    }
    public void PrintInfo()
    {
        Debug.Log($"�̸�({m_Name}) : ���� ({m_Level}) ���ݻ�·� ({m_AttRate}) ����({m_price})");
    }


}



public class Test_02 : MonoBehaviour
{
    List<MyItem> m_ItList = new List<MyItem>();

    int PriceASC(MyItem a, MyItem b)  //��������
    {
       return a.m_price.CompareTo(b.m_price); //�������� ����   ������ ���������� ���������� ����
    }

    int LevelDSC(MyItem a, MyItem b)
    {
        return b.m_Level.CompareTo(a.m_Level); //�������� ���� ������ ���������� ���������� ����
    }


    // Start is called before the first frame update
    void Start()
    {
        int AAA;
        AAA = 10;
        int BBB = 10; //���� ����� ���ÿ� �ʱ�ȭ

        //<1�� �ʱ�ȭ ���> ��ü�� ������ �ʱ�ȭ

        //MyItem a_Node = new MyItem();
        //a_Node.m_Name = "õ���� ����";
        //a_Node.m_Level = 3;
        //a_Node.m_AttRate = 2.0f;
        //a_Node.m_price = 2500;


        //2���ʱ�ȭ:��ü ����� ���ÿ� �ʱ�ȭ

        //MyItem a_Node = new MyItem("õ���� ����",3,2.0f, 2500);


        //3�� �ʱ�ȭ :��ü ����� ���ÿ� ������ �ʱ�ȭ 

        MyItem ABC = new MyItem { m_Name = "�׽�Ʈ", m_price = 1500 };
        ABC.PrintInfo();


        //��� �߰�

        MyItem a_Node = new MyItem("õ���� ����", 3, 2.0f, 2500);
        m_ItList.Add(a_Node);
        a_Node = new MyItem("�ȶ��� ��", 1, 1.2f, 1200);
        m_ItList.Add(a_Node);

        a_Node = new MyItem("�ü��� Ȱ", 4, 1.7f, 1700);
        m_ItList.Add(a_Node);

        a_Node = new MyItem("�ź����� ����", 5, 1.5f, 3000);
        m_ItList.Add(a_Node);


        //��ȯ

        for (int i = 0; i < m_ItList.Count; i++)
        {
            m_ItList[i].PrintInfo();
        }
        //~ ��ȯ


        //����
        Debug.Log("-----");

        //m_ItList.RemoveAt(0);
        //Debug.Log("ù��° ��� ���� ���--");

        //foreach (MyItem a_It in m_ItList)
        //{
        //    a_It.PrintInfo();
        //}

        //������ ��� ����

        //if(0 < m_ItList.Count)

        //    m_ItList .RemoveAt(m_ItList.Count - 1); //������ �ε��� ����

        // removeat�Լ��� ������ ��� �ε����� �����Ϸ��� �õ��ϸ� ��������.

        //foreach (MyItem a_It in m_ItList)
        //{
        //    a_It.PrintInfo(); <+_____ ���ڸ� ������ ����
        //}

        //����� ������ ã�Ƽ� �����ϴ� ���

        //MyItem a_FNode = m_ItList[1];//�ȶ��� ��
        //if (m_ItList.Contains(a_FNode) == true)  //a_FNode �ν��Ͻ��� ����Ʈ�� �ִ���?
        //{
        //    m_ItList.Remove(a_FNode);
        //}

        //foreach (MyItem a_It in m_ItList)
        //{
        //    a_It.PrintInfo();
        //}

        //MyItem a_FNode = new MyItem("�ʱ����� ��ȭ", 1, 1.1f, 1000);
        //m_ItList.Remove(a_FNode);
        ////remove �Լ��� ��ü�� ����Ʈ�� ����ġ ���� ���¿��� ���� �õ��� �ص� ���������ʴ´�.
        //foreach ( MyItem a_It in m_ItList)
        //{ a_It.PrintInfo(); } //������ ����~������ ������ �ȳ�

        //�߰� �߰��� ���ǿ� �����ϴ� ��츸 ���û���

        //for(int ii = 0; ii < m_ItList.Count; ii++)
        //{
        //    if (m_ItList[ii].m_price < 2000)
        //    {
        //        m_ItList.RemoveAt(ii); 
        //    }
        //    else
        //    {
        //        ii++;
        //    }

        //}
        //foreach (MyItem a_It in m_ItList)
        //{
        //    a_It.PrintInfo();
        //}


        //�߰��� �߰�

        //a_Node = new MyItem("����� �̻�", 4 ,1.2f,12000);
        //  m_ItList.Insert(1, a_Node);
        m_ItList.Insert(1, new MyItem("����� �̻�", 4, 1.2f, 12000)); 
        Debug.Log("1�� �ε��� �߰��� �߰� ���");
        foreach(MyItem a_It in m_ItList)
           a_It.PrintInfo();
        Debug.Log("-----");

        //����
        //������ ���������� ���������� ���� ���

        //List<MyItem> a_CopyList = new m_ItList.ToList(); //����Ʈ ���� using System.Linq;
        //a_CopyList.Sort(PriceASC);
        //Debug.Log("-------������ ���������� ���������� ����-------");

        m_ItList.Sort(PriceASC);
        Debug.Log("-------������ ���������� ���������� ����-------");
        foreach (MyItem a_It in m_ItList)
            a_It.PrintInfo();
       



        //������ ���������� ���������� ���� ���

        m_ItList.Sort(LevelDSC);
        Debug.Log("-----������ ���������� ���������� ����------");
        foreach (MyItem a_It in m_ItList)
            a_It.PrintInfo();


        //�˻�
        Debug.Log("--List �˻�----");
        MyItem a_FindNode = null;
        for(int i = 0; i < m_ItList.Count; i++)
        {
            if (m_ItList[i].m_Name == "����� �̻�")
            { 
                a_FindNode = m_ItList[i];
                break;
            }

        }
        if (a_FindNode != null)
            a_FindNode.PrintInfo();

        MyItem a_FNode = m_ItList.Find((a_NN) => a_NN.m_Name == "�ȶ��� ��");
        if (a_FNode == null)
            a_FNode.PrintInfo();
        //�˻��� ��

        //��ü��� ����
        m_ItList.Clear(); //allclear
        Debug.Log("--------��ü���������----");
        Debug.Log(m_ItList.Count);
        //~��ü������


    }

    // Update is called once per frame
    void Update()
    {

    }
}
