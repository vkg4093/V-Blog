var http = require('http');
http.createServer(function (req, res) {
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    res.end('Hello World\n');
}).listen(1337, '182.74.87.18');
console.log('Server running at http://182.74.87.18/');
//testing