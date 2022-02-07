using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
     Rigidbody paddleRB;
    [SerializeField]
    GameObject leftBound;
    [SerializeField]
    GameObject rightBound;
    Renderer rend;


    Vector3 center = new Vector3();
    float halfWidth = 0;
    float offset;

    float mousePos;

    void Start()
    {
        Cursor.visible = false;
        paddleRB = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    //�����, ����������� ����� �������� ���� � ���� �� ���������� x.
    // ����� ������������� ���������� ���� ������� ������ �� �������, ������� �������� ���(������������ ������).
    public float GetReflectAngle(float hit)
    {
        center = rend.bounds.center;
        halfWidth = transform.localScale.x / 2;
        offset = hit - center.x;
        var angle = 45 * (offset / halfWidth);

        return angle;
    }

    //����� ���������� ����� �������� �����.
    //��������� ������� ���������� �� ������.
    void Move()
    {
        
        mousePos = Mathf.Clamp(Camera.main.ScreenToWorldPoint(new Vector3(
                                                                   Input.mousePosition.x, 0, 0)).x, 
                                                                   leftBound.transform.position.x + 1.2f, 
                                                                   rightBound.transform.position.x - 1.2f);
        paddleRB.MovePosition(new Vector3(mousePos, 0.5f, -6));
    }
}
