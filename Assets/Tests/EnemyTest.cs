using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class EnemyTest
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(0);
    }

    [UnityTest]
    public IEnumerator EnemyLifeCycleTest()
    {
        yield return new WaitForSeconds(10);
        var enemy = GameObject.FindWithTag("Enemy");
        UnityEngine.Assertions.Assert.IsNotNull(enemy);

        var enemyHealth = enemy.GetComponent<Health>();

        enemyHealth.GetDamage(1000);
        yield return new WaitForSeconds(5);

        UnityEngine.Assertions.Assert.IsNull(enemy);
    }

    [UnityTest]
    public IEnumerator EnemyIsMovingTest()
    {
        yield return new WaitForSeconds(10);
        var enemy = GameObject.FindWithTag("Enemy");
        var startPosX = enemy.transform.position.x;
        var startPosY = enemy.transform.position.y;

        yield return new WaitForSeconds(1);

        var endPosX = enemy.transform.position.x;
        var endPosY = enemy.transform.position.y;

        bool pass = startPosX != endPosX ^ startPosY != endPosY;

        UnityEngine.Assertions.Assert.IsTrue(pass);
    }
}
