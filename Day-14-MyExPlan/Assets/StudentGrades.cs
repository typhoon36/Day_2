using System;
using UnityEngine;
using UnityEngine.UI;

public class StudentGrades : MonoBehaviour
{
    public InputField Language_InputField;
    public InputField English_InputField;
    public InputField Math_InputField;
    public Button Language_Btn;
    public Button English_Btn;
    public Button Math_Btn;
    public Text resultText;

    float koreanGrade, englishGrade, mathGrade;

    // Start is called before the first frame update
    void Start()
    {
        if (Language_Btn != null)
            Language_Btn.onClick.AddListener(Language_Btn_Click);
        if (English_Btn != null)
            English_Btn.onClick.AddListener(English_Btn_Click);
        if (Math_Btn != null)
            Math_Btn.onClick.AddListener(Math_Btn_Click);
    }

    private void Math_Btn_Click()
    {
        string valueB = Math_InputField.text;

        int a_CaCB = 0;
        int.TryParse(valueB, out a_CaCB);

        if (a_CaCB == 0)
        {
            // Handle the case when the input is not a valid integer
            Debug.LogError("Invalid input for Math.");
            return;
        }

        // Update mathGrade with the new value
        mathGrade = a_CaCB;

        UpdateResults();
    }

    private void English_Btn_Click()
    {
        string valueB = English_InputField.text;

        int a_CaCB = 0;
        int.TryParse(valueB, out a_CaCB);

        if (a_CaCB == 0)
        {
            Debug.LogError("Invalid input for English.");
            return;
        }

        englishGrade = a_CaCB;

        UpdateResults();
    }

    private void Language_Btn_Click()
    {
        string valueB = Language_InputField.text;

        int a_CaCB = 0;
        int.TryParse(valueB, out a_CaCB);

        if (a_CaCB == 0)
        {
            // Handle the case when the input is not a valid integer
            Debug.LogError("Invalid input for language.");
            return;
        }

        // Update mathGrade with the new value
        koreanGrade = a_CaCB;

        UpdateResults();
    }

    private void UpdateResults()
    {
        float total = koreanGrade + mathGrade + englishGrade;
        float average = total / 3f;

        resultText.text = "의 성적 " +"총점:" + total + "  평균:" + average;

        if (average >= 80)
        {
            resultText.text += "  A 등급입니다.";
        }
        else if (average >= 60)
        {
            resultText.text += "  B 등급입니다.";
        }
        else if (average >= 40)
        {
            resultText.text += "  C 등급입니다.";
        }
        else if (average >= 20)
        {
            resultText.text += "  D 등급입니다.";
        }
        else
        {
            resultText.text += "  낙제.";
        }
    }
}
