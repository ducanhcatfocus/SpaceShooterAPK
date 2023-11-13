using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : BossBaseState
{
    [SerializeField] float speed;
    [SerializeField] float shootRate;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] Transform[] shootingPos;


    public override void RunState()
    {
        StartCoroutine(RunFireState());
    }

    public override void StopState()
    {
        base.StopState();
    }

    IEnumerator RunFireState()
    {
        float shootingTimer = 0f;
        float fireStateTimer = 0f;
        float fireStateExitTime = Random.Range(5f, 10f);
        Vector2 targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxBottom, maxTop));
        while(fireStateTimer <= fireStateExitTime)
        {
            if(Vector2.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxBottom, maxTop));
            }
            shootingTimer += Time.deltaTime;
            if(shootingTimer >= shootRate)
            {
                for (int i = 0; i < shootingPos.Length; i++)
                {
                    Instantiate(bulletPrefab, shootingPos[i].position, Quaternion.identity);
                }
                shootingTimer = 0;
            }
            yield return new WaitForEndOfFrame();
            fireStateTimer += Time.deltaTime; 
        }

        bossController.ChangeState(BossState.special);

       
    }
}
