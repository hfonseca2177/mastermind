
public enum PlayerRole
{
    DECODER, CYPHER
}

public class Player 
{
    private string _name;
    private string _account;
    private PlayerRole _role;
    public int currentScore;
    public int highestScore;

    private Player(string name, string account)
    {
        _name = name;
        _account = account;
    }

    public static Player CreateDecoder(string name, string account)
    {
        Player decoder = new Player(name, account)
        {
            _role = PlayerRole.DECODER
        };
        return decoder;
    }

    public static Player CreateCypher(string name, string account)
    {
        Player cypher = new Player(name, account)
        {
            _role = PlayerRole.CYPHER
        };
        return cypher;
    }

    public bool IsDecoder()
    {
        return PlayerRole.DECODER.Equals(this._role);
    }

    public bool IsCypher()
    {
        return PlayerRole.CYPHER.Equals(this._role);
    }

    public string GetPlayerTag()
    {
        return this._name + ":" + this._account;
    }

}
