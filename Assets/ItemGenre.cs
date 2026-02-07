using UnityEngine;

public class ItemGenre : MonoBehaviour
{
    [SerializeField] private Type.Genre genre = Type.Genre.empty;
    public Type.Genre Genre => genre;
}
