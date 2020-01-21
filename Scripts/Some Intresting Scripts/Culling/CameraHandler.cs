using UnityEngine;

public class Camering : MonoBehaviour
{

    public float asp;

    public static float addedX = 0;
    public static float twoAddedX = 0;


    public static float aspect;

    static Camera _mainCamera;
    public static Camera MainCamera
    {
        get
        {
            if (_mainCamera == null) _mainCamera = Camera.main;
            return _mainCamera;
        }
    }
    static BoxCollider2D _cameraColl;
    public static BoxCollider2D CameraColl
    {
        get
        {
            if (_cameraColl == null) _cameraColl = MainCamera.GetComponent<BoxCollider2D>();
            return _cameraColl;
        }
    }

    public static Vector2 ScreenToWorldPoint(Vector2 pos)
    {
        return _mainCamera.ScreenToWorldPoint(pos);
    }

    void Start()
    {
        var const1 = (float)Screen.width / Screen.height;

        addedX = (const1 - asp) * 5; twoAddedX = addedX * 2;
        transform.position = new Vector3(transform.position.x + addedX, transform.position.y, transform.position.z);
        //if (const1 > asp)
        //{
        //    addedX = (const1 - asp) * 5; twoAddedX = addedX * 2;
        //    transform.position = new Vector3(transform.position.x + addedX, transform.position.y, transform.position.z);
        //}
        //else
        //{
        //    MainCamera.aspect = asp;
        //    var const2 = Mathf.Abs((const1 - asp) / 2);
        //    //if(const1 > asp) Camera.main.rect = new Rect(const2/2, 0, 1 - const2, 1);
        //    //else if(const1 < asp)
        //    MainCamera.rect = new Rect(0, const2, 1, 1);
        //}
        var col = MainCamera.GetComponent<BoxCollider2D>();
        if (col == null) return;
        col.size = new Vector2(const1 * 10f, 10f);

        aspect = MainCamera.aspect;
    }
}
