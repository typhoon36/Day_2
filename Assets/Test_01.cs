using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;



//c# �ڷᱸ��( �ڷᱸ�� ���̺귯�� : Generic Collection
//Generic collection �� list


public class Test_01 : MonoBehaviour
{
    //���������Լ�
    int Comp(int a, int b)
    {
      /*  return a.CompareTo(b);*/ //��������(ASX) : ���������� ���������� ���� 1,2,3,4,5
        return b.CompareTo(a); //��������(DESC) : ��->��
    }

    // Start is called before the first frame update
    void Start()
    {
        //list ���

        List<int> a_List = new List<int>();

        Debug.Log("��� �߰�����");

        a_List.Add(111);
        a_List.Add(222);
        a_List.Add(333);

        //for (int ii = 0; ii < a_List.Count; ii++)
        //{
        //    Debug.Log(a_List[ii]);
        //}

        Debug.Log("----------------");

        a_List.Add(444);
        a_List.Add(555);
        //for (int ii = 0; ii < a_List.Count; ii++)
        //{
        //    Debug.Log(a_List[ii]);
        //}
        //foreach (int Val in a_List)
        //{ Debug.Log(Val); }

        //Debug.Log("�߰��� ����");


        //a_List.RemoveAt(1);//1�� �ε��� ��� ����

        //for (int ii = 0; ii < a_List.Count; ii++)
        //{
        //    Debug.Log($"a_List[{ii}] : {a_List[ii]}"); //�߰��� ����
        //}

        //Debug.Log("----------�������������");
        //if (a_List.Count > 0)
        //    a_List.RemoveAt((a_List.Count - 1));
        for (int ii = 0; ii < a_List.Count; ii++)
        {
            Debug.Log($"a_List[{ii}] : {a_List[ii]}"); //�������� ����
        }

        Debug.Log("�߰��� �߰��ϱ�");
        a_List.Insert(1, 10);
        a_List.Insert(3, 30);

        int a_Idx = 0;
        foreach (int val in a_List) 
        {
            Debug.Log($"a_List[{a_Idx}] : {val}");
            a_Idx++;
        }

        Debug.Log("�����ϱ�");

        a_List.Sort( Comp );
        for (int ii = 0; ii < a_List.Count; ii++)
        {
            Debug.Log($"a_List[{ii}] : {a_List[ii]}"); 
        }

        Debug.Log("��ü��� �����ϱ�");

        a_List.Clear();

        Debug.Log("����� ���� : " + a_List.Count);




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
