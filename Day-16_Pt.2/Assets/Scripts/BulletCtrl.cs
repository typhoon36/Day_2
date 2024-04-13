using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    float m_Speed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.0f); //부모객체 소멸
    }

    // Update is called once per frame
    void Update()
    {
        // 속도= 거리 / 시간
        //속도 *시간 = 거리

        Vector3 a_CacVec = transform.position;
        transform.position += Vector3.right * m_Speed * Time.deltaTime; 
    }
}
