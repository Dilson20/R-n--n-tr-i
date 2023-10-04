using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCommand : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float BodySpeed = 5;
    public float SteerSpeed = 100;
    public int Gap = 200;
    public OnCollide oc;
    int recScore = 0;

    public GameObject BodyPrefab;

    private List<GameObject> BodyParts = new List<GameObject>();

    private List<Vector3> PositionHistory = new List<Vector3>();

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
        Steer();
        snakePosition();
        bodyPartsGenerated();

        if (oc.score > recScore)
        {
            GrowSnake();
            recScore= oc.score;
        }
    }

    private void bodyPartsGenerated()
    {
        // Di chuyển thân rắn
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionHistory[Mathf.Clamp(index * Gap, 0, PositionHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;

            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    }

    private void snakePosition()
    {
        // lưu trữ vị trí của rắn
        PositionHistory.Insert(0, transform.position);
    }

    private void Steer() { 
        // Rẽ
        float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);
    }

    private void MoveUp()
    {
        // Tiến lên
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    //Mọc thân rắn
    public void GrowSnake() 
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

}
