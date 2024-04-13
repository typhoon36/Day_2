using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//유니티 c# 자료구조 
//stack Queue
//스택
//용도 : 임시 저장소 
//LIFO(카드가 쌓여있다가 위에서부터 뒤집어보는 경우)

//큐
// 주용도 임시저장 버퍼
// 패킷이라는 정보를 받아놓고 처리하는 경우
//FIFO(먼저 추가한 데이터가 먼저처리)


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

        Debug.Log(a_Stk.Count + ": 스택의 개수");

        //큐
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
        Debug.Log("남은개수" + a_Que.Count);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
