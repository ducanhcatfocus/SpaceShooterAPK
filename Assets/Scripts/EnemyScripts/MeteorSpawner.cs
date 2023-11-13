using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] List<Sprite> meteorSprites;
    [SerializeField] GameObject meteorPrefab;
    [SerializeField] float spawnTime;
    float timer = 0f;
    int i;

    Camera mainCam;
    float maxLeft;
    float maxRight;
    float yPos;


    private void Start()
    {
        mainCam= Camera.main;
        StartCoroutine(SetBoundary());
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTime)
        {
            i = Random.Range(0, meteorSprites.Count);
            GameObject newMeteor = Instantiate(meteorPrefab, new Vector3(Random.Range(maxLeft, maxRight), yPos , -5), Quaternion.Euler(0,0, Random.Range(0,360)));
            newMeteor.GetComponent<SpriteRenderer>().sprite = meteorSprites[i];
            float size = Random.Range(0.8f, 1.2f);
            newMeteor.transform.localScale = new Vector3(size, size, 1);
            timer = 0;
        }
    }

    IEnumerator SetBoundary()
    {
        yield return new WaitForSeconds(0.4f);
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;


    }
}
