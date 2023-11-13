using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecial : BossBaseState
{
    [SerializeField] float speed;
    [SerializeField] float waitTime;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPos;
    Vector2 targetPoint;

    public override void RunState()
    {
        StartCoroutine(RunSpecialState());
    }

    public override void StopState()
    {
        base.StopState();
    }

    protected override void Start()
    {
        targetPoint = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.7f));
    }

    IEnumerator RunSpecialState()
    {
        while(Vector2.Distance(transform.position, targetPoint) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();

        }
        Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);

        bossController.ChangeState(BossState.fire);
    }
}
