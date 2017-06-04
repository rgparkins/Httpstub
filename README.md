# http-stub
An HTTP stub that run in docker that can be set up with responses for testing your system

Written as a basic learning experience for me in donetcore, docker, node and cucumber! The interface is simple and can be built on by anyone if they want to send me a pull request!

I'll be putting this in docker hub when I have some time

## API

Currently supports json and XML.

You can POST, DELETE and GET your data

You can post any object to any path and the object will be stored in an in-memory cache. Writing data to an existing path will overwrite the current data stored.

For example, POST `users/1` can be found under the GET `users/1`

Should you wish to remove this data (for example to test a 404) then you can call DELETE `users/1`

To clear the whole cache send a DELETE to `/`

## Current planned work

* I am looking to allow Deletes for example DELETE `users/`
* Support of exception throwing
* Support of Header responses
* Return Location header on POST
