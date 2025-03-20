using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class BulletTest
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(0);
    }

    [UnityTest]
    public IEnumerator BulletDamageTest()
    {
        yield return new WaitForSeconds(10);
        var player = GameObject.FindWithTag("Player");

        var shootComp = player.GetComponent<ShootAbility>();
        shootComp.Execute();
        yield return new WaitForSeconds(0.1f);

        var enemy = GameObject.FindWithTag("Enemy");
        var enemyHealth = enemy.GetComponent<Health>();
        float startHealth = enemyHealth.Healths;

        var bullet = GameObject.FindObjectOfType<Bullet>();
        bullet.transform.position = enemy.transform.position;
        yield return new WaitForSeconds(0.5f);

        float endHealth = enemyHealth.Healths;
        
        bool pass = startHealth > endHealth;
        UnityEngine.Assertions.Assert.IsTrue(pass);
    }
}
