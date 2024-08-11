using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class MauNhaChinh : MonoBehaviour
{
    public TextMeshProUGUI HealText;
    private static int healBuilding;
    public int heal = 100;

    // Start is called before the first frame update
    void Start()
    {
        healBuilding = heal;
    }

    // Update is called once per frame
    void Update()
    {
     
        HealText.text = "Heal: +" + heal.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("???");
            Destroy(other.gameObject);
            heal -= 1;
        }
    }




}
