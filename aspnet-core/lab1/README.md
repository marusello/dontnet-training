# Visão Geral
Criar uma API que suporte operações CRUD. As APIs devem usar o padrão REST.

## Requisitos
- Criar API para produtos

  - GET /api/produtos/
  - GET /api/produtos/{id}
  - POST /api/produtos/
  - PUT /api/produtos/{id}
  -   DELETE /api/produtos/{id}
- Fazer validação dentro dos métodos GET, PUT e DELETE para verificar se o registro existe; caso não exista, retornar erro 404.