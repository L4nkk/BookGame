using UnityEngine;

public class SlotGenre : MonoBehaviour
{
    [SerializeField] private Type.Genre genre = Type.Genre.empty;
    public Type.Genre Genre => genre;
}
