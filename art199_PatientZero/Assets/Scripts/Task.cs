using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public enum Status //current status of the task at hand
    {
        Inactive = 0,
        Active = 1,
        Completed = 2,
    }

    public string Name; //necessary information that the task manager might need.
    public string Description;
    public Status currentStatus;
    public List<Task> Subtasks;

    private bool subtasks_enabled = false;
    // Start is called before the first frame update
    void Start()
    {
        if(Subtasks.Count > 0)
        {
            subtasks_enabled = true;
        }
    }
    
    public bool HasSubtasks()
    {
        return subtasks_enabled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
