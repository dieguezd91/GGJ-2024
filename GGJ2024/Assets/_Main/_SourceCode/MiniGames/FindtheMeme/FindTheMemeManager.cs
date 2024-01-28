using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FindTheMemeManager : MonoBehaviour
{
    [SerializeField] private List<MemeSlot> _slotPrefabs;
    [SerializeField] private Meme _memePrefab;
    [SerializeField] private Transform _slotParent, _pieceParent;

    private void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        var randomSet = _slotPrefabs.OrderBy(s => Random.value).Take(8).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {
            var spawnedSlot = Instantiate(randomSet[i], _slotParent.GetChild(i).position, Quaternion.identity);
            var spawnedPiece = Instantiate(_memePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);

            spawnedPiece.Init(spawnedSlot);
        }
    }
    
}
