using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private Animation animation;

    float speed = 5;
    float fireTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(x, 0f, z) * speed * Time.deltaTime);
        fireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (fireTimer > 0.5f)
            {
                fireTimer = 0f;
                Bullet b = Instantiate(prefab, parent);
                b.transform.SetParent(bulletParent);
                b.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
        }

        // 마우스의 스크린 좌표를 월드 좌표로 변환
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(mouseRay, out rayDistance))
        {
            Vector3 lookPosition = mouseRay.GetPoint(rayDistance);
            lookPosition.y = transform.position.y;

            transform.LookAt(lookPosition);
        }

    }
}
