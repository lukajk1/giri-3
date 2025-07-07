using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    //[SerializeField] private bool addToDDOL = false;

    //private GameObject emptyHolder;

    //private static GameObject gameObjectsEmpty;
    //private static GameObject particleSystemsEmpty;
    //private static GameObject attackTracers;
    //private static GameObject soundFXEmpty;

    //private static Dictionary<GameObject, ObjectPool<GameObject>> objectPools;
    //private static Dictionary<GameObject, GameObject> cloneToPrefabMap;

    //public enum PoolType
    //{
    //    GameObjects,
    //    ParticleSystems,
    //    SoundFX
    //}

    //public static PoolType poolingType;

    //void Awake()
    //{
    //    objectPools = new();
    //    cloneToPrefabMap = new();

    //    SetupEmpties();
    //}

    //private void SetupEmpties()
    //{
    //    emptyHolder = new GameObject("Object Pools");

    //    particleSystemsEmpty = new GameObject("Particle Systems");
    //    particleSystemsEmpty.transform.parent = emptyHolder.transform;

    //    attackTracers = new GameObject("Attack Tracers");
    //    attackTracers.transform.parent = emptyHolder.transform;

    //    soundFXEmpty = new GameObject("SoundFX");
    //    soundFXEmpty.transform.parent = emptyHolder.transform;

    //    if (addToDDOL)
    //    {
    //        DontDestroyOnLoad(particleSystemsEmpty.transform.root); // targeting the empty holder? not sure why he doesn't just use a ref to it in the first place. He did say any of these children would work naturally
    //    }
    //}

    //private static void CreatePool(GameObject prefab, Vector3 pos, Quaternion rot, PoolType poolType = PoolType.GameObjects)
    //{
    //    ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
    //        createFunc: () => CreateObject(prefab, pos, rot, poolType),
    //        actionOnGet: OnGetObject,
    //        actionOnRelease: OnReleaseObject,
    //        actionOnDestroy: OnDestroyObject
    //        );

    //    objectPools.Add(prefab, pool);
    //}

    //private static GameObject CreateObject(GameObject prefab, Vector3 pos, Quaternion rot, PoolType poolType = PoolType.GameObjects)
    //{
    //    // set inactive to avoid calling awake..
    //    prefab.SetActive(false);
    //    GameObject obj = Instantiate(prefab, pos, rot);
    //    prefab.SetActive(true);

    //    GameObject parentObject = SetParentObject(poolType);
    //    obj.transform.SetParent(parentObject.transform);

    //    return obj;
    //}

    //private static void OnGetObject(GameObject obj)
    //{

    //}
    //private static void OnReleaseObject(GameObject obj)
    //{
    //    obj.SetActive(false);
    //}

    //private static void OnDestroyObject(GameObject obj)
    //{
    //    if (cloneToPrefabMap.ContainsKey(obj))
    //    {
    //        cloneToPrefabMap.Remove(obj);
    //    }
    //}

    //private static GameObject SetParentObject(PoolType poolType)
    //{
    //    switch (poolType)
    //    {
    //        case PoolType.GameObjects:
    //            return gameObjectsEmpty;

    //        case PoolType.ParticleSystems:
    //            return particleSystemsEmpty;

    //        case PoolType.SoundFX:
    //            return soundFXEmpty;

    //        default:
    //            return null;
    //    }
    //}

    //private static T SpawnObject<T>(GameObject objectToSpawn, Vector3 spawnPos, Quaternion spawnRotation, PoolType poolType = PoolType.GameObjects) where T : Object
    //{
    //    if (!objectPools.ContainsKey(objectToSpawn))
    //    {
    //        CreatePool(objectToSpawn, spawnPos, spawnRotation, poolType);
    //    }

    //    GameObject obj = objectPools[objectToSpawn].Get();

    //    if (obj != null)
    //    {
    //        if (!cloneToPrefabMap.ContainsKey(obj))
    //        {
    //            cloneToPrefabMap.Add(obj, objectToSpawn);
    //        }

    //        obj.transform.position = spawnPos;
    //        obj.transform.rotation = spawnRotation;
    //        obj.SetActive(true);

    //        if (typeof(T) == typeof(GameObject))
    //        {
    //            return obj as T;
    //        }

    //        T component = obj.GetComponent<T>();
    //        if (component == null)
    //        {
    //            Debug.LogError($"Object {objectToSpawn.name} doesn't have component of type {typeof(T)}");
    //            return null;
    //        }

    //        return component;
    //    }

    //    return null;
    //}

    //public static T SpawnObject<T>(T typePrefab, Vector3 spawnPos, Quaternion spawnRotation, PoolType poolType = PoolType.GameObjects) where T : Component
    //{
    //    return SpawnObject<T>(typePrefab, spawnPos, spawnRotation, poolType);
    //}

    //public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPos, Quaternion spawnRotation, PoolType poolType = PoolType.GameObjects)
    //{
    //    return SpawnObject<GameObject>(objectToSpawn, spawnPos, spawnRotation, poolType);
    //}

    //public static void ReturnObjectToPool(GameObject obj, PoolType poolType = PoolType.GameObjects)
    //{
    //    if (cloneToPrefabMap.TryGetValue(obj, out GameObject prefab))
    //    {
    //        GameObject parentObject = SetParentObject(poolType);

    //        if (obj.transform.parent != parentObject.transform)
    //        {
    //            obj.transform.SetParent(parentObject.transform);
    //        }

    //        if (objectPools.TryGetValue(prefab, out ObjectPool<GameObject> pool))
    //        {
    //            pool.Release(obj);
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogWarning("Trying to return an object that is not pooled: " + obj);
    //    }
    //}
}