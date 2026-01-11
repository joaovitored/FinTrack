using Avalonia.Controls;

namespace FinTrack.Service
{
    public class NavegarPaginas
    {
        private readonly ContentControl _mainContent;

        public NavegarPaginas(ContentControl mainContent)
        {
            _mainContent = mainContent;
        }

        public void NavegarPara(UserControl pagina)
        {
            if (_mainContent != null)
            {
                _mainContent.Content = pagina;
            }
        }
    }
}