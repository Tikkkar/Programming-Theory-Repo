using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    //Khoi tao bien de truy cập vào RenDer
    private Renderer rend;
    // Khởi tạo biến màu cho ô đất trống khi di chuyoojt vào
    public Color hoverColor;
    // Khởi tạo biến lưu trữ màu basic 
    public Color startColor;
    // Khởi tạo biến lấy thông tin từ Gameobject
    [Header("Optional")]
    public GameObject turrent;
    // Start is called before the first frame update
    public BuildManager buildManager;
 
    public Vector3 positionOffset;

   
    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        // Khai báo màu sắc cho biến color basic
        startColor = rend.material.color;

    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Khởi tạo sự kiện khi nhấp chuột
    private void OnMouseDown()
    {
        // Neu nhu chuot nam trong khu vuc su kien thi se khong duoc chon cac khu vuc trong node. Khu vuc su kien la Canva
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildManager.CanBuild)
        {
            return ;
        }

        // Neu nhu co thap phao o vi tri o dat do roi thi bao ve co roi.
        if (turrent != null)
        {
            Debug.Log("Co roi");
            return;
        }
        buildManager.BuildTurrentOn(this);
        // Build a turrent.
      
    }
    // Khởi tạo sự kiện khi di chuột vào ô đất trống
    private void OnMouseEnter()
    {
        if ( EventSystem.current.IsPointerOverGameObject())
            {
            return;
        }
        // Neu nhu khong co thap phao nao duoc chon thi khong lam gì cả
        if (buildManager.CanBuild) 
            return;
        rend.material.color = hoverColor;
      
    }
    // Khởi tạo sự kiện khi di chuột ra khỏi ô đất
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
