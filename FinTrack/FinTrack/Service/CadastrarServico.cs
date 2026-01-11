using FinTrack.Models;
using System.Threading.Tasks;

namespace FinTrack.Service
{
    public class CadastrarServico
    {
        public async Task<bool> CadastroAsync(Usuario usuario)
        {
            // Simula um tempo de cadastro com Task.Delay
            await Task.Delay(1000);  // Simula um atraso (como uma consulta ao banco de dados)
            return true;  // Aqui, você deveria conectar ao seu backend ou banco de dados.
        }
    }
}
