using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
[SerializeField] protected float attackDistance;    
[SerializeField] protected int damage;
[SerializeField] protected float cooldown;
protected GameObject player;    
protected Animator anim;
protected Rigidbody rb;
protected float distance;
protected float timer;  
bool dead = false;
void Start()
{
    player = FindObjectOfType<PlayerController>().gameObject; 
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody>();
}
private void Update() 
{
    distance = Vector3.Distance(transform.position, player.transform.position);
    if (!dead)
    {            
        Attack();
    }        
}

  public virtual void Move()
    {
        
    }
public virtual void Attack()
    {
        
    }
    private void FixedUpdate()
{
    if (!dead)
    {
        Move();
    }
}
public void ChangeHealth(int count)
{
// odejmowanie zdrowia
health -= count;
// jeśli zdrowie spada do zera lub niżej, to...
if(health <= 0)
{
// zmiana wartości zmiennej dead, co oznacza, że wywołania funkcji Attack i Move przestaną działać
dead = true;
// wyłączanie collidera wroga
GetComponent<Collider>().enabled = false;
// włączanie animacji śmierci
anim.SetBool("Die", true);
}
}
}
