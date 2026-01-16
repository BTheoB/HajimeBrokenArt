using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public GameObject projectilePrefab;
    private Camera mainCam;
    public Weapon weapon;

    public event Action OnPlayerDied;

    public float speed = 3.0f;
    public int maxHealth = 5;
    int currentHealth = 1;
    //Synthax qui met inconnue
    public int Health { get { return currentHealth; } }

    int energie = 0;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;

    public bool isActive;

    void Awake()
    {
        mainCam = Camera.main;
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        speed = 3.0f;
        isActive = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
        StartCoroutine(DelayedInit());
    }

    IEnumerator DelayedInit()
    {
        yield return new WaitUntil(() => UIHandler.instance != null);
        SetHealth(maxHealth);
        SetEnergie(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;


        if (currentHealth <= 0)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0)) {
            Launch();
        }
   
        move = MoveAction.ReadValue<Vector2>();

        animator.SetFloat("MoveX", move.x);
        animator.SetFloat("MoveY", move.y);
        animator.SetFloat("Velocity", move.magnitude);

        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }
    }

    // Update is called at a fixed interval
    void FixedUpdate()
    {
        if (!isActive) return;
        if (currentHealth <= 0 )
        {
            return;
        }

        Vector2 position = (Vector2)rigidbody2d.position + speed * Time.deltaTime * move;
        rigidbody2d.MovePosition(position);
        
    }


    //Affecte un nouveau montant à la vie
    private void SetHealth (int health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth );
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth);
        if(currentHealth <= 0)
        {
            Death();
        }
    }
    //Ajoute ou diminue de la vie a la vie déja existante
    public void ModifyHealth(int health)
    {
        if (health < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
        }
        SetHealth(currentHealth + health);

    }
    //Affecte un nouveau montant à l'énergie
    private void SetEnergie(int energie)
    {
        this.energie = Mathf.Max(energie, 0);
        UIHandler.instance.SetEnergieValue(this.energie);
    }

    //Ajoute ou diminue de l'énergie selon l'énergie courrante
    public void AddEnergie(int energie)
    {
        SetEnergie(this.energie + energie);
    }


    //Lance un projectil de l'arme en main
    void Launch()
    {
        weapon.Fire();
    }

    public void SetActivity(bool activity)
    {
        this.isActive = activity;
    }


    public void Death()
    {
        animator.enabled = false;
        rigidbody2d.linearVelocity = Vector2.zero; // stoppe le mouvement
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
        OnPlayerDied?.Invoke();
    }

}
