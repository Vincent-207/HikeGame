using UnityEngine;

public interface IItemConsumer
{
    public bool ItemMatches(ItemType itemType);

    public void AddItem(ItemType itemType);
}
