using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float heal = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void DieuKienBiPhaHuy()
    {
        if (heal < 0)
        {
            Destroy(gameObject);
        }
    }
}
