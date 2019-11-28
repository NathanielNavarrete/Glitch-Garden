using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackers;
    

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if(spawn)
                SpawnAttacker();
        } while (spawn);
    }

    public void StopSpawning()
    {
        
        spawn = false;
        Debug.Log(spawn);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackers.Length);
        Spawn(attackers[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation)
            as Attacker;
        newAttacker.transform.parent = transform;
    }

    public void SetSpawnFalse()
    {
        spawn = false;
    }
}
