using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public Rigidbody m_Shell;
    public Transform m_Firetransform;
    public float m_LaunchForce = 30f;

    void Update() {
        if (Input.GetButtonUp("Fire1"))
        {
            Fire();
        }
    }
     
    
    void Fire()
    {
        Rigidbody shellInstance = Instantiate(m_Shell,
                                        m_Firetransform.position,
                                        m_Firetransform.rotation);
        shellInstance.velocity = m_LaunchForce * m_Firetransform.forward;
    }
   
    
}
