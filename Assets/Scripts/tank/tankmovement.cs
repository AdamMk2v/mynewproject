using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankmovement : MonoBehaviour
{
    public Transform m_turretAsset;
    LayerMask m_LayerMask;
    Rigidbody m_Rigidbody;
    float m_MovementInputValue;
    float m_TurnInputValue;
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;

    void Start()
    {

    }

    //Start is called befor the first frame update

    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    
    }

    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_LayerMask = LayerMask.GetMask("Ground");
    }
    

    //update is called once per frame
    void Update()
    {
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
        TurnTurret();
    
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed *
        Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }
    void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);

    }

    void TurnTurret()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
    
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_LayerMask))
        {
            m_turretAsset.LookAt(hit.point);
            m_turretAsset.eulerAngles = new Vector3(0,
                                        m_turretAsset.eulerAngles.y,
                                        m_turretAsset.eulerAngles.z);
        }
    
    }   
    
     

}

