using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PetControl : MonoBehaviour
{
    [SerializeField] private int petCount = 1;
    [SerializeField] private Transform pointPivot,point;
    [SerializeField] [Range(0, 50)] private float rotateSpeed = 10f;
    private float rotateAng=0f,  ang;
    [SerializeField] private List<Transform> pets = new List<Transform>();
    private void Awake()
    {
        UpdateSpawnPet();

    }
    void Start()
    {
        pointPivot = transform.Find("PlayerPivot");
        point = pointPivot.Find("Point");

    }

    // Update is called once per frame
    void Update()
    {
        GenPetCircle();
    }
    private void FixedUpdate()
    {
        Rotate();
    }
    void UpdateSpawnPet() 
    {
        while (petCount > pets.Count)
        {
            //string name = PetNameList[pets.Count];
            pets.Add(SpawnManager.Instance.Spawn("Spoon", transform.position.x, transform.position.y, Quaternion.identity));
        }
        while (petCount < pets.Count)
        {
            SpawnManager.Instance.Despawn(pets[petCount]);

            pets.Remove(pets[petCount]);
        }
        
    }
    public void SendPet(Transform transform)
    {
        if(transform.TryGetComponent<EntityPetControl>(out EntityPetControl entitypet)&&petCount>0)
        {
            pets[0].GetComponent<Pet>().SetTarget(entitypet.transform);
            petCount--;
            entitypet.AddPet(pets[0]);
            pets.Remove(pets[0]);
        }  
    }
    public void GetPet(Transform transform)
    {
        if (transform.TryGetComponent<EntityPetControl>(out EntityPetControl entitypet)&&entitypet.petCount>0)
        {
            entitypet.pets[0].GetComponent<PetMovement>().SetSpeed(5f);
            petCount++;
            pets.Add(entitypet.pets[0]);
            entitypet.pets[0].GetComponent<Pet>().SetTarget(this.transform);
            entitypet.RemovePet(entitypet.pets[0]);
            
        }
    }
    public void AddPet(Transform trans)
    {
        petCount++;
        pets.Add(trans);
    }
    public bool CheckPet(Transform trans)
    {
        if(pets.Contains(trans)) return false;
        return true;
    }
    public void CreatePet(string name)
    {
            petCount++;
            pets.Add(SpawnManager.Instance.Spawn(name, transform.position.x, transform.position.y, Quaternion.identity));
    }
    void Rotate()
    {
        if (rotateAng >= 360f) rotateAng -= 360f;
        rotateAng += Time.deltaTime;
    }
    
    void GenPetCircle()
    {
       
        if (petCount != 0) ang = 360/petCount;
        for (int i = 0; i < pets.Count; i++)
        {   
            pointPivot.transform.rotation = Quaternion.Euler(0,0, pointPivot.transform.rotation.z + (i*ang)+rotateAng*rotateSpeed);
            pets[i].GetComponent<PetMovement>().playerMove = point.position;
        }
    }
}
