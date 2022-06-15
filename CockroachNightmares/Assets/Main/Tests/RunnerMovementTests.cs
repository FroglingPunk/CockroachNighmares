using System.Collections;
using System.Collections.Generic;
using Game.Mechanics;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RunnerMovementTests
{
    private GameObject environment;


    [SetUp]
    public void Setup()
    {
        environment = Object.Instantiate(Resources.Load(@"Tests/Test Runner Movement Environment")) as GameObject;
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(environment);
    }


    [UnityTest]
    public IEnumerator RunnerMovementBeyondScreenLimits()
    {
        Runner runner = environment.GetComponentInChildren<Runner>();
        runner.transform.position = new Vector3(1000f, 1000f, 0f);

        yield return null;

        Vector2 xLimit = new Vector2(
            -Camera.main.orthographicSize * Screen.width / Screen.height + runner.transform.lossyScale.x * 0.5f,
             Camera.main.orthographicSize * Screen.width / Screen.height - runner.transform.lossyScale.x * 0.5f);

        Vector2 yLimit = new Vector2(
            -Camera.main.orthographicSize + runner.transform.lossyScale.y * 0.5f,
             Camera.main.orthographicSize - runner.transform.lossyScale.y * 0.5f);

        Assert.GreaterOrEqual(runner.transform.position.x, xLimit.x);
        Assert.LessOrEqual(runner.transform.position.x, xLimit.y);

        Assert.GreaterOrEqual(runner.transform.position.y, yLimit.x);
        Assert.LessOrEqual(runner.transform.position.y, yLimit.y);


        runner.transform.position = new Vector3(-1000f, -1000f, 0f);

        yield return null;

        xLimit = new Vector2(
            -Camera.main.orthographicSize * Screen.width / Screen.height + runner.transform.lossyScale.x * 0.5f,
             Camera.main.orthographicSize * Screen.width / Screen.height - runner.transform.lossyScale.x * 0.5f);

        yLimit = new Vector2(
            -Camera.main.orthographicSize + runner.transform.lossyScale.y * 0.5f,
             Camera.main.orthographicSize - runner.transform.lossyScale.y * 0.5f);

        Assert.GreaterOrEqual(runner.transform.position.x, xLimit.x);
        Assert.LessOrEqual(runner.transform.position.x, xLimit.y);

        Assert.GreaterOrEqual(runner.transform.position.y, yLimit.x);
        Assert.LessOrEqual(runner.transform.position.y, yLimit.y);
    }

    [UnityTest]
    public IEnumerator RunnerRunsAwayFromPanicArea()
    {
        Vector3 runnerDestination = new Vector3(1f, 0, 0);

        Runner runner = environment.GetComponentInChildren<Runner>();
        runner.Init(new Vector3[] { runnerDestination }, 5f, 5f);

        PlayerCursor playerCursor = environment.GetComponentInChildren<PlayerCursor>();
        playerCursor.enabled = false;

        PanicArea panicArea = environment.GetComponentInChildren<PanicArea>();
        panicArea.transform.position = Vector3.zero;
        panicArea.transform.localScale = Vector3.one * 5f;

        runner.transform.position = new Vector3(-0.1f, 0, 0);

        float distanceBetweenRunnerAndDestination = Vector3.Distance(runner.transform.position, runnerDestination);

        yield return new WaitForSeconds(2f);

        Assert.Greater(Vector3.Distance(runner.transform.position, runnerDestination), distanceBetweenRunnerAndDestination);
    }

    [UnityTest]
    public IEnumerator RunnerRunsToDestination()
    {
        Vector3 runnerDestination = new Vector3(1f, 0, 0);

        Runner runner = environment.GetComponentInChildren<Runner>();
        runner.Init(new Vector3[] { runnerDestination }, 5f, 5f);

        PlayerCursor playerCursor = environment.GetComponentInChildren<PlayerCursor>();
        playerCursor.enabled = false;

        PanicArea panicArea = environment.GetComponentInChildren<PanicArea>();
        panicArea.enabled = false;

        runner.transform.position = new Vector3(-1f, 0, 0);

        float distanceBetweenRunnerAndDestination = Vector3.Distance(runner.transform.position, runnerDestination);

        yield return new WaitForSeconds(2f);

        Assert.Less(Vector3.Distance(runner.transform.position, runnerDestination), distanceBetweenRunnerAndDestination);
    }
}