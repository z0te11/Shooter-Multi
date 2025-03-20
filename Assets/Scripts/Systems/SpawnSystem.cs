using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Zenject;
using Photon.Pun;
using Photon.Realtime;

public class SpawnSystem : MonoBehaviour
{
    public static Action onPlayerSpawn;
    [SerializeField] private Transform[] _spawnsForPlayer;
    [SerializeField] private Transform[] _spawnsForEnemys;
    private ISettings _settings;

    public static SpawnSystem instance;
    [Inject]
    public void Construct(ISettings settings)
    {
        _settings = settings;
    }

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void StartSpawnEnemy()
    {
        if (_settings.Enemy != null) StartCoroutine(WaitAndSpawning(_settings.Enemy, _settings.DelaySpawn));
    }

    private IEnumerator WaitAndSpawning(GameObject go, float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            
            SpawnUnit(go, _spawnsForEnemys[UnityEngine.Random.Range(0, _spawnsForEnemys.Length)].position);
        }
    }

    public void SpawnUnit(GameObject go, Vector3 pos)
    {
        if (!go.GetComponent<Unit>()) return;

        var newUnit = PhotonNetwork.Instantiate(go.name, pos, Quaternion.identity);
        newUnit.GetComponent<Health>().SetHealth(_settings.HealthEnemy);
        newUnit.GetComponent<DamageAbilityTarget>().SetDamage(_settings.DamageEnemy);

    }

    public void SpawnPlayer( )
    {
        var id = PhotonNetwork.LocalPlayer.ActorNumber;
        if (id > (_spawnsForPlayer.Length + 1))
        {
            Debug.LogError("NO SPAWN POINT");
            return;
        }
        else
        {
            var newPlayer = PhotonNetwork.Instantiate(_settings.Player.name, _spawnsForPlayer[id - 1].position, Quaternion.identity);
            GameManager.instance.currentPlayer = newPlayer;
        }

        onPlayerSpawn?.Invoke();
    }

    public void SpawnBullet(GameObject go, Transform trans, float damage, TypeOfBuff typeOfBuff)
    {
        if (go != null)
        {
            var t = trans;

            var newBullet = PhotonNetwork.Instantiate(go.name, t.position, t.rotation);
            newBullet.GetComponent<DamageAbilityTarget>().damage = damage;

            if (typeOfBuff == TypeOfBuff.Reflect)
            {
                Destroy(newBullet.GetComponent<DestroyerAbility>());
                ReflectAbility ra = newBullet.AddComponent(typeof(ReflectAbility)) as ReflectAbility;
            }
        }
    }

    public void SpawnPickUp(GameObject go, Transform trans)
    {
        if (go != null)
        {
            var t = trans;

            var newPickUp = PhotonNetwork.Instantiate(go.name, t.position, t.rotation);
        }        
    }
}
