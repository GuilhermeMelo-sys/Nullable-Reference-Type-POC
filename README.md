# Nullable Reference Type

## O que é ?

Nullable Reference é uma propriedade que foi adicionada que chegou no C# 8.0,
que permiti o compilador traduzir o seu código e buscar
por valores que possivelmente possam se tornar nulos e assim gerar excessões.

Desta maneira é possível identificar de maneira mais clara regiões que possam se
tornar criticas e buscar estrategias contorna-las.

## Como utilizar ?

Para utilizar essa propriedade do C# 8.0 você pode tanto adiciona-lo em uma região
específica do código, quanto adicionar no projeto a partir do csproj.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

  <PropertyGroup>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

A partir do momento que você aplica essa propriedade no seu projeto, é possível que acabe 
recebendo uma grande quantidade de "Warnings" avisando sobre
as possíveis areas de risco, um exemplo muito comum são propriedades com tipo o "String" 
podem se tornar nullables, portanto o compilador julgas elas como algo "perigoso".

```C#
    public class Pessoa
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
```

Para corrigir este problema primeiro é necessário referenciar na propria propriedade 
que pode existir valor ou não e que isso não é um problema, sendo assim adicionaremos
uma interrogação no final do tipo da propriedade: "String?".

```C#
    public class Pessoa
    {
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
    }
```

Caso não queira utilizar a interrogação, também é possível desabilitar uma região
a partir das annotations, como por exemplo:

```C#
  #nullable disable
    public class Passaro
    {
        public string Apelido { get; set; }
        public string Nicho { get; set; }
        public List<Alimento> Alimentos { get; set; }
    }
    public class Alimento
    {
        public string Nome { get; set; }
        public int ValorEnergtico { get; set; }
    }
#nullable restore
```
Nesse exemplo é determinado que naquela região em especifico não haverá validação
do compilador, portanto não é necessário se preocupar com os warnings.

## Aplicando em conjunto com WarningAsErrors.

Aplicando essa propriedade em conjunto com a "WarningAsErrors" é possível transformar
todos os "Warnings" de valores nullable em "Errors" para o compilador, dessa maneira 
você conseguirá obrigar o programador a sempre alterar ou buscar estrategias que evitem 
a utilização de valores nulos.

```xml
  <PropertyGroup>
    <WarningsAsErrors>nullable</WarningsAsErrors>
    <Nullable>enable</Nullable>
  </PropertyGroup>
```

### Fontes: 

"WarningAsErrors": https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/compiler-options/errors-warnings

"Nullable Reference Type": https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references
			   https://dev.to/integerman/safer-code-with-c-8-non-null-reference-types-4f2c#:~:text=The%20nullable%20reference%20types%20feature,could%20potentially%20be%20null%2C%20etc
			   https://renatogroffe.medium.com/novidades-do-c-8-0-nullable-reference-types-6e82cffbe3d9
