using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBullet : Bullet
{
    
    public RageBullet()
    {
        speed = 30f;
        oxplosionRadius = 2f;
    }
 

    // Update is called once per frame
    void Update()
    {
        BulletWorks();
    }
}
