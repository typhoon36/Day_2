using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 상속
// 부모 클래스의 멤버변수나 멤버 함수를 자식 클래스가 상속받아서 사용하겠다.
// 코드의 재활용을 위해 사용 : 공통사항은 한번 만들고
// 기반 클래스를 가지고 파생클래스를 확장해서 만들어 사용하자

// 다형성을 위해 활용 (미래의 추가 기능을 대응하기위한 구조)

// 상속 특성에 따른 분류

// 확장 상속 ; 생물-> 동물 , 생물 - 식물
// 다차 상속 ; 생물- 동물 - 포유류 - 사람
// 다중 상속 ; 핸드폰, 카메라 - 카메라폰
// 프린터 스캐너 팩스 - 복합기
// c#에서는 다중상속 클래스는 인터페이스(IComparable method...)
//-> 순수히 추상함수만 있어서 상속이 가능치못함.


public class Parent //public을 빼면 다른 클래스 멤버변수로 사용 불가
{
    public int num;
    public int m_Age;
    protected int m_Height;



    public Parent()
    {
        m_Age = 10;
        m_Height = 130;
        Debug.Log("부모 클래스 생성자가 호출되었습니다.");
    }

    public void PrintInfo()
    {
        Debug.Log($"num : {this.num}");
    }


}

public class child : Parent  //부모클래스 호출 콜론(:)
{
    new public int num; //부모클래스에 선언된 num을 숨긴다.-> 잠재적 오류를 없애주기 위해 숨겨줌
    public int m_Kg;

    public child(int a_Num)   //생성자 오버로드
    {
        this.num = a_Num; //자신 호출
        base.num = a_Num * 100;//부모변수/함수 호출
        m_Kg = 40;

        Debug.Log("자식클래스의 생성자가 호출되었습니다.");
    }


    public void DisplayValue()
    {
        Debug.Log($"부모의 num : {base.num}, 자식쪽 num, : {this.num}");
        Debug.Log($"나이: {m_Age} , 키 :  {m_Height}, 몸 무게 : {m_Kg}");

        PrintInfo();
    }
}


public class Test_02 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Parent pt = new Parent();
        pt.num = 80;
        pt.PrintInfo();


        child cd = new child(20);
        cd.DisplayValue();
        Debug.Log(cd.m_Age);
        //Debug.Log(cd.m_Height--protected --sealed키워드처럼 외부에서 사용못하게 지정자를 했기에 사용 불가

        cd.num = 77;
        cd.DisplayValue();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

