using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public Rigidbody m_Shell;
    public Transform m_Firetransform;
    public float m_LaunchForce = 30f;
    public GameObject m_AudioSource;
    public AudioClip m_CannonSfx;
    public AudioClip m_ExplosionSfx;

    void Update() {
        if (Input.GetButtonUp("Fire1"))
        {
            AudioSource.PlayClipAtPoint(m_CannonSfx, m_AudioSource.transform.position);
            Fire();
            AudioSource.PlayClipAtPoint(m_ExplosionSfx, m_AudioSource.transform.position);
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
