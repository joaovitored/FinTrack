
using System;
using Monetria.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Monetria.Models;

namespace Monetria.ViewModels;

public class TransacaoPageViewModel : ViewModelBase    
{
   public ObservableCollection<Transacao> Transacoes { get; }

   public TransacaoPageViewModel()
   {
      var transacoes = new List<Transacao>
      {
         new Transacao(false,new DateOnly(2023, 10, 20), "Descricao", "Descricao", "Teste", 10.50m)
      };
      Transacoes = new ObservableCollection<Transacao>(transacoes);
   }
}