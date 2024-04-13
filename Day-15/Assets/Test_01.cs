using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// 제너릭 -> c++ template
//컴파일러가 인수를 적용하여 컴파일 중에 클래스나 함수를 만들어 내는 형틀이다.

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
        return $"{m_Name} : 국어({m_Kor}) 영어({m_Eng}) 수학({m_Math}) 총점({m_Total}) 평균({m_Avg:N2})";
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
            //int abc = a_ii + 123; //이러면 변환이 안됨.
            //a_ii = a_ii = 123; //이래도 피연산자가 t라 안됨
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
    //void MySwap(ref double a, ref double b) //오버로딩
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


        Student CCC = new Student("고양이", 34, 56, 78);
        MyGeneric<Student> DDD = new MyGeneric<Student>(CCC);
        Debug.Log(DDD.Get().m_Name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
