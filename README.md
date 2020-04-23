## Desafios para aprendizagem de backend

### Desafio 1 - Rotas [DONE]
Criar um webservice que passado um parâmetro date por GET no formato ddMMAAAA (14/04/2020 nesse formato seria 14042020) e responda um JSON com os dias que faltam (ou que passaram da data).
Caso a date venha vazia ou não especificada deve retornar um código de erro.
Exemplos:
Entrada: /diferenca?date=10042020 Resposta:
{"dias entre as data":-4}
Entrada 2: /diferenca?date=20042020 Resposta:
{"dias entre as data":6}
Vamos agora construir um servidor para guardar nossas reflections.


### Desafio 2 - Model [DONE]
Crie uma classe model para guardar a reflection. Sugestão de classe.
Class Reflection{
String(Int) id; String text;
Date creationTime;
}
OBS: Dependendo do framework usado o model é criado junto com o DB. Neste caso os desafios 2 e 3 devem ser feitos juntos.

### Desafío 3 - Banco de dados [DONE]
Coloque a classe no banco de dados (SQL/NoSQL)
Crie endpoints para o CRUD dela.
A entrada deve usar os verbos do REST (GET/POST/PATCH/PUT/DELETE).
GET - requer um recurso
No caso do GET, considere também o caso do retorno do recurso passando-o como parte da URL. Exemplo:
 /reflection/45 → Retorna a reflection de id 45
O retorno deve ser um JSON
Ex:
{ "id":"a6a39006-7e7d-11ea-bc55-0242ac130003", "text":"Ser ou não ser. Eis a questão?!" creationTime:16041218
}
POST - cria um novo recurso DELETE - remove um recurso PATCH/PUT - modifica um recurso

### Desafío 4 - Buscas
Faça rotas onde possamos buscar reflections passando entre datas.
Caso a date venha vazia ou não especificada deve retornar um código de erro.
Exemplos:
Entrada: /reflection?from=10042020&to=13042020
Entrada: /reflection?from=10042020
Deve retornar todas as reflections entre 10/04/2020 até agora.

### Desafio 5 - Users e Autenticação
Coloque autenticação e possibilidade de criação/remoção de users (eles devem ser guardados no banco de dados tb).
Sugestão de classe.
Class User{
String username; String password; String name;
}
Crie buscar para poder encontrar um usuário pelo nome e pelo username dele.

### Desafío 6 - Users Reflections
Agora realize/modifique a model para os reflections dos usuários. Sugestão de classe.
Class UserReflection{
String(Int) id;

String text;
Date creationTime;
User belongsTo;
User[] sharedWith;
Int visibility; {public/private)
}
Crie as funções de CRUD dela (mantendo a proteção que somente o user pode criar e modificar os parâmetros de suas UserReflection.
Crie também rotas para buscar todas as reflection que estão sendo compartilhadas com um determinado usuário.

### Desafio 7 - Publicação
Publique o seu servidor em um serviço cloud (Heroku, AWS, GoogleCloud, Azure, BlueMix...)

### Desafíos Extras
Coloque um serviço de autenticação Auth2.0 (Google/Facebook) Faça um frontend para o seu servidor (HTML/Mobile)
Crie opções de reflections por áudio e imagens.
