# Problema

1. Crie uma pasta chamada entities, dentro da pasta src.

2. Crie uma pasta chamada interfaces, dentro da pasta src.

3. Crie uma interface chamada ICustomer.cs, dentro da pasta src/interfaces, com os seguintes membros:

> Propriedades:
> Codigo → Tipo String
> Nome → Tipo String
>
> Método:
> Save → parametro: Customer → tipo de retorno: void

4. Crie uma classe chamada Customer.cs na pasta src/entities que implemente a interface ICustomer.cs. No método Save, imprima a mensagem "Customer saved!" (dica: use a classe Console).

5. Na classe Program, dentro do método Main, defina uma variável do tipo da interface ICustomer.cs e inicialize esta variável com um objeto da classe Customer.cs. Por fim, chame o método Save desta classe.

6. No terminal do VS Code, rode o comando abaixo na pasta do projeto:

> user:~$ dotnet build

**Resultado esperado**: a aplicação deve compilar com sucesso.