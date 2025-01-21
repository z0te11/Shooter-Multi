using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnSystem : MonoBehaviour
{
    private Settings settings;

    [Inject]
    public void Construct(Settings settings)
    {
        this.settings = settings;
    }

    public void StartSpawnEnemy()
    {
        if (settings.enemy != null) StartCoroutine(WaitAndSpawning(settings.enemy, settings.delaySpawn));
    }

    private IEnumerator WaitAndSpawning(GameObject go, float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            SpawnUnit(go, Utils.GetRandomPos());
        }
    }

    public void SpawnUnit(GameObject go, Vector3 pos)
    {
        if (!go.GetComponent<Unit>()) return;

        var newUnit = Instantiate(go, pos, Quaternion.identity);
        newUnit.GetComponent<Health>().SetHealth(settings.healthEnemy);
        newUnit.GetComponent<DamageAbilityTarget>().SetDamage(settings.damageEnemy);

    }

    public GameObject SpawnPlayer(PlayerStats playerStats)
    {
        var newPlayer = Instantiate(settings.player, new Vector3(0,0,0), Quaternion.identity);
        newPlayer.GetComponent<PlayerHealth>().SetHealth(playerStats.health);
        newPlayer.GetComponent<ShootAbility>().SetDamage(playerStats.damage);
        return newPlayer;
    }
}
