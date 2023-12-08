using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Diamond Counter")]
public class DiamondCounter : ScriptableObject
{
    //This class is just counting the number of diamonds the player has collected
    //And plays the score UI animation? although maybe it shouldn't be.

    public RectTransform m_DiamondImage;

    private int m_NumberOfDiamonds;
    public int NumberOfDiamonds { get => m_NumberOfDiamonds; private set => m_NumberOfDiamonds = value; }


    public int Count => NumberOfDiamonds;

    public void Reset()
    {
        NumberOfDiamonds = 0;
    }

    public event Action<Vector3> Changed;

    private void OnEnable()
    {
        NumberOfDiamonds = 0;
    }

    public void Add(Vector3 position)
    {
        NumberOfDiamonds++;
        Changed?.Invoke(position);
    }

}
