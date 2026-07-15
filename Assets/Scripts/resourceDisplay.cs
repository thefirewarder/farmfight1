using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;
public class resourceDisplay : MonoBehaviour
{
    public Kingdom playerKingdom;
    public TMP_Text gemBox;
    public List<resource> resources;
    void Start()
    {
        playerKingdom = GetComponent<Kingdom>();
        resources = playerKingdom.resources;
    }

    void Update()
    {
        gemBox.text = "Resource Stock: "+string.Join(", ",resources.Select(r => r.type + "(" + r.amount + ")"));
    }
}
