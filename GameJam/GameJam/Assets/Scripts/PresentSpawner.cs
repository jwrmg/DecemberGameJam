using System.Collections;
using UnityEngine;

public class PresentSpawner : MonoBehaviour
{
    public GameObject[] Toys;

    public AnimationCurve Curve;

    public float SpawnHeight;

    public float SpawnTimeRange = 10;
    public float ScoreThreshold;

    public bool ShouldSpawn = true;

    public float SpawnDistance;

    private Vector2 m_PreviousLocation;

    public void Update()
    {
        if (ShouldSpawn && GameManager.Instance.State == GameStates.Playing)
        {
            float time = UnityEngine.Random.Range(0, SpawnTimeRange);

            var value = Curve.Evaluate(Player.Instance.Score / ScoreThreshold);

            Debug.Log(value);

            StartCoroutine(Spawn(time * value));
            ShouldSpawn = false;
        }
    }

    public IEnumerator Spawn(float time)
    {
        Vector2 location = new Vector2(UnityEngine.Random.Range(0.0f, (float)Screen.width), 0);

        if ((location - m_PreviousLocation).magnitude <= SpawnDistance)
        {
            yield return Spawn(time);
        }

        m_PreviousLocation = location;

        yield return new WaitForSeconds(time);

        GameObject obj = Toys[UnityEngine.Random.Range(0, Toys.Length)];

        var convertedLocation = Camera.main.ScreenToWorldPoint(location);
        convertedLocation.z = 0;
        convertedLocation.y = SpawnHeight;

        Instantiate(obj, convertedLocation, Quaternion.identity);

        ShouldSpawn = true;
    }
}