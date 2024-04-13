using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//overriding : virtual ,override
//상속관계 있는 부모쪽에 있는 메서드를 자식 쪽 클래스에 같은 메서드로 생성하기위해
//재정의해서 사용하는 문법
//overriding 조건
//1. 함수의 이름이 같아야함
//2. 매개변수가 같아야한다
//3. 반환타입이 같아야한다
//4. 부모클래스의 virtual 키워드가 있어야한다.




//up down casting 

// up - class Animal{}
// class dog:aniaml{}
//Dog dog new dog
//Animal animal = dog;

//down 

// animal animal2  = new animal();
//Dog a_Dog2 = (dog)a_animal2; //down casting---아래의 조건이 아니면 Invalid catException에러
//업캐스팅이 되어있던 객체만 다시 다운시키는게 가능하다.
//Invaild Casting exception
//Dog a_Down = (Dog)animal-- 원래대로 


class MyParent
{
    public int m_ii;

    public MyParent()
    {
        Debug.Log("Myparent의 생성자 함수 호출");

       
    }
    public void method()
    {
        Debug.Log("Myparent 메서드 호출");
    }
    public virtual void Myprint()
    {
        Debug.Log("부모클래스의 Myprint메서드 호출");
    }
}

class MyBoy : MyParent
{
    public MyBoy()
    {
        m_ii = 0;
    }


    public new void method() //up casting 시 override와 달리 그 데이터형 변수를 호출한다.
    {   //new 키워드를 사용시 오버라이딩을 대신한다.
        Debug.Log("MyBoy의 method 호출");
    }

    public override void Myprint()
    {
        Debug.Log("MyBoy의 myprint 호출");
    }
}


class MyDaughter : MyParent
{
    public override void Myprint()
    {
        Debug.Log(" MyDaughter 클래스의 myprint 메서드 호출");
    }
}

public class Test_03 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyParent a_pp = new MyParent();
        a_pp.Myprint(); //----output ("부모클래스의 Myprint메서드 호출");


        MyBoy xx = new MyBoy();//"MyBoy의 myprint 호출");
        xx.Myprint();

        MyDaughter a_dd = new MyDaughter();
        a_dd.Myprint(); //(" MyDaughter 클래스의 myprint 메서드 호출");

        MyParent a_yy = xx; //upcasting
        a_yy.method(); //output : "Myparent 메서드 호출");
        a_yy.Myprint(); //output : /"MyBoy의 myprint 호출");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
