using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValue 
{
    //    public static string g_Unique_ID = ""; //������ȣ

    //    public static string g_NickName = "";
    //    public static int g_BestScore = 0;
    //    public static int g_UserGold = 0;
    //    public static int g_Exp = 0;
    //    public static int g_Level = 0;

    public static Chr_Stat g_CurSelCStat = null; //���� �����ϰ� �ִ� ĳ���� �ε��� null�� ���õ� ĳ���Ͱ� ���ٴ� ��
    public static List<Chr_Stat> g_MyChrList = new List<Chr_Stat>(); //���� �����ϰ��ִ� ĳ���� ����Ʈ�� ������ ���� ����Ʈ �Լ� �̿�

    //���� ����

    public static void LoadGameData()
    {
        if (g_MyChrList.Count <= 0)  //�ε� �ѹ��� �ǰ� �ϱ� ����
        {
            //+ �� �κ��丮�� ���� �����ϰ� �ִ� ĳ���� ��� �ε� �� �߰��� ���� ���� -->30ea 3-4ea�϶� ������ ¥���� ���� ������
            Chr_Stat a_CrNode = new Wizard_Stat("������", 70);
            g_MyChrList.Add(a_CrNode);

            a_CrNode = new BarBarian_Stat("����ŷ", 1, 3);
            g_MyChrList.Add(a_CrNode );

            a_CrNode = new Archer_Stat("�����", 100);
            g_MyChrList.Add (a_CrNode );

            a_CrNode = new Healer_Stat("�ʺ�ġ���", 5);
            g_MyChrList.Add(a_CrNode);
            //~ �� �κ��丮�� ���� �����ϰ� �ִ� ĳ���� ��� �ε� �� �߰��� ���� ����

        } //~ �ε� �ѹ��� �ǰ� �ϱ� ����






    }//~�ε����ӵ�����





}
