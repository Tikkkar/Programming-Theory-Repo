using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraMove : MonoBehaviour
{
    // Khai bao bien luu tru toc do di chuyen cua camera
    public float cameraSpeed = 30f;
    //Khai bao bien de tru di phan khung hinh vien.
    public float khungVien = 10f;
    // Kiem tra da an esc chua neu an roi thi khogn su dung viec di chuot de keo camera nua
    public bool doMove = true;
    //Khai bao bien luu tru do cao min max
    public float minY = 10f;
    public float maxY = 80f;
    // Khai bao toc do cuon chuot;
    public float scrollSpeed = 10f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMove = !doMove;
        }

        if (!doMove)
            return;

        // Khai bao cac vi tri de co the di chuyen duoc camera.
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - khungVien)
        {
            transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= khungVien )
        {
            
            transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x >= Screen.width - khungVien)

        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x < khungVien)
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime, Space.World);
        }
        GioiHanTrucXYZ();

        // Khai bao nhan thong tin dau vao la con lan chuot
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        // Khai bao lay vi tri cua camera, va luu lai vi tri cua camera khi code chay
       
        Vector3 pos =  transform.position;
        // Code de thay doi toa do truc y khi lan chuot. Vi toc do lan chuot thap nen ta nhan them 1000 de tawng them toc do
        pos.y -=   scroll* 1000 * scrollSpeed * Time.deltaTime;
        //Gioi han truc y khi cuon tren truc y
        pos.y = Mathf.Clamp(pos.y,minY,maxY);
        transform.position = pos;

        void GioiHanTrucXYZ()
        {
            if (transform.position.z > 72)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 72);
            }
            if (transform.position.z < -50 )
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -50);
            }
            if (transform.position.x > 50)
            {
                transform.position = new Vector3(50, transform.position.y, transform.position.z);
            }
            if (transform.position.x <-50 )
            {
                transform.position = new Vector3(-50, transform.position.y, transform.position.z);
            }
        }
    }
}


