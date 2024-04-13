using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMgr : MonoBehaviour
{
    CUnit m_RefHero = null;

    public Button m_BackBtn;
    public Text txtLogMsg;
    List<string> m_MsgList = new List<string>();

    public Button m_AttackBtn;
    public Button m_SkillBtn;

    // Start is called before the first frame update
    void Start()
    {
        if (m_BackBtn != null)
            m_BackBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("LobbyScene");
            });

        if (m_AttackBtn != null)
            m_AttackBtn.onClick.AddListener(AttackBtnClick);

        if (m_SkillBtn != null)
            m_SkillBtn.onClick.AddListener(SkillBtnClick);


        SpawnCharacter();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AttackBtnClick()   
    {
        //LogMsg("공격 발동");
        if(m_RefHero == null)
            return;

        m_RefHero.Attack();
    }

    void SkillBtnClick()
    {
        //LogMsg("스킬을 시전합니다.");

        if(m_RefHero == null)
            return;


        m_RefHero.UseSkill();
    }

    public void LogMsg(string msg)
    {
        m_MsgList.Add(msg);
        if (8 < m_MsgList.Count)
            m_MsgList.RemoveAt(0);

        txtLogMsg.text = "";
        for(int i = 0; i < m_MsgList.Count; i++)
        {
            txtLogMsg.text += m_MsgList[i];
            txtLogMsg.text += "\n";
        }
    }//public void LogMsg(string msg)


    void SpawnCharacter()
    {
        if (GlobalValue.g_CurSelCStat == null) //선택된게 없다.
            return;

        GameObject a_ChrObj = Resources.Load("Hero") as GameObject;
        if(a_ChrObj != null)
        {
            GameObject a_CloneObj = Instantiate(a_ChrObj); //히어로 스폰
            if (a_CloneObj != null)
            {
                m_RefHero = GlobalValue.g_CurSelCStat.MyAddComponent(a_CloneObj);
                //직업 컴포넌트 빙의 및 GlobalValue.g_CurSelCStat <---이 스탯 전달
            }
        }// if(a_ChrObj == null)

    }// void SpawnCharacter()
}
