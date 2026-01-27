namespace Monetria.Models;

public class Categoria
{
    public string Nome { get; set; }
    
    public string Cor { get; set; }
    
    public string Tipo  { get; set; }
    
    public bool Acoes { get; set; }

    public Categoria(string nome, string cor, string tipo, bool acoes)
    {
        Nome = nome;
        Cor = cor;
        Tipo = tipo;
        Acoes = acoes;

    }
}