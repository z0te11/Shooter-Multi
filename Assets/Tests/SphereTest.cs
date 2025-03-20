using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class SphereTest
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(0);
    }

    [UnityTest]
    public IEnumerator SphereDoKillTest()
    {
        var sphere = GameObject.FindWithTag("Sphere");
        var rb = sphere.GetComponent<Rigidbody>();
        
        yield return new WaitForSeconds(10);

        var enemy = GameObject.FindWithTag("Enemy");

        enemy.transform.position = sphere.transform.position;
        rb.velocity = new Vector3(1, 0, 0);
        yield return new WaitForSeconds(2f);
        
        UnityEngine.Assertions.Assert.IsNull(enemy);
    }
}
