using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    List<bool> gottenItens = new List<bool>();
    List<int> remainingPuzzles = new List<int>();
    List<int> completedPuzzles = new List<int>();
    public bool inicio = false;
    
    public bool fiufiuState = false;
    public bool fiufiuPassou = false;
    public bool inside = false;

    public static PuzzleManager instance;

    private void Awake()
    {

        if (!inicio)
        {
            inicio = true;
            for (int i = 0; i < 5; i++)
            {
                remainingPuzzles.Add(i);
            }

            for (int i = 0; i < 25; i++)
            {
                gottenItens.Add(false);

            }
        }

        if (instance != null && instance != this)
            Destroy(gameObject);

        else instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void completePuzzle(int number)
    {
        remainingPuzzles.Remove(number);
        completedPuzzles.Add(number);
    }

    public void obtainItem(int itemId)
    {
        Debug.Log("foi inserido na posição" + itemId);
        gottenItens[itemId] = true;
    }

    public bool hasItem(int itemId)
    {
        return gottenItens[itemId];
    }

    public bool checkCompletion(int id)
    {
        foreach (int puzzleId in completedPuzzles)
        {
            if (id == puzzleId)
            {
                return true;
            }
        }
        return false;
    }

    public bool getFiufiu()
    {

        return fiufiuState;
    }
}