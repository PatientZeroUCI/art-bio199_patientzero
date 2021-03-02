using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskListController : MonoBehaviour
{
    public LogicBoardPhases logic_board;

    private List<GameObject> tasks_remaining = new List<GameObject>();
    private int lastPhase = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(logic_board.currentPhase != lastPhase)
        {
            lastPhase = logic_board.currentPhase;
            UpdateTasks();
        }
    }

    private void UpdateTasks()
    {
        //Unity Events?
    }
}

