using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//������ӿ����� ������ ȣ�� grand - parent2 - child2


public class GrandParent
{
    public string m_UserName;
    public long m_UserId;

 //public GrandParent()
 //   {
 //       Debug.Log("������ �Լ� ȣ��");
 //   }

    public void CallPrint()
    {
        Debug.Log("GrandParent �� �Լ� ȣ��");
    }


    public virtual void Mypint()
    {
        Debug.Log("grandparent �� mypint ȣ��");
    }
}

public class Parent2 : GrandParent
{
    public int m_UserAge;

    //public Parent2()
    //{
    //    Debug.Log("parent2�� ������ �Լ� ȣǮ");
    //}
    public new void CallPrint()
    {
        Debug.Log("Parent2 �� callprint �Լ� ȣ��");
    }

    public override void Mypint()
    {
        Debug.Log("Parent2 mypint �޼��� ȣǮ");
    }
}

public class Child2 : Parent2
{
    public int m_Height;

    //public Child2()
    //{
    //    Debug.Log("Child2 ������ ȣ��");


    //}

    public new void CallPrint()
    {
        Debug.Log("Child2 �� callprint �Լ� ȣ��");
    }

    public override void Mypint()
    {
        Debug.Log("child2 mypint mypint�޼��� ȣ��");
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
        BBB.Mypint(); //parnet mypint�޼��� ȣ��


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
