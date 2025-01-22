using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    [SerializeField]protected float shakeDuration = 0.1f, shakeMagnitude = 0.05f,hp=20f,maxHp=20f,attackDamage = 1f,attackSpeed=2f;
    [SerializeField] protected bool canAttack = true,isDeath= false,onColli = false,onAttack=false;
    [SerializeField] protected Vector2 direct;
    [SerializeField] protected LayerMask dashLayer;
    public float speed = 25f;
    private Vector3 velocity = Vector3.zero;
    private void Awake()
    {
        ResetComponent();
    }
    private void Start()
    {
        ResetComponent();
    }
    private void Update()
    {
        LookAt();
        CheckMove();
        CheckHp();
        if (Vector3.Distance(transform.position, PlayerData.Instance.transform.position) <= 0.5f&&transform.name=="Fork")
        {
            onColli = true;
        }
        else if (Vector3.Distance(transform.position, PlayerData.Instance.transform.position) <= 4f && (transform.name == "Nail"||transform.name=="Cactus"))
        {
            onColli= true;
        }
        else
            onColli = false;
        if (onColli)
        {
            ColliDamage();
        }
    }
    public void SetDeath(bool value)
    {
        isDeath = value;
    }
    public bool GetDeath()
    {
        return isDeath;
    }
    public void LookAt()
    {
        if (transform.name == "Fork")
        {
            Quaternion temp = LookAtTarget();
            temp = Quaternion.Euler(0f, 0f, temp.eulerAngles.z + 180f);
            transform.GetComponentInChildren<SpriteRenderer>().transform.rotation = temp;
        }
    }
    public void CheckMove()
    {
        if (Vector3.Distance(transform.position, direct) <= 0.75f) onAttack = false;

        if (transform.name == "Nail" && onAttack)
        {
            Debug.DrawRay(transform.position, direct, Color.green);
            transform.position = Vector3.SmoothDamp(transform.position, direct, ref velocity, 1 / speed);
        }
    }
    public virtual void CheckHp()
    {
        if (hp <= 0&&!isDeath)
        {
            isDeath = true;
            
            PetReturn(GetComponent<EntityPetControl>().petCount);
            DropItem();
            hp = 0;
        }
    }
    protected virtual void DropItem()
    {
        switch (transform.name)
        {
            case ("Wood"):
                {
                    PlayerData.Instance.SetWood(2);
                    break;
                }
            case ("Iron"):
                {
                    PlayerData.Instance.SetIron(1);
                    break;
                }
            case ("SunL"):
                {
                    PlayerData.Instance.SetSunL(1);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    public void ColliDamage()
    {
        switch (transform.name)
        {
            case ("Fork"):
                {
                    Attack();
                    break;
                }
            case ("Nail"):
                {
                    Attack();
                    break;
                }
            case ("Cactus"):
                {
                    Attack();
                    break;
                }
            default:
                {
                    Debug.Log(transform.name + "Not Colli Damage");
                    break;
                }
        }
    }
    protected virtual void Attack()
    {
        switch (transform.name)
        {
            case ("Fork"):
                {
                    if (canAttack)
                    {
                        PlayerData.Instance.SetHp(-attackDamage);
                        canAttack = false;
                        Invoke(nameof(AttackCountDown),attackSpeed);
                    }
                    break;
                }
            case ("Nail"):
                {
                    if (canAttack)
                    {
                        Vector3 Pos = PlayerData.Instance.transform.position - transform.position;
                        Pos.Normalize();
                        direct = transform.position + 8 * Pos;
                        RaycastHit2D ray = Physics2D.Raycast(transform.position, Pos, 8, dashLayer);

                        if (ray.collider != null)
                        {

                            direct = ray.point;

                        }
                        canAttack = false;
                        onAttack = true;
                        Invoke(nameof(AttackCountDown), attackSpeed);
                        break;
                    }
                    break;
                }
            case ("Cactus"):
                {
                    if (canAttack)
                    {
                        Spawn();
                        canAttack = false;
                        Invoke(nameof(AttackCountDown), attackSpeed);
                        break;
                    }
                    break;
                }
            default:
                {
                    Debug.Log(transform.name + "Can Attack");
                    break;
                }
        }
    }
    private Quaternion LookAtTarget()
    {
        //Vector3 diff = Vector3.Lerp(this.targetPosition, this.lerpPosition, 10f) - aimTransform.position;
        Vector3 diff = PlayerData.Instance.transform.position - transform.position;
        //this.lerpPosition = this.targetPosition;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.x, diff.y) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, -rot_z);

    }
    private void Spawn()
    {
        SpawnManager.Instance.Spawn("Spike", transform.position.x, transform.position.y, LookAtTarget());

    }
    public void SetOncolli(bool value)
    {
        onColli = value;
    }
    private void AttackCountDown()
    {
        canAttack = true;
    }
    public virtual float GetHp()
    {
        return hp;
    }
    public virtual float GetMaxHp()
    {
        return maxHp;
    }

    public virtual void SetDamage(float damage)
    {
        hp -= damage;
        ShakeObject();
        
    }
    protected virtual void ShakeObject()
    {
        if (transform.Find("Sprite").TryGetComponent<ShakeObject>(out ShakeObject obj))
        {
            StartCoroutine(obj.Shake(shakeDuration, shakeMagnitude));

        }
    }
    protected virtual void PetReturn(int count)
    {
        PetControl petctrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PetControl>();
        for (int i = 0; i < count; i++)
        {
            petctrl.GetPet(transform);
        }
    }
    public void ResetComponent()
    {
        hp = maxHp;
        isDeath = false;
        canAttack = true;
    }
}
