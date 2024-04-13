using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Mgr : MonoBehaviour
{
    //---- 유저 정보 
    public static string g_UserName = "유저";
    public static int g_GameGold    = 1000;
    //---- 유저 정보

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

    [Header("--- UpLvMode ---")]//아이템 강화모드
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

    [Header("------ShowNickName-----")]
    public InputField NickInputField;  //닉네임 입력상자 
    bool bEnter = false;



    // Start is called before the first frame update
    void Start()
    {
        LoadGameData();
        RefreshUIList(m_ItemList);

        //--- AddEditMode ---
        if (Add_Btn != null)
            Add_Btn.onClick.AddListener(AddBtnClick);  //아이템 추가

        if (ShowList_Btn != null)
            ShowList_Btn.onClick.AddListener(ShowListBtnClick); //추가 순으로 보기

        if (LvSort_Btn != null)
            LvSort_Btn.onClick.AddListener(LvSortBtnClick); //레벨 큰순으로 보기

        if (GdSort_Btn != null)
            GdSort_Btn.onClick.AddListener(GdSortBtnClick); //등급 순으로 보기

        if (Clear_Btn != null)
            Clear_Btn.onClick.AddListener(ClearBtnClick); //전체 노드 삭제

        if (Find_Btn != null)
            Find_Btn.onClick.AddListener(FindBtnClick);  //아이템 찾기
        //--- AddEditMode ---

        //--- UpLvMode
        if (Sell_Btn != null)
            Sell_Btn.onClick.AddListener(()=>
            {
                SellItem(0.8f);
            });  //아이템 판매

        if (LvUp_Btn != null)
            LvUp_Btn.onClick.AddListener(LvUpBtnClick);    //레벨 강화

        if(GdUp_Btn != null)
            GdUp_Btn.onClick.AddListener(GdUpBtnClick);    //등급강화


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


        //nick change inputfield active on off
        if(Input.GetKeyDown(KeyCode.Return) == true)  
        {
            //if (ItName_Ifd.isFocused == true) //포커스가 가있을때 리턴시키기
            //    return;

            bEnter = !bEnter;

            if(bEnter == true)
            {
                NickInputField.gameObject.SetActive(true);
                NickInputField.ActivateInputField(); //포커스 인풋필드로 이동시킴
            }
            else
            {
                NickInputField.gameObject.SetActive(false);
                ChangeNickName();
            }
        
        }//~ nickchange inputfield active on off

        
    }//void Update()

    void AddBtnClick()
    {
        if (ItName_Ifd == null)
            return;

        string a_ItName = ItName_Ifd.text.Trim();   //.Trim() 앞 뒤 공백 제거 함수

        if (string.IsNullOrEmpty(a_ItName) == true)  //입력 상자가 비어 있는 상황에서 추가 버튼을 누른 경우
        {
            CItem a_Item = new CItem();
            a_Item.InitItem();
            m_ItemList.Add(a_Item);

        }
        else  //입력 상자에 아이템 이름을 입력할 상태에서 추가 버튼을 누른 경우
        {
            m_ItemList.Add(new CItem(a_ItName));
        }

        SaveGameData();
        RefreshUIList(m_ItemList);  //화명 갱신

        ItName_Ifd.text = "";  //<--- 입력 상자 초기화
    }

    void ShowListBtnClick()  //리스트를 추가순으로 보여주기
    {
        RefreshUIList(m_ItemList);
    }

    void LvSortBtnClick()  //레벨 큰순에서 작은순으로 정렬해서 보여주기
    {
        List<CItem> a_CopyList = m_ItemList.ToList();  //리스트 복사 using System.Linq;
        a_CopyList.Sort( (a, b) => b.m_Level.CompareTo(a.m_Level) ); //레벨 내림차순(DESC) 정렬
        RefreshUIList(a_CopyList);
    }

    void GdSortBtnClick()
    {
        List<CItem> a_CopyList = m_ItemList.ToList();  //리스트 복사
        a_CopyList.Sort( (a, b) => a.m_Grade.CompareTo(b.m_Grade) ); //등급 오름차순(ASC) 정렬
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

        if(m_FIndex < 0) //입력한 ItemId 는 리스트에 존재하지 않는다는 뜻
        {
          
                ShowMessage("찾는 아이템 Id는 존재하지 않습니다.");
             

            return;
        }//if(m_FIndex < 0) //입력한 ItemId 는 리스트에 존재하지 않는다는 뜻

        if (UpLvModeRoot != null)
            UpLvModeRoot.SetActive(true);

        int a_LVStep = m_ItemList[m_FIndex].m_Level;

        float a_LVRate = (31 - a_LVStep) / 30.0f * 100.0f; //1~30을 만들기 위해
        if (m_LvRateText != null)
            m_LvRateText.text = "확률" + (int)a_LVRate + "%";

        int a_GdStep = m_ItemList[m_FIndex].m_Grade;

        float a_GdRate = a_GdStep / 7.0f * 100.0f;//7~1등급이 등급 
        if (m_GdRateText != null)
            m_GdRateText.text = "확률" + (int)a_GdRate + "%"; 




        //--- 검색 아이템 정보 출력
        CItem a_FNode = m_ItemList[m_FIndex];
        string a_StrBuff =  $"[ (<color=#ff99ff>{a_FNode.m_ItemUId}</color>) {a_FNode.m_Name} ] : " +
                        $"레벨({a_FNode.m_Level}) 등급({a_FNode.m_Grade}) " +
                        $"가격({a_FNode.m_Price})";

        UpLvMdFindInfo.text = a_StrBuff;

    }//void FindBtnClick()

    void ClearBtnClick()
    {
        m_ItemList.Clear();
        PlayerPrefs.DeleteAll();    //저장 상태를 모두 제거
        LoadGameData();
        RefreshUIList(m_ItemList);
        ItName_Ifd.text = "";
    }

   

 

    private void SellItem(float a_CompensationRate = 0.8f)
    {
        if (m_FIndex < 0 || m_ItemList.Count <= m_FIndex)
            return;

        int a_CacCost = (int)(m_ItemList[m_FIndex].m_Price * a_CompensationRate);
        g_GameGold += a_CacCost;
        if (0.8f <= a_CompensationRate)
            ShowMessage("유저 보유 골드 + " + a_CacCost + " 상승!!");

        m_ItemList.RemoveAt(m_FIndex);

        m_FIndex = -1;
        UpLvMdFindInfo.text = "";
        ItName_Ifd.text = "";
        SaveGameData();
        RefreshUIList(m_ItemList);

        if (UpLvModeRoot != null)
            UpLvModeRoot.SetActive(false);
    }





    void LvUpBtnClick()
    {
        if (m_FIndex < 0 || m_ItemList.Count <= m_FIndex)
            return;

        if (30 <= m_ItemList[m_FIndex].m_Level)
        {
            ShowMessage("<color=#ff8684>이미 최고레벨입니다.</color>");
            return;
        }

        
        int a_Step = m_ItemList[m_FIndex].m_Level;
        int a_Chance = Random.Range(2, 32); //2~31 //30ea 
        if (a_Step < a_Chance) //1lv 100% 2lv 90%.....
        {
            m_ItemList[m_FIndex].m_Level++;
            ShowMessage("<color=#00ff00>레벨업에 성공하셨습니다.1레벨 상승</color>");
            m_ItemList[m_FIndex].m_Price += 100;

            int a_LvStep = m_ItemList[m_FIndex].m_Level;
            float a_LvRate = (31 - a_LvStep) / 30.0f * 100.0f;
            if (m_LvRateText != null)
                m_LvRateText.text = "확률" + (int)a_LvRate + "%";

            //검색된 아이템정보 갱신
            CItem a_FNode = m_ItemList[m_FIndex];
            string a_StrBuff = $"[ (<color=#ff99ff>{a_FNode.m_ItemUId}</color>) {a_FNode.m_Name} ] : " +
                    $"레벨({a_FNode.m_Level}) 등급({a_FNode.m_Grade}) " +
                    $"가격({a_FNode.m_Price})";
            UpLvMdFindInfo.text = a_StrBuff;

            SaveGameData();
            RefreshUIList(m_ItemList);
        }
        else 
        {
            CItem a_FNode = m_ItemList[m_FIndex];
            string a_StrBuff = "<color=#00ff00>레벨업 실패..!" + a_FNode.m_ItemUId + "번" +
                a_FNode.m_Name + "이(가) 재료의 가루로 변했습니다." + "</color>";

            ShowMessage(a_StrBuff);


            SellItem(0.3f);

        } //레벨업 실패

    
    }

    void GdUpBtnClick()
    {
        if (m_FIndex < 0 || m_ItemList.Count <= m_FIndex)
            return;
        if (m_ItemList[m_FIndex].m_Grade <= 1)
        {
            ShowMessage("<color=#ff8684>이미 최고치로 강화한 상태입니다.</color>");
            return;
        }

        int a_Step = m_ItemList[m_FIndex].m_Grade;
        int a_Chance = Random.Range(0, 7);
        if(a_Chance < a_Step) //7 100% 6 85%
        {
            m_ItemList[m_FIndex].m_Grade--;

            ShowMessage("<color=#00ff00> 등급업 성공!1등급업!</color>");
            m_ItemList[m_FIndex].m_Price += (7 - m_ItemList[m_FIndex].m_Grade) * 500;

            int a_GdStep = m_ItemList[m_FIndex].m_Grade;
            float a_GdRate =  a_GdStep / 7.0f * 100.0f;

            if (m_GdRateText != null)
                m_GdRateText.text = "확률" + (int)a_GdRate + "%";

            //검색된 아이템정보 갱신
            CItem a_FNode = m_ItemList[m_FIndex];
            string a_StrBuff = $"[ (<color=#ff99ff>{a_FNode.m_ItemUId}</color>) {a_FNode.m_Name} ] : " +
                    $"레벨({a_FNode.m_Level}) 등급({a_FNode.m_Grade}) " +
                    $"가격({a_FNode.m_Price})";
            UpLvMdFindInfo.text = a_StrBuff;

            SaveGameData();
            RefreshUIList(m_ItemList);

        }
        else
        {
            CItem a_FNode = m_ItemList[m_FIndex];
            string a_StrBuff = "<color=#00ff00>등급업 실패..!" + a_FNode.m_ItemUId + "(번)" +
                a_FNode.m_Name + "아이템을 잃었습니다." + "</color>";

            ShowMessage(a_StrBuff);


            SellItem(0.3f);
        }
    }

    void SaveGameData()
    {
        PlayerPrefs.DeleteAll();    //저장 상태를 모두 제거

        PlayerPrefs.SetInt("CurUniqId", CItem.g_CurUniqId);
        PlayerPrefs.SetString("NickName", g_UserName);  
        PlayerPrefs.SetInt("GameGold", g_GameGold);

        if (m_ItemList.Count <= 0)
            return;

        PlayerPrefs.SetInt("It_Count", m_ItemList.Count);   //아이템 수 저장

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
        g_UserName = PlayerPrefs.GetString("NickName", "유저");
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
                Debug.Log($"ItemId {a_Node.m_ItemUId} 번, {a_Node.m_Name} 아이템은 " +
                            $"중복될 수 있는 번호이므로 삭제되었습니다.");
                continue;  //중복된 Id가 나올 수 있는 상황을 피하기 위한 코드
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
                $"레벨({a_ItemList[i].m_Level}) 등급({a_ItemList[i].m_Grade}) 가격({a_ItemList[i].m_Price})";

            a_StrBuff += "\n";  //"\n" 줄바꿈 기호(엔터 역할)

        }//for(int i = 0; i < a_ItemList.Count; i++)

        PrintList.text = a_StrBuff;

    }//void RefreshUIList(List<CItem> a_ItemList = null)

    void ChangeNickName()

    {
        string a_NickName = NickInputField.text;

        NickInputField.text = "";
        
        a_NickName = a_NickName.Trim();


        bool a_IsFail = false;
        if(string .IsNullOrEmpty(a_NickName) == true)
        {
            a_IsFail =true;
        }

        //if(a_NickName.Length < 2 || 10 <= a_NickName.Length)

        if(!(2 <= a_NickName.Length && a_NickName.Length <=  10))
            a_IsFail = true;
        
        if(a_IsFail == true)
        {
            ShowMessage("닉네임은 2글자 이상 10글자 이하로 작성하여주십시오.");
            return;
        }

        g_UserName = a_NickName;
        PlayerPrefs.SetString("Nickname", g_UserName);
        RefreshUIList();

    }


    void ShowMessage(string msg)
    {
        if (Help_Text == null)
            return;
        Help_Text.gameObject.SetActive(true);
        Help_Text.text = msg;
        m_ShowTime = 3.0f;
    }
}
