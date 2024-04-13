using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItem 
{
    public static int g_CurUniqId = 0; //���� ���۽� ���ÿ��� �ε��� �� ��  UniqueId

    string[] m_ItName = {"�巡���ǰ�", "�����ǹ���", "�������̻�", "�ȶ���Ȱ", 
                        "������ǰ���", "����Ǵܰ�", "�ʱ�����������", "��������â"};

    public int m_ItemUId = -1;   //-1�� ���� ������Id�� �ο� ���� �ʾҴٴ� ��
    public string m_Name = "";  //�巡���� ��, õ���� ����, ������� ����
    public int m_Level = 1;     //1 ~ 30 ����
    public int m_Grade = 7;     //��� 7 ~ 1 ���
    public int m_Price = 1000;  //������ ����

    public CItem() //����Ʈ ������ �Լ�
    {
    }          

    public CItem(string a_Name) //������ �����ε� �Լ�
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


