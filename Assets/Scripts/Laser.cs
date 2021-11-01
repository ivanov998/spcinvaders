using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed = 3.0f;
    public Vector3 direction;
    void Update() {
        this.transform.position += direction * speed * Time.deltaTime;

        if (Mathf.Abs(this.transform.position.y) > 1.75f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) {
        Destroy(gameObject);
    }
}