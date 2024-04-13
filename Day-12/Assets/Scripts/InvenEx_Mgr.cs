using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;




public class InvenEx_Mgr : MonoBehaviour
{
    [Header("----버튼-----")]
    public Button Add_Btn;
    public Button AddList_Btn;
    public Button AllDelete_Btn;
    public Button Insert_Btn;
    public Button InsertItDel_Btn;
    public Button LevelRein_Btn;
    public Button GradeRein_Btn;
    public Button GradeList_Btn;
    public Button LVList_Btn;

    [Header("------텍스트들")]
    public Text Title;
    public Text GradeInfro_Text;
    public Text GradeUp_Text;
    public Text ItemName_Text;
    public Text ItemResult_Text;
    public Text ItemStatus_Text;
    public Text LevelInfo_Text;

    [Header("----입력상자-----")]
    public InputField ItemName_IF;


    public List<Mitem> itemList = new List<Mitem>();

 


    public class Mitem
    {
        public string m_name= "";   //이름
        public int m_Level = Random.Range(1,9); //레벨1~8
        public float M_ReinRate = 1.0f;
        public int m_price = Random.Range(100, 1001);//100~1000까지의 가격 랜덤
        public int m_Grade = 7 - Random.Range(0, 2);

        public Mitem(string a_name, int a_level, float a_reinRate, int a_price,int a_grade)
        {
            m_name = a_name;
            m_Level = a_level;
            M_ReinRate = a_reinRate;
            m_price = a_price;
            m_Grade =a_grade;
        }
    }


    public StringBuilder itemInfoBuilder = new StringBuilder();

    int GradeASC(Mitem a, Mitem b)    //정렬 조건 함수
    {
        return a.m_Grade.CompareTo(b.m_Grade);
    }

    int LevelDESC(Mitem a, Mitem b)  //정렬 조건 함수
    {
        return b.m_Level.CompareTo(a.m_Level); //내림차순정렬(레벨이 높은순에서 낮은순으로 정렬)
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Add_Btn !=  null) //버튼 선언
        Add_Btn.onClick.AddListener(Add_Btn_Click);
        if(AddList_Btn != null)
            AddList_Btn.onClick.AddListener(AddList_Btn_Click);
        if(AllDelete_Btn != null)
            AllDelete_Btn.onClick.AddListener(AllDelete_Btn_Click);
        if(Insert_Btn != null)
            Insert_Btn.onClick.AddListener(Insert_Btn_Click);
        if (InsertItDel_Btn != null)
            InsertItDel_Btn.onClick.AddListener(InsertItDel_Btn_Click);
        if(LevelRein_Btn != null)
            LevelRein_Btn.onClick.AddListener(LevelRein_Btn_Click);
        if (GradeRein_Btn != null)
            GradeRein_Btn.onClick.AddListener(GradeRein_Btn_Click);
        if(GradeList_Btn != null)
            GradeList_Btn.onClick.AddListener(GradeList_Btn_Click);
        if(LVList_Btn != null)
            LVList_Btn.onClick.AddListener(LVList_Btn_Click);
        //~버튼선언


    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void Add_Btn_Click()
    {
        string itemname = ItemName_IF.text;
        int level = Random.Range(1, 9);
        int grade = 7 - Random.Range(0, 2);
        int price = Random.Range(100, 1001);

        Mitem newItem = new Mitem(itemname, level, 1.0f, price, grade);
        string itemInfo = $"[{newItem.m_name}], 레벨: {newItem.m_Level}, 등급: ({newItem.m_Grade}), 가격: ({newItem.m_price})";
        itemInfoBuilder.AppendLine(itemInfo);

        ItemResult_Text.text = itemInfoBuilder.ToString();

    }


    private void AddList_Btn_Click()
    {
        string itemname = ItemName_IF.text;
        int level = Random.Range(1, 9);
        int grade = 7 - Random.Range(0, 2);
        int price = Random.Range(100, 1001);

        Mitem newItem = new Mitem(itemname, level, 1.0f, price, grade);
        string itemInfo = $"[{newItem.m_name}], 레벨: {newItem.m_Level}, 등급: ({newItem.m_Grade}), 가격: ({newItem.m_price})";
        itemInfoBuilder.AppendLine(itemInfo);
        
        ItemResult_Text.text = itemInfoBuilder.ToString(); ;
    }
    private void AllDelete_Btn_Click() //전체삭제
    {
        itemInfoBuilder.Clear(); // itemInfoBuilder(문자열) 초기화
        ItemResult_Text.text = ""; // ItemResult_Text 내용 지움
    }

    private void Insert_Btn_Click()
    {
        string itemName = ItemName_IF.text;

        // 검색된 아이템을 찾습니다.
        var searchResult = itemList.FirstOrDefault(item => item.m_name == itemName);

        if (searchResult == null)
        {
            Debug.Log("검색된 아이템이 없습니다.");
            return;
        }

        // 검색된 아이템 정보를 텍스트로 표시합니다.
        string itemInfo = $"[{searchResult.m_name}], 레벨: {searchResult.m_Level}, 등급: ({searchResult.m_Grade}), 가격: ({searchResult.m_price})";
        ItemStatus_Text.text = itemInfo;

    }



    private void InsertItDel_Btn_Click() //검색된 아이템 삭제
    {
        
    }

    private void LevelRein_Btn_Click() //레벨 강화 
    {
        
    }

    private void GradeRein_Btn_Click() //등급강화
    {
        
    }

    private void GradeList_Btn_Click() // 등급순 정렬
    {
        List<Mitem> mitems = new List<Mitem>(itemList); // itemList를 복사하여 새로운 리스트 생성
        mitems.Sort(GradeASC); // 등급순으로 정렬

        StringBuilder sortedItemInfoBuilder = new StringBuilder(); // 새로운 StringBuilder 생성

        foreach (Mitem mitem in mitems)
        {
            string itemInfo = $"[{mitem.m_name}], 레벨: {mitem.m_Level}, 등급: ({mitem.m_Grade}), 가격: ({mitem.m_price})";
            sortedItemInfoBuilder.AppendLine(itemInfo); // 각 아이템 정보를 StringBuilder에 추가
        }

        // 정렬된 정보를 텍스트 상자에 표시
        ItemResult_Text.text = sortedItemInfoBuilder.ToString();
    }

    private void LVList_Btn_Click() // 레벨순 정렬
    {
        List<Mitem> Nitems = new List<Mitem>(itemList); // itemList를 복사하여 새로운 리스트 생성
        Nitems.Sort(LevelDESC); // 레벨순으로 정렬

        StringBuilder sortedItemInfoBuilder = new StringBuilder(); // 새로운 StringBuilder 생성

        foreach (Mitem mitem in Nitems)
        {
            string itemInfo = $"[{mitem.m_name}], 레벨: {mitem.m_Level}, 등급: ({mitem.m_Grade}), 가격: ({mitem.m_price})";
            sortedItemInfoBuilder.AppendLine(itemInfo); // 각 아이템 정보를 StringBuilder에 추가
        }

        // 정렬된 정보를 텍스트 상자에 표시
        ItemResult_Text.text = sortedItemInfoBuilder.ToString();
    }


}


