using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
// Referencja do AudioSource
[SerializeField] AudioSource characterSounds;
// Referencja do klipu audio skoku
[SerializeField] AudioClip jump;
    [SerializeField] float movementSpeed = 5f;
float currentSpeed;
Rigidbody rb;
Vector3 direction;
[SerializeField] Image pistolUI, rifleUI, miniGunUI, cusror;

[SerializeField] float shiftSpeed = 10f;
[SerializeField] float jumpForce = 7f;
bool isGrounded = true;

[SerializeField] Animator animator;
[SerializeField] GameObject pistol, rifle, miniGun;
bool isPistol, isRifle, isMiniGun;
public enum Weapons
{
    None,
    Pistol,
    Rifle,
    MiniGun
}
Weapons weapons = Weapons.None;
// Start is called before the first frame update
private int health;
void Start()
{
    rb = GetComponent<Rigidbody>();
    currentSpeed = movementSpeed;
    animator = GetComponent<Animator>();
    health = 100;
}

// Update is called once per frame
void Update()
{
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
    direction = transform.TransformDirection(direction);

    if (direction.x != 0f || direction.z != 0f)
    {
        animator.SetBool("Run", true);
        if(!characterSounds.isPlaying && isGrounded)
            {
                characterSounds.Play();
                
            }
        
    }
    if (direction.x == 0f && direction.z == 0f)
    {
        animator.SetBool("Run", false);
        characterSounds.Stop();
    }

    if (Input.GetKey(KeyCode.LeftShift))
    {
        currentSpeed = shiftSpeed;
    }
    else
    {
        currentSpeed = movementSpeed;
    }

    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        animator.SetBool("Jump", true);
        rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        isGrounded = false;
        // Wyłączanie dźwięku biegu
        characterSounds.Stop();
        // Tworzenie tymczasowego źródła audio dla skoku
        AudioSource.PlayClipAtPoint(jump, transform.position);
        
        
    }
        if(Input.GetKeyDown(KeyCode.Alpha1) && isPistol)
{
    ChooseWeapon(Weapons.Pistol);
}
if (Input.GetKeyDown(KeyCode.Alpha2) && isRifle)
{
    ChooseWeapon(Weapons.Rifle);

}
    if (Input.GetKeyDown(KeyCode.Alpha3) && isMiniGun)
{
    ChooseWeapon(Weapons.MiniGun);

}
    if (Input.GetKeyDown(KeyCode.Alpha4))
{
    ChooseWeapon(Weapons.None);

}

//Tutaj dopisz logikę dla miniguna i dla braku broni
}


void FixedUpdate()
{
    rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
}

private void OnCollisionEnter(Collision collision)
{
    isGrounded = true;
    animator.SetBool("Jump", false);
}

public void ChooseWeapon(Weapons weapons)
{
    animator.SetBool("Pistol", weapons == Weapons.Pistol);
    animator.SetBool("Assault", weapons == Weapons.Rifle);
    animator.SetBool("MiniGun", weapons == Weapons.MiniGun);
    animator.SetBool("NoWeapon", weapons == Weapons.None);
    pistol.SetActive(weapons == Weapons.Pistol);
    rifle.SetActive(weapons == Weapons.Rifle);
    miniGun.SetActive(weapons == Weapons.MiniGun);
    if(weapons != Weapons.None)
        {
            cusror.enabled = true;
        }
    else
        {
            cusror.enabled = false;
        }    
        
            
}

private void OnTriggerEnter(Collider other)
{
    switch (other.gameObject.tag)
    {
        case "pistol":
            if (!isPistol)
            {
                isPistol = true;
                pistolUI.color = Color.white;
                ChooseWeapon(Weapons.Pistol);
            }
            break;
        case "rifle":
            if (!isRifle)
            {
                isRifle = true;
                rifleUI.color = Color.white;
                ChooseWeapon(Weapons.Rifle);
            }
            break;
        case "minigun":
            if (!isMiniGun)
            {
                isMiniGun = true;
                miniGunUI.color = Color.white;
                ChooseWeapon(Weapons.MiniGun);
            }
            break;
        default:
            break;
    }
    Destroy(other.gameObject);

    }
    public void ChangeHealth(int count)
    {
// odejmowanie zdrowia
    health -= count;
// jeśli zdrowie spadnie do zera lub niżej, to...
    if (health <= 0)
    {
    // Aktywowanie animacji śmierci
    animator.SetBool("Die", true);
    // Usunięcie broni
    ChooseWeapon(Weapons.None);
    // Wyłączenie skryptu PlayerController, co uniemożliwia ruch gracza
    this.enabled = false;
    //Przetestujemy to wkrótce, jak tylko zaimplementujemy przeciwników!
    }
}
}



