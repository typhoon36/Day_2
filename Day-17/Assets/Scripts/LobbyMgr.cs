using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMgr : MonoBehaviour
{
    public Button m_GameStartBtn;

    public Transform m_Root_Canvas = null;
    public Text m_SelChrText;

    Chr_Stat m_CurChrStat = null; //Lobby���� UI ǥ�ÿ� ����
    GameObject m_SelHero = null;  //Lobby���� UI ǥ�ÿ� ����


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;  //�Ͻ������� ���� �ӵ���
        GlobalValue.LoadGameData();

        RefreshChrUI();
        RefreshChrSelUI();

        if (m_GameStartBtn != null)
            m_GameStartBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("InGameScene");
            });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshChrUI()
    {
        GameObject a_CItemBtn = Resources.Load("ChrItemBtn") as GameObject;

        if(a_CItemBtn != null)
            for(int i = 0; i< GlobalValue.g_MyChrList.Count; i++)
            {
                GameObject obj = Instantiate(a_CItemBtn);
                obj.transform.SetParent(m_Root_Canvas, false);
                Vector3 a_CacPos = obj.transform.localPosition;
                a_CacPos.x += (i * 200);
                obj.transform.localPosition = a_CacPos;
                ChrItemBtn a_ChrItem = obj.GetComponent<ChrItemBtn>();
                a_ChrItem.InitState(GlobalValue.g_MyChrList[i]);
                

            }


    }

    public void RefreshChrSelUI()
    {
        if (m_SelChrText == null)
            return;

        m_SelChrText.text = "���� ���õ� ĳ���� : " + "����";

        if (GlobalValue.g_CurSelCStat == null)
            return;

        Chr_Stat a_ChrStat = GlobalValue.g_CurSelCStat;
        m_SelChrText.text = "���� ���õ� ĳ���� : " +$"{a_ChrStat.m_StrJob}, ({a_ChrStat.m_Name})";

        if (m_CurChrStat != GlobalValue.g_CurSelCStat)
        {
            if(m_SelHero != null)
            Destroy(m_SelHero );

            //ĳ���� ���� ������
            GameObject a_ChrObj = Resources.Load("Hero") as GameObject;
            
            if(a_ChrObj != null)
            {
                m_SelHero = Instantiate(a_ChrObj);
                if (m_SelHero != null)
                {
                    GlobalValue.g_CurSelCStat.MyAddComponent(m_SelHero);
                    //���� ������Ʈ ���� �� gloabalvalue g_CurSelCStat ����


                    //��ġ ������ ����

                    Vector3 a_Pos = m_SelHero.transform.position;
                    a_Pos.y -= 2.8f;
                    m_SelHero.transform.position = a_Pos;

                    Vector3 a_Scale = m_SelHero.transform.localScale;
                    a_Scale *= 0.7f;
                    m_SelHero.transform.localScale = a_Scale;
                }

            }



        }




    }



}
