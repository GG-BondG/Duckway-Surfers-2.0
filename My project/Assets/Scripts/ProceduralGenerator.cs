using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    public GameObject[] Blocks;
    void Start()
    {
        Blocks = Resources.LoadAll<GameObject>("Blocks");
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.transform.name == "Duck")
        {
            GameObject NextBlock = Instantiate(Blocks[Random.Range(0, 17)]);
            int NextBlockName = int.Parse(this.transform.parent.name) + 3;
            NextBlock.name = NextBlockName.ToString();
            NextBlock.transform.position = new Vector3(0, 0, this.transform.parent.position.z + 216);
            if (this.transform.parent.name == "1")
            {
                Destroy(GameObject.FindGameObjectWithTag("BaseBlock"));
            }
            Destroy(this.transform.parent.gameObject);
        }
    }
}
