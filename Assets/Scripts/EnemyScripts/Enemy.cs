using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BoDemQuaiVat quaivat;
   
    public bool enemyDestroy;
    private void Start()
    {
        quaivat = GameObject.Find("Ground").GetComponent<BoDemQuaiVat>();
    }
    public void OnDestroy()
    {
        enemyDestroy = true;
        Debug.Log("Da bi tieu diet");
        quaivat.amountEnemy -= 2;
    }
}
