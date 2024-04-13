using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;



//c# 자료구조( 자료구조 라이브러리 : Generic Collection
//Generic collection 중 list


public class Test_01 : MonoBehaviour
{
    //정렬조건함수
    int Comp(int a, int b)
    {
      /*  return a.CompareTo(b);*/ //오름차순(ASX) : 낮은값에서 높은값으로 정렬 1,2,3,4,5
        return b.CompareTo(a); //내림차순(DESC) : 높->낮
    }

    // Start is called before the first frame update
    void Start()
    {
        //list 사용

        List<int> a_List = new List<int>();

        Debug.Log("노드 추가히기");

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

        //Debug.Log("중간값 제거");


        //a_List.RemoveAt(1);//1번 인덱스 노드 제거

        //for (int ii = 0; ii < a_List.Count; ii++)
        //{
        //    Debug.Log($"a_List[{ii}] : {a_List[ii]}"); //중간값 제거
        //}

        //Debug.Log("----------마지막노드제거");
        //if (a_List.Count > 0)
        //    a_List.RemoveAt((a_List.Count - 1));
        for (int ii = 0; ii < a_List.Count; ii++)
        {
            Debug.Log($"a_List[{ii}] : {a_List[ii]}"); //마지막값 제거
        }

        Debug.Log("중간값 추가하기");
        a_List.Insert(1, 10);
        a_List.Insert(3, 30);

        int a_Idx = 0;
        foreach (int val in a_List) 
        {
            Debug.Log($"a_List[{a_Idx}] : {val}");
            a_Idx++;
        }

        Debug.Log("정렬하기");

        a_List.Sort( Comp );
        for (int ii = 0; ii < a_List.Count; ii++)
        {
            Debug.Log($"a_List[{ii}] : {a_List[ii]}"); 
        }

        Debug.Log("전체노드 삭제하기");

        a_List.Clear();

        Debug.Log("노드의 갯수 : " + a_List.Count);




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
