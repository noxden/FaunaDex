using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGuideAnimal : MonoBehaviour
{
    public GameObject AnimalPrefab;

    private GameObject SpawnedAnimal = null;

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void OnButtonClick()
    {
        Debug.Log($"Button has been clicked.");
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.DrawRay(Camera.main.transform.position, ray.GetPoint(200.0f), Color.red, 10.0f);
            if (hit.collider.tag != "ARPlane")
                return;

            Debug.Log($"Plane has been hit.");
            if (SpawnedAnimal == null)
                SpawnedAnimal = Instantiate(AnimalPrefab, hit.point, Quaternion.identity);
            else
            {
                SpawnedAnimal.transform.SetLocalPositionAndRotation(hit.point, Quaternion.identity);
            }
        }
    }
}
