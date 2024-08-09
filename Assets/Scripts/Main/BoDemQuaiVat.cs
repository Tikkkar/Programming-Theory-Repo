using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class BoDemQuaiVat : MonoBehaviour
{
    [SerializeField] public int amountEnemy;
    [SerializeField] TextMeshProUGUI amount;
    [SerializeField] bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
      amountEnemy = 0;
      
    }

    // Update is called once per frame
    private void Update()
    {
        amount.text = "Amount" + amountEnemy;
       
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            amountEnemy++;
            
        }
       
        
    }


}
