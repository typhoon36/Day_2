using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//overriding : virtual ,override
//��Ӱ��� �ִ� �θ��ʿ� �ִ� �޼��带 �ڽ� �� Ŭ������ ���� �޼���� �����ϱ�����
//�������ؼ� ����ϴ� ����
//overriding ����
//1. �Լ��� �̸��� ���ƾ���
//2. �Ű������� ���ƾ��Ѵ�
//3. ��ȯŸ���� ���ƾ��Ѵ�
//4. �θ�Ŭ������ virtual Ű���尡 �־���Ѵ�.




//up down casting 

// up - class Animal{}
// class dog:aniaml{}
//Dog dog new dog
//Animal animal = dog;

//down 

// animal animal2  = new animal();
//Dog a_Dog2 = (dog)a_animal2; //down casting---�Ʒ��� ������ �ƴϸ� Invalid catException����
//��ĳ������ �Ǿ��ִ� ��ü�� �ٽ� �ٿ��Ű�°� �����ϴ�.
//Invaild Casting exception
//Dog a_Down = (Dog)animal-- ������� 


class MyParent
{
    public int m_ii;

    public MyParent()
    {
        Debug.Log("Myparent�� ������ �Լ� ȣ��");

       
    }
    public void method()
    {
        Debug.Log("Myparent �޼��� ȣ��");
    }
    public virtual void Myprint()
    {
        Debug.Log("�θ�Ŭ������ Myprint�޼��� ȣ��");
    }
}

class MyBoy : MyParent
{
    public MyBoy()
    {
        m_ii = 0;
    }


    public new void method() //up casting �� override�� �޸� �� �������� ������ ȣ���Ѵ�.
    {   //new Ű���带 ���� �������̵��� ����Ѵ�.
        Debug.Log("MyBoy�� method ȣ��");
    }

    public override void Myprint()
    {
        Debug.Log("MyBoy�� myprint ȣ��");
    }
}


class MyDaughter : MyParent
{
    public override void Myprint()
    {
        Debug.Log(" MyDaughter Ŭ������ myprint �޼��� ȣ��");
    }
}

public class Test_03 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyParent a_pp = new MyParent();
        a_pp.Myprint(); //----output ("�θ�Ŭ������ Myprint�޼��� ȣ��");


        MyBoy xx = new MyBoy();//"MyBoy�� myprint ȣ��");
        xx.Myprint();

        MyDaughter a_dd = new MyDaughter();
        a_dd.Myprint(); //(" MyDaughter Ŭ������ myprint �޼��� ȣ��");

        MyParent a_yy = xx; //upcasting
        a_yy.method(); //output : "Myparent �޼��� ȣ��");
        a_yy.Myprint(); //output : /"MyBoy�� myprint ȣ��");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
