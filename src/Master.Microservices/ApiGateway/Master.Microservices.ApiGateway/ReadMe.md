# Ocelot ApiGateway 

## Configurations 

- DownstreampathTemplate -  Defines the route of actual endpoint of Microservice 
- DownstreamScheme - scheme of Microservice, HTTPS  
- DownstreamHostsandPorts - Host and Port of Microservice will define here. 
- UpstreampathTemplate - The path at which the client will request the Ocelot API Gateway 
- UpstreamHttpmethod - The Supported HTTP Methods to the API Gateway. Based on the incoming method,Ocelot sends a  similar HTTP method request to microservices as well.

## Features 

- Ip Rate Limit: 
Rate limiting is a technique for controlling network traffic. It sets a limit on how many times you can perform a specific activity within a given period - for example, accessing a particular resource, logging into an account, etc. Typically, rate-limiting keeps track of the IP addresses and the time elapsed between requests. The IP address helps determine the source of a particular request.
// ocelot.Development.json
<code>
"RateLimitOptions":{
   "ClientWhitelist":[      
   ],
   "EnableRateLimiting":true,
   "Period":"5s",
   "PeriodTimespan":1,
   "Limit":1,
   "HttpStatusCode":429
}
</code>

1. ClientWhitelist setting - This is an array used to specify the clients that should not be affected by the rate-limiting.
2. EnableRateLimiting setting - This is a boolean value, true if you want to enable rate-limiting, false otherwise.
3. HttpStatusCode setting - This is used to specify the HTTP status code that is returned when rate limiting occurs.
4. Period setting - This specifies the duration that the rate limit is applicable, which in turn implies that if you make more requests within this duration than what is allowed, you'll need to wait for the duration specified in the PeriodTimespan.
5. PeriodTimespan setting - This is used to specify the duration after which you can retry to connect to a service.
6. Limit setting - This specifies the maximum number of requests that are allowed within the duration specified in Period.
<h2>References</h2>

- https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/implement-api-gateways-with-ocelot <br>
- https://sksonudas.medium.com/developing-api-gateways-using-ocelot-for-net-core-3-1-microservices-805bf824aeb9
