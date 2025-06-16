using System;
using UnityEngine;
using Photon.Pun;
using Zenject;

public class SpawnSystem : MonoBehaviour
{
    public static Action onPlayerSpawn;
    [SerializeField] private Transform[] _spawnsForPlayer;
    private ISettings _settings;
    public static SpawnSystem instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    
    [Inject]
    public void Construct(ISettings settings)
    {
        _settings = settings;
    }

    public void SpawnUnit(GameObject go, Vector3 pos)
    {
        if (!go.GetComponent<Unit>()) return;

        var newUnit = PhotonNetwork.Instantiate(go.name, pos, Quaternion.identity);
        newUnit.GetComponent<Health>().SetHealth(_settings.HealthEnemy);
        if (newUnit.TryGetComponent<DamageAbilityTarget>(out DamageAbilityTarget damageAbilty))
        {
            damageAbilty.SetDamage(_settings.DamageEnemy);
        }
        if (newUnit.TryGetComponent<ShootAbility>(out ShootAbility damageShootAbilty))
        {
            damageShootAbilty.SetDamage(_settings.DamageEnemy);
        }
    }

    public void SpawnPlayer()
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

    public void SpawnBullet(GameObject go, Transform trans, float damage)
    {
        if (go != null)
        {
            var t = trans;

            var newBullet = PhotonNetwork.Instantiate(go.name, new Vector3(t.position.x, t.position.y + 1, t.position.z), t.rotation);
            newBullet.GetComponent<DamageAbilityTarget>().damage = damage;
        }
    }

    public void SpawnPickUp(GameObject go, Transform trans)
    {
        if (go != null)
        {
            var t = trans;

            var newPickUp = PhotonNetwork.Instantiate(go.name, new Vector3(t.position.x, t.position.y + 1, t.position.z), t.rotation);
        }        
    }
}
