﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="NewSpawnPlayEffect", menuName ="CardData/PlayEffects/Spawn")]
public class SpawnPlayEffect : CardPlayEffect
{
    [SerializeField] GameObject _prefabToSpawn = null;

    public override void Activate(ITargetable target)
    {
        MonoBehaviour worldObject = target as MonoBehaviour;
        if(worldObject != null)
        {
            Vector3 spawnLocation = worldObject.transform.position;
            GameObject newGameObject = Instantiate(_prefabToSpawn, spawnLocation, Quaternion.identity);
            Debug.Log("spawn new object: " + newGameObject.name);
        }
          else
        {
            Debug.Log("target does not have a transform");
        }
    }

}
