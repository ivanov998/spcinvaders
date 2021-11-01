using UnityEngine;

public class Controller : MonoBehaviour
{

    public GameObject laser;
    public float playerSpeed;

    private GameObject activeLaser;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            this.transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            this.transform.position += Vector3.right * playerSpeed * Time.deltaTime;
    }

    void Shoot() {
        if (activeLaser) return;
        var pos = new Vector3(this.transform.position.x, this.transform.position.y + 0.15f, this.transform.position.z);
        activeLaser = Instantiate(laser,pos,Quaternion.identity);
        activeLaser.GetComponent<Laser>().direction = Vector3.up;
    }
}
