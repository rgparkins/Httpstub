# http-stub
An HTTP stub that run in docker that can be set up with responses for testing your system

Written as a basic learning experience for me in donetcore, docker, node and cucumber! The interface is simple and can be built on by anyone if they want to send me a pull request!

I'll be putting this in docker hub when I have some time

## API

Currently supports json and XML.

### POST

You can POST any data to any path in your uri. Any duplicate path will be overwritten with the data posted

For example, POST `users/1` can be found under the GET `users/1`

### GET

You can GET by path. If the path exists in the stub it will retirn the data in the form you request (json or XML)

If the 

You can POST, DELETE and GET your data

You can post any object to any path and the object will be stored in an in-memory cache. Writing data to an existing path will overwrite the current data stored.

For example, POST `users/1` can be found under the GET `users/1`

Should you wish to remove this data (for example to test a 404) then you can call DELETE `users/1`


To clear the whole cache send a DELETE to `/`

## Current planned work

* Support of exception throwing
* Support of Header responses
* Return Location header on POST
