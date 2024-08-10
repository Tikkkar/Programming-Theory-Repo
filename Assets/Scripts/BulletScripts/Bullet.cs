using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField] BoDemQuaiVat soLuong;
    
    protected float speed = 70f;

    // Khai bao bien ban kinh vien dan.
    protected float oxplosionRadius = 1f;

    public void Start()
    {
        soLuong = GameObject.Find("Ground").GetComponent<BoDemQuaiVat>();
    }

    // Khai bao bien tim kiem muc tieu Seek co nghia la tim kiem.
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        BulletWorks();
    }
     void HitTarget()
    {
        if (oxplosionRadius > 0)
        {
            Expole();
        }
        else 
        {
            Damege(target);
        }
        Destroy(gameObject);
    }

    void Expole()
    {
        // Tao bien kiem tra doi tuong co nam trong pham vi cua vien dan hay khong. va doi tuong collider nay la ai?
        Collider[] colliders = Physics.OverlapSphere(transform.position, oxplosionRadius);
        // Dung phuong phap lap foreach de duyet doi tuong co trong collider

        foreach ( Collider collider in colliders)
        {
            //Doi tuong nay la ai
            if (collider.tag == "Enemy")
            {
                Damege(collider.transform);
            }
        }
    }
    void Damege(Transform enemy)
    {
        Destroy(enemy.gameObject);
       
    }
    public void BulletWorks()
    {
        // Neu khong co doi tuong ngam ban
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        // Tim Huong Di Cho Vien Dan bang vi tri cua muc tieu - di vi tri cua vien dan.
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, oxplosionRadius);
    }
}
