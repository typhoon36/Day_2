using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;




public class InvenEx_Mgr : MonoBehaviour
{
    [Header("----��ư-----")]
    public Button Add_Btn;
    public Button AddList_Btn;
    public Button AllDelete_Btn;
    public Button Insert_Btn;
    public Button InsertItDel_Btn;
    public Button LevelRein_Btn;
    public Button GradeRein_Btn;
    public Button GradeList_Btn;
    public Button LVList_Btn;

    [Header("------�ؽ�Ʈ��")]
    public Text Title;
    public Text GradeInfro_Text;
    public Text GradeUp_Text;
    public Text ItemName_Text;
    public Text ItemResult_Text;
    public Text ItemStatus_Text;
    public Text LevelInfo_Text;

    [Header("----�Է»���-----")]
    public InputField ItemName_IF;


    public List<Mitem> itemList = new List<Mitem>();

 


    public class Mitem
    {
        public string m_name= "";   //�̸�
        public int m_Level = Random.Range(1,9); //����1~8
        public float M_ReinRate = 1.0f;
        public int m_price = Random.Range(100, 1001);//100~1000������ ���� ����
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

    int GradeASC(Mitem a, Mitem b)    //���� ���� �Լ�
    {
        return a.m_Grade.CompareTo(b.m_Grade);
    }

    int LevelDESC(Mitem a, Mitem b)  //���� ���� �Լ�
    {
        return b.m_Level.CompareTo(a.m_Level); //������������(������ ���������� ���������� ����)
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Add_Btn !=  null) //��ư ����
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
        //~��ư����


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
        string itemInfo = $"[{newItem.m_name}], ����: {newItem.m_Level}, ���: ({newItem.m_Grade}), ����: ({newItem.m_price})";
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
        string itemInfo = $"[{newItem.m_name}], ����: {newItem.m_Level}, ���: ({newItem.m_Grade}), ����: ({newItem.m_price})";
        itemInfoBuilder.AppendLine(itemInfo);
        
        ItemResult_Text.text = itemInfoBuilder.ToString(); ;
    }
    private void AllDelete_Btn_Click() //��ü����
    {
        itemInfoBuilder.Clear(); // itemInfoBuilder(���ڿ�) �ʱ�ȭ
        ItemResult_Text.text = ""; // ItemResult_Text ���� ����
    }

    private void Insert_Btn_Click()
    {
        string itemName = ItemName_IF.text;

        // �˻��� �������� ã���ϴ�.
        var searchResult = itemList.FirstOrDefault(item => item.m_name == itemName);

        if (searchResult == null)
        {
            Debug.Log("�˻��� �������� �����ϴ�.");
            return;
        }

        // �˻��� ������ ������ �ؽ�Ʈ�� ǥ���մϴ�.
        string itemInfo = $"[{searchResult.m_name}], ����: {searchResult.m_Level}, ���: ({searchResult.m_Grade}), ����: ({searchResult.m_price})";
        ItemStatus_Text.text = itemInfo;

    }



    private void InsertItDel_Btn_Click() //�˻��� ������ ����
    {
        
    }

    private void LevelRein_Btn_Click() //���� ��ȭ 
    {
        
    }

    private void GradeRein_Btn_Click() //��ް�ȭ
    {
        
    }

    private void GradeList_Btn_Click() // ��޼� ����
    {
        List<Mitem> mitems = new List<Mitem>(itemList); // itemList�� �����Ͽ� ���ο� ����Ʈ ����
        mitems.Sort(GradeASC); // ��޼����� ����

        StringBuilder sortedItemInfoBuilder = new StringBuilder(); // ���ο� StringBuilder ����

        foreach (Mitem mitem in mitems)
        {
            string itemInfo = $"[{mitem.m_name}], ����: {mitem.m_Level}, ���: ({mitem.m_Grade}), ����: ({mitem.m_price})";
            sortedItemInfoBuilder.AppendLine(itemInfo); // �� ������ ������ StringBuilder�� �߰�
        }

        // ���ĵ� ������ �ؽ�Ʈ ���ڿ� ǥ��
        ItemResult_Text.text = sortedItemInfoBuilder.ToString();
    }

    private void LVList_Btn_Click() // ������ ����
    {
        List<Mitem> Nitems = new List<Mitem>(itemList); // itemList�� �����Ͽ� ���ο� ����Ʈ ����
        Nitems.Sort(LevelDESC); // ���������� ����

        StringBuilder sortedItemInfoBuilder = new StringBuilder(); // ���ο� StringBuilder ����

        foreach (Mitem mitem in Nitems)
        {
            string itemInfo = $"[{mitem.m_name}], ����: {mitem.m_Level}, ���: ({mitem.m_Grade}), ����: ({mitem.m_price})";
            sortedItemInfoBuilder.AppendLine(itemInfo); // �� ������ ������ StringBuilder�� �߰�
        }

        // ���ĵ� ������ �ؽ�Ʈ ���ڿ� ǥ��
        ItemResult_Text.text = sortedItemInfoBuilder.ToString();
    }


}


