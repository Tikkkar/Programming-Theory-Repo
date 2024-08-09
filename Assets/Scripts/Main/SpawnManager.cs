using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;


public class SpawnManager : MonoBehaviour
{
    // Khai bao bien luu tru cac loai quai vat trong trinh chinh sua.
    public GameObject[] enemySpawn;
    // Truy cap vao vi tri cua startPoint. startPoint duoc khai bao trong trinh chinh sua.
    public Transform startPoint;
    public TextMeshProUGUI coutDownTime;
    public TextMeshProUGUI waveCount;
    // Khai bao bien luu tru kieu quai vat
    private int kieuEnemy;
    // Thoi gian gian cach giua cac roud
    private float timeStart = 5f;
    // Thoi gian Bat dau tro choi
    private float coutdown = 5f;
    // The hien Wave nay la Wave bao nhieu.
    private float waveIndex = 1;
    // Khai bao wave quai cuoi cung.
   [SerializeField] private float finalWave = 4f;
    // So luong quai cua tung roud
    private float enemyNumber = 1;

    bool gameIsActive;

    // Start is called before the first frame update
    void Start()
    {
        gameIsActive = true;
        waveIndex = 1;
   
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (gameIsActive)
        {
            // Thiet lap thoi gian xuat hien cua moi round
            if (coutdown < 0f)
            {
                // Goi ham de quai xuat hien.
                StartCoroutine("WaySpawn");
                // Thiet lap lai thoi gian de xuat hien dot quai tiep theo.
                coutdown = timeStart;
            }
            // Thiet lap bo dem nguoc
            coutdown -= Time.deltaTime;
            // In thoi gian cho Roud Tiep Theo Ra Man Hinh.
            coutDownTime.text = "Time : " + Mathf.Floor(coutdown).ToString();
        }
        
        
    }
        IEnumerator WaySpawn()
        {
        // Thiet lap wave quai cuoi cung 
        if (waveIndex < finalWave)
        {
            // Thiet Lap So Luong Quai Xuat Hien Cua 1 Wave. Neu waveIndex = 5 thi goi ham nay 5 lan cho den khi i = 4 thi se dung. Khi do o wave 5 se xuat hien 4 con quai.
            for (int i = 0; i < enemyNumber; i++)
            {

                EnemyRandomSpawn();
                // Khai bao de quai vat khong dung chi chit vao nhau khi xuat hien.
                yield return new WaitForSeconds(0.5f);
            }
            // so luong quai vat tang len theo theo cap so nhan.
            enemyNumber += waveIndex;
            // Tang kieu quai xuat hien theo roud.
            //kieuEnemy++;
            waveCount.text = "Wave : " + waveIndex;

        }
        // Khi hoan thanh wave quai cuoi cung thi co thong bao chien thang.
        else
        {
            Debug.Log("Victory!");
            gameIsActive = false;
        }
            // Chuyen tiep thanh wave tiep theo va lap lai ham tren
             waveIndex++;
        
        }

        

    
    void EnemyRandomSpawn()
    {
            kieuEnemy = Random.Range(0,3);

            Instantiate(enemySpawn[kieuEnemy], startPoint.transform.position, enemySpawn[kieuEnemy].transform.rotation);   
    }
}
    
    
   
   
