using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChange : MonoBehaviour, IPointerClickHandler
{
    LampPuzzle puzzle;
    public List<GameObject> adjacents = new List<GameObject>();
    
    Renderer itemRenderer;
    Color[] colors = new Color[3];
    int state = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Alterna o state entre 0 e 1 para o bloco clicado
        state = state == 0 ? 1 : 0;

        itemRenderer.material.color = colors[state];

        foreach(GameObject adjacent in adjacents)
        {
            //Alterna o state entre 0 e 1 para cada bloco adjacente
            ColorChange objectScript = adjacent.GetComponent<ColorChange>();
            objectScript.state = objectScript.state == 0 ? 1 : 0;
            objectScript.itemRenderer.material.color = colors[objectScript.state];
        }


        puzzle.checkCompletion();
    }

    public void complete()
    {
        state = 2;
        itemRenderer.material.color = colors[state];
    }

    private void Awake()
    {
        colors[0] = Color.black;
        colors[1] = Color.cyan;
        colors[2] = Color.green;
        this.itemRenderer = GetComponent<Renderer>();
        
    }

    private void Start()
    {
        this.itemRenderer.material.color = colors[0];
        puzzle = GetComponentInParent<LampPuzzle>();
    }

    public int getState()
    {
        return this.state;
    }

    public void setState(int valor) {
        this.state = valor;
    }
}
