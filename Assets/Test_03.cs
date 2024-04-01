using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 연산자 
// 1, 수식연산자 : +, -, *, /, %
// 2, 증감연산자 : ++, --
// 3, 할당연산자 : =, -=, +=, *=, /=, %=
// 4, 논리연산자 : &&, ||, !
// 5, 관계연산자 : <, >, ==, <=, >=, !=
// 6, 비트연산자 : &, |, ^

public class Test_03 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //1, 수식연산자 : +, -, *, /, %
        int a = 88, b = 22;
        int c = a + b;
        Debug.Log(a + " + " + b + " = " + c);

        c = a - b;
        Debug.Log(a + " - " + b + " = " + c);

        //string str = string.Format("{0} * {1} = {2}", a, b, a * b);
        string str = $"{a} * {b} = {a * b}";
        Debug.Log(str);

        //str = string.Format("{0} / {1} = {2}", a, b, a / b);
        //str = $"{a} / {b} = {a / b}";
        Debug.Log($"{a} / {b} = {a / b}");

        // % 나머지 연산자
        Debug.Log($"{a} % {b} = {a % b}");
        // 나눈 숫자보다 하나 작은 값까지 반복되는 특징이 있다.
        //    몫         나머지
        // 0 / 2 = 0    0 % 2 = 0
        // 1 / 2 = 0    1 % 2 = 1
        // 2 / 2 = 1    2 % 2 = 0
        // 3 / 2 = 1    3 % 2 = 1
        // 4 / 2 = 2    4 % 2 = 0
        // 5 / 2 = 2    5 % 2 = 1

        // 2, 증감 연산자 : ++, --
        // c, c++, c#
        int cc = 0;
        cc++;       // c = c + 1;  1증가 시키라는 뜻
        ++cc;       // 단독으로 쓰일 때는 1증가 시키라는 뜻
        Debug.Log("단독 사용일 경우 : " + cc);

        cc = 0;
        Debug.Log(string.Format("복합 명령어로 사용될 경우 뒤에 붙일 때 : {0}", cc++));

        cc = 0;
        Debug.Log(string.Format("복합 명령어로 사용될 경우 앞에 붙일 때 : {0}", ++cc));

        int ff = 10;
        ff--;       // ff = ff - 1; //단독으로 쓰일 때는 1감소 시키라는 의미
        --ff;
        Debug.Log(string.Format("ff : {0}", ff));

        // 3, 할당연산자 =, -=, +=, *=, /=, %=
        int a_xx = 10;
        a_xx += 5;      // a_xx = a_xx + 5;
        // a_xx = a_xx + 1;   a_xx++;   a_xx += 1;
        a_xx -= 3;      // a_xx = a_xx - 3;
        int a_yy = 10;
        a_yy *= 2;      // a_yy = a_yy * 2;
        a_yy /= 2;      // a_yy = a_yy / 2;
        a_yy %= 2;      // a_yy = a_yy % 2;

        //4, 논리연산자 &&, ||, !
        int ggg = 50;
        int hhh = 60;
        bool a_Check = ggg > 40 && hhh > 50;    // && And  ~이고, 그리고
        Debug.Log("ggg > 40 && hhh > 50 : " + a_Check);
        // true  && true  = true
        // true  && false = false
        // false && true  = false
        // false && false = false

        a_Check = ggg > 40 || hhh > 70;     // || Or  ~이거나, 또는
        Debug.Log("ggg > 40 || hhh > 70 : " + a_Check);
        // true  || true  = true
        // true  || false = true
        // false || true  = true
        // false || false = false

        a_Check = !(ggg > hhh);     // Not 결과를 반전시키는 연산자
        Debug.Log(a_Check);

        // 5, 관계연산자 : <, >, <=, >=, ==, !=
        int AAA = 50;
        int BBB = 60;
        Debug.Log("AAA < BBB : " + (AAA < BBB));    // True
        Debug.Log("AAA > BBB : " + (AAA > BBB));    // False
        Debug.Log("AAA == BBB : " + (AAA == BBB));  // False
        Debug.Log("AAA != BBB : " + (AAA != BBB));  // True
        Debug.Log("AAA <= BBB : " + (AAA <= BBB));  // True
        Debug.Log("AAA >= BBB : " + (AAA >= BBB));  // False

        // 6, 비트연산자 : &, |, ^
        int nnn = 5;        // 0101
        int mmm = 10;       // 1010

        int Result = nnn & mmm;   // 0000 --> 0
        Debug.Log("nnn & mmm : " + Result);

        Result = nnn | mmm;       // 1111 --> 15
        Debug.Log("nnn | mmm : " + Result);

        // ^ XOR 연산자 : 두값이 같으면 0, 두값이 다르면 1
        Result = nnn ^ mmm;       // 1111 --> 15
        Debug.Log("nnn ^ mmm : " + Result);

        int kkk = 2357;
        int a_ScVal = kkk ^ 6789;   //암호화
        Debug.Log("a_ScVal : " + a_ScVal);  //5040
        int a_MyVal = a_ScVal ^ 6789;   //복호화
        Debug.Log("a_MyVal : " + a_MyVal);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
