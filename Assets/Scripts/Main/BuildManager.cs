using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Tạo bản lưu trữ thông tin mà mọi scrips khác có thể vào tham chiếu.
    public static BuildManager instance;
    private void Awake()
    {
        //Kiểm tra xem có bản dựng nào khác ngoài bản dựng này không, Không Nên Có Nhiều Hơn 1.
        if (instance != null)
        {
            Debug.LogError("Co Nhieu Hon 1 Ban Dung Trong Canh");
        }    
        instance = this;
    }
    // Khởi tạo các biến các lớp để tham chiếu giữa các scripts.
    // 
    public GameObject standardTurrentPrefab;
    public GameObject anotherTurrenprefab;
    private GameObject turrentToBuild;
    // Chọn đối tương nào sẽ được xây dựng
    public GameObject GetTurrentToBuild()
    {
        return turrentToBuild;
    }
    public void SetTurrentToBuild(GameObject turrent)
    {
        turrentToBuild = turrent;
    }

}
