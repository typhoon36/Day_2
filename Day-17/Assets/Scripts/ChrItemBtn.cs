using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChrItemBtn : MonoBehaviour
{
    public Text ShowInfo;
    Chr_Stat m_RefChrStat = null;

    // Start is called before the first frame update
    void Start()
    {
        Button a_BtnCom = this.GetComponent<Button>();
        if (a_BtnCom != null)
            a_BtnCom.onClick.AddListener(() =>
            {
                GlobalValue.g_CurSelCStat = m_RefChrStat;

                LobbyMgr a_LobbyMgr = GameObject.FindObjectOfType<LobbyMgr>();
                if (a_LobbyMgr != null)
                    a_LobbyMgr.RefreshChrSelUI();
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitState(Chr_Stat a_ChrStat)
    {
        m_RefChrStat =a_ChrStat;

        //직업 한글로 가져오기
        ShowInfo.text = $"{a_ChrStat.m_StrJob}\n({a_ChrStat.m_Name})";


    }
}
