using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform m_target;
    private Vector3 m_DesiredPosition;
    public float m_DampTime = 0.2f;
    private Vector3 m_MoveVelocity;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()

    {
        m_DesiredPosition = m_target.position;
        Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
        transform.position = m_DesiredPosition;
    }
}
