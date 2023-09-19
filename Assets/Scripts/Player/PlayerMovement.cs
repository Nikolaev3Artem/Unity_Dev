using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed;
    public float sprintSpeed;
    public int maxDashCharges = 3;
    public float dashCooldown = 5.0f;
    public float dashDuration = 0.1f;
    public float dashSpeed = 20.0f; // Швидкість під час деша

    public int dashCharges = 3;
    private bool isDashing = false;
    private float dashStartTime;
    private Rigidbody2D rb2d;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.drag = 10f;
        currentSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Перевірка, чи можна використовувати деш та чи натиснута клавіша "Shift"
        if (!isDashing && dashCharges > 0 && Input.GetKeyDown(KeyCode.LeftShift) && (moveHorizontal != 0 || moveVertical != 0))
        {
            currentSpeed = dashSpeed; // Встановити швидкість під час деша
            dashCharges--;
            isDashing = true;
            dashStartTime = Time.time;
        }

        // Перевірка, чи деш ще діє та чи минув час dashDuration
        if (isDashing && Time.time - dashStartTime >= dashDuration)
        {
            isDashing = false;
            currentSpeed = normalSpeed;
        }

        // Перевірка, чи можна відновити заряди
        if (dashCharges < maxDashCharges)
        {
            if (Time.time - dashStartTime >= dashCooldown)
            {
                dashCharges++;
                dashStartTime = Time.time; // Скидаємо таймер перезарядки при відновленні зарядів
            }
        }

        Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;

        // Рух гравця з поточною швидкістю
        rb2d.velocity = moveDirection * currentSpeed;
    }
}
