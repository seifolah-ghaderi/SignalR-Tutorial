-add package  `Microsoft.AspNetCore.SignalR.Client`
-in program.cd add dependency builder.Services.AddSignalR();
-add a `Hub` class :  NotificationHub
	The  Hub allowes `client` to connect to the `Server`
	and allow `server` to send message to `Clients`
-implement `OnConnectedAsync` function
	usefull properites:
	-Clients : all connected client
	-Groups : can be used fro groupping clients
	-Context : current client information !
-Expose Hub to allow clients connecting to it
	using `MapHub` extension(in  signalR) needed two parameters:
	-Your Hub class (NotificationHub)
	-Api Rout (hubs-notify)
	sample : `app.MapHub<NotificationHub>("hubs-notify");`


Test:
json message:{"protocol":"json","version":1}
It has a termination character with ASCII code 0X1E and it's necessary


Call Message on server :
protocol : {"arguments":["message_to_send"],"target":"MethodToInvoke","type":1}
example: {"arguments":["this is seifolah"],"target":"CallMe","type":1}