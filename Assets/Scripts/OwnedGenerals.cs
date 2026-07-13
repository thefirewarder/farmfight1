using UnityEngine;
using System.Collections.Generic;

public class OwnedGenerals : MonoBehaviour
{
    public General startingGeneral;
    public List<General> generalsOwned;
    void Start()
    {
        generalsOwned = new List<General>();
        addGeneral(startingGeneral);
    }

    public void addGeneral(General general){
        foreach(General gen in generalsOwned){
            if(gen.name == general.name){
                return;
            }
        }
        generalsOwned.Add(general);
    }
}
