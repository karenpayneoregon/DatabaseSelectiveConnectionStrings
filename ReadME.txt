The main focus here is to read connection strings from app.config to allow a developer to switch connections. One area this would be good for is for
storing databases for development, testing and production. We would tweak the connections to get databases from say different folders or as done here
with different names.

The windows form project has two connections to two MS-Access databases which shows how to swtich connections and keep track of the current connection.
I did one for SQL-Server, one attached and one server based connection and all worked as expected.

There is a vb.net and cs examples where I mixed it up, meaning each project demos usage of reading connection strings from app.config yet
there are different in how I presented it.

For instance in the vb.net project I added databases via the ide data wizards and left the generated classes while in the cs project
I removed the generated classes and went strictly with a very simple example via a data reader.

When the ide data wizard adds connections to app.config bin\debug is added after |DataDirectory| while I removed them where ever they were
added to the app.config.

I would urge those examining the code to look at both the vb.net and the cs projects as especially the code in ProjectConnection differs in
that we need to examine the connections slightly different e.g. filter .Properties.Settings. in cs projects while in vb.net .My.MySettings.
