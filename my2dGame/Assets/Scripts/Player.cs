using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private GameObject weapon;

    [SerializeField] private Transform shootTransform; // ���ϴ� �� transform

    [SerializeField] private float ShootInterval = 0.05f;
    private float lastShootTime = 0f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f); // ������ �ּڰ� ũ�� �ִ� �߰��̸� ���� ��
        transform.position =new Vector3(toX, transform.position.y, transform.position.z);

        Shoot();
    }

    void Shoot()
    {
        if (Time.time - lastShootTime > ShootInterval)
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShootTime = Time.time;
        }
    }
}