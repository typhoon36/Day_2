using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Mgr : MonoBehaviour
{
    //---- ���� ���� 
    public static string g_UserName = "SBS����";
    public static int g_GameGold    = 1000;
    //---- ���� ����

    List<CItem> m_ItemList = new List<CItem>();

    [Header("--- AddEditNode ---")]
    public GameObject AddNodeRoot = null;
    public InputField ItName_Ifd  = null;

    public Button Add_Btn = null;
    public Button Find_Btn = null;
    public Text PrintList = null;

    public Button ShowList_Btn = null;
    public Button LvSort_Btn = null;
    public Button GdSort_Btn = null;
    public Button Clear_Btn  = null;

    public Text Help_Text = null;
    public Text UserInfo_Text = null;

    [Header("--- UpLvMode ---")]
    public GameObject UpLvModeRoot = null;
    public Button UpLvModeCloseBtn = null;
    public Button Sell_Btn = null;
    public Button LvUp_Btn = null;
    public Button GdUp_Btn = null;
    public Text UpLvMdFindInfo = null;

    public Text m_LvRateText = null;
    public Text m_GdRateText = null;

    float m_ShowTime = 0.0f;
    int m_FIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        LoadGameData();
        RefreshUIList(m_ItemList);

        //--- AddEditMode ---
        if (Add_Btn != null)
            Add_Btn.onClick.AddListener(AddBtnClick);  //������ �߰�

        if (ShowList_Btn != null)
            ShowList_Btn.onClick.AddListener(ShowListBtnClick); //�߰� ������ ����

        if (LvSort_Btn != null)
            LvSort_Btn.onClick.AddListener(LvSortBtnClick); //���� ū������ ����

        if (GdSort_Btn != null)
            GdSort_Btn.onClick.AddListener(GdSortBtnClick); //��� ������ ����

        if (Clear_Btn != null)
            Clear_Btn.onClick.AddListener(ClearBtnClick); //��ü ��� ����

        if (Find_Btn != null)
            Find_Btn.onClick.AddListener(FindBtnClick);  //������ ã��
        //--- AddEditMode ---

        //--- UpLvMode
        if (Sell_Btn != null)
            Sell_Btn.onClick.AddListener(SellBtnClick);  //������ �Ǹ�

        if (UpLvModeCloseBtn != null)
            UpLvModeCloseBtn.onClick.AddListener(() =>
            {
                m_FIndex = -1;
                UpLvMdFindInfo.text = "";
                ItName_Ifd.text = "";

                if (UpLvModeRoot != null)
                    UpLvModeRoot.SetActive(false);
            });
        //--- UpLvMode
    }

    // Update is called once per frame
    void Update()
    {
        if(0.0f < m_ShowTime)
        {
            m_ShowTime -= Time.deltaTime;
            if(m_ShowTime <= 0.0f)
            {
                if (Help_Text != null)
                    Help_Text.gameObject.SetActive(false);
            }
        }//if(0.0f < m_ShowTime)
        
    }//void Update()

    void AddBtnClick()
    {
        if (ItName_Ifd == null)
            return;

        string a_ItName = ItName_Ifd.text.Trim();   //.Trim() �� �� ���� ���� �Լ�

        if (string.IsNullOrEmpty(a_ItName) == true)  //�Է� ���ڰ� ��� �ִ� ��Ȳ���� �߰� ��ư�� ���� ���
        {
            CItem a_Item = new CItem();
            a_Item.InitItem();
            m_ItemList.Add(a_Item);

        }
        else  //�Է� ���ڿ� ������ �̸��� �Է��� ���¿��� �߰� ��ư�� ���� ���
        {
            m_ItemList.Add(new CItem(a_ItName));
        }

        SaveGameData();
        RefreshUIList(m_ItemList);  //ȭ�� ����

        ItName_Ifd.text = "";  //<--- �Է� ���� �ʱ�ȭ
    }

    void ShowListBtnClick()  //����Ʈ�� �߰������� �����ֱ�
    {
        RefreshUIList(m_ItemList);
    }

    void LvSortBtnClick()  //���� ū������ ���������� �����ؼ� �����ֱ�
    {
        List<CItem> a_CopyList = m_ItemList.ToList();  //����Ʈ ���� using System.Linq;
        a_CopyList.Sort( (a, b) => b.m_Level.CompareTo(a.m_Level) ); //���� ��������(DESC) ����
        RefreshUIList(a_CopyList);
    }

    void GdSortBtnClick()
    {
        List<CItem> a_CopyList = m_ItemList.ToList();  //����Ʈ ����
        a_CopyList.Sort( (a, b) => a.m_Grade.CompareTo(b.m_Grade) ); //��� ��������(ASC) ����
        RefreshUIList(a_CopyList);
    }

    void FindBtnClick()
    {
        if (ItName_Ifd == null)
            return;

        string a_strItemId = ItName_Ifd.text.Trim();
        ItName_Ifd.text = "";

        if (string.IsNullOrEmpty(a_strItemId) == true)
            return;

        int a_CkIdx = -1;
        if (int.TryParse(a_strItemId, out a_CkIdx) == false)
            return;

        m_FIndex = m_ItemList.FindIndex(x => x.m_ItemUId == a_CkIdx);

        if(m_FIndex < 0) //�Է��� ItemId �� ����Ʈ�� �������� �ʴ´ٴ� ��
        {
            if(Help_Text != null)
            {
                Help_Text.gameObject.SetActive(true);
                Help_Text.text = "ã�� ������ Id�� �������� �ʽ��ϴ�.";
                m_ShowTime = 3.0f;
            }

            return;
        }//if(m_FIndex < 0) //�Է��� ItemId �� ����Ʈ�� �������� �ʴ´ٴ� ��

        if (UpLvModeRoot != null)
            UpLvModeRoot.SetActive(true);

        //--- �˻� ������ ���� ���
        CItem a_FNode = m_ItemList[m_FIndex];
        string a_StrBuff =  $"[ (<color=#ff99ff>{a_FNode.m_ItemUId}</color>) {a_FNode.m_Name} ] : " +
                        $"����({a_FNode.m_Level}) ���({a_FNode.m_Grade}) " +
                        $"����({a_FNode.m_Price})";

        UpLvMdFindInfo.text = a_StrBuff;

    }//void FindBtnClick()

    void ClearBtnClick()
    {
        m_ItemList.Clear();
        PlayerPrefs.DeleteAll();    //���� ���¸� ��� ����
        LoadGameData();
        RefreshUIList(m_ItemList);
        ItName_Ifd.text = "";
    }

    void SellBtnClick()
    {
        if(m_FIndex < 0 || m_ItemList.Count <= m_FIndex)
            return;

        int a_CacCost = (int)(m_ItemList[m_FIndex].m_Price * 0.8f);
        g_GameGold += a_CacCost;
        Help_Text.gameObject.SetActive(true);
        Help_Text.text = "���� ���� ��� + " + a_CacCost + " ���!!";
        m_ShowTime = 3.0f;

        m_ItemList.RemoveAt(m_FIndex);

        m_FIndex = -1;
        UpLvMdFindInfo.text = "";
        ItName_Ifd.text = "";
        SaveGameData();
        RefreshUIList(m_ItemList);

        if (UpLvModeRoot != null)
            UpLvModeRoot.SetActive(false); 
    }

    void SaveGameData()
    {
        PlayerPrefs.DeleteAll();    //���� ���¸� ��� ����

        PlayerPrefs.SetInt("CurUniqId", CItem.g_CurUniqId);
        PlayerPrefs.SetString("NickName", g_UserName);
        PlayerPrefs.SetInt("GameGold", g_GameGold);

        if (m_ItemList.Count <= 0)
            return;

        PlayerPrefs.SetInt("It_Count", m_ItemList.Count);   //������ �� ����

        for(int i = 0; i < m_ItemList.Count; i++)
        {
            PlayerPrefs.SetInt($"IT_{i}_ItemUId", m_ItemList[i].m_ItemUId);
            PlayerPrefs.SetString($"IT_{i}_Name", m_ItemList[i].m_Name);
            PlayerPrefs.SetInt($"IT_{i}_Level",   m_ItemList[i].m_Level);
            PlayerPrefs.SetInt($"IT_{i}_Grade",   m_ItemList[i].m_Grade);
            PlayerPrefs.SetInt($"IT_{i}_Price",   m_ItemList[i].m_Price);
        }
    }//void SaveGameData()

    void LoadGameData()
    {
        CItem.g_CurUniqId = PlayerPrefs.GetInt("CurUniqId", 0);
        g_UserName = PlayerPrefs.GetString("NickName", "SBS����");
        g_GameGold = PlayerPrefs.GetInt("GameGold", 1000);

        int a_ItCount = PlayerPrefs.GetInt("It_Count", 0);

        if(a_ItCount <= 0)
            return;

        CItem a_Node;
        for(int i = 0; i < a_ItCount; i++) 
        {
            a_Node = new CItem();

            a_Node.m_ItemUId = PlayerPrefs.GetInt($"IT_{i}_ItemUId", -1);
            a_Node.m_Name    = PlayerPrefs.GetString($"IT_{i}_Name", "");
            a_Node.m_Level   = PlayerPrefs.GetInt($"IT_{i}_Level", 0);
            a_Node.m_Grade   = PlayerPrefs.GetInt($"IT_{i}_Grade", 0);
            a_Node.m_Price   = PlayerPrefs.GetInt($"IT_{i}_Price", 0);

            if (CItem.g_CurUniqId <= a_Node.m_ItemUId)
            {
                Debug.Log($"ItemId {a_Node.m_ItemUId} ��, {a_Node.m_Name} �������� " +
                            $"�ߺ��� �� �ִ� ��ȣ�̹Ƿ� �����Ǿ����ϴ�.");
                continue;  //�ߺ��� Id�� ���� �� �ִ� ��Ȳ�� ���ϱ� ���� �ڵ�
            }

            m_ItemList.Add(a_Node);
        }//for(int i = 0; i < a_ItCount; i++) 

    }//void LoadGameData()

    void RefreshUIList(List<CItem> a_ItemList = null)
    {
        UserInfo_Text.text = $"[{g_UserName}] : Gold({g_GameGold})";

        if (a_ItemList == null)
            return;

        PrintList.text = "";

        if (a_ItemList.Count <= 0)
            return;

        string a_StrBuff = "";
        for(int i = 0; i < a_ItemList.Count; i++)
        {
            a_StrBuff += $"[ (<color=#ff99ff>{a_ItemList[i].m_ItemUId}</color>) {a_ItemList[i].m_Name} ] : " +
                $"����({a_ItemList[i].m_Level}) ���({a_ItemList[i].m_Grade}) ����({a_ItemList[i].m_Price})";

            a_StrBuff += "\n";  //"\n" �ٹٲ� ��ȣ(���� ����)

        }//for(int i = 0; i < a_ItemList.Count; i++)

        PrintList.text = a_StrBuff;

    }//void RefreshUIList(List<CItem> a_ItemList = null)
}
