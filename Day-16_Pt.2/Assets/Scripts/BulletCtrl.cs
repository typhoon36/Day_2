using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    float m_Speed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.0f); //�θ�ü �Ҹ�
    }

    // Update is called once per frame
    void Update()
    {
        // �ӵ�= �Ÿ� / �ð�
        //�ӵ� *�ð� = �Ÿ�

        Vector3 a_CacVec = transform.position;
        transform.position += Vector3.right * m_Speed * Time.deltaTime; 
    }
}
