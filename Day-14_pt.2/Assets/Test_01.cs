using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����Ƽ c# �ڷᱸ�� 
//stack Queue
//����
//�뵵 : �ӽ� ����� 
//LIFO(ī�尡 �׿��ִٰ� ���������� ������� ���)

//ť
// �ֿ뵵 �ӽ����� ����
// ��Ŷ�̶�� ������ �޾Ƴ��� ó���ϴ� ���
//FIFO(���� �߰��� �����Ͱ� ����ó��)


public class Test_01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //stack
        Stack<int> a_Stk = new Stack<int>();
        a_Stk.Push(10);
        a_Stk.Push(22);
        a_Stk.Push(33);
        a_Stk.Push(3);
        a_Stk.Push(45);

        int a_Idx = 0;
        while (0 < a_Stk.Count)
        {
            int Val = a_Stk.Pop();
            Debug.Log($"[{a_Idx}] : {Val}");
            a_Idx++;
        }

        Debug.Log(a_Stk.Count + ": ������ ����");

        //ť
        Queue<float> a_Que = new Queue<float>();

        a_Que.Enqueue(1.1f);
        a_Que.Enqueue(2.2f);
        a_Que.Enqueue(3.3f);
        a_Que.Enqueue(4.4f);
        a_Que.Enqueue(5.5f);

        a_Idx = 0;
        while (0 < a_Stk.Count)
        {
            float a_Quval = a_Que.Dequeue();
            Debug.Log($"[{a_Idx}] {a_Quval}");
            a_Idx++;
        }
        Debug.Log("��������" + a_Que.Count);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
