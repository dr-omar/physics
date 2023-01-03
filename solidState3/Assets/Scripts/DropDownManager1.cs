using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

using TMPro;

public class DropDownManager1 : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    public Transform periodicTable;
    public TMP_InputField mainInput;
    public GameObject[] Lattice;
    private GameObject g;
    
    public void ActivateLattice() {
        string t = mainInput.text;
        if (g!=null) {
            g.SetActive (false);
            dehighlight ();
        }
        int v=-1;
        
        if (t == "simple cubic/sc (polonium)") v=0;
        if (t == "base centered cubic/bcc (iron)") v=1;
        if (t == "face centered cubic/fcc (nickel)") v=2;
        if (t == "fcc (salt)") v=3;
        if (t == "fcc sub group (diamond)") v=4;
        if (t == "fcc sub group (zincblende)") v=5;
        if (t == "bcc (cscl)") v=6;
        if (v == -1) return;
        if (v < Lattice.Length) {
            g = Lattice[v];
            //Debug.Log (g);
            if (g) {
                g.SetActive(true);
                highlight (v);
            }
        }
    }
   public void highlight(int v) {
        item[] a;
        Transform b;
        a=Globals.SimpleCubePo;
        switch (v) {
            case 0: a=Globals.SimpleCubePo; break;
            case 1: a=Globals.bcc; break;
            case 2: a=Globals.fcc; break;
            case 3: a=Globals.SimpleCubeSalt; break;
            case 4: a=Globals.fccDiamond; break;
            case 5: a=Globals.fccZincblende; break;
            case 6: a=Globals.bccCSCL; break;
        }
        foreach (item s in a) {
            string c = "Canvas/"+s.name;
            b = periodicTable.transform.Find (c);
            b.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            b.GetComponent<Image>().color = new Color32 (255, 36, 94, 255);
        }
    }
    public void dehighlight() {
        dehighlightSingle (Globals.SimpleCubePo);
        dehighlightSingle (Globals.bcc);
        dehighlightSingle (Globals.fcc);
        dehighlightSingle (Globals.SimpleCubeSalt);
        dehighlightSingle (Globals.fccDiamond);
        dehighlightSingle (Globals.fccZincblende);
    }
    private void dehighlightSingle(item[] a) {
        Transform b;
        foreach (item s in a) {
            string c = "Canvas/"+s.name;
            b = periodicTable.transform.Find (c);
            b.transform.localScale = new Vector3(1f, 1f, 1f);
            b.GetComponent<Image>().color = s.color;
        }
    }
/*
    GameObject FindInActiveObjectByTag(string tag)
{
Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
    foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
    for (int i = 0; i < objs.Length; i++)
    {
        if (objs[i].hideFlags == HideFlags.None)
        {
            if (objs[i].CompareTag(tag))
            {
                return objs[i].gameObject;
            }
        }
    }
    return null;
}
    */
}
