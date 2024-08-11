using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // khai bao bien luu tru vi tri cua muc tieu.
    private Transform target;

    [Header("Cac thuoc tinh cua Town")]
    //Khai bao toc do ban
    protected float fireRate = 0f;
    // Khai bao thoi gian lap lai phat ban
    protected float fireCoutdown = 0f;
    //Khai bao bien luu ban kinh hoat dong cua doi tuong.
    protected float range;

    [Header("Cac Thuoc tinh co dinh")]

    // Khai bao chuoi luu chu tag Enemy.
    private string enemytag = "Enemy";
    // Start is called before the first frame update
    // Khai bao su dung Transform cua PartToRotate
    public Transform partToRotate;
    // Tham chieu de su dung vien dan.
    public GameObject bulletPrefabs;
    // Khoi tao vi tri cua vien dan.
    public Transform bulletLocation;

   

    // Khai bao toc do xoay cua may ban
    float turnSpeed = 10f;
    void Start()
    {
        //Goi ham cap nhat vi tri cua muc tieu moi 0.5s/lan
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    // Tao phuong thuc de cap nhat vi tri cua muc tieu
    protected void UpdateTarget()
    {
        // Khai Bao Tim Enemies duoc luu tru trong Enemies voi Tag la Enemy.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        // Luu tru khoang cach xa nhat tu doituong Gameobject den vi tri cua Enemy;
        float shortestDistance = Mathf.Infinity;
        //
        GameObject nearestEnemy = null;
        // Tim kiem khoang cach tu vi tri cua game object den vi tri cua Enemy;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //Neu khoang cach tu vi tri cua gameobject den vi tri cua Enemy nho hon khoang cach ngan nhat tu Enemy den vi tri cua gameobject.
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            // Dieu kien kiem tra xem co enemy nao nam trong pham vi khong, va neu no nam trong pham vi thi do la muc tieu 
            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        LockTaget();
    }
    protected void Shoot()
    {
        // Tham chieu den mot vi tri thap Phao de lay vi tri cho vien dan
        GameObject bulletGo = (GameObject) Instantiate(bulletPrefabs, bulletLocation.position, bulletPrefabs.transform.rotation);
        //Tham chieu den tap lenh Bullet va, bien co ten bullet se lay thong tin tu tap lenh nay cua Gameobject Bullet tuong ung duoc gan vao.
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet != null)
        {
            //Neu bullet khong trong rong thi goi ham Seek o ben tap lenh C# Bullet.
            bullet.Seek(target);
        }
    }


    // Khai bao su dung ve duong line gizmos
    private void OnDrawGizmosSelected()
    {
        // To mau cho duong line nay
        Gizmos.color = Color.red;
        // Ve mot duong tron day tai vi tri cua muc tieu, voi ban kinh la range.
        Gizmos.DrawWireSphere(transform.position, range);
    }
    protected void LockTaget()
    {
        if (target == null)
            return;

        /*********Ham dung de khoa muc tieu nen tai su dung va doc lai de hieu ro hon***********/
        // Luu vector3 chua khoang cach tu vi tri cua doi tuong muc tieu den vi tri hien tai cua GameObject.
        Vector3 dir = target.position - transform.position;
        // Class su ly van de quay. va o day se quay theo huong vector tu vi tri cua Enemy den vi tri cua GameObject
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // Bien doi truc quay Quaternion ve euler. euler la noi cach khac cua quay quanh truc x,y hoac z . Mot trong 3. Giong nhu la ep kieu tu int thanh float.
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        // Noi cho may biet la dung goc quay euler chi de quay truc Y cua phan dau may ban phao chu khong quay cac truc khac.
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //Khai bao cach hoat dong cua che do ban
        if (fireCoutdown <= 0f)
        {
            Shoot();
            // Khai bao thoi gian ban
            fireCoutdown = 1f / fireRate;
        }
        fireCoutdown -= Time.deltaTime;
    }
}
