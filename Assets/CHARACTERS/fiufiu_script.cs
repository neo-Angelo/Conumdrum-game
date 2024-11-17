using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fiufiu_script : MonoBehaviour
{
    private PuzzleManager manager;
    public List<GameObject> wayPoints;

    public GameObject fiufiuEvent;

    int nextNode = 0;

    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        manager = FindFirstObjectByType<PuzzleManager>();
        if (manager.fiufiuState == true && manager.fiufiuPassou == false)
        {
            gameObject.SetActive(true);
            manager.fiufiuState = true;
            manager.fiufiuPassou = true;
            fiufiuEvent.GetComponent<FIUFIU_EVENT>().startEvent();
        }
        else {
            gameObject.SetActive(false);
        }
        
    }

    private void pegaOpombo() {

        if (nextNode < wayPoints.Count) {
            agent.destination = wayPoints[nextNode].transform.position;
            nextNode++;
        }
        else
        {
            OnEndOfPath();
        }




    }

    void OnEndOfPath()
    {
        fiufiuEvent.GetComponent<FIUFIU_EVENT>().endEvent();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (agent.remainingDistance == 0)
            pegaOpombo();
    }


}
