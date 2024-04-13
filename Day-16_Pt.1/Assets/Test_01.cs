using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// ���ʸ� -> c++ template
//�����Ϸ��� �μ��� �����Ͽ� ������ �߿� Ŭ������ �Լ��� ����� ���� ��Ʋ�̴�.

public class Student

{
    public string m_Name;

    public int m_Kor;

    public int m_Eng;

    public int m_Math;

    public int m_Total;

    public float m_Avg;

    public Student(string a_Name = "", int a_Kor = 0, int a_Eng = 0, int a_Math = 0)
    {
        m_Name = a_Name;

        m_Kor = a_Kor;

        m_Eng = a_Eng;

        m_Math = a_Math;

        m_Total = m_Kor + m_Eng + m_Math;

        m_Avg = m_Total / 3.0f;
    }
    public string GetInfoStr()
    {
        return $"{m_Name} : ����({m_Kor}) ����({m_Eng}) ����({m_Math}) ����({m_Total}) ���({m_Avg:N2})";
    }

}
public class Test_01 : MonoBehaviour
{
    public class MyGeneric<T>
    {
        T a_ii;
        public MyGeneric(T a_in)
        {
            a_ii = a_in;
        }
        public T Get()
        {
            //int abc = a_ii + 123; //�̷��� ��ȯ�� �ȵ�.
            //a_ii = a_ii = 123; //�̷��� �ǿ����ڰ� t�� �ȵ�
            return a_ii;
        }
    }


    void MySwap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    //void MySwap(ref int a,  ref int b)
    //{
    //    int temp = a;
    //    a = b;
    //    b = temp;
    //}
    //void MySwap(ref double a, ref double b) //�����ε�
    //{
    //    double temp = a;
    //    a = b;
    //    b = temp;
    //}

    //void MySwap(ref float a, ref float b)
    //{
    //    float temp = a;
    //    a = b;
    //    b = temp;
    //}


    // Start is called before the first frame update
    void Start()
    {
        int a = 111;
        int b = 999;


        //MySwap(ref a, ref b);
        MySwap<int>(ref a, ref b);
        Debug.Log($"a({a}) {b}");


        double C = 10.1, d = 20.2;
        //MySwap(ref C, ref d);
        MySwap<double>(ref C, ref d);
        Debug.Log($"C({C}), d({d})");

        float e = 3.14f, f = 1.23f;
        //MySwap(ref e, ref f);
        MySwap<float>(ref e, ref f);
        Debug.Log($"e({e}),f({f}");



        MyGeneric<int> AAA = new MyGeneric<int>(10);
        Debug.Log(AAA.Get());



        MyGeneric<string> BBB = new MyGeneric<string>("GDragon");
        Debug.Log(BBB.Get()); //output : GDragon


        Student CCC = new Student("�����", 34, 56, 78);
        MyGeneric<Student> DDD = new MyGeneric<Student>(CCC);
        Debug.Log(DDD.Get().m_Name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
