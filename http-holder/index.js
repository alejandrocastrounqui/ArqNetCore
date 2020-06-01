var express = require('express');
var app = express();

var holded = [];

app.get('/status', function (request, response) {
  var result = {};
  for(let id in holded){
    result[id] = holded[id].length;
  }
  response.status(200).send(JSON.stringify(result, null, 2));
  
});

app.get('/hold/:id', function (request, response) {
  var id = request.params.id;
  var scope = holded[id];
  if(!scope){
    scope = holded[id] = []
  }
  scope.push({
    request:request,
    response:response
  })
});

app.get('/v1/pom/*', function (request, response) {
  var id = 100;
  var scope = holded[id];
  if(!scope){
    scope = holded[id] = []
  }
  scope.push({
    request:request,
    response:response
  })
});

app.post('/v1/pom/*', function (request, response) {
  var id = 100;
  var scope = holded[id];
  if(!scope){
    scope = holded[id] = []
  }
  scope.push({
    request:request,
    response:response
  })
});


app.get('/v5/pom/*', function (request, response) {
  var id = 101;
  var scope = holded[id];
  if(!scope){
    scope = holded[id] = []
  }
  scope.push({
    request:request,
    response:response
  })
});

app.get('/release/:id', function (request, response) {
  var id = request.params.id;
  var scope = holded[id];
  if(!scope){
    response.status(500).send('Scope does not exist');
    return;
  }
  for(let holded of scope){
    holded.response.status(200).send('{"status": "OK"}');
  }
  scope.length = 0;
  response.status(200).send('OK');
});

app.listen(process.env.PORT, function () {
  console.log('Example app listening on port ' + process.env.PORT + '!');
});
