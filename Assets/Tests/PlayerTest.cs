using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayerTest
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(0);
    }

    [UnityTest]
    public IEnumerator PlayerLifeCycleTest()
    {
        yield return new WaitForSeconds(5);
        var player = GameObject.FindWithTag("Player");
        UnityEngine.Assertions.Assert.IsNotNull(player);

        var playerHealth = player.GetComponent<Health>();

        playerHealth.GetDamage(1000);
        yield return new WaitForSeconds(1);

        UnityEngine.Assertions.Assert.IsNull(player);
    }

    [UnityTest]
    public IEnumerator PlayerGetDamageTest()
    {
        yield return new WaitForSeconds(5);
        var player = GameObject.FindWithTag("Player");
        var playerHealth = player.GetComponent<Health>();
        float startHealth = playerHealth.Healths;

        yield return new WaitForSeconds(5);
        var enemy = GameObject.FindWithTag("Enemy");
        enemy.transform.position = player.transform.position;

        yield return new WaitForSeconds(3);

        float endHealth = playerHealth.Healths;
        bool pass = startHealth > endHealth;

        UnityEngine.Assertions.Assert.IsTrue(pass);
    }

}
