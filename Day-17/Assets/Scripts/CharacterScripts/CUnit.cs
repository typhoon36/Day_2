using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharicType
{
    Wizard = 0,     //마법사
    Barbarian,      //바바리안
    Archer,         //궁수
    Healer,         //힐러
    Count
}

public class Chr_Stat       //Stat, attribute, 능력치 (캐릭터 설정 데이터)
{
    public CharicType m_CharType;   //캐릭터 타입
    public string m_StrJob = "";    //직업이름 한글로 저장해 놓는다.
    public string m_Name = "";      //이름
    public string m_RscFile = "";   //리소스 프리팹 이름
    public int m_MaxHp   = 0;       //체력피통
    public int m_MaxMana = 0;       //마나통
    public int m_Attack  = 0;       //기본 공격력

    //캐릭터의 스텟 정보를 기반으로 지형에 돌아다니는 캐릭터 객체를 추가하려고 할 때 
    //Hero 게임 오브젝트에 빙의 시키킬 원하는 클래스 추가 함수
    public virtual CUnit MyAddComponent(GameObject a_ParentGObj)
    {
        CUnit a_RefHero = null;
        return a_RefHero;
    }
}

public class CUnit : MonoBehaviour
{
    [HideInInspector] public Chr_Stat m_ChrStat = null;

    [HideInInspector] public int m_CurHp   = 0;  //체력
    [HideInInspector] public int m_CurMana = 0;  //마나
    [HideInInspector] public int m_CurAtt  = 0;  //레벨업에 따른 공격력

    [HideInInspector] public InGameMgr m_RefGameMgr = null; //InGameMgr와 소통을 위한 객체

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //--- 캐릭터 공통 등장 준비
        m_RefGameMgr = FindObjectOfType<InGameMgr>(); //InGameMgr와 소통을 위한 객체를 찾아 놓는다.
        
        //등장시 호출함수(외형 모델링 로딩 리소스 셋탱, 캐릭터 고유 이펙트 메모리풀 준비)
        //상속 받는 쪽 공통 등장 코드(스폰 위치 등...)       
        GameObject a_ChrSprite = Resources.Load(m_ChrStat.m_RscFile) as GameObject; //--- 리소스 로딩
        if (a_ChrSprite != null)
        {
            GameObject a_Clone = Instantiate(a_ChrSprite); //지금 이 Hero GameObject 에 붙일 스프라이트 스폰
            a_Clone.transform.SetParent(this.transform, false); //Hero 밑에 차일드로 WizRenderer 붙이기...
        }
        //--- 캐릭터 공통 등장 준비

        //--- 스탯치 상태 변수에 충전
        m_CurHp   = m_ChrStat.m_MaxHp;
        m_CurMana = m_ChrStat.m_MaxMana;
        m_CurAtt  = m_ChrStat.m_Attack;
        //--- 스탯치 상태 변수에 충전
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //--- 캐릭터 공통 행동 패턴을 동작 시키키
    }

    public virtual void Attack()
    {
        //--- 캐릭터 공통 Attack 발동 처리
    }

    public virtual void UseSkill()
    {
        //--- 캐릭터 공통 Skill 발동 처리
    }
}
