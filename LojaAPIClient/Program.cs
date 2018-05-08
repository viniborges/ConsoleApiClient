using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LojaAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cria a requisição que vai ler o XML
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50838/api/carrinho/1/produto/6237/quantidade");
            request.Method = "PUT";

            string xml = "<Produto xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/LojaAPI.Models'><Id>6237</Id><Nome>PlayStation 4</Nome><Preco>4000</Preco><Quantidade>100</Quantidade></Produto>";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);

            //Escrever o xml de bytes na requisição
            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);

            request.ContentType = "Application/xml";

            //Guarda a resposta da requisição
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);

            Console.Read();

        }

        static void TestaGet()
        {
            //Armazenar o conteúdo do XML
            string conteudo = "";

            //Cria a requisição que vai ler o XML
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");
            request.Method = "GET";

            //Guarda a resposta da requisição
            WebResponse response = request.GetResponse();

            //Cria um stream para ler os dados da response
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd(); //ler a resposta até o final e colocar no conteudo
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaGetXml()
        {
            //Armazenar o conteúdo do XML
            string conteudo = "";

            //Cria a requisição que vai ler o XML
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");
            request.Method = "GET";
            request.Accept = "application/xml";

            //Guarda a resposta da requisição
            WebResponse response = request.GetResponse();

            //Cria um stream para ler os dados da response
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd(); //ler a resposta até o final e colocar no conteudo
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaGetJson()
        {
            //Armazenar o conteúdo do XML
            string conteudo = "";

            //Cria a requisição que vai ler o XML
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");
            request.Method = "GET";
            request.Accept = "application/json";

            //Guarda a resposta da requisição
            WebResponse response = request.GetResponse();

            //Cria um stream para ler os dados da response
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd(); //ler a resposta até o final e colocar no conteudo
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaGetJsonStatusCode()
        {
            //Cria a requisição que vai ler o XML
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50838/api/carrinho/200");
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";

            //Guarda a resposta da requisição
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers["Location"]);
            Console.Read();
        }

        static void TestaPostJson()
        {
            //Armazenar o conteúdo do XML
            string conteudo = "";

            //Cria a requisição que vai ler o XML
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50838/api/carrinho/");
            request.Method = "POST";
            request.Accept = "application/json";

            string json = "{'Produtos':[{'Id':6237,'Preco':2000.0,'Nome':'Switch','Quantidade':3}],'Endereco':'Rua José Spoladore, 77, Londrina / PR','Id':3}";
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            //Escrever o json de bytes na requisição
            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);

            request.ContentType = "application/json";

            //Guarda a resposta da requisição
            WebResponse response = request.GetResponse();

            //Cria um stream para ler os dados da response
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd(); //ler a resposta até o final e colocar no conteudo
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaPostXml()
        {
            //Armazenar o conteúdo do XML
            string conteudo = "";

            //Cria a requisição que vai ler o XML
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50838/api/carrinho/1");
            request.Method = "POST";
            request.Accept = "application/xml";

            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/Loja.Models'><Endereco>Rua Vergueiro 3185, 8 andar, Sao Paulo</Endereco><Id>1</Id><Produtos><Produto><Id>123</Id><Nome>Produto criado com POST</Nome><Preco>100</Preco><Quantidade>1</Quantidade></Produto></Produtos></Carrinho>";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);

            //Escrever o xml de bytes na requisição
            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);

            request.ContentType = "application/xml";

            //Guarda a resposta da requisição
            WebResponse response = request.GetResponse();

            //Cria um stream para ler os dados da response
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd(); //ler a resposta até o final e colocar no conteudo
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaPostJson2()
        {
            //Cria a requisição que vai ler o XML
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50838/api/carrinho/");
            request.Method = "POST";
            request.Accept = "application/json";

            string json = "{'Produtos':[{'Id':6237,'Preco':2000.0,'Nome':'Switch','Quantidade':3}],'Endereco':'Rua José Spoladore, 77, Londrina / PR','Id':3}";
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            //Escrever o json de bytes na requisição
            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);

            request.ContentType = "application/json";

            //Guarda a resposta da requisição
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers["Location"]);
            Console.Read();
        }

        static void TestaDelete()
        {
            //Cria a requisição que vai ler o XML
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50838/api/carrinho/1/produto/3467");
            request.Method = "DELETE";

            //Guarda a resposta da requisição
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);

            Console.Read();
        }
    }
}
