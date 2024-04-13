using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValue 
{
    //    public static string g_Unique_ID = ""; //고유번호

    //    public static string g_NickName = "";
    //    public static int g_BestScore = 0;
    //    public static int g_UserGold = 0;
    //    public static int g_Exp = 0;
    //    public static int g_Level = 0;

    public static Chr_Stat g_CurSelCStat = null; //현재 선택하고 있는 캐릭터 인덱스 null은 선택된 캐릭터가 없다는 뜻
    public static List<Chr_Stat> g_MyChrList = new List<Chr_Stat>(); //내가 보유하고있는 캐릭터 리스트로 관리를 위해 리스트 함수 이용

    //유저 정보

    public static void LoadGameData()
    {
        if (g_MyChrList.Count <= 0)  //로딩 한번만 되게 하기 위해
        {
            //+ 내 인벤토리에 내가 보유하고 있는 캐릭터 목록 로딩 및 추가를 위한 로직 -->30ea 3-4ea일때 로직을 짜놓기 위한 로직문
            Chr_Stat a_CrNode = new Wizard_Stat("간달프", 70);
            g_MyChrList.Add(a_CrNode);

            a_CrNode = new BarBarian_Stat("바이킹", 1, 3);
            g_MyChrList.Add(a_CrNode );

            a_CrNode = new Archer_Stat("레골라스", 100);
            g_MyChrList.Add (a_CrNode );

            a_CrNode = new Healer_Stat("초보치료사", 5);
            g_MyChrList.Add(a_CrNode);
            //~ 내 인벤토리에 내가 보유하고 있는 캐릭터 목록 로딩 및 추가를 위한 로직

        } //~ 로딩 한번만 되게 하기 위해






    }//~로딩게임데이터





}
