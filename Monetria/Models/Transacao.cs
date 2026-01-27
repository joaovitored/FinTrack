using System;

namespace Monetria.Models;

public class Transacao
{
    public bool Selecionar { get; set; }
    public DateOnly Data { get; set; }
    public string Tipo { get; set; }
    public string Categoria {get; set;}
    public string Descricao {get; set;}
    public decimal Valor {get; set;}
    
    

    public Transacao(bool selecionar,DateOnly data, string tipo, string categoria,string descricao, decimal valor)
    {
        Selecionar = selecionar;
        Data = data;
        Tipo = tipo;
        Categoria = categoria;
        Descricao = descricao;
        Valor = valor;
        
    }
}