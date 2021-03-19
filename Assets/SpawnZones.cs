using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnZones : MonoBehaviour
{
    public GameObject characterZones, vehicleZones;

    private BoxCollider[] characterColliders, vehicleColliders;
    private CharacterController[] characters;
    private VehicleController[] vehicles;

    // Start is called before the first frame update
    void Start()
    {
        characterColliders = GameObject.FindWithTag("CharacterSpawns").GetComponentsInChildren<BoxCollider>();
        vehicleColliders = GameObject.FindWithTag("VehicleSpawns").GetComponentsInChildren<BoxCollider>();
        characters = GameObject.FindWithTag("Characters").GetComponentsInChildren<CharacterController>();
        vehicles = GameObject.FindWithTag("Vehicles").GetComponentsInChildren<VehicleController>();   
        InvokeRepeating(nameof(SpawnCharacterTargets), .85f, 2f);
        InvokeRepeating(nameof(SpawnVehicleTargets), 3f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnCharacterTargets()
    {
        int charToSpawn = Random.Range(0, characters.Length);
        Instantiate(characters[charToSpawn].transform.gameObject, characterColliders[Random.Range(0, characterColliders.Length)].ClosestPoint(GameObject.FindWithTag("Player").transform.position) + new Vector3(Random.Range(0, 5), 0f, 0f), characters[charToSpawn].transform.rotation);
    }

    void SpawnVehicleTargets()
    {
        int vehToSpawn = Random.Range(0, vehicles.Length);
        int vehArea = Random.Range(0, vehicleColliders.Length);
        Vector3 offset = Vector3.zero;//new Vector3(Random.Range(0, 1) == 0 ? 0 : 10, 0f, 0f);

        var newVehicle = Instantiate(vehicles[vehToSpawn].transform.gameObject, vehicleColliders[vehArea].ClosestPoint(GameObject.FindWithTag("Player").transform.position) + offset, vehicles[vehToSpawn].transform.rotation);
        
        print(vehToSpawn + "; " + vehicleColliders.Length + "; " + newVehicle.transform.position + "; " + vehicleColliders[vehArea].center);
    }
}
