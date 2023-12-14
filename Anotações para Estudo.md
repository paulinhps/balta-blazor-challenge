# Para estudar

## Exemplo do Paulinho para utilizar Constantes e Constantes estruturadas

~~~csharp


public enum BrasilStatesCodes {
    AC = 11
}

public struct BrazilState(BrasilStatesCodes code, string description)
{
    public static BrazilState AC = new BrazilState(BrasilStatesCodes.AC, "Acre");
    public BrasilStatesCodes Code { get;} = code;
    public string Description {get;} = description;

    private static IEnumerable<BrazilState> States() {

        yield return AC;
    }

    public static implicit operator BrazilState(BrasilStatesCodes code )
        => States().FirstOrDefault(c => c.Code == code);

}
~~~
