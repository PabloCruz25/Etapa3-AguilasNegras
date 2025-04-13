using UnityEngine;

public class ShyGuySaltoAleatorio : MonoBehaviour
{
     public float minJumpForce = 3f;
    public float maxJumpForce = 6f;
    public float minInterval = 1f;
    public float maxInterval = 3f;

    private Rigidbody2D rb;
    private float nextJumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetNextJumpTime();
    }

    void Update()
    {
        if (Time.time >= nextJumpTime)
        {
            Saltar();
            SetNextJumpTime();
        }
    }

    void Saltar()
    {
        float fuerzaSalto = Random.Range(minJumpForce, maxJumpForce);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
    }

    void SetNextJumpTime()
    {
        float intervalo = Random.Range(minInterval, maxInterval);
        nextJumpTime = Time.time + intervalo;
    }
}
