<h1> Ocelot ApiGateway </h1>

<h2> Configurations </h2>

- DownstreampathTemplate -  Defines the route of actual endpoint of Microservice 
- DownstreamScheme - scheme of Microservice, HTTPS  
- DownstreamHostsandPorts - Host and Port of Microservice will define here. 
- UpstreampathTemplate - The path at which the client will request the Ocelot API Gateway 
- UpstreamHttpmethod - The Supported HTTP Methods to the API Gateway. Based on the incoming method,Ocelot sends a  similar HTTP method request to microservices as well.

<h2>References</h2>
1) https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/implement-api-gateways-with-ocelot <br>
2) https://sksonudas.medium.com/developing-api-gateways-using-ocelot-for-net-core-3-1-microservices-805bf824aeb9
