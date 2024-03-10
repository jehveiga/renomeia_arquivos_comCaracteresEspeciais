using System.Text.RegularExpressions;


string pasta = @"C:\Caminho\Para\Sua\Pasta"; // Substitua pelo caminho da sua pasta

if (Directory.Exists(pasta))
{
    DirectoryInfo diretorio = new DirectoryInfo(pasta);

    foreach (FileInfo arquivo in diretorio.GetFiles())
    {
        string nomeSemExtensao = Path.GetFileNameWithoutExtension(arquivo.Name);
        string extensao = Path.GetExtension(arquivo.Name);

        string novoNome = RemoverCaracteresEspeciais(nomeSemExtensao) + extensao;
        string novoCaminho = Path.Combine(arquivo.DirectoryName, novoNome);

        if (arquivo.Name != novoNome)
        {
            File.Move(arquivo.FullName, novoCaminho);
            Console.WriteLine($"Renomeado: {arquivo.FullName} para {novoCaminho}");
        }
    }

    Console.WriteLine("Concluído!");
}
else
{
    Console.WriteLine("A pasta especificada não existe.");
}


static string RemoverCaracteresEspeciais(string input)
{
    // Remove os caracteres especiais utilizando expressão regular
    string pattern = "[^a-zA-Z0-9]";
    string replacement = "_";
    Regex regex = new Regex(pattern);
    string novoNome = regex.Replace(input, replacement);

    return novoNome;
}

