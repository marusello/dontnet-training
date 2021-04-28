# Problema

1. Copie a classe abaixo e cole dentro do namespace ConsoleApp, abaixo da classe Program:

> public class RepositorioGenerico
> {
>    public Guid Save(Object obj)
>    {
>        return Guid.NewGuid();
>    }
>
>   public void Update(Object obj)
>   {
>   }
>
>   public void Delete(Object obj)
>   {
>   }
>
>   public Object Get(Guid id)
>   {
>      return null;
>   }
> }
>
> public class Cliente
> {
> }
>
> public class Produto
> {
> }

2. Refatore a classe RepositorioGenerico. Utilize generics para que seja possível     reutilizar todo o código existente para manipular as entidades Cliente e Produto.

- Requisitos técnicos:
  - Restringir para que o tipo genérico  seja uma classe;
  - Restringir para garantir que o tipo genérico tenha um construtor vazio;
  - Tipos de retorno devem ser genéricos;
  - Os parâmetros também devem ser genéricos.

3. Dentro do método Main crie uma instância do repositório genérico, que deve ser tipado com a classe Cliente.

4. Compile a aplicação utilizando o seguinte comando no terminal:

> user:~$ dotnet build
> **Resultado esperado**: 
A aplicação deve compilar com sucesso

5. Dentro do método Main crie uma instância do repositório genérico, que deve ser tipado com a classe Produto.

6. Compile a aplicação utilizando o seguinte comando no terminal:

> user:~$ dotnet build
> **Resultado esperado**: 
A aplicação deve compilar com sucesso

7. Ao concluir, chame os instrutores para apresentar sua solução.
