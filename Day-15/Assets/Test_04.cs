using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//다차상속에서의 생성자 호출 grand - parent2 - child2


public class GrandParent
{
    public string m_UserName;
    public long m_UserId;

 //public GrandParent()
 //   {
 //       Debug.Log("생성자 함수 호출");
 //   }

    public void CallPrint()
    {
        Debug.Log("GrandParent 의 함수 호출");
    }


    public virtual void Mypint()
    {
        Debug.Log("grandparent 의 mypint 호출");
    }
}

public class Parent2 : GrandParent
{
    public int m_UserAge;

    //public Parent2()
    //{
    //    Debug.Log("parent2의 생성자 함수 호풀");
    //}
    public new void CallPrint()
    {
        Debug.Log("Parent2 의 callprint 함수 호출");
    }

    public override void Mypint()
    {
        Debug.Log("Parent2 mypint 메서드 호풀");
    }
}

public class Child2 : Parent2
{
    public int m_Height;

    //public Child2()
    //{
    //    Debug.Log("Child2 생성자 호출");


    //}

    public new void CallPrint()
    {
        Debug.Log("Child2 의 callprint 함수 호출");
    }

    public override void Mypint()
    {
        Debug.Log("child2 mypint mypint메서드 호출");
    }
}


public class Test_04 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Child2 a_Cld = new Child2();
        //GrandParent AAA = a_Cld;


        GrandParent AAA = new Child2();
        AAA.Mypint();
        AAA.CallPrint(); //grand parent....
        ((Parent2)AAA).CallPrint();
        ((Child2)AAA).CallPrint();

        GrandParent BBB = new  Parent2();
        BBB.Mypint(); //parnet mypint메서드 호출


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
