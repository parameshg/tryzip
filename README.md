# Zip-o-lite

This is a sample application hosting REST endpoints for creating users and their credit account with few requirements.

* Cannot create more than one user with the same email address
* Cannot create an account if an user's salary - expenses is less than $1000

Swagger UI is located at /swagger

Docker image is located at docker.io/parameshg/zipolite:latest

The data is stored using Sqlite database