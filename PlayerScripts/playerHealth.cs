using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("Ustawienia HP")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("UI")]
    public TMP_Text hpText;

    [Header("Respawn")]
    public Transform spawnPoint;

    [Header("Obra¿enia od kolców")]
    public float damageCooldown = 1f; 
    private float lastDamageTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPText();
    }

    void Update()
    {


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHPText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHPText()
    {
        if (hpText != null)
            hpText.text = "HP: " + currentHealth;
    }

    void Die()
    {
        Debug.Log("Gracz zgin¹³!");
        Respawn();
    }
    void Respawn()
    {
        transform.position = spawnPoint.position;
        currentHealth = maxHealth;
        UpdateHPText();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Trap"))
        {
            if(Time.time >= lastDamageTime + damageCooldown)
            {
                TakeDamage(50);
                lastDamageTime = Time.time;
                

            }
        }
    }
}
