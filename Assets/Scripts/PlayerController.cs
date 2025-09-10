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

    public float speed = 3.0f;
    public int maxHealth = 5;
    int currentHealth;
    //Synthax qui met inconnue
    public int Health { get { return currentHealth; } }

    int energie = 0;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;



    void Awake()
    {
        mainCam = Camera.main;
        Debug.Log("MainCam = " + mainCam.name);
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        speed = 3.0f;
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

        //if(currentHealth <= 0)
        //{
        //    return;
        //}

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
        //if (currentHealth <= 0)
        //{
        //    return;
        //}

        Vector2 position = (Vector2)rigidbody2d.position + speed * Time.deltaTime * move;
        rigidbody2d.MovePosition(position);
        
    }


    //Affecte un nouveau montant à la vie
    private void SetHealth (int health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth );
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth);
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
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();

        // Calcul la direction du joueur vers le pointeur de la souris 
        Vector2 direction = GetDirectionToMousePointer();
        projectile.Launch(direction, 500);
    }
    Vector2 GetDirectionToMousePointer()
    {
        Vector3 mousePos = Input.mousePosition;

        // due a la camera virtuel a -12 en Z On fixe une profondeur correcte pour un monde 2D
        mousePos.z = Mathf.Abs(mainCam.transform.position.z);  // Ex: si cam à z = -10, on met z = 10

        Vector3 worldPos = mainCam.ScreenToWorldPoint(mousePos);

        return (((Vector2)worldPos - rigidbody2d.position)).normalized;
    }

}
