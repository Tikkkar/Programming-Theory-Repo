using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject Effect;

    protected float timeDestroyEffect = 1f;

    [SerializeField] BoDemQuaiVat soLuong;

    public Enemy Enemy;
    
    protected float speed = 70f;

    protected int damege = 5;

    // Khai bao bien ban kinh vien dan.
    protected float oxplosionRadius = 0f;

    public void Start()
    {
        soLuong = GameObject.Find("Ground").GetComponent<BoDemQuaiVat>();
    }

    // Khai bao bien tim kiem muc tieu Seek co nghia la tim kiem. taget cua may ban cung la muc tieu cua vien dan
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        BulletWorks();
       
    }

    // Khi bắn trúng mục tiêu thì làm gì đó.
     void HitTarget()
    {

        // Thực hiện hiệu ứng khi trúng mục tiêu
        if (Effect != null)
        {
            GameObject Effecint = (GameObject)Instantiate(Effect, transform.position, transform.rotation);
            Destroy(Effecint, timeDestroyEffect);
        }
        // Bán kính tác dụng của viên đạn lớn hơn 0 thì gọi phương thức Expole
        if (oxplosionRadius > 0)
        {
            Expole();
        }
        else 
        {
            Damage(target);
          
        }
        Destroy(gameObject);
    }
    // Sử lý vụ nổ
    void Expole()
    {
        // Mảng này là mảng có đối tượng nằm trong phạm vi của vụ nổ. Phạm vi của vụ nổ được mô tả là Physics.OverLapSphere. Nghĩa là đối tượng có nằm trong bán kính này không tâm là vị trí của
        // đối tượng còn bán kính là oxplosionRadius.
       
        Collider[] colliders = Physics.OverlapSphere(transform.position, oxplosionRadius);
        
        // Phương thức này để kiểm tra trong vụ nổ có đối tượng có tag là Enemy không và nếu có thì thực hiện điều gì.

        foreach ( Collider collider in colliders)
        {
            //Doi tuong nay la ai?
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    // Khi bắn trung đối tượng là Enemy rồi thì sao sẽ gây ra điều gì?
    void Damage(Transform enemy)
    {

        enemy.GetComponent<Enemy>().TakeDame(damege);
       
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
        // Tương tự như tìm khoảng cách từ vị trí người chơi đến vị trí của enemy.
        Vector3 dir = target.position - transform.position;
        // Cái này để làm cho viên đạn bay theo giây chứ không bay theo khung hình.
        float distanceThisFrame = speed * Time.deltaTime;
        // Kiểm tra xem đối tượng viên đạn có va chạm với mục tiêu trong khung hình hiện tại hay không.
        // dir.magnitudee Là độ dài của mục tiêu và viên đạn
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        // Di chuyển viên đạn đến mục tiêu bằng tốc độ bình thường chứ không tăng lên theo khoảng cách và cũng bay theo dây, theo hướng Global chứ không phải local
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, oxplosionRadius);
    }
   
}
