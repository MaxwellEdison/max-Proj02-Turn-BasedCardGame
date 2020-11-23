using UnityEngine;

public class SpawnTokenCommand : ICommand
{

    BoardSpawner _boardSpawner;
    Vector3 _position;

    Token _spawnedToken;


    public SpawnTokenCommand(BoardSpawner boardSpawner, Vector3 position)
    {
        _boardSpawner = boardSpawner;
        _position = position;
    }

    public void Execute()
    {
        Debug.Log("Spawn token");
        _spawnedToken = _boardSpawner.SpawnToken(_position);
    }

    public void Undo()
    {
        _boardSpawner.RemoveToken(_spawnedToken);
    }
}
