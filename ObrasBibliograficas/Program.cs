using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ObrasBibliograficas
{
    class Program
    {
        static void Main(string[] args)
        {

            TextInfo textInfo = new CultureInfo("pt-br", false).TextInfo;

            Console.WriteLine("Informe o número de autores: ");


            int _numAutor = Convert.ToInt32(Console.ReadLine());

            List<string> autores = new List<string>();

            for (int i = 0; i < _numAutor; i++)
            {
                Console.WriteLine("Informe o nome do autor: ");
                autores.Add(FormataNome(textInfo.ToTitleCase(Console.ReadLine().Trim())));
            }

            Console.WriteLine("------------------------------");
            foreach (var item in autores)
            {
                Console.WriteLine("Autor: " + item);
            }

            Console.ReadKey();
        }

        private static string FormataNome(string nome)
        {
            string _nomeFormatado = string.Empty;
            string _sulfixoNome = SeparaSufixo(nome);

            

            //caso tenha só um nome, retorna diretamente.
            if (nome.LastIndexOf(" ") == -1)
            {
                return nome.ToUpper();
            }


            if (!String.IsNullOrEmpty(_sulfixoNome))
            {
                nome = nome.Replace(_sulfixoNome, string.Empty, StringComparison.CurrentCultureIgnoreCase).Trim();
            }

                _nomeFormatado = nome.Split(" ").Last().ToUpper() +
                     _sulfixoNome + ", " +
                     nome.Substring(0, nome.LastIndexOf(" ") == -1 ? 0 : nome.LastIndexOf(" "));


            return _nomeFormatado;
        }

        private static string SeparaSufixo(string nome)
        {
            var _sulfixos = new[] { "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA", "JUNIOR" };

            if (nome.Split(" ").Count() <= 2)
            {
                return string.Empty;
            }

            string _sulfixoNome = nome.Split(" ").Last().ToUpper();

            return (_sulfixos.Contains(_sulfixoNome) == true ? " " + _sulfixoNome : string.Empty);

        }

    }
}
