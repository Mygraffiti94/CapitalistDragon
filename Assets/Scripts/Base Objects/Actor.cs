using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsContainer
{
	public List<ValueReference>	stats;

	public StatsContainer()
	{
		stats = new List<ValueReference>();
	}
}

public class Actor : MonoBehaviour
{
	public ValueStructure statStructure;
	StatsContainer statList;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void Init()
	{
		statList = new StatsContainer();

		for(int i = 0; i < statStructure.values.Count; i++)
		{
			if(statStructure.values[i] is ValueFloat)
			{
				statList.stats.Add(new ValueFloatReference(statStructure.values[i], 0f));
			}
			else if(statStructure.values[i] is ValueInt)
			{
				statList.stats.Add(new ValueIntReference(statStructure.values[i], 0));
			}
		}
	}

	private void OnGUI()
	{
		for (int i = 0; i < statList.stats.Count; i++)
		{
			GUI.Label(new Rect(10,10 + 30*i, 500, 22), statList.stats[i].valueBase.name);
		}
	}
}
