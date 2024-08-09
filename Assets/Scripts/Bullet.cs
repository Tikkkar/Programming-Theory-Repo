using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField] BoDemQuaiVat soLuong;
    
    public float speed = 70f;

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
    public void HitTarget()
    {

        Destroy(gameObject);
        Destroy(target.gameObject);
        
    }
    
}
