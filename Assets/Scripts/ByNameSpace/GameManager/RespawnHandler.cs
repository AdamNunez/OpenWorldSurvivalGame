using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RespawnHandler : MonoBehaviour {
    public Terrain Map;
    public float SpawnDistance;
    Vector3 SpawnPos = Vector3.zero;
    private int LoopFailSafeCounter;

    public Vector3 GenerateSpawnPointNavMesh()
    {
        bool GoodSpawn = false;
        LoopFailSafeCounter = 0;
        while (!GoodSpawn)
        {
            LoopFailSafeCounter++;

            SpawnPos = new Vector3(Random.Range(Map.transform.position.x, Map.terrainData.size.x), 0, Random.Range(Map.transform.position.z, Map.terrainData.size.z));
            SpawnPos = FindGroundLevel(SpawnPos);
            NavMeshHit NavMeshHit;
            NavMesh.SamplePosition(SpawnPos, out NavMeshHit, 5, NavMesh.AllAreas);
            SpawnPos = new Vector3(NavMeshHit.position.x, NavMeshHit.position.y + .1f, NavMeshHit.position.z);
            Collider[] EnemyNearbyCheck = Physics.OverlapSphere(SpawnPos, 5f);
            foreach (Collider col in EnemyNearbyCheck)
            {
                if (col.transform.root.tag == "Enemy" && col.GetType() == typeof(CapsuleCollider))
                {
                    GoodSpawn = false;
                    break;
                }
                else
                {
                    if (OnGround())
                    {
                        GoodSpawn = true;
                    }
                    else
                        GoodSpawn = false;
                }

            }
            if (LoopFailSafeCounter > 10000)
            {
                SpawnPos = Vector3.zero;
                break;
            }
        }
        return SpawnPos;
    }

    public Vector3 GenerateSpawnPointTerrain()
    {
        bool GoodSpawn = false;
        LoopFailSafeCounter = 0;
        while (!GoodSpawn)
        {
            LoopFailSafeCounter++;

            SpawnPos = new Vector3(Random.Range(Map.transform.position.x, Map.terrainData.size.x), 0, Random.Range(Map.transform.position.z, Map.terrainData.size.z));
            SpawnPos = FindGroundLevel(SpawnPos);
            Collider[] EnemyNearbyCheck = Physics.OverlapSphere(SpawnPos, 5f);
            foreach (Collider col in EnemyNearbyCheck)
            {
                if (col.transform.root.tag == "Enemy" && col.GetType() == typeof(CapsuleCollider))
                {
                    GoodSpawn = false;
                    break;
                }
                else
                {
                    if (OnGround())
                    {
                        GoodSpawn = true;
                    }
                    else
                        GoodSpawn = false;
                }

            }
            if (LoopFailSafeCounter > 10000)
            {
                SpawnPos = Vector3.zero;
                break;
            }
        }
        return SpawnPos;
    }


    private bool OnGround()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(SpawnPos, Vector3.down * 5, out hitInfo))
        {
            if (hitInfo.collider.GetType() == typeof(TerrainCollider))
            {
                return true;
            }
        }
        return false;
    }


    private Vector3 FindGroundLevel(Vector3 NeedYSet)
    {
        Vector3 PosWithYSet = NeedYSet;
        RaycastHit Hit;
        Physics.Raycast(NeedYSet, Vector3.up, out Hit, 400);
        if (Hit.collider)
            PosWithYSet = new Vector3(NeedYSet.x, Hit.point.y + 2f, NeedYSet.z);
        return PosWithYSet;
    }

}
