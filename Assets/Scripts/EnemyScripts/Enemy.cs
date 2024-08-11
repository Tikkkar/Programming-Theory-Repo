    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healE = 5;
    public BoDemQuaiVat quaivat;
    public bool enemyDestroy;
    private void Start()
    {
        quaivat = GameObject.Find("Ground").GetComponent<BoDemQuaiVat>();
        
    }
    public void TakeDame(int amout)
    {
        healE -= amout;
        
        if (healE < 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(healE);
    }

  
}
