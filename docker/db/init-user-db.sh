#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" <<-EOSQL
    CREATE USER ymazieres WITH PASSWORD 'ymazieres';
    CREATE DATABASE ymazieres;
    GRANT ALL PRIVILEGES ON DATABASE ymazieres TO ymazieres;
EOSQL