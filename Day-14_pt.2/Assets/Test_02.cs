using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//dictionary
//Ű���� value�� ������ �ڷᱸ��
//����;ū �����͸� �����ϱ� ���ϴ�.
//����;���ϴ� �������� ������ �����ʴ�.

public class Test_02 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string , string> a_dt = new Dictionary<string , string>();

        a_dt["apple"] = "���";
        a_dt["strawberry"] = "����";
        a_dt["banana"] = "�ٳ���!";
        a_dt["watermelon"] = "����";
        a_dt["orange"] = "������";


        //---��ȯ ���
        //KeyValuePair<string, string> a_PrNode;

        //for(int i = 0; i<a_dt.Count; i++)
        //{
        //    a_PrNode = a_dt.ElementAt(i);      //linq
        //    Debug.Log($"[{i} : Key({a_PrNode.Key}) , value({a_PrNode.Value})");
        //}


        int a_Idx = 0;
        foreach (KeyValuePair<string, string> a_Node in a_dt)
        {
            Debug.Log($"[{a_Idx} : Key({a_Node.Key}) , value({a_Node.Value})");
            a_Idx++;
        }



        //�˻�
        Debug.Log(a_dt["banana"]);

        if(a_dt.ContainsKey("mango")==true) //�����Ұ�� �˻�
        Debug.Log(a_dt["mango"]);

        a_dt["apple"] = "���"; //�̹� �����ϴ� Ű�� ���Խ� value���� �ٲ�.



         a_Idx = 0;
        foreach (KeyValuePair<string, string> a_Node in a_dt)
        {
            Debug.Log($"[{a_Idx} : Key({a_Node.Key}) , value({a_Node.Value})");
            a_Idx++;
        }

        //���ǻ��� :KeyNotFoundException: The given key 'mango' was not present in the dictionary.��� ������ �߻��Ѵ�.
        //�����ϴ����� �����ؾ߸� �˻����� -> �ذ���? 46���� key.containskey�� ���翩�� ���

        //����
        a_dt.Remove("banana");

        Debug.Log("�������Ȯ��");
        a_Idx = 0;
        foreach (KeyValuePair<string, string> a_Node in a_dt)
        {
            Debug.Log($"[{a_Idx} : Key({a_Node.Key}) , value({a_Node.Value})");
            a_Idx++;
        }
        //��ü����
        a_dt.Clear();
        Debug.Log("��ü������� Ȯ�� : " + a_dt.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
