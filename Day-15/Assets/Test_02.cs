using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���
// �θ� Ŭ������ ��������� ��� �Լ��� �ڽ� Ŭ������ ��ӹ޾Ƽ� ����ϰڴ�.
// �ڵ��� ��Ȱ���� ���� ��� : ��������� �ѹ� �����
// ��� Ŭ������ ������ �Ļ�Ŭ������ Ȯ���ؼ� ����� �������

// �������� ���� Ȱ�� (�̷��� �߰� ����� �����ϱ����� ����)

// ��� Ư���� ���� �з�

// Ȯ�� ��� ; ����-> ���� , ���� - �Ĺ�
// ���� ��� ; ����- ���� - ������ - ���
// ���� ��� ; �ڵ���, ī�޶� - ī�޶���
// ������ ��ĳ�� �ѽ� - ���ձ�
// c#������ ���߻�� Ŭ������ �������̽�(IComparable method...)
//-> ������ �߻��Լ��� �־ ����� ����ġ����.


public class Parent //public�� ���� �ٸ� Ŭ���� ��������� ��� �Ұ�
{
    public int num;
    public int m_Age;
    protected int m_Height;



    public Parent()
    {
        m_Age = 10;
        m_Height = 130;
        Debug.Log("�θ� Ŭ���� �����ڰ� ȣ��Ǿ����ϴ�.");
    }

    public void PrintInfo()
    {
        Debug.Log($"num : {this.num}");
    }


}

public class child : Parent  //�θ�Ŭ���� ȣ�� �ݷ�(:)
{
    new public int num; //�θ�Ŭ������ ����� num�� �����.-> ������ ������ �����ֱ� ���� ������
    public int m_Kg;

    public child(int a_Num)   //������ �����ε�
    {
        this.num = a_Num; //�ڽ� ȣ��
        base.num = a_Num * 100;//�θ𺯼�/�Լ� ȣ��
        m_Kg = 40;

        Debug.Log("�ڽ�Ŭ������ �����ڰ� ȣ��Ǿ����ϴ�.");
    }


    public void DisplayValue()
    {
        Debug.Log($"�θ��� num : {base.num}, �ڽ��� num, : {this.num}");
        Debug.Log($"����: {m_Age} , Ű :  {m_Height}, �� ���� : {m_Kg}");

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
        //Debug.Log(cd.m_Height--protected --sealedŰ����ó�� �ܺο��� �����ϰ� �����ڸ� �߱⿡ ��� �Ұ�

        cd.num = 77;
        cd.DisplayValue();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

