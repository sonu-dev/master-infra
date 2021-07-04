
 # JWT Authentication 
 
 ### References
 [https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api#app-settings-development-json] 
 
Token-based security is commonly used in today’s security architecture. There are several token-based security techniques. JWT is one of the more popular techniques. JWT token is used to identify authorized users.

<b>What is the JWT WEB TOKEN? </b><br/>
- Open Standard: Means anywhere, anytime, and anyone can use JWT.
- Secure data transfer between any two bodies, any two users, any two servers.
- It is digitally signed: Information is verified and trusted.
- There is no alteration of data.
- Compact: because JWT can be sent via URL, post request & HTTP header.
- Fast transmission makes JWT more usable.
- Self Contained: because JWT itself holds user information.
- It avoids querying the database more than once after a user is logged in and has been verified. <br/>
<b>JWT is useful for </b> <br/>
- Authentication
- Secure data transfer
- JWT Token Structure 
- A JWT token contains a Header, a Payload, and a Signature. 
