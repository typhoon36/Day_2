using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// <C# 변수 적용범위 분류>
// 1, 지역변수
// 2, 클래스 소속 맴버변수 : 클래스 소속의 변수를 맴버 변수라고 한다.
// 3, 클래스 소속 정적맴버변수 : 생명주기가 프로그램 시작해서 끝날 때까지의 변수

// <C, C++ 변수의 적용범위 분류>
// 1, 지역변수
// 2, 클래스 소속 맴버변수 
// 3, 클래스 소속 정적맴버변수
// 4, 전역변수
// 5, 지역 정적변수

// 지역변수의 특징 : 자기 지역 소속 내에서만 사용 가능한 변수 {  }
// 1, 자기 소속의 지역을 벗어나서는 사용할 수 없다.
// 2, 변수 선언 전에는 사용 할 수 없다.
// 3, 자기 소속의 하위 중괄호(지역) 안에서는 사용할 수 있다.
// 4, 같은 지역 내에서는 같은 이름의 변수를 선언할 수 없다.
// 5, 소속이 다르면 같은 이름의 지역변수를 만들 수 있다.



public class Test_02 : MonoBehaviour
{ //< Ctrl > + < ] > : 중괄호 짝을 찾아가는 단축키

    public int m_ABC = 0;  //<-- 클래스 소속의 맴버변수
    public static int s_CDE = 0;    //<-- 클래스 소속의 정적 맴버변수

    public int m_zzz = 0;

    // Start is called before the first frame update
    void Start()
    {

        m_ABC = 11;

        //a_AAA = 123;  //변수 선언 전에는 사용할 수 없다.

        int a_AAA = 0;  //<-- 지역 변수의 선언
        a_AAA = 777;
        Debug.Log(a_AAA);

        {
            a_AAA = 888; //<-- 자기 소속의 하위 중괄호(지역) 안에서는 사용할 수 있다.

            int a_BBB = 5; //<-- 지역 변수의 선언
            a_BBB = 10;

            {
                a_AAA = 55; //<-- 자기 소속의 하위 중괄호(지역) 안에서는 사용할 수 있다.
                a_BBB = 33; //<-- 자기 소속의 하위 중괄호(지역) 안에서는 사용할 수 있다.
            }
        }

        //a_BBB = 77; //<-- 자기 소속 지역을 벗어나서는 사용할 수 없다.

        //int a_CCC = 0;

        {
            int a_CCC = 10;
            //int a_CCC = 20; //<-- 같은 지역 내에서는 같은 이름의 변수를 선언할 수 없다.
        }

        {
            int a_CCC = 20;
        }

        {
            int m_ABC = 123; //<-- 지역변수는 맴버변수와 같은 이름으로 선언해서 사용할 수 있다.
            m_ABC = 333; //여기서는 m_ABC는 가까운쪽 우선된다는 규칙에 의해 지역변수를 의미한다.
            Debug.Log(m_ABC + " : " + this.m_ABC); //<-- 명시적으로 맴버변수에 접근하는 방법
            //여기서의 this는 Test_2 class 자기 자신을 의미한다.
        }

    }//void Start()

    //a_AAA = 123; //자기 지역을 벗어나서 사용할 수 없다.
    //<-- 클래스 중괄호 안에서는 코드를 작성할 수 없다.

    // Update is called once per frame
    void Update()
    {
        //a_AAA = 123; //지역변수는 자기 소속을 벗어나서는 사용할 수 없다.
        m_ABC = 777;
    } //void Update()
}