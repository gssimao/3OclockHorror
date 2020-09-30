
public interface IItemContainer
{
    bool ContainsItem(Item item);
    bool RemoveItem(Item item);
    bool AddItem(Item item);
    bool IsFull();
    int CountItems(Item item);
}
