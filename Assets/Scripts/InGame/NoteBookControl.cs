using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBookControl : MonoBehaviour
{
    public GameObject PrintPanel;

    private void OnTriggerEnter(Collider other)
    {
        PrintPanel.SetActive(true);
    }

}
