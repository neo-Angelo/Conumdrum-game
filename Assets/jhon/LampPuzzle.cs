//lampPuzzle
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LampPuzzle : MonoBehaviour
{
    public GameObject cubePrefab;
    public int gridSize = 3;
    public int tipoLamp;
    private AudioSource audiosource;

    private GameObject[,] cubes;


    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        CreateGrid();
    }

    private void CreateGrid()
    {
        cubes = new GameObject[gridSize, gridSize];

        //Pega rotação inicial do bloco base
        Quaternion startRotation = transform.rotation;
       
        //Reseta a rotação para identidade (0,0,0,0)
        transform.rotation = Quaternion.identity;

        Vector3 baseSize = GetComponent<MeshRenderer>().bounds.size;
        float marginX = baseSize.x * 0.1f;
        float marginZ = baseSize.z * 0.1f;

        Vector3 cubeSize = new Vector3(
            baseSize.x / gridSize - marginX,
            baseSize.y,
            baseSize.z / gridSize - marginZ
            );

        

        float startPosX = transform.position.x - baseSize.x / 2 + marginX/2 + cubeSize.x / 2;
        float startPosZ = transform.position.z - baseSize.z / 2 + marginZ/2 + cubeSize.z / 2;
        float yPosition = transform.position.y + baseSize.y;
        
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Vector3 position = new Vector3(startPosX + (i * (cubeSize.x + marginX)), yPosition, startPosZ + (j * (cubeSize.z + marginZ)));
                
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                cube.transform.localScale = new Vector3(cubeSize.x, cubeSize.y, cubeSize.z);
                cube.transform.rotation = transform.rotation;
                cube.transform.parent = transform;

                cubes[i, j] = cube;

            }
        }

        //Volta a rotação para a rotação inicial
        transform.rotation = startRotation;

        for(int i = 0; i < gridSize; i++)
        {
            for(int j = 0; j < gridSize; j++)
            {
                ColorChange script = cubes[i,j].GetComponent<ColorChange>();
                
                if (i > 0) script.adjacents.Add(cubes[i - 1, j]);
                
                if (i < gridSize - 1) script.adjacents.Add(cubes[i + 1, j]);
                
                if (j > 0) script.adjacents.Add(cubes[i, j - 1]);
                
                if (j < gridSize - 1) script.adjacents.Add(cubes[i, j + 1]);
                
            }
        }

    }
    public void checkCompletion()
    {
        foreach(GameObject cube in cubes)
        {
            ColorChange script = cube.GetComponent<ColorChange>();
            if (script.getState() == 0)
                return;
        }
        foreach(GameObject cube in cubes)
        {
            ColorChange script = cube.GetComponent<ColorChange>();
            script.setState(2);
            script.complete();
            script.enabled = false;
        }
        Debug.Log("completo");
        PuzzleManager manager = FindFirstObjectByType<PuzzleManager>();
        
        switch (tipoLamp) {
            case 0:
                audiosource.Play();
                SceneManager.LoadScene("SampleScene");
                break;
            case 1:
                audiosource.Play();
                manager.completePuzzle(3);
                break;
        }
        
    }
}
