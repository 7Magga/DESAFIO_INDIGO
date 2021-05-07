using DESAFIO_INDIGO.Models;
using PuppeteerSharp;
using PuppeteerSharp.Contrib.Extensions;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DESAFIO_INDIGO.Controllers
{
    public class BuscaController : Controller
    {
        [Route("Buscar")]
        public ActionResult Buscar()
        {
            return View();
        }
        [Route("Invalido")]
        public ActionResult Invalido()
        {
            return View();
        }

        [Route("Buscando/{id}")]
        [Obsolete]
        public async Task<ActionResult> Buscando(String id)
        {
            var cepModel = new CepModel();

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            Browser browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                //Não mostrar:
                Headless = true
                //Mostrar:
                //Headless = false
            });

            //Url Correios
            string fullUrl = "http://www.buscacep.correios.com.br/sistemas/buscacep/BuscaCepEndereco.cfm";
            
            //Abertura de pagina       
            var page = await browser.NewPageAsync();

            var timeout = (int)TimeSpan.FromSeconds(30).TotalMilliseconds;
            page.DefaultNavigationTimeout = timeout;
            page.DefaultTimeout = timeout;
            var options = new NavigationOptions { Timeout = timeout };

            await page.GoToAsync(fullUrl, options);

            //Preenchimento e clique
            await page.TypeAsync("[name='relaxation']", id);
            await page.ClickAsync("[value='Buscar']");

            try
            {
                //Obter dados
                var _obterDados = new ObterDados();

                var _logradouro = _obterDados.GetLogradouro(page);
                cepModel.logradouro = await _logradouro;

                var _bairro = _obterDados.GetBairro(page);
                cepModel.bairro = await _bairro;

                var _estado = _obterDados.GetEstado(page);
                cepModel.estado = await _estado;

                await browser.CloseAsync();
                cepModel.cep = id;
                //Fim Obter dados
            }
            catch
            {
                Invalido();
            }

            return View(cepModel);
        }

    }

    public class ObterDados
    {
        public async Task<string> GetLogradouro(Page page)
        {            
            var listREturn = await page.QuerySelectorAllAsync("td");
            string itemReturn = await listREturn[0].InnerTextAsync();

            if (itemReturn != null)
            {
                return itemReturn;
            }
            else
            {
                return "Não localizou";
            }
        }

        public async Task<string> GetBairro(Page page)
        {
            var listREturn = await page.QuerySelectorAllAsync("td");
            string itemReturn = await listREturn[1].InnerTextAsync();

            if (itemReturn != null)
            {
                return itemReturn;
            }
            else
            {
                return "Não localizou";
            }
        }

        public async Task<string> GetEstado(Page page)
        {
            var listREturn = await page.QuerySelectorAllAsync("td");
            string itemReturn = await listREturn[2].InnerTextAsync();

            if (itemReturn != null)
            {
                return itemReturn;
            }
            else
            {
                return "Não localizou";
            }
        }

    }

}