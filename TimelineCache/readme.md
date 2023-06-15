## Setup PostgreSQL database, pgadmin4, and redis containers

Run `docker-compose -p timeline up -d`

## Connect pgadmin4 to PostgreSQL server

Get the IPv4 of the PostgreSQL container by `docker network inspect timeline_network`.
The IP address of the PostgreSQL container is a server hostname for pgadmin4.

## Credentials

Credentials for PostgreSQL database, pgadmin4, and redis could be found in `docker-compose.yml`

