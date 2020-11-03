
public class BuffCommand : ICommand
{
    IBuffable _buffableToken;

    public BuffCommand(IBuffable buffableToken)
    {
        _buffableToken = buffableToken;
    }

    public void Execute()
    {
        _token.Buff();
    }

    public void Undo()
    {
        _token.Debuff();
    }
}
