using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskListController : MonoBehaviour
{

    public Canvas taskDisplay;
    public LogicBoardPhases logic_board; //tasks related to logic board can be triggered based on the current phase
    public List<Task> tasks_remaining; //all other tasks can be created using the Task object
    public GameObject task_prefab;

    private Transform current_bottom = null;
    private List<GameObject> textTasks;
    //private Animator task_remove;
    private int lastPhase = 0;

    void Awake()
    {
        textTasks = new List<GameObject>();
        Task[] tasks = GetComponents<Task>();
        foreach(Task start_task in tasks)
        {
            tasks_remaining.Add(start_task);
        }


        float i = 0f;
        foreach (Task i_task in tasks_remaining)
        {
            GameObject new_task = AddDisplayTask(i_task.Name, i_task.Description);
            textTasks.Add(new_task);
            //new_task.transform.Translate(new Vector3(0, i, 0));
            //i -= 0.5f; //distance between each task visually

            current_bottom = new_task.transform;
        }
    }

    public void DeleteTask(string taskName)
    {
        Task taskToDelete = new Task();
        foreach (Task i_task in tasks_remaining)
        {
            if (i_task.Name == taskName)
            {
                taskToDelete = i_task;
            }
        }
        //play satisfying delete animation


        GameObject textToDelete = GameObject.Find(taskToDelete.Name);

        StartCoroutine(PlayRemoveAnimation(textToDelete));

        tasks_remaining.Remove(taskToDelete);
    }

    public Task AddTask(string taskName, string taskDescription)
    {
        Task add_task = new Task();
        add_task.Name = taskName;
        add_task.Description = taskDescription;

        tasks_remaining.Add(add_task);

        AddDisplayTask(add_task.Name, add_task.Description);

        return add_task;
    }

    public GameObject AddDisplayTask(string taskName, string taskDescription)
    {
        //instantiate the taskDisplay prefab
        GameObject new_task = Instantiate(task_prefab);
        new_task.name = taskName;
        new_task.transform.SetParent(taskDisplay.transform, false);

        //configure position on task board
        if(current_bottom != null)
        {
            new_task.transform.position = current_bottom.position;
            new_task.transform.Translate(new Vector3(0, -0.5f, 0));
        }
        current_bottom = new_task.transform;

        Text new_description = new_task.GetComponent<Text>();
        new_description.text = taskDescription;
        return new_task;
    }

    void Update()
    {

        if(logic_board.currentPhase != lastPhase)
        {
            lastPhase = logic_board.currentPhase;
            DeleteTask(tasks_remaining[0].Name);
            //UpdateTasks();
        }
    }

    IEnumerator PlayRemoveAnimation(GameObject textObject)
    {
        Animator text_animator = textObject.GetComponent<Animator>();
        text_animator.Play("TextDelete");
        yield return new WaitForSeconds(3);
        textTasks.Remove(textObject);
        Destroy(textObject);
        foreach (GameObject text in textTasks)
        {
            text.transform.Translate(new Vector3(0, 0.5f, 0));
        }

        current_bottom = textTasks[textTasks.Count].transform;
    }
}

