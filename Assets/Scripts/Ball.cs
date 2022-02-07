using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody ballRb;

    Vector3 velocity;

    Scores score;
    Paddle paddle;
    [SerializeField]
    float timeAccelerationMultiplier;
    SphereCollider ballColl;

    bool isStart = false;

    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        score = FindObjectOfType<Scores>();
        paddle = FindObjectOfType<Paddle>();
        ballColl = GetComponent<SphereCollider>();
        
    }

    void FixedUpdate()
    {
        BallMoving();
    }

    void BallMoving()
    { 
        //������� ��� ������ ����. ��� ����� ��������� �� �����, ���� ����� �� ������ ����� ������ ����.
        if (isStart == false)
        {
            transform.position = paddle.transform.position + new Vector3(0, 0, 2f);
            ballColl.isTrigger = true;
            ballRb.velocity = Vector3.zero;
        }
        if (Input.GetMouseButtonDown(0) && isStart == false)
        {
            ballRb.velocity = new Vector3(Random.Range(-1f, 1f), 0, 1) * speed;
            isStart = true;
            ballColl.isTrigger = false;
        }

        //���������� �������� � �������� ����
        ballRb.velocity = ballRb.velocity.normalized * speed;
        ballRb.AddForce(Vector3.down * speed, ForceMode.Impulse);
        velocity = ballRb.velocity;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //���������� ������� ��������
        ballRb.velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);

        //�������� �������� � ����� ��� � ������ ������
        if (collision.gameObject.tag == "Paddle")
        {
            score.AddGameCubeScore();
            var contacrPaddle = paddle.GetReflectAngle(collision.contacts[0].point.x);

            //�������, ������� ����� ����������. �� ����� ������� � �� ��������.
            ballRb.velocity = Vector3.Reflect(velocity, collision.contacts[0].normal) + new Vector3(contacrPaddle / 2f, 0, 0);
        }
        else if (collision.gameObject.tag == "RedBorder")
        {
            score.AddRedBorderScore();
        }

        //���������� �������� ���� � �������� ��������
        if (speed < 20f)
            speed += Time.deltaTime * timeAccelerationMultiplier;
    }

}
