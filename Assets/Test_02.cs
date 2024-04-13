using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class MyItem
{
    public string m_Name = ""; //아이템 이름
    public int m_Level = 0; //아이템 레벨
    public float m_AttRate = 1.0f; //공격상승률
    public int m_price = 100; //아이템 가격

    public MyItem(string a_Name = "", int a_Lv = 0, float a_Ar = 0.0f, int a_price = 0)
    {
        // 생성자 오버로딩 함수
        m_Name = a_Name;
        m_Level = a_Lv;
        m_AttRate = a_Ar;
        m_price = a_price;
    }
    public void PrintInfo()
    {
        Debug.Log($"이름({m_Name}) : 레벨 ({m_Level}) 공격상승률 ({m_AttRate}) 가격({m_price})");
    }


}



public class Test_02 : MonoBehaviour
{
    List<MyItem> m_ItList = new List<MyItem>();

    int PriceASC(MyItem a, MyItem b)  //정렬조건
    {
       return a.m_price.CompareTo(b.m_price); //오름차순 정렬   가격이 낮은순에서 높은순으로 정렬
    }

    int LevelDSC(MyItem a, MyItem b)
    {
        return b.m_Level.CompareTo(a.m_Level); //내림차순 정렬 레벨이 높은순에서 낮은순으로 정렬
    }


    // Start is called before the first frame update
    void Start()
    {
        int AAA;
        AAA = 10;
        int BBB = 10; //변수 선언과 동시에 초기화

        //<1번 초기화 방법> 객체를 선언후 초기화

        //MyItem a_Node = new MyItem();
        //a_Node.m_Name = "천사의 반지";
        //a_Node.m_Level = 3;
        //a_Node.m_AttRate = 2.0f;
        //a_Node.m_price = 2500;


        //2번초기화:객체 선언과 동시에 초기화

        //MyItem a_Node = new MyItem("천사의 반지",3,2.0f, 2500);


        //3번 초기화 :객체 선언과 동시에 선택적 초기화 

        MyItem ABC = new MyItem { m_Name = "테스트", m_price = 1500 };
        ABC.PrintInfo();


        //노드 추가

        MyItem a_Node = new MyItem("천사의 반지", 3, 2.0f, 2500);
        m_ItList.Add(a_Node);
        a_Node = new MyItem("팔라독의 검", 1, 1.2f, 1200);
        m_ItList.Add(a_Node);

        a_Node = new MyItem("궁수의 활", 4, 1.7f, 1700);
        m_ItList.Add(a_Node);

        a_Node = new MyItem("거북이의 갑옷", 5, 1.5f, 3000);
        m_ItList.Add(a_Node);


        //순환

        for (int i = 0; i < m_ItList.Count; i++)
        {
            m_ItList[i].PrintInfo();
        }
        //~ 순환


        //삭제
        Debug.Log("-----");

        //m_ItList.RemoveAt(0);
        //Debug.Log("첫번째 노드 삭제 결과--");

        //foreach (MyItem a_It in m_ItList)
        //{
        //    a_It.PrintInfo();
        //}

        //마지막 노드 삭제

        //if(0 < m_ItList.Count)

        //    m_ItList .RemoveAt(m_ItList.Count - 1); //마지막 인덱스 삭제

        // removeat함수는 법뮈을 벗어난 인덱스를 제거하려고 시도하면 에러난다.

        //foreach (MyItem a_It in m_ItList)
        //{
        //    a_It.PrintInfo(); <+_____ 숫자를 넣으면 에러
        //}

        //노드의 내용을 찾아서 삭제하는 방법

        //MyItem a_FNode = m_ItList[1];//팔라독의 검
        //if (m_ItList.Contains(a_FNode) == true)  //a_FNode 인스턴스가 리스트에 있는지?
        //{
        //    m_ItList.Remove(a_FNode);
        //}

        //foreach (MyItem a_It in m_ItList)
        //{
        //    a_It.PrintInfo();
        //}

        //MyItem a_FNode = new MyItem("너구리의 장화", 1, 1.1f, 1000);
        //m_ItList.Remove(a_FNode);
        ////remove 함수는 객체가 리스트에 존재치 않은 상태에서 제거 시도를 해도 에러나지않는다.
        //foreach ( MyItem a_It in m_ItList)
        //{ a_It.PrintInfo(); } //없으면 말고~식으로 에러가 안남

        //중간 중간에 조건에 만족하는 경우만 선택삭제

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


        //중간값 추가

        //a_Node = new MyItem("상어의 이빨", 4 ,1.2f,12000);
        //  m_ItList.Insert(1, a_Node);
        m_ItList.Insert(1, new MyItem("상어의 이빨", 4, 1.2f, 12000)); 
        Debug.Log("1번 인덱스 중간값 추가 결과");
        foreach(MyItem a_It in m_ItList)
           a_It.PrintInfo();
        Debug.Log("-----");

        //정렬
        //가격이 낮은순에서 높은순으로 정렬 사용

        //List<MyItem> a_CopyList = new m_ItList.ToList(); //리스트 복사 using System.Linq;
        //a_CopyList.Sort(PriceASC);
        //Debug.Log("-------가격이 낮은순에서 높은순으로 정렬-------");

        m_ItList.Sort(PriceASC);
        Debug.Log("-------가격이 낮은순에서 높은순으로 정렬-------");
        foreach (MyItem a_It in m_ItList)
            a_It.PrintInfo();
       



        //레벨이 높은순에서 낮은순으로 정렬 사용

        m_ItList.Sort(LevelDSC);
        Debug.Log("-----레벨이 높은순에서 낮은순으로 정렬------");
        foreach (MyItem a_It in m_ItList)
            a_It.PrintInfo();


        //검색
        Debug.Log("--List 검색----");
        MyItem a_FindNode = null;
        for(int i = 0; i < m_ItList.Count; i++)
        {
            if (m_ItList[i].m_Name == "상어의 이빨")
            { 
                a_FindNode = m_ItList[i];
                break;
            }

        }
        if (a_FindNode != null)
            a_FindNode.PrintInfo();

        MyItem a_FNode = m_ItList.Find((a_NN) => a_NN.m_Name == "팔라독의 검");
        if (a_FNode == null)
            a_FNode.PrintInfo();
        //검색의 끝

        //전체노드 삭제
        m_ItList.Clear(); //allclear
        Debug.Log("--------전체노드삭제결과----");
        Debug.Log(m_ItList.Count);
        //~전체노드삭제


    }

    // Update is called once per frame
    void Update()
    {

    }
}
