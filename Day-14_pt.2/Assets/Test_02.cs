using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//dictionary
//키값과 value로 구성된 자료구조
//장점;큰 데이터를 관리하기 편하다.
//단점;원하는 조건으로 정렬이 쉽지않다.

public class Test_02 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string , string> a_dt = new Dictionary<string , string>();

        a_dt["apple"] = "사과";
        a_dt["strawberry"] = "딸기";
        a_dt["banana"] = "바나나!";
        a_dt["watermelon"] = "수박";
        a_dt["orange"] = "오렌지";


        //---순환 출력
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



        //검색
        Debug.Log(a_dt["banana"]);

        if(a_dt.ContainsKey("mango")==true) //존재할경우 검색
        Debug.Log(a_dt["mango"]);

        a_dt["apple"] = "멜론"; //이미 존재하는 키를 대입시 value값이 바뀜.



         a_Idx = 0;
        foreach (KeyValuePair<string, string> a_Node in a_dt)
        {
            Debug.Log($"[{a_Idx} : Key({a_Node.Key}) , value({a_Node.Value})");
            a_Idx++;
        }

        //주의사항 :KeyNotFoundException: The given key 'mango' was not present in the dictionary.라는 에러가 발생한다.
        //존재하는지를 인지해야만 검색가능 -> 해결방법? 46줄의 key.containskey로 존재여부 물어봄

        //삭제
        a_dt.Remove("banana");

        Debug.Log("삭제결과확인");
        a_Idx = 0;
        foreach (KeyValuePair<string, string> a_Node in a_dt)
        {
            Debug.Log($"[{a_Idx} : Key({a_Node.Key}) , value({a_Node.Value})");
            a_Idx++;
        }
        //전체삭제
        a_dt.Clear();
        Debug.Log("전체삭제결과 확인 : " + a_dt.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
