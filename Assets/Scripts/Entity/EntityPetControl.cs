using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPetControl : MonoBehaviour
{
    [SerializeField][Range(0, 20)] public int petCount = 1;
    [SerializeField] private Transform pointPivot, point;
    [SerializeField][Range(0, 50)] private float rotateSpeed = 10f;
    private float rotateAng = 0f, ang;
    [SerializeField] public List<Transform> pets = new List<Transform>();

    void Start()
    {
        pointPivot = transform.Find("PlayerPivot");
        point = pointPivot.Find("Point");
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateSpawnPet();
        GenPetCircle();
    }
    private void FixedUpdate()
    {
        Rotate();
    }
   
    public void AddPet(Transform transform)
    {
        petCount++;
        transform.GetComponent<PetMovement>().SetSpeedInvoke(50f,0.25f);
        pets.Add (transform);
    }
    public void RemovePet(Transform transform)
    {
        petCount--;
        pets[0].GetComponent<PetMovement>().SetSpeed(5f);
        pets.Remove(pets[0]);
    }
   
    void Rotate()
    {
        if (rotateAng >= 360f) rotateAng -= 360f;
        rotateAng += Time.deltaTime;
    }

    void GenPetCircle()
    {

        if (petCount != 0) ang = 360 / petCount;
        for (int i = 0; i < pets.Count; i++)
        {
            pointPivot.transform.rotation = Quaternion.Euler(0, 0, pointPivot.transform.rotation.z + (i * ang) + rotateAng * rotateSpeed);
            pets[i].GetComponent<PetMovement>().playerMove = point.position;
        }
    }
}
