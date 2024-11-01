using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    public float m_MaxLifeTime = 2f;
    public ParticleSystem m_ExplosionParticles;
    public float m_MaxDamage = 34f;
   // public AudioClip m_ExplosionAudio;


    public float m_ExplosionRadius = 5;
    public float m_ExplosionForce = 100f;

    void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }


    float CalculateDamage(Vector3 targetPosition)
    {

       Vector3 explosionToTarget = targetPosition - transform.position;
       float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
        float damage = relativeDistance * m_MaxDamage;

        damage = Mathf.Max(0f, damage);

        return damage;

    }

    void Update()
    {

    }
    void Damage(Collision target)
    {
        TankHealth targetHealth = target.transform.GetComponent<TankHealth>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(m_MaxDamage);
        }

    } 
    void Damage(Rigidbody  targetRigidbody)
    {
        targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

        TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
        if(targetHealth != null)
        {
            float damage = CalculateDamage(targetRigidbody.position);
            targetHealth.TakeDamage(damage);
        }  

    }
    private void OnCollisionEnter(Collision Other)
    {

        Collider[] objectInRange = Physics.OverlapSphere(transform.position, m_ExplosionRadius);
        for(int i=0; i<objectInRange.Length;  i++)
        {
            Rigidbody targetRB = objectInRange[i].GetComponent<Rigidbody>();
            if (targetRB != null){

                Damage(targetRB);
            }

        }

        Damage(Other);
       // m_ExplosionParticles.transform.parent = null;
        //m_ExplosionParticles.Play();
        //Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
       // AudioSource.PlayClipAtPoint(m_ExplosionAudio, transform.position);
    }


}
